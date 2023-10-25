using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TechShop.Bases
{
    partial class Product
    {
        public string costDiscount
        { 
            get
            {
                if(Discount == 0)
                {
                    return "";
                }
                else
                {
                    return $"{Cost - (Cost * (decimal) Discount/100)}";
                }
            }
        }
        
        public string DiscountStr
        {
            get
            {
                if(Discount == 0)
                {
                    return "";
                }
                else
                {
                    return $"{Discount}%";
                }
            }
        }
    }
}
