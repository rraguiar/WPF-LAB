using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterLoginUserControl
{
    public class UserDetails : INotifyPropertyChanged
    {
        private string userName;
        private string userPassword;

        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName!=value)
                {
                    userName = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        public string UserPassword
        {
            get { return userPassword; }
            set
            {
                if (userPassword != value)
                {
                    userPassword = value;
                    OnPropertyChanged("UserPassword");
                }
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
