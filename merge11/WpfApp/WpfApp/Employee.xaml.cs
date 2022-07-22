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
    public partial class Employee : Window
    {
        string EmployeeEmail { get; set; }
        string EmployeePass { get; set; }
        public Employee(string email, string pass)
        {
            InitializeComponent();
            EmployeeEmail = email;
            EmployeePass = pass;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Employee_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Show_Balance(object sender, RoutedEventArgs e)
        {
            ShowEmployeeBalance balance = new ShowEmployeeBalance(EmployeeEmail, EmployeePass);
            balance.Show();
        }

        private void Edit_Info(object sender, RoutedEventArgs e)
        {
            EditEmployeeInfo EditInfo = new EditEmployeeInfo(EmployeeEmail, EmployeePass);
            EditInfo.Show();
        }

        private void Book_List(object sender, RoutedEventArgs e)
        {
            showbook show = new showbook();
            show.Show();
        }

        private void Available(object sender, RoutedEventArgs e)
        {
            ShowAvailableBooks aBooks = new ShowAvailableBooks();
            aBooks.Show();
        }

        private void Borrowed(object sender, RoutedEventArgs e)
        {
            Borrowed bb = new Borrowed();
            bb.Show();
        }

        private void Member_List(object sender, RoutedEventArgs e)
        {
            MemberList mL = new MemberList();
            mL.Show();
        }

        private void Delayed_Return(object sender, RoutedEventArgs e)
        {
            DelayedReturn DelayedR = new DelayedReturn();
            DelayedR.Show();
        }

        private void Delayed_Pay(object sender, RoutedEventArgs e)
        {
            DelayedPay dP = new DelayedPay();
            dP.Show();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
    }
}
