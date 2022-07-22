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
    /// Interaction logic for showEmployee.xaml
    /// </summary>
    public partial class showEmployee : Window
    {
        public List<infoem> info { get; set; }

        public showEmployee()
        {
            InitializeComponent();
            info = new List<infoem>();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command;
            command = "select * from EmployeeInfo";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable data = new DataTable();
            adapter.Fill(data);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                //ImageSource r =(ImageSource)data.Rows[i][6];
                infoem c = new infoem(data.Rows[i][1].ToString(), data.Rows[i][2].ToString(), data.Rows[i][4].ToString());
                info.Add(c);
            }
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();

           
            DataContext = this;
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
    public class infoem
    {
       public string name { get; set; }
       public string family { get; set; }
       public string phone { get; set; }
       // ImageSource pic { get; set; }
        public infoem(string name,string family,string phone)
        {
            this.name = name;
            this.family = family;
            this.phone = phone;
            
        }
    }

}
