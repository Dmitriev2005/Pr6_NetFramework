using Pr6_NetFramework.Autorisation;
using Pr6_NetFramework.OtherWindows;
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

namespace Pr6_NetFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in App.DB.Tovaris.ToList())
            {
                if (item.Izobrazhenie==null)
                    item.Izobrazhenie = "picture.png";
                App.DB.SaveChanges();
            }
            grProducts.ItemsSource = null;
            grProducts.ItemsSource = App.DB.Tovaris.ToList();
            if (!App.isAdmin)
            {
                btnAdd.IsEnabled = false;
                btnDel.IsEnabled = false;
                btnEdit.IsEnabled = false;
            }
            lbCurrentUser.Content = App.currentUser;
         }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit(new Tovari(),true);
            addOrEdit.ShowDialog();
            grProducts.ItemsSource = null;
            grProducts.ItemsSource = App.DB.Tovaris.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddOrEdit addOrEdit = new AddOrEdit(grProducts.SelectedItem as Tovari, false);
            addOrEdit.ShowDialog();
            grProducts.ItemsSource = null;
            grProducts.ItemsSource = App.DB.Tovaris.ToList();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            App.DB.Tovaris.Remove(grProducts.SelectedItem as Tovari);
            App.DB.SaveChanges();

            grProducts.ItemsSource = null;
            grProducts.ItemsSource = App.DB.Tovaris.ToList();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.currentUser = "";
            App.isAdmin = false;
            SigIn sigIn = new SigIn();
            sigIn.Show();
            Hide();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var ob = (sender as MenuItem);
            switch (ob.Header) {
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


    }
}
