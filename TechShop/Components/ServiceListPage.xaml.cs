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
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public ServiceListPage()
        {
            InitializeComponent();
            Refresh();

        }
        private void Refresh()
        {
            IEnumerable<Product> serviceSortList = App.db.Product;

            if (SortCb.SelectedIndex != 0)
            {
                if (SortCb.SelectedIndex == 1)
                {
                    serviceSortList = serviceSortList.OrderBy(x => x.costDiscount);
                }
                else
                {
                    serviceSortList = serviceSortList.OrderByDescending(x => x.costDiscount);
                }
            }

            ServiceWp.Children.Clear();
            foreach (var service in serviceSortList)
            {
                ServiceWp.Children.Add(new ServiceUserControl(service));
            }
            CountDataTb.Text = serviceSortList.Count() + " из " + App.db.Product.Count();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DiscountFiltrCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
