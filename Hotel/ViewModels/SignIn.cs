using Hotel.Repositories;
using Hotel.Utils;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    class SignIn:NotifyPropertyChangedUtil
    {
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                ErrorMessage = "";
                Regex regex = new Regex(@"^[A-Za-z0-9._]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
                if (regex.Match(Email) == Match.Empty)
                {
                    ErrorMessage = "INVALID EMAIL FORMAT";
                    CanExecuteCommand = false;
                }
                else
                {
                    CanExecuteCommand = true;
                }
                NotifyPropertyChanged("Email");
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }


        
        public bool CanExecuteCommand { get; set; } = false;

        private ICommand signInCommand;
        public ICommand SignInCommand
        {
            get
            {
                if (signInCommand == null)
                {
                    signInCommand = new RelayCommand(SignInFunction, param => CanExecuteCommand);
                }
                return signInCommand;
            }
        }

        public void SignInFunction(object param)
        {
            string password = (param as PasswordBox).Password;
            if (password.Length == 0)
            {
                MessageBox.Show("Enter your password");
            }
            else
            {
                UserRepository userRepo = new UserRepository();
                var user = userRepo.GetUser(email,password);

                    if(user==null)
                    {
                    MessageBox.Show("Incorrect email or password!");
                }
                    else if(user.Role==UserRole.Admin)
                    {
                    AdminWindow window = new AdminWindow();
                    App.Current.MainWindow.Close();
                    App.Current.MainWindow = window;
                    App.Current.MainWindow.Show();
                     }
                else if(user.Role==UserRole.Employee)
                {
                    EmployeeWindow window = new EmployeeWindow();
                    App.Current.MainWindow.Close();
                    App.Current.MainWindow = window;
                    App.Current.MainWindow.Show();
                }
                
             
            }
        }
    }
}
