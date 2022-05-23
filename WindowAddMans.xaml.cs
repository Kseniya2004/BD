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
using BD.Classes;

namespace BD
{
    /// <summary>
    /// Логика взаимодействия для WindowAddMans.xaml
    /// </summary>
    public partial class WindowAddMans : Window
    {
        int mode;
        public WindowAddMans()
        {
            InitializeComponent();
            mode = 0;
        }
        public WindowAddMans(Man man)
        {
            InitializeComponent();
            TxbName.Text = man.Name;
            TxbBirthday.Text = man.Birth_year.ToString();
            TxbPay.Text = man.Pay.ToString();            
            mode = 1;
            BtnAddMan.Content = "Сохранить";
        }
        private void BtnAddMan_Click(object sender, RoutedEventArgs e)
        {
            if (mode == 0)
            {
                try
                {
                    Man pharmacy = new Man()
                    {
                        Name = TxbName.Text,
                        Birth_year = int.Parse(TxbBirthday.Text),
                        Pay = double.Parse(TxbPay.Text),
                        
                    };
                    ConnectHelper.dbase.Add(pharmacy);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            //редактирование данных
            else
            {
                try
                {
                    for (int i = 0; i < ConnectHelper.dbase.Count; i++)
                    {
                        if (ConnectHelper.dbase[i].Name == TxbName.Text)
                        {
                            ConnectHelper.dbase[i].Birth_year = int.Parse(TxbBirthday.Text);
                            ConnectHelper.dbase[i].Pay = double.Parse(TxbPay.Text);
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            ConnectHelper.SaveListToFile(@"ListPrice.txt");
            this.Close();
        }
    }
}

