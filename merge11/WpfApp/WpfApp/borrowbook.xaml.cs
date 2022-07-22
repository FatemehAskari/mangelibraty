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
    /// Interaction logic for borrowbook.xaml
    /// </summary>
    public partial class borrowbook : Window
    {
        
        public string email;
        public borrowbook(string email)
        {
            InitializeComponent();
            this.email = email;
            
            
            //MessageBox.Show(email);
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

        private void borrow_Click(object sender, RoutedEventArgs e)
        {
           bool t1 =checkbook(namebook.Text, writer1.Text);
           bool t2 = checkborrow();
           bool t3 = checktime();
            bool t4 = eshterak();
            if(t1==true && t2==true && t3==true && t4==true)
            {
                upbook(namebook.Text);
                addListbook(namebook.Text);
                MessageBox.Show("sabt shod");
                namebook.Text = string.Empty;
                writer1.Text = string.Empty;
            }
            if(t1==false)
            {
                MessageBox.Show("ketab mojood nist");
                namebook.Text = string.Empty;
                writer1.Text = string.Empty;
            }

            if (t2 == false)
            {
                MessageBox.Show("bish az 4 ketab amanat gerefti  ");
                namebook.Text = string.Empty;
                writer1.Text = string.Empty;
                
            }

            if (t3 == false)
            {
                MessageBox.Show("takhir dari");
                namebook.Text = string.Empty;
                writer1.Text = string.Empty;
            }

            if (t4 == false)
            {
                MessageBox.Show("kamtar az yek yafte eshterak moondeh");
                namebook.Text = string.Empty;
                writer1.Text = string.Empty;
            }

        }

        public bool checkbook(string name, string writer)
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
                if ((name== a[i].name.ToString()) && writer == a[i].writer.ToString() && a[i].borrow==false)
                {

                    
                    k = true;

                }
            }
            return k;
        }



        public bool checkborrow()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string command;
            command = "select * from bookList1";

            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            int x = 0;
            for(int i=0;i<data.Rows.Count;i++)
            {
                if(data.Rows[i][1].ToString()==email)
                {
                   // MessageBox.Show(x.ToString());
                    x++;
                }
            }
            SqlCommand com = new SqlCommand(command, con);
            com.ExecuteNonQuery();
            con.Close();
            if(x>4)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public void upbook(string name)
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            string command1;
            //compiler warning
            //bool f1 = false;
            bool f2 = true;
            
            command1 = "update book SET Borrowed='" + f2+ "' where Name='"+name+"'";
            
            SqlCommand com1 = new SqlCommand(command1, con1);

            com1.ExecuteNonQuery();
            con1.Close();
        }

        public int numlistbook()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string command;
            command = "select * from bookList1";

            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            
            SqlCommand com = new SqlCommand(command, con);
            com.ExecuteNonQuery();
            con.Close();
            return data.Rows.Count;
        }

        public void addListbook(string name)
        {
            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con2.Open();
            string command2;
            int id = numlistbook() + 1;
            DateTime d = DateTime.Now;
            command2 = "insert into bookList1 values('" +id + "','"+ email+ "','"+name+"','"+d+"')";
            SqlCommand com2 = new SqlCommand(command2, con2);
            com2.ExecuteNonQuery();
            con2.Close();
        }

        public bool checktime()
        {
            bool k = true;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string command;
            command = "select * from bookList1";

            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for(int i=0;i<data.Rows.Count;i++)
            {
                if(data.Rows[i][1].ToString()==email)
                {
                    DateTime b = Convert.ToDateTime(data.Rows[i][3].ToString());
                    DateTime c = DateTime.Now;
                    TimeSpan diff = c.Subtract(b);

                    int day = int.Parse(diff.Days.ToString());
                    if (day>7)
                    {
                        k = false;
                    }
                }
            }
            SqlCommand com = new SqlCommand(command, con);
            com.ExecuteNonQuery();
            con.Close();
            if(k==false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool eshterak()
        {
            bool k = true;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();
            string command;
            command = "select * from member";

            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for(int i=0;i<data.Rows.Count;i++)
            {
                if(data.Rows[i][2].ToString()==email)
                {
                    DateTime b = Convert.ToDateTime(data.Rows[i][7].ToString());
                    DateTime c = DateTime.Now;
                    TimeSpan diff = c.Subtract(b);
                    
                    int day = int.Parse(diff.Days.ToString());
                    
                    if(day>23)
                    {
                        k = false;
                    }
                }
            }
            SqlCommand com = new SqlCommand(command, con);
            com.ExecuteNonQuery();
            con.Close();
            if(k==false)
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
