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
using TechShop.Bases;

namespace TechShop.Components
{
    /// <summary>
    /// Логика взаимодействия для ServiceUserControl.xaml
    /// </summary>
    public partial class ServiceUserControl : UserControl
    {

        private Product product;

        public ServiceUserControl(Product _product)
        {
            InitializeComponent();
            product = _product;
            NameProductTb.Text = _product.Title;
            ImageProduct.Source = new BitmapImage(new Uri(@"\Resources\6347567.png", UriKind.Relative));

      
            DiscountTb.Text = _product.DiscountStr;
            RaitingTb.Text = _product.OverrideFeedback;

            if(Convert.ToString(_product.Discount) != "0")
            {
                OriginalPriceLb.Text = Convert.ToString(_product.Cost) + "";
                FirstPriceLb.Text = Convert.ToString(Convert.ToDouble(_product.Cost) - (Convert.ToDouble(_product.Cost) * (_product.Discount / 100))) + "";
                FirstPriceLb.Background = Brushes.Green;
            }
            else
            {
                FirstPriceLb.Text = _product.Cost + "";
                OriginalPriceLb.Text = "";

                
            }
            if(!App.isAdmin)
            {
                EditBtn.Visibility = Visibility.Hidden;
                DelBtn.Visibility = Visibility.Hidden;
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if(product.Feedback.Count != 0)
            {
                MessageBox.Show("Запрещено удалять");
            }
            else
            {
                App.db.Product.Remove(product);
                App.db.SaveChanges();
                MessageBox.Show("Удалено: " + product.Title);
                Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.mainWindow.MainFrame.Navigate(new AddEditServicePage(product));
        }
    }
}
