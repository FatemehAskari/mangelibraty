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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void showbook_Click(object sender, RoutedEventArgs e)
        {
            showbook s = new showbook();
            s.Show();
        }

        private void addbook_Click(object sender, RoutedEventArgs e)
        {
            addB u = new addB();
            u.Show();
        }

        private void deletebook_Click(object sender, RoutedEventArgs e)
        {
            delete u1 = new delete();
            u1.Show();
        }

        private void incrementbalance_Click(object sender, RoutedEventArgs e)
        {
            balanceA u2 = new balanceA();
            u2.Show();
        }

        private void addemployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee u3 = new AddEmployee();
            u3.Show();
        }

        private void deleteemployee_Click(object sender, RoutedEventArgs e)
        {
            delemp m = new delemp();
            m.Show();
        }

        private void settleemployee_Click(object sender, RoutedEventArgs e)
        {
            settleem f = new settleem();
            f.Show();
        }

        private void showemployee_Click(object sender, RoutedEventArgs e)
        {
            showEmployee n =new showEmployee();
            n.Show();
        }

        private void showbalance_Click(object sender, RoutedEventArgs e)
        {
            showbalance a = new showbalance();
            a.Show();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
        }
    }
}
