using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _301041266_aguiar__Lab02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //instantiate the fullmenu with lists of menu items
        FullMenu menu = new FullMenu();
        //instantiate object with the properties that will be columns on the data Grid
        DataGridItems menuItem = new DataGridItems();

        //instantiate observable collections to use with the combo box'es and data grid
        public ObservableCollection<Appetizer> appetizers = new ObservableCollection<Appetizer>();
        public ObservableCollection<Beverage> beverages = new ObservableCollection<Beverage>();
        public ObservableCollection<Dessert> desserts = new ObservableCollection<Dessert>();
        public ObservableCollection<MainCourse> mainCourses = new ObservableCollection<MainCourse>();

        //instantiate observable collection for the bill - data grid items
        public ObservableCollection<DataGridItems> check = new ObservableCollection<DataGridItems>();

        double subTotal = 0, total = 0, tax = 0;

        //instantiate object to print the bill
        PrintDialog printdialog = new PrintDialog();

        public MainWindow()
        {
            InitializeComponent();
            //ensure data grid list of items points to null

            //load the observable lists and load into the Combo Box'es
            loadComboBox();
            dGridCheck.ItemsSource = check;
            disableButtons();
        }

        /// <summary>
        /// method that handles the disabling of datagrid cells
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in dGridCheck.Columns)
            {
                item.IsReadOnly = true;
            }
            dGridCheck.Columns.ElementAt(2).IsReadOnly = false;
        }

        /// <summary>
        /// Load the combo box with the list of items
        /// </summary>
        private void loadComboBox()
        {
            //load the all menu items into the 4 observable lists
            foreach (Appetizer item in menu.listAppetizers)
            {
                appetizers.Add(item);
            }
            foreach (Beverage item in menu.listBeverages)
            {
                beverages.Add(item);
            }
            foreach (Dessert item in menu.listDesserts)
            {
                desserts.Add(item);
            }
            foreach (MainCourse item in menu.listMainCourses)
            {
                mainCourses.Add(item);
            }
            //load combo box'es
            cBoxAppetizer.ItemsSource = appetizers;
            cBoxBeverage.ItemsSource = beverages;
            cBoxDessert.ItemsSource = desserts;
            cBoxMainCourse.ItemsSource = mainCourses;
        }

        /// <summary>
        /// Event handlers for when the combo boxes are used by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxBeverage_DropDownClosed(object sender, EventArgs e)
        {

            //statement to avoid program breaking in case combo box is closed without any selection
            if (cBoxBeverage.SelectedIndex >= 0)
            {
                //load the object information into the menuItem to be loaded into the data grid
                menuItem.Category = "Beverage";
                menuItem.Name = beverages.ElementAt(cBoxBeverage.SelectedIndex).BeverageName;
                menuItem.Price = beverages.ElementAt(cBoxBeverage.SelectedIndex).BeveragePrice;

                //boolean to check if exist item on the datagrid
                bool existItem = false;

                //load the menu Item in to the dataGrid through data binding
                foreach (DataGridItems item in check)
                {
                    //if the item already exist on the data grid, increment quantity
                    if (item.Name == menuItem.Name)
                    {
                        existItem = true;
                        item.Quantity++;
                        dGridCheck.Items.Refresh();
                    }

                }
                //if the item doesn´t exist on the data grid, add the item
                if (!existItem)
                {
                    DataGridItems newMenuItem = new DataGridItems();
                    newMenuItem.Category = "Beverage";
                    newMenuItem.Name = beverages.ElementAt(cBoxBeverage.SelectedIndex).BeverageName;
                    newMenuItem.Price = beverages.ElementAt(cBoxBeverage.SelectedIndex).BeveragePrice;
                    newMenuItem.Quantity++;
                    check.Add(newMenuItem);
                }

                //update the bill text boxes with the values
                UpdateBill();

                //enable buttons
                enableButtons();
            }
        }
        private void cBoxAppetizer_DropDownClosed(object sender, EventArgs e)
        {
            //statement to avoid program breaking in case combo box is closed without any selection
            if (cBoxAppetizer.SelectedIndex >= 0)
            {
                //load the object information into the menuItem to be loaded into the data grid
                menuItem.Category = "Appetizer";
                menuItem.Name = appetizers.ElementAt(cBoxAppetizer.SelectedIndex).AppetizerName;
                menuItem.Price = appetizers.ElementAt(cBoxAppetizer.SelectedIndex).AppetizerPrice;

                //boolean to check if exist item on the datagrid
                bool existItem = false;

                //load the menu Item in to the dataGrid through data binding
                foreach (DataGridItems item in check)
                {
                    //if the item already exist on the data grid, increment quantity
                    if (item.Name == menuItem.Name)
                    {
                        existItem = true;
                        item.Quantity++;
                        dGridCheck.Items.Refresh();
                    }

                }
                //if the item doesn´t exist on the data grid, add the item
                if (!existItem)
                {
                    DataGridItems newMenuItem = new DataGridItems();
                    newMenuItem.Category = "Appetizer";
                    newMenuItem.Name = appetizers.ElementAt(cBoxAppetizer.SelectedIndex).AppetizerName;
                    newMenuItem.Price = appetizers.ElementAt(cBoxAppetizer.SelectedIndex).AppetizerPrice;
                    newMenuItem.Quantity++;
                    check.Add(newMenuItem);
                }

                //update the bill text boxes with the values
                UpdateBill();

                //enable buttons
                enableButtons();
            }
        }
        private void cBoxMainCourse_DropDownClosed(object sender, EventArgs e)
        {
            //statement to avoid program breaking in case combo box is closed without any selection
            if (cBoxMainCourse.SelectedIndex >= 0)
            {
                //load the object information into the menuItem to be loaded into the data grid
                menuItem.Category = "Main Course";
                menuItem.Name = mainCourses.ElementAt(cBoxMainCourse.SelectedIndex).MainCourseName;
                menuItem.Price = mainCourses.ElementAt(cBoxMainCourse.SelectedIndex).MainCoursePrice;

                //boolean to check if exist item on the datagrid
                bool existItem = false;

                //load the menu Item in to the dataGrid through data binding
                foreach (DataGridItems item in check)
                {
                    //if the item already exist on the data grid, increment quantity
                    if (item.Name == menuItem.Name)
                    {
                        existItem = true;
                        item.Quantity++;
                        dGridCheck.Items.Refresh();
                    }

                }
                //if the item doesn´t exist on the data grid, add the item
                if (!existItem)
                {
                    DataGridItems newMenuItem = new DataGridItems();
                    newMenuItem.Category = "Main Course";
                    newMenuItem.Name = mainCourses.ElementAt(cBoxMainCourse.SelectedIndex).MainCourseName;
                    newMenuItem.Price = mainCourses.ElementAt(cBoxMainCourse.SelectedIndex).MainCoursePrice;
                    newMenuItem.Quantity++;
                    check.Add(newMenuItem);
                }

                //update the bill text boxes with the values
                UpdateBill();

                //enable buttons
                enableButtons();
            }
        }
        private void cBoxDessert_DropDownClosed(object sender, EventArgs e)
        {
            //statement to avoid program breaking in case combo box is closed without any selection
            if (cBoxDessert.SelectedIndex >= 0)
            {
                //load the object information into the menuItem to be loaded into the data grid
                menuItem.Category = "Dessert";
                menuItem.Name = desserts.ElementAt(cBoxDessert.SelectedIndex).DessertName;
                menuItem.Price = desserts.ElementAt(cBoxDessert.SelectedIndex).DessertPrice;

                //boolean to check if exist item on the datagrid
                bool existItem = false;

                //load the menu Item in to the dataGrid through data binding
                foreach (DataGridItems item in check)
                {
                    //if the item already exist on the data grid, increment quantity
                    if (item.Name == menuItem.Name)
                    {
                        existItem = true;
                        item.Quantity++;
                        dGridCheck.Items.Refresh();
                    }

                }
                //if the item doesn´t exist on the data grid, add the item
                if (!existItem)
                {
                    DataGridItems newMenuItem = new DataGridItems();
                    newMenuItem.Category = "Dessert";
                    newMenuItem.Name = desserts.ElementAt(cBoxDessert.SelectedIndex).DessertName;
                    newMenuItem.Price = desserts.ElementAt(cBoxDessert.SelectedIndex).DessertPrice;
                    newMenuItem.Quantity++;
                    check.Add(newMenuItem);
                }

                //update the bill text boxes with the values
                UpdateBill();

                //enable buttons
                enableButtons();
            }
        }

        /// <summary>
        /// This method updates Total, SubTotal and Tax text boxes
        /// </summary>
        private void UpdateBill()
        {
            subTotal = 0; tax = 0; total = 0;
            foreach (DataGridItems item in check)
            {
                subTotal += item.Price * item.Quantity;
            }
            tax = subTotal * 0.13;
            total = subTotal + tax;
            txtBoxSubTotal.Text = String.Format("{0:C}", subTotal);
            txtBoxTax.Text = String.Format("{0:C}", tax);
            txtBoxTotal.Text = String.Format("{0:C}", total);
        }

        /// <summary>
        /// Handler method for the remove item button
        /// It removes the selected item (if any selected) from the data grid
        /// and recalculate the bill
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (dGridCheck.SelectedIndex >= 0)
            {
                check.RemoveAt(dGridCheck.SelectedIndex);
            }
            UpdateBill();
            if (check.Count == 0)
            {
                cBoxBeverage.SelectedIndex = -1;
                cBoxAppetizer.SelectedIndex = -1;
                cBoxMainCourse.SelectedIndex = -1;
                cBoxDessert.SelectedIndex = -1;
                disableButtons();
            }
        }

        /// <summary>
        /// Method that handle Clear All button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            cBoxBeverage.SelectedIndex = -1;
            cBoxAppetizer.SelectedIndex = -1;
            cBoxMainCourse.SelectedIndex = -1;
            cBoxDessert.SelectedIndex = -1;
            txtBoxSubTotal.Text = null;
            txtBoxTax.Text = null;
            txtBoxTotal.Text = null;
            check.Clear();
            disableButtons();

        }

        /// <summary>
        /// This is the event handler that change the price from double to currency 
        /// into the data grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertPriceToCurrency(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Price")
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "c";
            }
        }

        /// <summary>
        /// This method handles the Print Invoice button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintInvoice_Click(object sender, RoutedEventArgs e)
        {
            //Create flow document with initial content
            FlowDocument doc = CreateBill();
            doc.Name = "Bill";
            IDocumentPaginatorSource idpSource = doc;
            printdialog.PrintDocument(idpSource.DocumentPaginator, "Print the Bill");
        }

        private FlowDocument CreateBill()
        {
            string billItems = "";
            // Create a FlowDocument  
            FlowDocument doc = new FlowDocument();
            // Create a Section  
            Section sec = new Section();
            // Create first Paragraph  
            Paragraph p1 = new Paragraph();
            // Create and add a new Bold, Italic and Underline  
            //Bold bld = new Bold();
            p1.Inlines.Add(new Run("Centennial College - The Local Restaurant"));
            p1.Inlines.Add(new Run("\n937 Progress Ave, Scarborough, ON M1G 3T8\n\n"));
            p1.Inlines.Add(new Run("*****************************************\n"));
            p1.Inlines.Add(new Run("                            INVOICE               \n"));
            p1.Inlines.Add(new Run("*****************************************\n"));
            p1.Inlines.Add(new Run("Qty\tItem\t\t\tPrice\n\n"));


            foreach (DataGridItems item in check)
            {
                p1.Inlines.Add(new Run(item.ToString()+"\n"));
            }
            p1.Inlines.Add(new Run("\n*****************************************\n\n"));
            p1.Inlines.Add(new Run("\t\tSubTotal: "+"\t"+txtBoxSubTotal.Text+"\n"));
            p1.Inlines.Add(new Run("\t\tTax: "+ "\t\t" + txtBoxTax.Text + "\n"));
            p1.Inlines.Add(new Run("\t\tTotal: "+ "\t\t" + txtBoxTotal.Text+"\n\n"));
            p1.Inlines.Add(new Run("\t\tTIP: ______________"));
            p1.Inlines.Add(new Run("\n\n*****************************************\n"));
            p1.Inlines.Add(new Run("THANK YOU FOR DINNING WITH US!"));
            // Add Paragraph to Section  
            sec.Blocks.Add(p1);
            // Add Section to FlowDocument  
            doc.Blocks.Add(sec);
            return doc;
        }

        /// <summary>
        /// this method handles the event of the user chanding the 
        /// quantity of items directly into the data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dGridCheck_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBill();
        }

        /// <summary>
        /// This method handles the event for the hyperlink
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        /// <summary>
        /// Event Handler for when all Combo Boxes are open, no selection is made.
        /// In case they are closed without any selection, it will not add their
        /// last selection to the Data Grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxBeverage_DropDownOpened(object sender, EventArgs e)
        {
            cBoxBeverage.SelectedIndex = -1;
        }
        private void cBoxAppetizer_DropDownOpened(object sender, EventArgs e)
        {
            cBoxAppetizer.SelectedIndex = -1;
        }
        private void cBoxMainCourse_DropDownOpened(object sender, EventArgs e)
        {
            cBoxMainCourse.SelectedIndex = -1;
        }
        private void cBoxDessert_DropDownOpened(object sender, EventArgs e)
        {
            cBoxDessert.SelectedIndex = -1;
        }

        /// <summary>
        /// Methods that handle disable/enable buttons
        /// </summary>
        private void disableButtons()
        {
            btnClearAll.IsEnabled = false;
            btnPrintInvoice.IsEnabled = false;
            btnRemoveItem.IsEnabled = false;
        }

        private void enableButtons()
        {
            btnClearAll.IsEnabled = true;
            btnPrintInvoice.IsEnabled = true;
            btnRemoveItem.IsEnabled = true;
        }
    }
}
