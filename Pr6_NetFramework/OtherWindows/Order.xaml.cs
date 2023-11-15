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

namespace Pr6_NetFramework.OtherWindows
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Order()
        {
            InitializeComponent();
            grOrder.ItemsSource = null;
            grOrder.ItemsSource = App.DB.Zakazs.ToList();

            lbCurrentUser.Content = App.currentUser;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var ob = (sender as MenuItem);
            switch (ob.Header)
            {
                case "Товары":
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Hide();
                    break;
                case "Заказы":
                    Order order = new Order();
                    order.Show();
                    Hide();
                    break;
                case "Пункты выдачи":
                    PointOutput point = new PointOutput();
                    point.Show();
                    Hide();
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
