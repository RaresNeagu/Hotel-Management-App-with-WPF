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
    class OffersViewModel: NotifyPropertyChangedUtil
    {
        public OffersViewModel()
        {

            OfferRepository offerRepository = new OfferRepository();
            Offers = new ObservableCollection<Offer>(offerRepository.GetOffers());
        }


       

        private Offer selectedItemList;
        public Offer SelectedItemList
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

        private ObservableCollection<Offer> offers;
        public ObservableCollection<Offer> Offers
        {
            get
            {
                return offers;
            }
            set
            {
                offers = value;
                NotifyPropertyChanged("Offers");
            }
        }



        private bool CanExecuteCommand { get; set; } = false;
        private ICommand deleteOfferCommand;
        public ICommand DeleteOfferCommand
        {
            get
            {
                if (deleteOfferCommand == null)
                {
                    deleteOfferCommand = new RelayCommand(DeleteOffer, param => CanExecuteCommand);
                }
                return deleteOfferCommand;
            }
        }

        public void DeleteOffer(object param)
        {
            OfferRepository offerRepository = new OfferRepository();
            offerRepository.DeleteOffer(selectedItemList.OfferId, true);
            Offers.Remove(selectedItemList);
        }

        private ICommand addOfferCommand;
        public ICommand AddOfferCommand
        {
            get
            {
                if (addOfferCommand == null)
                {
                    addOfferCommand = new RelayCommand(AddOffer, param => true);
                }
                return addOfferCommand;
            }
        }

        public void AddOffer(object param)
        {

            AddOffer startWindow = new AddOffer();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            App.Current.MainWindow.Show();

        }

        private ICommand editOfferCommand;
        public ICommand EditOfferCommand
        {
            get
            {
                if (editOfferCommand == null)
                {
                    editOfferCommand = new RelayCommand(EditOffer, param => CanExecuteCommand);
                }
                return editOfferCommand;
            }
        }

        public void EditOffer(object param)
        {
            AddOffer startWindow = new AddOffer();
            startWindow.AddOfferButton.Content = "Edit Offer";
            AddOfferViewModel addOfferViewModel = new AddOfferViewModel();
            addOfferViewModel.OfferName = SelectedItemList.OfferName;
            addOfferViewModel.Price = selectedItemList.Price.ToString();
            addOfferViewModel.CheckIn = selectedItemList.CheckIn;
            addOfferViewModel.CheckOut = selectedItemList.CheckOut;
            addOfferViewModel.SelectedItemList = selectedItemList.Room;
            addOfferViewModel.id = selectedItemList.OfferId;
            addOfferViewModel.isEdit = true;
            startWindow.DataContext = addOfferViewModel;
            startWindow.Title = "EditOffer";
            App.Current.MainWindow.Close();
            App.Current.MainWindow = startWindow;
            App.Current.MainWindow.Show();

        }
    }
}
