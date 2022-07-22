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
using System.Collections.ObjectModel;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for returnbook1.xaml
    /// </summary>
    public partial class returnbook1 : Window
    {
        public string email;
        public List<f1> bookme { get; set; }

        public returnbook1(string email)
        {
            InitializeComponent();
            this.email = email;
            bookme = new List<f1>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string command;
            command = "select * from bookList1";

            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i][1].ToString() == email)
                {
                   
                    f1 c = new f1(data.Rows[i][2].ToString());                    
                    bookme.Add(c);
                }
            }
            SqlCommand com = new SqlCommand(command, con);
            com.ExecuteNonQuery();
            con.Close();
            DataContext = this;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void returnbook_Click(object sender, RoutedEventArgs e)
        {
            return22 v = new return22(email);
            v.Show();
        }

        public class f1
        {
            public string name { get; set; }
          public f1(string name)
          {
                this.name = name;
          }
        }            

    }
}
