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
    /// Interaction logic for showbook.xaml
    /// </summary>
    public partial class showbook : Window
    {
        public List<Book> books { get; set; }
        public showbook()
        {
            InitializeComponent();
            books = new List<Book>();
            ///
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
                books.Add(z);
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
        private void ShowBalance_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
    public class Book
    {
        public string name { get; set; }
        public string writer { get; set; }

        public bool borrow { get; set; }

        public int number { get; set; }
        public int time { get; set; }


        public Book(string name, string writer, int number, bool borrow)
        {
            this.name = name;
            this.writer = writer;
            this.number = number;
            this.borrow = borrow;
        }
    }
}

