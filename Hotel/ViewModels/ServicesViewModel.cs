using Hotel.Models;
using Hotel.Repositories;
using Hotel.Utils;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    class ServicesViewModel: NotifyPropertyChangedUtil
    {
        public ServicesViewModel()
        {

            ServicesRepository servicesRepository = new ServicesRepository();
            Services = new ObservableCollection<Service>(servicesRepository.GetServices());
        }




        private Service selectedItemList;
        public Service SelectedItemList
        {
            get
            {
                return selectedItemList;
            }
            set
            {
                selectedItemList = value;
                CanExecuteCommand = true;
                NotifyPropertyChanged("SelectedItemList");
            }
        }

        private ObservableCollection<Service> services;
        public ObservableCollection<Service> Services
        {
            get
            {
                return services;
            }
            set
            {
                services = value;
                NotifyPropertyChanged("Services");
            }
        }



        private bool CanExecuteCommand { get; set; } = false;
        private ICommand deleteServiceCommand;
        public ICommand DeleteServiceCommand
        {
            get
            {
                if (deleteServiceCommand == null)
                {
                    deleteServiceCommand = new RelayCommand(DeleteService, param => CanExecuteCommand);
                }
                return deleteServiceCommand;
            }
        }

        public void DeleteService(object param)
        {
            ServicesRepository servicesRepository = new ServicesRepository();
            servicesRepository.DeleteService(selectedItemList.ServiceId, true);
            Services.Remove(selectedItemList);
        }

        private ICommand addServiceCommand;
        public ICommand AddServiceCommand
        {
            get
            {
                if (addServiceCommand == null)
                {
                    addServiceCommand = new RelayCommand(AddService, param => true);
                }
                return addServiceCommand;
            }
        }

        public void AddService(object param)
        {

            AddService startWindow = new AddService();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            App.Current.MainWindow.Show();

        }

        private ICommand editServiceCommand;
        public ICommand EditServiceCommand
        {
            get
            {
                if (editServiceCommand == null)
                {
                    editServiceCommand = new RelayCommand(EditService, param => CanExecuteCommand);
                }
                return editServiceCommand;
            }
        }

        public void EditService(object param)
        {
            AddService startWindow = new AddService();
            startWindow.AddServiceButton.Content = "Edit Service";
            AddServiceViewModel addServiceViewModel = new AddServiceViewModel();
            addServiceViewModel.ServiceName = SelectedItemList.ServiceName;
            addServiceViewModel.Price = selectedItemList.PricePerDay.ToString();
            
            addServiceViewModel.id = selectedItemList.ServiceId;
            addServiceViewModel.isEdit = true;
            startWindow.DataContext = addServiceViewModel;
            startWindow.Title = "EditService";
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            App.Current.MainWindow.Show();

        }
    }
}
