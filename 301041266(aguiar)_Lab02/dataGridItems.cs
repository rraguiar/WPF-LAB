using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301041266_aguiar__Lab02
{
    public class DataGridItems
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public DataGridItems()
        {
            Quantity = 0;
        }
        public override string ToString()
        {
            return $"{Quantity}\t{Name}\t        {String.Format("{0:C}", Price)}";
        }
    }
}
