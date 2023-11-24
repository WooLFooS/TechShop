using Microsoft.Win32;
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
using TechShop.Bases;

namespace TechShop.Components
{
    /// <summary>
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Window
    {
        Product product;
        public AddEditServicePage(Product _product)
        {
            product = _product;
            InitializeComponent();
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png.|*jpg.|*.jpg|*.jpeg|*.jpeg"
            };
            //if (openFile.ShowDialog().GetValueOrDefault())
            //{
            //    product.MainImage = Fi
            //}
        }
    }
}
