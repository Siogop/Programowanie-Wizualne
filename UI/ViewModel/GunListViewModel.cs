using Pogodski.GunCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Pogodski.GunCatalog.UI.ViewModel
{
    public class GunListViewModel : ViewModelBase
    {
        public ObservableCollection<GunViewModel> Guns { get; set; } = new ObservableCollection<GunViewModel>();
        private ListCollectionView _view;
        Properties.Settings properties = new Properties.Settings();

        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand { get => _filterDataCommand; }
        public string FilterValue { get; set; }

        public GunListViewModel()
        {
            OnPropertyChanged("Guns");
            GetAllBeers();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Guns);
            _filterDataCommand = new RelayCommand(param => this.FilterData());
            _addNewGunCommand = new RelayCommand(param => this.AddNewBeer(), param => this.CanAddNewGun());
            _saveGunCommand = new RelayCommand(param => this.SaveBeer(), param => this.CanSaveBeer());

            EditedGun = Guns[0];
            SelectedGun = EditedGun;
        }

        private void GetAllBeers()
        {
            Properties.Settings properties = new Properties.Settings();
            BLC.DataAcces dataAcces = null;
            try
            {
                dataAcces = new BLC.DataAcces(properties.DAO);
            }
            catch (NullReferenceException) { Console.WriteLine("Creating DAO Failed!"); }

            List<IProducer> producers = (List<IProducer>)dataAcces.Producers;
            foreach (var beer in dataAcces.Guns)
            {
                Guns.Add(new GunViewModel(beer, producers));
            }
        }

        private void FilterData()
        {
            if (string.IsNullOrEmpty(FilterValue))
            {
                _view.Filter = null;
            }
            else
            {
                _view.Filter = (b) => ((GunViewModel)b).Model.Contains(FilterValue);
            }
        }

        private GunViewModel _editedGun;
        public GunViewModel EditedGun
        {
            get => _editedGun;
            set
            {
                _editedGun = value;
                OnPropertyChanged(nameof(EditedGun));
            }
        }

        private GunViewModel _selectedGun;
        public GunViewModel SelectedGun
        {
            get => _selectedGun;
            set
            {
                _selectedGun = value;
                EditedGun = value;
                OnPropertyChanged(nameof(EditedGun));
            }
        }

        private RelayCommand _saveGunCommand;

        public RelayCommand SaveBeerCommand
        {
            get => _saveGunCommand;
        }

        private void SaveBeer()
        {
            if (!Guns.Contains(EditedGun))
            {
                Guns.Add(EditedGun);
                EditedGun = null;
            }
            EditedGun = null;
        }

        private bool CanSaveBeer()
        {
            if (EditedGun != null && !EditedGun.HasErrors)
            {
                return true;
            }
            return false;
        }

        private RelayCommand _addNewGunCommand;

        public RelayCommand AddNewBeerCommand
        {
            get => _addNewGunCommand;
        }

        private void AddNewBeer()
        {
            Properties.Settings properties = new Properties.Settings();
            BLC.DataAcces dataAcces = null;
            try
            {
                dataAcces = new BLC.DataAcces(properties.DAO);
            }
            catch (NullReferenceException) { Console.WriteLine("Creating DAO Failed!"); }

            IGun newGun = dataAcces.AddGun();
            EditedGun = new GunViewModel(newGun, (List<IProducer>)dataAcces.Producers);
            EditedGun.Validate();
        }

        private bool CanAddNewGun()
        {
            if (EditedGun != null)
                return false;
            return true;
        }

    }
}
