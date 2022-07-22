using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    public partial class register : Page
    {
        ImageSource path;
        public register()
        {
            InitializeComponent();
        }
        //to close the page window
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Window win = (Window)this.Parent;
            win.Close();
        }

        //a method to check wether the password input are identical
        private bool pass_Valid(string passOne, string passTwo)
        {
            if (passOne == passTwo && 8 <= passOne.Length && 8 <= passTwo.Length) return true;
            if (passOne.Length < 8)
            {
                MessageBox.Show("Your password is less than 8 characters.");
                return false;
            }
            else
            {
                MessageBox.Show("Passwords Do Not Match!");
                return false;
            }
        }

        //checks if the username is an email in correct format
        private bool user_Valid(string user)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(user);

            if (!match.Success)
            {
                MessageBox.Show("Email format is incorrect");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void signUp_Click(object sender, RoutedEventArgs e)
        {
            string first = firstName.Text;
            string last = lastName.Text;
            string phone = phoneNumber.Text;
            string passOne = password.Password;
            string passTwo = password2.Password;
            string user = username.Text;
            bool passValid = pass_Valid(passOne, passTwo);
            bool userValid = user_Valid(user);
            if (passValid && userValid)
            {
                //creating an instance of the member class
                member m = new member(first, last, user, passOne, path, phone);
                MessageBox.Show("Successfully Signed Up!");
                
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
        }

        //to remove the placeholder text after clicking
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void Upload_Btn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                profile.Source = new BitmapImage(new Uri(op.FileName));
            }

            //save the image address to path var
            path = profile.Source;
        }
    }

    //a class for library members that is connected to sql
    public class member
    {
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public string _userName { get; set; }
        public string _password { get; set; }
        public string _phone { get; set; }
        public ImageSource _photoPath { get; set; }
        DateTime _membershipDate { get; set; }

        public member(string firstName, string lastName, string username,
                        string pass, ImageSource path, string phoneNum)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._userName = username;
            this._password = pass;
            this._photoPath = path;
            this._phone = phoneNum;

            SqlConnection con = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string command;
            double f = 0;
            _membershipDate = DateTime.Now;
            command = "insert into member values('" + _firstName + "', '" + _lastName + "', '" + _userName.Trim() + "', " +
                "'" + _phone.Trim() + "', '" + _password.Trim() + "', '" + _photoPath + "','" + f + "','"+ _membershipDate + "')";
            SqlCommand com = new SqlCommand(command, con);
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}