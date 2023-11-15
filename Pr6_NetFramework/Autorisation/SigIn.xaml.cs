using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Pr6_NetFramework.Autorisation
{
    /// <summary>
    /// Interaction logic for SigIn.xaml
    /// </summary>
    public partial class SigIn : Window
    {
        // public User user = new User();
        Random random = new Random();
        public SigIn()
        {
            InitializeComponent();
            DataContext = new User();
            lbGenerateCap.Content = GeneratorCaptcha(4);
            foreach (var item in App.DB.Role2.ToList())
            {
                cmbRole.Items.Add(item.TitleRole);

            }

        }

        private void btnSigIn_Click(object sender, RoutedEventArgs e)
        {
            var context = DataContext as User;
            switch (cmbRole.Text) {
                case "Администратор":
                    context.Role = 1;
                    break;
                case "Менеджер":
                    context.Role = 2;
                    break;
                case "Клиент":
                    context.Role = 3;
                    break;
            }

            if(App.DB.Users.Where(q => q.Password == context.Password && q.Login==context.Login && q.Name == context.Name && q.Role == context.Role && lbGenerateCap.Content.ToString()==tbCaptha.Text).Any())
            {
                App.currentUser = context.Name;
                if (cmbRole.Text.Equals("Администратор"))
                    App.isAdmin = true;
                Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private string GeneratorCaptcha(int seed)
        {
            
            string codeCaptch = "";
            for (int i = 0; i < seed; i++)
            {
                codeCaptch = codeCaptch + random.Next(0,9).ToString();
            }

            return codeCaptch;
        }
    }
}
