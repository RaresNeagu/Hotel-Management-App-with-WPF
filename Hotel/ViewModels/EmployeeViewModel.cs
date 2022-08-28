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
    class EmployeeViewModel: NotifyPropertyChangedUtil
    {
        public EmployeeViewModel()
        {

            ReservationRepository servicesRepository = new ReservationRepository();
            Reservations = new ObservableCollection<Reservation>(servicesRepository.GetReservations());
            ReservationStatus = new ObservableCollection<ReservationStatus>();
            ReservationStatus.Add(Utils.ReservationStatus.Activ);
            ReservationStatus.Add(Utils.ReservationStatus.Payed);
            ReservationStatus.Add(Utils.ReservationStatus.Cancelled);
            
        }


        private ReservationStatus status;
        public ReservationStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                CanExecuteCommand = true;
                NotifyPropertyChanged("Status");
            }
        }

        private ObservableCollection<ReservationStatus> reservationStatus;
        public ObservableCollection<ReservationStatus> ReservationStatus
        {
            get
            {
                return reservationStatus;
            }
            set
            {
                reservationStatus = value;
                NotifyPropertyChanged("ReservationStatus");
            }
        }

        private Reservation selectedItemList;
        public Reservation SelectedItemList
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

        private ObservableCollection<Reservation> reservations;
        public ObservableCollection<Reservation> Reservations
        {
            get
            {
                return reservations;
            }
            set
            {
                reservations = value;
                NotifyPropertyChanged("Reservations");
            }
        }



        private bool CanExecuteCommand { get; set; } = false;
        private ICommand setStatusCommand;
        public ICommand SetStatusCommand
        {
            get
            {
                if (setStatusCommand == null)
                {
                    setStatusCommand = new RelayCommand(SetStatus, param => CanExecuteCommand);
                }
                return setStatusCommand;
            }
        }

        public void SetStatus(object param)
        {
            ReservationRepository reservationRepository = new ReservationRepository();
            reservationRepository.UpdateReservation(selectedItemList.ReservationId, selectedItemList.Services, selectedItemList.Price, false, selectedItemList.Room,Status, selectedItemList.CheckIn, selectedItemList.CheckOut, SelectedItemList.User);
            Reservations = new ObservableCollection<Reservation>(reservationRepository.GetReservations());
        }

       
       
    }
}
