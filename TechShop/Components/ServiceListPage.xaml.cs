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

namespace TechShop.Components
{
    /// <summary>
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        private Product product;

        public ServiceListPage()
        {
            InitializeComponent();
            if(!App.isAdmin)
            {
                AddBtn.Visibility = Visibility.Hidden;
            }
            Refresh();

        }
        private void Refresh()
        {
            IEnumerable<Product> serviceSortList = App.db.Product;

            
            if(SortCb.SelectedIndex == 1)
            {
                serviceSortList = serviceSortList.OrderBy(x => x.Cost);
            }
            else if(SortCb.SelectedIndex == 2)
            {
                serviceSortList = serviceSortList.OrderByDescending(x => x.Cost);
            }

            if (DiscountFiltrCb.SelectedIndex != 0)
            {
                if (DiscountFiltrCb.SelectedIndex == 1)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 0 && x.Discount < 5);
                if (DiscountFiltrCb.SelectedIndex == 2)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 5 && x.Discount < 15);
                if (DiscountFiltrCb.SelectedIndex == 3)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 15 && x.Discount < 30);
                if (DiscountFiltrCb.SelectedIndex == 4)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 30 && x.Discount < 70);
                if (DiscountFiltrCb.SelectedIndex == 5)
                    serviceSortList = serviceSortList.Where(x => x.Discount >= 70 && x.Discount < 100);
            }
            if (SearchTb.Text != null)
            {
                serviceSortList = serviceSortList.Where(x => x.Title.ToLower().Contains(SearchTb.Text.ToLower()) ||
                x.Description.ToLower().Contains(SearchTb.Text.ToLower()));
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
            new AddEditServicePage(product).ShowDialog();
        }
    }
}
