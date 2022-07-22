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
    /// Interaction logic for balancemem.xaml
    /// </summary>
    public partial class balancemem : Window
    {
        public string email;
       public double b = 0;
        public balancemem(string email)
        {
            InitializeComponent();
            this.email = email;


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command;            
            command = "select * from member";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);           
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][2].ToString() == email)
                {
                    b = double.Parse(data.Rows[i][6].ToString());
                }
            }
            balanceme.Text ="Balance:" +b.ToString();
            SqlCommand com = new SqlCommand(command, con);
            com.ExecuteNonQuery();
            con.Close();

        }

        private void record_Click(object sender, RoutedEventArgs e)
        {
            if (cardnum.Text == string.Empty || CVV.Text == string.Empty || payment.Text
    == string.Empty || month.Text == string.Empty || year.Text == null)
            {
                MessageBox.Show("hame field ha ra vared kon");
            }
            else
            {
                if (check(cardnum.Text) == false)
                {
                    MessageBox.Show("cardnum dorost nist");
                    cardnum.Text = string.Empty;
                }
                else if (checkcvv(CVV.Text) == false)
                {
                    MessageBox.Show("cvv dorost nist");
                    CVV.Text = string.Empty;
                }
                else if (checkpay(payment.Text) == false)
                {
                    MessageBox.Show("payment dorost nist");
                    payment.Text = string.Empty;
                }

                else if (checkmonth(month.Text) == false)
                {
                    MessageBox.Show("month dorost nist");
                    month.Text = string.Empty;
                }
                else if (checkyear(year.Text) == false)
                {
                    MessageBox.Show("year dorost nist");
                    year.Text = string.Empty;
                }
                else
                {
                    

                    ///
                    SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                    con1.Open();
                    string command1;
                    double c = b + double.Parse(payment.Text.ToString());
                    balanceme.Text = "Balance:"+ c.ToString();
                    command1 = "update member SET balance='" + c + "' where balance='" + b + "'";
                    SqlCommand com1 = new SqlCommand(command1, con1);
                    com1.ExecuteNonQuery();
                    con1.Close();
                    MessageBox.Show("anjam shod");
                }
            }
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public static bool check(string a)
        {
            if (a.Length != 16)
            {
                return false;
            }

            else
            {
                int[] b = new int[a.Length];
                for (int i = 0; i < a.Length; i++)
                {
                    b[i] = int.Parse(a[i].ToString());
                }


                List<int> c = new List<int>();
                //compiler warning
                //int x = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        c.Add(jam(b[i] * 2));
                    }
                    if (i % 2 == 1)
                    {
                        c.Add(b[i]);
                    }
                }
                int f = 0;
                for (int i = 0; i < c.Count; i++)
                {
                    f = f + c[i];
                }
                if (f % 10 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public static int jam(int a)
        {

            int x = 0;
            int b;
            while (a > 0)
            {
                b = a % 10;
                x = x + b;
                a = a / 10;
            }
            return x;
        }

        public bool checkcvv(string a)
        {
            if (a.Length != 3 && a.Length != 4)
            {
                return false;
            }

            else
            {
                bool k = true;
                for (int i = 0; i < a.Length; i++)
                {
                    if (char.IsDigit(a[i]) == false)
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
                    return true;
                }
            }
        }
        public bool checkpay(string a)
        {
            bool k = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsDigit(a[i]) == false)
                {
                    k = false;
                }

            }
            if (k == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkmonth(string a)
        {
            bool k = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsDigit(a[i]) != true)
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
                int x = int.Parse(a);
                if (x <= 0 || x >= 13)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public bool checkyear(string a)
        {
            bool k = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsDigit(a[i]) == false)
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
                int x = int.Parse(a);
                if (x != 2021)
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
