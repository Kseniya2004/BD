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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BD.Classes;
using Microsoft.Win32;

namespace BD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            ConnectHelper.ReadListFromFile(@"dbase.txt");
            DtgListMan.ItemsSource = ConnectHelper.dbase.ToList();
            DtgListMan.SelectedIndex = -1;
            txbPay.Text = ConnectHelper.dbase.Average(x => x.Pay).ToString();           
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddMans windowAdd = new WindowAddMans();
            windowAdd.ShowDialog();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DtgListMan.ItemsSource = ConnectHelper.dbase.Where(x =>
               x.Name.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAddMans windowAdd = new WindowAddMans((sender as Button).DataContext as Man);
            windowAdd.ShowDialog();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            DtgListMan.ItemsSource = null;
        }
    }
}
