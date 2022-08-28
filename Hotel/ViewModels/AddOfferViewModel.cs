using Hotel.Models;
using Hotel.Repositories;
using Hotel.Utils;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    class AddOfferViewModel: NotifyPropertyChangedUtil
    {
        public int id;
        public bool isEdit = false;

        public AddOfferViewModel()
        {
            RoomRepository roomRepository = new RoomRepository();
            Rooms = new ObservableCollection<Room>(roomRepository.GetRooms());
            CheckIn = DateTime.Now;
            checkOut = DateTime.Now;
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

        private string offerName;
        public string OfferName
        {
            get
            {
                return offerName;
            }
            set
            {
                offerName = value;
                NotifyPropertyChanged("OfferName");
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

                NotifyPropertyChanged("CheckOut");
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
        private ICommand addOfferCommand;
        public ICommand AddOfferCommand
        {
            get
            {
                if (addOfferCommand == null)
                {
                    addOfferCommand = new RelayCommand(AddOfferFunction, param => CanExecuteCommand);
                }
                return addOfferCommand;
            }
        }

        public void AddOfferFunction(object param)
        {
            OfferRepository offerRepository = new OfferRepository();


        


            if (isEdit == false)
            {
                offerRepository.AddOffer(offerName, int.Parse(Price), checkIn, checkOut, selectedItemList, false);
            }
            else
            {
                offerRepository.UpdateOffer(id,offerName, int.Parse(Price), checkIn, checkOut, selectedItemList, false);
            }



            ServicesWindow startWindow = new ServicesWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            App.Current.MainWindow.Show();
        }

       
    }
}
