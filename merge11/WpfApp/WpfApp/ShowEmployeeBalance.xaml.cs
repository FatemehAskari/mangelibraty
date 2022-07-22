using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
    public partial class ShowEmployeeBalance : Window
    {
        string empEmail;
        string empPass;
        public ShowEmployeeBalance(string email, string pass)
        {
            InitializeComponent();
            this.empEmail = email;
            this.empPass = pass;
            EmployeeInfo emp = Search_Employee(empEmail, empPass);
            double b = emp._account;
            string Name = $"{emp._firstName} {emp._lastName}";
            txtBlock.Text = $"{b} Dollars";
            name.Text = Name;
        }

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
                    //why doesn't it work?
                    //Image photo = (Image)data.Rows[i][6];
                    e = new EmployeeInfo(employeeEmail, firstName, lastName,
                        employeePass, phone, balance);

                    SqlCommand cmd = new SqlCommand(command, c);
                    cmd.BeginExecuteNonQuery();
                    c.Close();
                    return e;
                }
            }

            c.Close();
            //if the employee was not found
            MessageBox.Show("User not found!");
            return null;
        }

        private void ShowBalance_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class EmployeeInfo
    {
        public string _email;
        public string _firstName;
        public string _lastName;
        public string _password;
        public string _phone;
        public double _account;
        //public ImageSource _img;
        public EmployeeInfo(string email, string firstName, string lastName, string pass,
                                string phone, double acc)
        {
            this._email = email;
            this._firstName = firstName;
            this._lastName = lastName;
            this._password = pass;
            this._phone = phone;
            this._account = acc;
            //this._img = img;
        }
    }
}
