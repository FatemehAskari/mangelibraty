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
    /// Interaction logic for return22.xaml
    /// </summary>
    public partial class return22 : Window
    {
        public string email;
        List<string> me = new List<string>();

        public return22(string email)
        {
            InitializeComponent();
            this.email = email;
            
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
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
                    me.Add(data.Rows[i][2].ToString());
                }
            }
            SqlCommand com = new SqlCommand(command, con);
            com.ExecuteNonQuery();
            con.Close();
            bool t1 = check3(me, namebook.Text);
            if(t1==false)
            {
                MessageBox.Show("in ketab ar list shoma nist");
                namebook.Text = string.Empty;
            }
            if(t1==true)
            {
                delli(namebook.Text);
                update(namebook.Text);
                MessageBox.Show("anjam shod");
                namebook.Text = string.Empty;
            }
        }

        public bool check3(List<string>n,string name)
        {
            bool k = false;
            for(int i=0;i<n.Count;i++)
            {
                if(n[i]==name)
                {
                    k = true;
                }
            }
            if(k==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void delli(string name)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            string command1;

            command1 = "delete from bookList1 where namebook='" + name + "'";
            
            SqlCommand com1 = new SqlCommand(command1, con1);

            com1.ExecuteNonQuery();
            con1.Close();
        }
        public void update(string name)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            string command1;
            bool f1 = false;
            //compiler warning
            //bool f2 = true;

            command1 = "update book SET Borrowed='" + f1 + "' where Name='" + name + "'";

            SqlCommand com1 = new SqlCommand(command1, con1);

            com1.ExecuteNonQuery();
            con1.Close();
        }
    }
}
