using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301041266_aguiar__Lab02
{
    public class MainCourse
    {
        public string MainCourseName { get; set; }
        public double MainCoursePrice { get; set; }

        public string MainCourseItem
        {
            get { return $"{MainCourseName}\t{String.Format("{0:C}", MainCoursePrice)}"; }
        }

        public string getMainCourseName()
        {
            return MainCourseName;
        }

        public double getMainCoursePrice()
        {
            return MainCoursePrice;
        }

        public override string ToString()
        {
            return MainCourseItem;
        }
    }
}
