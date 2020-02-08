using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301041266_aguiar__Lab02
{
    public class Appetizer
    {
        public string AppetizerName { get; set; }
        public double AppetizerPrice { get; set; }

        public string AppetizerItem
        {
            get { return $"{AppetizerName}\t{String.Format("{0:C}", AppetizerPrice)}"; }
            
        }

        public string getAppetizerName()
        {
            return AppetizerName;
        }

        public double getAppetizerPrice()
        {
            return AppetizerPrice;
        }

        public override string ToString()
        {
            return AppetizerItem;
        }
    }
}
