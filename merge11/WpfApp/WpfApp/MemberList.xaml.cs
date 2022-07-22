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
    public partial class MemberList : Window
    {
        public List<MemberInfo> memList { get; set; }
        public MemberList()
        {
            InitializeComponent();

            memList = new List<MemberInfo>();
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
                string phoneNum = data.Rows[i][3].ToString();
                string pass = data.Rows[i][4].ToString();
                //should I put picture here?
                //ImageSource = ;
                double balance = Convert.ToDouble(data.Rows[i][6]);
                DateTime membershipDate = Convert.ToDateTime(data.Rows[i][7]);
                //create a member
                MemberInfo m = new MemberInfo(firstName, lastName, email,
                    pass, phoneNum, balance, membershipDate);
                memList.Add(m);
            }
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();

            DataContext = this;
        }

        private void MemberList_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        //why doesn't it work?
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    //a class to store all the members properties
    public class MemberInfo
    {
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public string _userName { get; set; }
        public string _password { get; set; }
        public string _phone { get; set; }
        public double _balance { get; set; }
        public DateTime _memDate { get; set; }
        //ImageSource _photoPath;
        public MemberInfo(string firstName, string lastName, string username,
                        string pass, string phoneNum,
                        double balance, DateTime date)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._userName = username;
            this._password = pass;
            //this._photoPath = path;
            this._phone = phoneNum;
            this._balance = balance;
            this._memDate = date;
        }
    }
}
