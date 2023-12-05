using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        private Product products;
        public AddEditServicePage(Product _product)
        {
            InitializeComponent();
            products = _product;
            this.DataContext = products;
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            openFileDialog.ShowDialog();
            if(openFileDialog.FileName != null)
            {
                products.MainImage = File.ReadAllBytes(openFileDialog.FileName);
                ImageProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            Product newService = App.db.Product.Add(products);
            if (App.db.Product.Any(x => x.Title == products.Title))
                error.AppendLine("Услуга с таким именем уже существует");
            else if (TitleTb.Text == "")
                error.AppendLine("Введите имя");
            else
            {
                if (DiscountTb.Text.Replace(' ', '\n') == "")
                    error.AppendLine("Скидка не может быть пустой");
                else if (CostTb.Text.Replace(' ', '\n') == "")
                    error.AppendLine("Стоимость не может быть пустой");
            }
            App.db.Product.Add(products);
            App.db.SaveChanges();
            Navigation.mainWindow.MainFrame.Navigate(new ServiceListPage());
        }
    }
}
