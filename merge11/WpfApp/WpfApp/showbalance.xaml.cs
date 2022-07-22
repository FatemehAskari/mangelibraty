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
    /// Interaction logic for showbalance.xaml
    /// </summary>
    public partial class showbalance : Window
    {
        public List<me> r { get; set; }
        public showbalance()
        {
            InitializeComponent();
            r = new List<me>();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command;

            command = "select * from balanceli";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);

            double b = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                b = double.Parse(data.Rows[i][0].ToString());
                me z = new me() { s = b };
                r.Add(z);
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
    }
   public class me
   {
      public  double s { get; set; }
   }
}
