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

        public decimal costDiscount
        {
            get
            {
                if (Discount == 0)
                {
                    return Cost;
                }
                else
                {
                    return Cost - (Cost * (decimal)Discount);
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
        public string OverrideFeedback
        {
            get
            {
                double sum = 0;

                foreach (var item in Feedback)
                {
                    sum += item.Evaluation;
                }
                if (Feedback.Count() >= 11 && Feedback.Count() <= 19)
                    return $" {(sum / Feedback.Count()).ToString("N2")} {Feedback.Count()} отзывов";
                else if (Feedback.Count() == 1 || Feedback.Count() % 10 == 1)
                    return $" {(sum / Feedback.Count()).ToString("N2")} {Feedback.Count()} отзывов";
                else if (Feedback.Count() % 10 >= 2 || Feedback.Count() % 10 <= 4)
                    return $" {(sum / Feedback.Count()).ToString("N2")} {Feedback.Count()} отзывов";
                else
                    return $" {(sum / Feedback.Count()).ToString("N2")} {Feedback.Count()} отзывов";
            }
        }
    }
}
