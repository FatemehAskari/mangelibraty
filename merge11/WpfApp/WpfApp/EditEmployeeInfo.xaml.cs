using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace WpfApp
{
    public partial class EditEmployeeInfo : Window
    {
        string EmployeeEmail;
        string EmployeePass;
        Image path;
        public EditEmployeeInfo(string email, string pass)
        {
            InitializeComponent();
            this.EmployeeEmail = email;
            this.EmployeePass = pass;
            //for showing in the text box
            EmployeeInfo emp = Search_Employee(EmployeeEmail, EmployeePass);
            firstName.Text = emp._firstName;
            lastName.Text = emp._lastName;
            phoneNumber.Text = emp._phone;
            username.Text = emp._email;

        }

        private void EditEmp_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Changes(object sender, RoutedEventArgs e)
        {
            //put Regex here
            string email = username.Text;
            string name = firstName.Text;
            string last = lastName.Text;
            string phone = phoneNumber.Text;
            double Bal = Emp_Balance(EmployeeEmail, EmployeePass);
            bool Valid = valid(email, EmployeePass);
            //only after checking the validity change the database
            if (Valid)
            {
                EditInfo(email, name, last, EmployeePass, phone, Bal, path);
                MessageBox.Show("Updated Successfuly!");
            }
        }
        private void EditInfo(string email, string firstName, string lastName,
            string pass, string phone, double balance, Image photoPath)
        {
            try
            {
                SqlConnection con = new SqlConnection(
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command =
                command = "Update EmployeeInfo SET email = '" + email + "', name = '" + firstName + "', lastName = '" + lastName + "', password = '" + pass + "', phone = '" + phone + "', balance = '" + balance + "', picture = '" + photoPath + "' where email = '" + EmployeeEmail + "'";
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {


            }

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
            path = profile;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        public double Emp_Balance(string username, string pass)
        {
            double balance = 0;
            SqlConnection c = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
            string command;
            command = "select * from EmployeeInfo";
            SqlDataAdapter adapter = new SqlDataAdapter(command, c);
            DataTable data = new DataTable();
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                if ((string)data.Rows[i][0] == username && (string)data.Rows[i][3] == pass)
                {
                    balance = Convert.ToDouble(data.Rows[i][5]);
                }
            }
            SqlCommand cmd = new SqlCommand(command, c);
            cmd.BeginExecuteNonQuery();
            c.Close();
            return balance;
        }

        //search for employee's info to show up on the screen
        public EmployeeInfo Search_Employee(string email, string pass)
        {
            SqlConnection c = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
            string command;
            command = "select * from EmployeeInfo";
            SqlDataAdapter adapter = new SqlDataAdapter(command, c);
            DataTable data = new DataTable();
            adapter.Fill(data);
            EmployeeInfo e;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if ((string)data.Rows[i][0] == email && (string)data.Rows[i][3] == pass)
                {
                    string employeeEmail = (string)data.Rows[i][0];
                    string firstName = (string)data.Rows[i][1];
                    string lastName = (string)data.Rows[i][2];
                    string employeePass = (string)data.Rows[i][3];
                    string phone = (string)data.Rows[i][4];
                    double balance = (double)data.Rows[i][5];
                    e = new EmployeeInfo(employeeEmail, firstName, lastName,
                        employeePass, phone, balance);

                    SqlCommand cmd = new SqlCommand(command, c);
                    cmd.ExecuteNonQuery();
                    c.Close();
                    return e;
                }
            }
            c.Close();
            //if the employee was not found
            MessageBox.Show("User not found!");
            return null;
        }

        //checks the validity of the email and pass
        private bool valid(string user, string pass)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(user);

            if (pass.Length < 8)
            {
                MessageBox.Show("Your password is less than 8 characters.");
                return false;
            }
            if (!match.Success)
            {
                MessageBox.Show("Email format is incorrect");
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
