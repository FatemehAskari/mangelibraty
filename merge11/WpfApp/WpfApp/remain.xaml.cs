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
    /// Interaction logic for remain.xaml
    /// </summary>
    public partial class remain : Window
    {
        List<string> a = new List<string>();
        public string email;
        bool f = false;
        public remain(string email)
        {
            InitializeComponent();
            a.Add(email);
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
                    DateTime b = Convert.ToDateTime(data.Rows[i][7].ToString());
                    DateTime c = DateTime.Now;
                    TimeSpan diff = c.Subtract(b);

                    int day = int.Parse(diff.Days.ToString());
                    int re = 30 - day;
                    if (re > 0)
                    {
                        Remaim.Text = "The days of left : " + re.ToString();
                        f = true;
                    }

                    else
                    {
                        Remaim1.Text = "The deadline has expired : " + Math.Abs(re).ToString();
                    }
                }
            }
            SqlCommand com = new SqlCommand(command, con);
            com.ExecuteNonQuery();
            con.Close();
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void pay_Click(object sender, RoutedEventArgs e)
        {
            if (f == true)
            {
                MessageBox.Show("shoma eshterak dari");
            }
            else
            {
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
                        //MessageBox.Show((data.Rows[i][6].ToString()));
                        float f = float.Parse(data.Rows[i][6].ToString());

                        if (f > 10)
                        {
                            upbalance(f);
                            MessageBox.Show("tamdid shod");
                        }
                        else
                        {
                            MessageBox.Show("Mojoodi hesab shoma kafi nist");
                        }
                    }
                }
                SqlCommand com = new SqlCommand(command, con);
                com.ExecuteNonQuery();
                con.Close();
            }
        }

        public void upbalance(float ba)
        {
            for (int i = 0; i < a.Count; i++)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                string command;
                float g = ba - 10;
                DateTime v = DateTime.Now;
                command = "Update member SET balance='" + g + "', datem='"+ v +"' where email='" + email.Trim() + "'";
                SqlCommand com = new SqlCommand(command, con);

                com.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
