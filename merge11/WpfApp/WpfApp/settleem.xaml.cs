using System;
using System.Collections.Generic;
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
using System.Collections;
using System.Data;
//using System.Data.SqlClient;
using System.IO;
//using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for settleem.xaml
    /// </summary>
    public partial class settleem : Window
    {
        public settleem()
        {
            InitializeComponent();
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void recrd1_Click(object sender, RoutedEventArgs e)
        {
            if (password3.Password != "AdminLib123")
            {
                MessageBox.Show("ramz dorost nist");
            }
            else
            {
                if (pay3.Text == string.Empty)
                {
                    MessageBox.Show("fieldha ra vared kon");
                }
                else
                {
                    List<double> w = new List<double>();
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                    con.Open();
                    string command;
                    command = "select * from EmployeeInfo";
                    SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    int x = data.Rows.Count;
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        double r = double.Parse(data.Rows[i][5].ToString());
                        w.Add(r);
                    }
                    SqlCommand com = new SqlCommand(command, con);
                    com.ExecuteNonQuery();
                    con.Close();

                    ////
                    double y = 0;
                    bool h = true;
                    try
                    {
                        y = double.Parse(pay3.Text.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("pay ra dorost vared nakari");
                        pay3.Text = string.Empty;
                        h = false;
                    }
                    if (h == true)
                    {
                        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                        con1.Open();
                        string command1;

                        command1 = "select * from balanceli";
                        SqlDataAdapter adapter1 = new SqlDataAdapter(command1, con1);
                        DataTable data1 = new DataTable();
                        adapter1.Fill(data1);

                        double b = 0;
                        for (int i = 0; i < data1.Rows.Count; i++)
                        {
                            b = int.Parse(data1.Rows[i][0].ToString());
                        }
                        SqlCommand com1 = new SqlCommand(command1, con1);
                        com1.ExecuteNonQuery();
                        con1.Close();
                        if ((x * y) > b)
                        {
                            MessageBox.Show("mojoodi library kafi nist");
                            password3.Password = string.Empty;
                            pay3.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("pardakht shod");
                            password3.Password = string.Empty;
                            pay3.Text = string.Empty;

                            //
                            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                            con2.Open();
                            string command2;
                            double c = b - (x * y);
                            command2 = "update balanceli SET balance='" + c + "' where balance='" + b + "'";
                            SqlCommand com2 = new SqlCommand(command2, con2);
                            com2.ExecuteNonQuery();
                            con2.Close();

                            //
                            for (int i = 0; i < w.Count; i++)
                            {
                                SqlConnection con3 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                                con3.Open();
                                string command3 = "";

                                MessageBox.Show(w[i].ToString());
                                double d = w[i] + y;
                                command3 = "update EmployeeInfo SET balance='" + d + "' where balance='" + w[i] + "'";

                                SqlCommand com3 = new SqlCommand(command3, con3);
                                com3.ExecuteNonQuery();
                                con3.Close();
                            }

                        }
                    }

                }
            }
        }
    }
}
