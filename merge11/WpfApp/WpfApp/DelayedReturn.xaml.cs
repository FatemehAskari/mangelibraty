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
    public partial class DelayedReturn : Window
    {
        public List<Delayers> delayedMem { get; set; }
        public DelayedReturn()
        {
            InitializeComponent();

            delayedMem = new List<Delayers>();
            SqlConnection con = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command;
            command = "select * from bookList1";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string email = data.Rows[i][1].ToString();
                string BookName = data.Rows[i][2].ToString();
                DateTime borrowedDate = Convert.ToDateTime(data.Rows[i][3]);
                DateTime now = DateTime.Now;
                TimeSpan value = now.Subtract(borrowedDate);
                if (7 < value.Days)
                {
                    Delayers delayer = new Delayers(BookName, email, value.Days - 7);
                    delayedMem.Add(delayer);
                }
            }
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();

            DataContext = this;
        }

        private void DelayedReturn_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class Delayers
    {
        public string _bookName { get; set; }
        public string _email { get; set; }

        //number of days delayed
        public int _delayedDays { get; set; }

        //do this if you have time
        //public ImageSource _photo { get; set; }
        public Delayers(string name, string email, int delayedDays)
        {
            this._bookName = name;
            this._email = email;
            this._delayedDays = delayedDays;
        }
    }
}
