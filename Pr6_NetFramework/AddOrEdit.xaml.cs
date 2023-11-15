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

namespace Pr6_NetFramework
{
    /// <summary>
    /// Interaction logic for AddOrEdit.xaml
    /// </summary>
    public partial class AddOrEdit : Window
    {
        private bool isAdd = true;
        public AddOrEdit(Tovari tovari, bool isAdd)
        {
            InitializeComponent();
            this.isAdd = isAdd;
            DataContext = tovari;
            lbCurrentUser.Content = App.currentUser;
        }

        private void btnAddOrEdit_Click(object sender, RoutedEventArgs e)
        {
            if(isAdd)
                App.DB.Tovaris.Add(DataContext as Tovari);
            App.DB.SaveChanges();
            Close();
        }
    }
}
