using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data;
//using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for editmember.xaml
    /// </summary>
    public partial class editmember : Window
    {
        public string email;

        public editmember(string email)
        {
            InitializeComponent();
            this.email = email;
            
        }
        private void upload_Click(object sender, RoutedEventArgs e)
        {


            OpenFileDialog upload1 = new OpenFileDialog();
            upload1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)| *.jpg; *.jpeg; *.gif *.png";
            //bool? response = upload1.ShowDialog();
            upload1.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png;)| *.jpg; *.jpeg; *.gif; *.png;";
            Nullable<bool> result = upload1.ShowDialog();
            if (result == true)
            {
                string x = upload1.FileName;
                // MessageBox.Show(x);

                picture.Source = new BitmapImage(new Uri(x));

            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (nameemployee2.Text == string.Empty || familyemployee2.Text == string.Empty || emailemployee2.Text == string.Empty || phoneemployee2.Text
                == string.Empty || passwordem.Password == string.Empty || picture.Source == null)
            {
                MessageBox.Show("hame field ha ra vared kon");
            }

            else
            {
                if (isvalidname(nameemployee2.Text) == false)
                {
                    MessageBox.Show("name format dorost nist");
                    nameemployee2.Text = string.Empty;
                }

                else if ((emailemployee2.Text) != email)
                {
                    MessageBox.Show("email dorost nist email khodat ra vared kon");
                    emailemployee2.Text = string.Empty;
                }
                else if (isvalidphone(phoneemployee2.Text) == false)
                {
                    MessageBox.Show("phone format dorost nist");
                    phoneemployee2.Text = string.Empty;
                }
                else if (isvalidPassword(passwordem.Password) == false)
                {
                    MessageBox.Show("password format dorost nist");
                    passwordem.Password = string.Empty;
                }
                else
                {
                    SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                    con1.Open();
                    string command1;
                    Image p = picture;
                    command1 = "update member SET firstname='" + nameemployee2.Text + "', lastName='"+ familyemployee2.Text + "', phonenumber='"+ phoneemployee2.Text + "' , password='" + passwordem.Password + "', profilepath='"+p.Source +"'  where email='" + email + "'";
                    SqlCommand com1 = new SqlCommand(command1, con1);
                    com1.ExecuteNonQuery();
                    con1.Close();
                    MessageBox.Show("taghirat anjam shod ");
                    Member v = new Member(email);
                    v.Show();
                }
            }
        }

        public static bool isvalidname(string name)
        {
            if (name.Length < 3 || name.Length > 32)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool isvalidphone(string phone)
        {
            bool k = true;
            for (int i = 0; i < phone.Length; i++)
            {
                if (char.IsDigit(phone[i]) == false)
                {
                    k = false;
                }
            }
            if (k == false)
            {
                return false;
            }
            else
            {
                if (phone.Length != 11)
                {
                    return false;
                }
                else if (phone.Substring(0, 2) != "09")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static bool isvalidPassword(string password)
        {
            bool k = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i]) == true)
                {
                    k = true;
                }
            }
            if (k == false)
            {
                return false;
            }
            else
            {
                if (password.Length < 8 || password.Length > 32)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
