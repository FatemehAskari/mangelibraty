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
    /// Interaction logic for Member.xaml
    /// </summary>
    public partial class Member : Window
    {
       public string email;
        public Member(string email)
        {
            InitializeComponent();
            string name1="";
            string family1="";
            //compiler warning
            //Image v =null;
            this.email = email;
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
                if (data.Rows[i][2].ToString()==email)
                {
                    name1 = data.Rows[i][0].ToString();
                    family1= data.Rows[i][1].ToString();
                  //  v = (Image)data.Rows[i][5];
                   
                    break;
                }
            }
            SqlCommand cmd = new SqlCommand(command, c);
            cmd.BeginExecuteNonQuery();
            c.Close();
          //  image.Source = new BitmapImage(new Uri(v.Source.ToString()));
            string info = name1 + " " + family1;
            title.Text = info;
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void bookme_Click(object sender, RoutedEventArgs e)
        {
            returnbook1 b = new returnbook1(email);
            b.Show();
        }

        private void lbook_Click(object sender, RoutedEventArgs e)
        {
            booksmem a = new booksmem(email);
            a.Show();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow c = new MainWindow();
            c.Show();
        }

        private void remaine_Click(object sender, RoutedEventArgs e)
        {
            remain n = new remain(email);
            n.Show();
        }

        private void balanceme_Click(object sender, RoutedEventArgs e)
        {
            balancemem n = new balancemem(email);
            n.Show();
        }

        private void editMem_Click(object sender, RoutedEventArgs e)
        {
            editmember b = new editmember(email);
            b.Show();
            this.Close();
        }
    }
}
