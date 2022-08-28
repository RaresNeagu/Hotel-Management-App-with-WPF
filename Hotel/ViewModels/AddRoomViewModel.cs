using Hotel.Models;
using Hotel.Repositories;
using Hotel.Utils;
using Hotel.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModels
{
    class AddRoomViewModel: NotifyPropertyChangedUtil
    {
        public int id;
        public bool isEdit = false;
        private string roomName;
        public string RoomName
        {
            get
            {
                return roomName;
            }
            set
            {
                roomName = value;
                NotifyPropertyChanged("RoomName");
            }
        }

        private bool validMaxOccupancy { get; set; } = false;
        private string maxOccupancy;
        public string MaxOccupancy
        {
            get
            {
                return maxOccupancy;
            }
            set
            {
                maxOccupancy = value;
                Regex regex = new Regex(@"[0-9]*");
                if (regex.Match(maxOccupancy) == Match.Empty)
                {
                    ErrorMessage = "INVALID MAX OCCUPANCY";
                    validMaxOccupancy = false;
                    CanExecuteCommand = false;
                }
                else
                {
                    if (ErrorMessage == "INVALID MAX OCCUPANCY")
                    {
                        ErrorMessage = "";
                    }
                    validMaxOccupancy = true;
                    CanExecuteCommand = true;
                }
                NotifyPropertyChanged("MaxOccupancy");
            }
        }

        private bool validPrice { get; set; } = false;
        private string pricePerNight;
        public string PricePerNight
        {
            get
            {
                return pricePerNight;
            }
            set
            {
                pricePerNight = value;
                Regex regex = new Regex(@"[0-9]*");
                if (regex.Match(pricePerNight) == Match.Empty)
                {
                    ErrorMessage = "INVALID PRICE PER NIGHT";
                    validPrice = false;
                    CanExecuteCommand = false;
                }
                else
                {
                    if (ErrorMessage == "INVALID PRICE PER NIGHT")
                    {
                        ErrorMessage = "";
                    }
                    validPrice = true;
                    CanExecuteCommand = true;
                }
                NotifyPropertyChanged("PricePerNight");
            }
        }

       
        private string photo1;
        public string Photo1
        {
            get
            {
                return photo1;
            }
            set
            {
                photo1 = value;
                NotifyPropertyChanged("Photo1");
            }
        }

        private string photo2;
        public string Photo2
        {
            get
            {
                return photo2;
            }
            set
            {
                photo2 = value;
                NotifyPropertyChanged("Photo2");
            }
        }

        private string facilities;
        public string Facilities
        {
            get
            {
                return facilities;
            }
            set
            {
                facilities = value;
                NotifyPropertyChanged("Facilities");
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

        private ICommand photo1Command;
        public ICommand Photo1Command
        {
            get
            {
                if (photo1Command == null)
                {
                    photo1Command = new RelayCommand(Photo1Function, param => true);
                }
                return photo1Command;
            }
        }

        private ICommand photo2Command;
        public ICommand Photo2Command
        {
            get
            {
                if (photo2Command == null)
                {
                    photo2Command = new RelayCommand(Photo2Function, param => true);
                }
                return photo2Command;
            }
        }


        private bool CanExecuteCommand { get; set; } = false;
        private ICommand addRoomCommand;
        public ICommand AddRoomCommand
        {
            get
            {
                if (addRoomCommand == null)
                {
                    addRoomCommand = new RelayCommand(AddRoomFunction, param => CanExecuteCommand);
                }
                return addRoomCommand;
            }
        }

        public void AddRoomFunction(object param)
        {
            RoomRepository roomRepository = new RoomRepository();
           
            
                List<RoomImage> images = new List<RoomImage>()
            {
                new RoomImage
                {
                    Deleted=false,
                    Image=ImageConvertor.ConvertImageToBytes(Photo1)
                },
                new RoomImage
                {
                    Deleted=false,
                    Image=ImageConvertor.ConvertImageToBytes(Photo2)
                }
            };

                List<Facility> facilities = new List<Facility>()
            {
                new Facility
                {
                    Name=Facilities,
                    Deleted=false
                }
            };


            if (isEdit == false)
            {
                roomRepository.AddRoom(RoomName, int.Parse(PricePerNight), int.Parse(MaxOccupancy), facilities, images, false);
            }
            else
            {
                roomRepository.UpdateRoom(id,RoomName, int.Parse(PricePerNight), int.Parse(MaxOccupancy), facilities, images, false);
            }
          
            

            AdminWindow startWindow = new AdminWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            App.Current.MainWindow.Show();
        }

        public void Photo1Function(object param)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Photo1 = openFileDialog.FileName;
            }
        }

        public void Photo2Function(object param)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Photo2 = openFileDialog.FileName;
            }
        }
    }
}
