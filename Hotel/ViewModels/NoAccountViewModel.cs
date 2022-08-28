using Hotel.Models;
using Hotel.Repositories;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    class NoAccountViewModel: NotifyPropertyChangedUtil
    {
        private RoomRepository roomRepostitory;

        public NoAccountViewModel()
        {
            roomRepostitory = new RoomRepository();

            Rooms = new ObservableCollection<Room>(roomRepostitory.GetRooms());
            checkIn = DateTime.Now;
            checkOut = DateTime.Now;
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
                CanExecuteCommand = true;
                NotifyPropertyChanged("Rooms");
            }
        }

        private DateTime checkIn;
        public DateTime CheckIn
        {
            get
            {
                return checkIn;
            }
            set
            {
                checkIn = value;
                CanExecuteCommand = true;
                NotifyPropertyChanged("CheckIn");
            }
        }

        private DateTime checkOut;
        public DateTime CheckOut
        {
            get
            {
                return checkOut;
            }
            set
            {
                checkOut = value;
                CanExecuteCommand = true;
                NotifyPropertyChanged("CheckOut");
            }
        }



        private bool CanExecuteCommand { get; set; } = false;
        private ICommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new RelayCommand(Search, param => CanExecuteCommand);
                }
                return searchCommand;
            }
        }

        public void Search(object param)
        {
            RoomRepository roomRepository = new RoomRepository();
            Rooms = new ObservableCollection<Room>(roomRepository.GetRoomsBetweenDates(CheckIn, CheckOut));
        }

     
    }
}
