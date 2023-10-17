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
using TechShop.Components;

namespace TechShop.UserControls
{
    /// <summary>
    /// Логика взаимодействия для FonesOne.xaml
    /// </summary>
    public partial class FonesOne : Page
    {
        public FonesOne()
        {
            InitializeComponent();
            Refresh();

        }
        public void Refresh()
        {
            IEnumerable<Product> serviceSortList = App.db.Product;
            foreach (var product in serviceSortList)
            {
                FonesOneWp.Children.Add(new ServiceUserControl(product));
            }
        }
    }
}
