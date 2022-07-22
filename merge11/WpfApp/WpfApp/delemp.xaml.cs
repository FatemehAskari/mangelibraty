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
    /// Interaction logic for delemp.xaml
    /// </summary>
    public partial class delemp : Window
    {
        public delemp()
        {
            InitializeComponent();
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void deleteb_Click(object sender, RoutedEventArgs e)
        {
            if (nameemployee3.Text == string.Empty)
            {
                MessageBox.Show("field ha ra vared kon");
            }
            else
            {
                List<info> a = new List<info>();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command = "select * from EmployeeInfo";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    info c = new info(data.Rows[i][1].ToString(), data.Rows[i][2].ToString());
                    a.Add(c);
                }
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
                con.Close();

                bool k = false;
                for (int i = 0; i < a.Count; i++)
                {
                    if (nameemployee3.Text == a[i].name && familyemployee3.Text==a[i].family)
                    {
                        k = true;
                        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                        con1.Open();
                        string command1;

                        command1 = "delete from  EmployeeInfo where name='" + a[i].name.ToString() + "'";
                        a.Remove(a[i]);
                        SqlCommand com1 = new SqlCommand(command1, con1);

                        com1.ExecuteNonQuery();
                        con1.Close();

                        MessageBox.Show("hazf shod");

                        nameemployee3.Text = String.Empty;
                        familyemployee3.Text= String.Empty;
                        break;
                    }

                }
                if (k == false)
                {
                    MessageBox.Show("in karmand vojood nadarad");
                    nameemployee3.Text = string.Empty;
                }
            }
        }
        public class info
        {
            public string name { get; set; }
            public string family { get; set; }
            public info(string name, string family)
            {
                this.name = name;
                this.family = family;
            }
        }
    }
}
