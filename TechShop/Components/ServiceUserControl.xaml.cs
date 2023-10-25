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
       

        public ServiceUserControl(Product product)
        {
            InitializeComponent();
            NameProductTb.Text = product.Title;
            ImageProduct.Source = new BitmapImage(new Uri(@"\Resources\6347567.png", UriKind.Relative));

            OriginalPriceLb.Text = product.Cost.ToString();
            FirstPriceLb.Text = product.costDiscount;
            DiscountTb.Text = product.DiscountStr;
            RaitingTb.Text = product.
        }
        

    }
}
