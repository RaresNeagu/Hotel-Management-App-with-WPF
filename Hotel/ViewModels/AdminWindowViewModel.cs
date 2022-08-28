using Hotel.Models;
using Hotel.Repositories;
using Hotel.Utils;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    class AdminWindowViewModel: NotifyPropertyChangedUtil
    {
        private RoomRepository roomRepostitory;

        public AdminWindowViewModel()
        {
            roomRepostitory = new RoomRepository();

            Rooms = new ObservableCollection<Room>(roomRepostitory.GetRooms());
           
        }


       

        private Room selectedItemList;
        public Room SelectedItemList
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

        private ObservableCollection<Room> rooms;
        public ObservableCollection<Room> Rooms
        {
            get
            {
                return rooms;
            }
            set
            {
                rooms = value;
                NotifyPropertyChanged("Rooms");
            }
        }


        
        private bool CanExecuteCommand { get; set; } = false;
        private ICommand deleteRoomCommand;
        public ICommand DeleteRoomCommand
        {
            get
            {
                if (deleteRoomCommand == null)
                {
                    deleteRoomCommand = new RelayCommand(DeleteRoom, param => CanExecuteCommand);
                }
                return deleteRoomCommand;
            }
        }

        public void DeleteRoom(object param)
        {
            RoomRepository roomRepository = new RoomRepository();
            roomRepository.DeleteRoom(selectedItemList.RoomId, true);
            Rooms.Remove(selectedItemList);
        }

        private ICommand addRoomCommand;
        public ICommand AddRoomCommand
        {
            get
            {
                if (addRoomCommand == null)
                {
                    addRoomCommand = new RelayCommand(AddRoom, param => true);
                }
                return addRoomCommand;
            }
        }

        public void AddRoom(object param)
        {
          
            AddRoom startWindow = new AddRoom();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            App.Current.MainWindow.Show();
            
        }

        private ICommand editRoomCommand;
        public ICommand EditRoomCommand
        {
            get
            {
                if (editRoomCommand == null)
                {
                    editRoomCommand = new RelayCommand(EditRoom, param => CanExecuteCommand);
                }
                return editRoomCommand;
            }
        }

        public void EditRoom(object param)
        {
            AddRoom startWindow = new AddRoom();
            startWindow.AddRoomButton.Content = "Edit Room";
            AddRoomViewModel addRoomViewModel = new AddRoomViewModel();
            addRoomViewModel.RoomName = SelectedItemList.RoomName;
            addRoomViewModel.PricePerNight = selectedItemList.PricePerNight.ToString();
            addRoomViewModel.MaxOccupancy = selectedItemList.MaxOccupancy.ToString();
            addRoomViewModel.Facilities = selectedItemList.Facilities.ToString();
            addRoomViewModel.id = selectedItemList.RoomId;
            addRoomViewModel.isEdit = true;
            startWindow.DataContext = addRoomViewModel;
            startWindow.Title = "EditRoom";
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            App.Current.MainWindow.Show();
            
        }

        private ICommand servicesCommand;
        public ICommand ServicesCommand
        {
            get
            {
                if (servicesCommand == null)
                {
                    servicesCommand = new RelayCommand(ServicesFunction, param => true);
                }
                return servicesCommand;
            }
        }

        public void ServicesFunction(object param)
        {
            ServicesView startWindow = new ServicesView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            App.Current.MainWindow.Show();

        }

        private ICommand offersCommand;
        public ICommand OffersCommand
        {
            get
            {
                if (offersCommand == null)
                {
                    offersCommand = new RelayCommand(OffersFunction, param => true);
                }
                return offersCommand;
            }
        }

        public void OffersFunction(object param)
        {
            ServicesWindow startWindow = new ServicesWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            App.Current.MainWindow.Show();

        }
    }
}
