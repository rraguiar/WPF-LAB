using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301041266_aguiar__Lab02
{
    public class Beverage
    {
        public string BeverageName { get; set; }
        public double BeveragePrice { get; set; }

        public string BeverageItem
        {
            get { return $"{BeverageName}\t{String.Format("{0:C}", BeveragePrice)}"; }
        }

        public string getBeverageName()
        {
            return BeverageName;
        }

        public double getBeveragePrice()
        {
            return BeveragePrice;
        }

        public override string ToString()
        {
            return BeverageItem;
        }
    }
}
