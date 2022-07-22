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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //a method to check the validity of given information
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
        private void register_Click(object sender, RoutedEventArgs e)
        {
            register r = new register();
            this.Content = r;
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            //saves the status of the user
            string stat = status.Text;
            //first checks if the password and username are in valid format
            string userName = username.Text;
            string pass = password.Password;
            bool memberExists = false;
            bool empExists = false;
            //checks if the email and pass are in correct format
            valid(userName, pass);

            if (username.Text == "admin@yahoo.com" && password.Password == "AdminLib123")
            {
                Admin v = new Admin();
                v.Show();
                this.Close();
                //why is this here?
                //this.Close();
            }
            if (stat == "Memeber")
            {
                
                //checks if the member exists
                memberExists = user_Exists(userName, pass);
            }
            if (stat.ToLower() == "employee")
            {
                //checks if the employee exits
                empExists = Emp_Exists(userName, pass);
            }

            //if the member or the employee exists go to the assigned pages
            if (memberExists)
            {
                Member v = new Member(username.Text);
                v.Show();
                this.Close();
            }
            if (empExists)
            {
                //go to employees' page
                Employee emp = new Employee(userName, pass);
                emp.Show();
                this.Close();
            }

        }

        //to remove the placeholder text after clicking
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }


        //search for a username in database
        public bool user_Exists(string username, string pass)
        {
            bool exists = false;

            SqlConnection c =
                new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
            string command;
            command = "select * from member";
            SqlDataAdapter adapter = new SqlDataAdapter(command, c);
            DataTable data = new DataTable();
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                if ((string)data.Rows[i][2] == username && (string)data.Rows[i][4] == pass)
                {
                    exists = true;
                }
            }
            SqlCommand cmd = new SqlCommand(command, c);
            cmd.BeginExecuteNonQuery();
            c.Close();

            //check the value of exist variable
            if (exists)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Wrong Email Or Password!");
                return false;
            }
        }

        //searches for employee in database
        public bool Emp_Exists(string username, string pass)
        {
            bool exists = false;

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
                    exists = true;
                }
            }
            SqlCommand cmd = new SqlCommand(command, c);
            cmd.ExecuteNonQuery();
            c.Close();

            //check the value of exist variable
            if (exists)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Wrong Email Or Password!");
                return false;
            }
        }
    }
}
