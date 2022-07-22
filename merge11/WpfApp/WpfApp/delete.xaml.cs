using System;
using System.Collections.Generic;
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
using System.Collections;
using System.Data;
//using System.Data.SqlClient;
using System.IO;
//using Microsoft.Data.SqlClient;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for delete.xaml
    /// </summary>
    public partial class delete : Window
    {
        public delete()
        {
            InitializeComponent();
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void deleteb_Click(object sender, RoutedEventArgs e)
        {
            if (namebook2.Text == string.Empty || writer2.Text == String.Empty)
            {
                MessageBox.Show("field ha ra vared kon");
            }
            //hame ketaha dar sql ra dar yek list zakhre kardam
            else
            {
                List<Book> a = new List<Book>();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                command = "select * from book";
                SqlDataAdapter adapter = new SqlDataAdapter(command, con);
                DataTable data = new DataTable();
                adapter.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    Book z = new Book(data.Rows[i][0].ToString(),
                    data.Rows[i][1].ToString(), Convert.ToInt32(data.Rows[i][2]), Convert.ToBoolean(data.Rows[i][3]));
                    a.Add(z);
                }
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
                con.Close();
                ////////////
                bool k = false;
                for (int i = 0; i < a.Count; i++)
                {
                    if ((namebook2.Text == a[i].name.ToString()) && writer2.Text == a[i].writer.ToString())
                    {
                        ///hazf ketab

                        k = true;
                        SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                        con1.Open();
                        string command1;

                        command1 = "delete from book where name='" + a[i].name.ToString() + "'";
                        a.Remove(a[i]);
                        SqlCommand com1 = new SqlCommand(command1, con1);

                        com1.ExecuteNonQuery();
                        con1.Close();
                        //con.Close();
                        MessageBox.Show("hazf shod");

                        namebook2.Text = String.Empty;
                        writer2.Text = String.Empty;

                        break;
                    }
                }
                if (k == false)
                {
                    MessageBox.Show("chenin ketabi vojood nadarad");
                    namebook2.Text = String.Empty;
                    writer2.Text = String.Empty;
                }

            }
        }
        public class Book
        {
            public string name { get; set; }
            public string writer { get; set; }

            public bool borrow { get; set; }

            public int number { get; set; }
            public int time { get; set; }


            public Book(string name, string writer, int number, bool borrow)
            {
                this.name = name;
                this.writer = writer;
                this.number = number;
                this.borrow = borrow;
            }
        }
    }
}
