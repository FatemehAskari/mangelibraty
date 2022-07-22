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
    public partial class DelayedPay : Window
    {
        public List<MemberInfo> DelayedMembership { get; set; }
        public DelayedPay()
        {
            InitializeComponent();

            DelayedMembership = new List<MemberInfo>();
            SqlConnection con = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command;
            command = "select * from member";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string firstName = data.Rows[i][0].ToString();
                string lastName = data.Rows[i][1].ToString();
                string email = data.Rows[i][2].ToString();
                string phone = data.Rows[i][3].ToString();
                string pass = data.Rows[i][4].ToString();
                //ImageSource photo = (ImageSource)data.Rows[i][5];
                double balance = Convert.ToDouble(data.Rows[i][6]);
                DateTime memDate = Convert.ToDateTime(data.Rows[i][7]);
                DateTime now = DateTime.Now;
                TimeSpan value = now.Subtract(memDate);
                if (30 < value.Days)
                {
                    MemberInfo m = new MemberInfo(firstName, lastName, email, pass, phone, balance, memDate);
                    DelayedMembership.Add(m);
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

        private void DelayedReturn_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
