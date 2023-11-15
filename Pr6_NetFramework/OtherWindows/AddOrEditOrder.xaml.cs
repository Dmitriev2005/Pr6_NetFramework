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
    /// Interaction logic for AddOrEditOrder.xaml
    /// </summary>
    public partial class AddOrEditOrder : Window
    {
        private Zakaz order { get; set; }
        private bool isEdit { get; set; }
        public AddOrEditOrder(Zakaz order, bool isEdit = false)
        {
            InitializeComponent();
            this.order = order;
            foreach (var item in App.DB.Punkt_vidachi)
            {
                cmbOutPoint.Items.Add(item.Name_punkt_vidachi);
            }
            
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {

            }
            else
            {
               // order.Punkt_vidochiNumber = cmbOutPoint.Text; 
                App.DB.Zakazs.Append(order);
                App.DB.SaveChanges();
                Close();
            }
        }
    }
}
