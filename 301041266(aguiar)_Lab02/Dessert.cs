using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301041266_aguiar__Lab02
{
    public class Dessert
    {
        public string DessertName { get; set; }
        public double DessertPrice { get; set; }

        public string DessertItem
        {
            get { return $"{DessertName}\t{String.Format("{0:C}", DessertPrice)}"; }
        }

        public string getDessertName()
        {
            return DessertName;
        }

        public double getDessertPrice()
        {
            return DessertPrice;
        }

        public override string ToString()
        {
            return DessertItem;
        }
    }
}
