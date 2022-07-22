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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for addB.xaml
    /// </summary>
    public partial class addB : Window
    {
        public addB()
        {
            InitializeComponent();
        }
        private void namebook_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void ADDb_Click(object sender, RoutedEventArgs e)
        {
            if (namebook.Text == string.Empty || writer1.Text == String.Empty)
            {
                MessageBox.Show("field ha ra vared kon");
            }
            else
            {
                string name = namebook.Text;
                string writer = writer1.Text;
                int num = 1;
                bool borrow = false;
                Book book = new Book(name, writer, num, borrow);
                SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\db\members.mdf;Integrated Security=True;Connect Timeout=30");
                con2.Open();
                string command2;
                command2 = "insert into book values('" + name.Trim() + "','" + writer.Trim() + "','" + num + "','" + borrow + "')";
                SqlCommand com2 = new SqlCommand(command2, con2);
                com2.ExecuteNonQuery();
                con2.Close();
                MessageBox.Show("ketab ezafe shod");

            }
            namebook.Text = String.Empty;
            writer1.Text = String.Empty;
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
}
