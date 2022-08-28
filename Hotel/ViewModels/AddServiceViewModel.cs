using Hotel.Repositories;
using Hotel.Utils;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    class AddServiceViewModel: NotifyPropertyChangedUtil
    {
        public int id;
        public bool isEdit = false;

       

       

        private string serviceName;
        public string ServiceName
        {
            get
            {
                return serviceName;
            }
            set
            {
                serviceName = value;
                NotifyPropertyChanged("ServiceName");
            }
        }
       

        private bool validPrice { get; set; } = false;
        private string price;
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                Regex regex = new Regex(@"[0-9]*");
                if (regex.Match(price) == Match.Empty)
                {
                    ErrorMessage = "INVALID PRICE ";
                    validPrice = false;
                    CanExecuteCommand = false;
                }
                else
                {
                    if (ErrorMessage == "INVALID PRICE")
                    {
                        ErrorMessage = "";
                    }
                    validPrice = true;
                    CanExecuteCommand = true;
                }
                NotifyPropertyChanged("Price");
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




        private bool CanExecuteCommand { get; set; } = false;
        private ICommand addServiceCommand;
        public ICommand AddServiceCommand
        {
            get
            {
                if (addServiceCommand == null)
                {
                    addServiceCommand = new RelayCommand(AddServiceFunction, param => CanExecuteCommand);
                }
                return addServiceCommand;
            }
        }

        public void AddServiceFunction(object param)
        {
            ServicesRepository serviceRepository = new ServicesRepository();





            if (isEdit == false)
            {
                serviceRepository.AddService(ServiceName, int.Parse(Price), false);
            }
            else
            {
                serviceRepository.UpdateService(id, ServiceName, int.Parse(Price), false);
            }



            ServicesView startWindow = new ServicesView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            App.Current.MainWindow.Show();
        }
    }
}
