using System;
using System.Collections.Generic;
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

namespace LoginUserControl
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public LoginUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
        }

        public static DependencyProperty UserNameProperty =
           DependencyProperty.Register(nameof(UserName), typeof(string), typeof(LoginUserControl));


        public string UserPassword
        {
            get { return (string)GetValue(UserPasswordProperty); }
        }

        public static DependencyProperty UserPasswordProperty =
           DependencyProperty.Register(nameof(UserPassword), typeof(string), typeof(LoginUserControl));

    }

}
