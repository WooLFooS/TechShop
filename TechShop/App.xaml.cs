using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TechShop.Bases;

namespace TechShop
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HardwareShopNiyazEntities db = new HardwareShopNiyazEntities();
        public static bool isAdmin = false;
    }
}
