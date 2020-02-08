using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _301041266_aguiar__Lab02
{
    public class FullMenu
    {
        public List<Appetizer> listAppetizers = new List<Appetizer>();
        public List<Beverage> listBeverages = new List<Beverage>();
        public List<Dessert> listDesserts = new List<Dessert>();
        public List<MainCourse> listMainCourses = new List<MainCourse>();

        public FullMenu()
        {
            listAppetizers.Add(new Appetizer { AppetizerName = "Buffalo Wings", AppetizerPrice = 5.95 });
            listAppetizers.Add(new Appetizer { AppetizerName = "Buffalo Fingers", AppetizerPrice = 6.95 });
            listAppetizers.Add(new Appetizer { AppetizerName = "Potato Skins", AppetizerPrice = 8.95 });
            listAppetizers.Add(new Appetizer { AppetizerName = "Nachos", AppetizerPrice = 8.95 });
            listAppetizers.Add(new Appetizer { AppetizerName = "Mushroom Caps", AppetizerPrice = 10.95 });
            listAppetizers.Add(new Appetizer { AppetizerName = "Shrimp Cocktail", AppetizerPrice = 12.95 });
            listAppetizers.Add(new Appetizer { AppetizerName = "Chips and Salsa", AppetizerPrice = 6.95 });

            listBeverages.Add(new Beverage { BeverageName = "Soda", BeveragePrice = 1.95 });
            listBeverages.Add(new Beverage { BeverageName = "Tea", BeveragePrice = 1.50 });
            listBeverages.Add(new Beverage { BeverageName = "Coffee", BeveragePrice = 1.25 });
            listBeverages.Add(new Beverage { BeverageName = "Mineral Water", BeveragePrice = 2.95 });
            listBeverages.Add(new Beverage { BeverageName = "Juice", BeveragePrice = 2.50 });
            listBeverages.Add(new Beverage { BeverageName = "Milk", BeveragePrice = 1.50 });

            listDesserts.Add(new Dessert { DessertName = "Apple Pie", DessertPrice = 5.95 });
            listDesserts.Add(new Dessert { DessertName = "Sundae", DessertPrice = 3.95 });
            listDesserts.Add(new Dessert { DessertName = "Carrot Cake", DessertPrice = 5.95 });
            listDesserts.Add(new Dessert { DessertName = "Mud Pie", DessertPrice = 4.95 });
            listDesserts.Add(new Dessert { DessertName = "Apple Crisp", DessertPrice = 5.95 });

            listMainCourses.Add(new MainCourse { MainCourseName = "Seafood Alfredo", MainCoursePrice = 15.95 });
            listMainCourses.Add(new MainCourse { MainCourseName = "Chicken Alfredo", MainCoursePrice = 13.95 });
            listMainCourses.Add(new MainCourse { MainCourseName = "Chicken Picatta", MainCoursePrice = 13.95 });
            listMainCourses.Add(new MainCourse { MainCourseName = "Turkey Club", MainCoursePrice = 11.95 });
            listMainCourses.Add(new MainCourse { MainCourseName = "Lobster Pie", MainCoursePrice = 19.95 });
            listMainCourses.Add(new MainCourse { MainCourseName = "Prime Rib", MainCoursePrice = 20.95 });
            listMainCourses.Add(new MainCourse { MainCourseName = "Shrimp Scampi", MainCoursePrice = 18.95 });
            listMainCourses.Add(new MainCourse { MainCourseName = "Turkey Dinner", MainCoursePrice = 13.95 });
            listMainCourses.Add(new MainCourse { MainCourseName = "Stuffed Chiken", MainCoursePrice = 14.95 });
        }
    }
}
