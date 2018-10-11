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
            GetAllGuns();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Guns);
            _filterDataCommand = new RelayCommand(param => this.FilterData());
            _addNewGunCommand = new RelayCommand(param => this.AddNewGun(), param => this.CanAddNewGun());
            _saveGunCommand = new RelayCommand(param => this.SaveGun(), param => this.CanSaveGun());

            EditedGun = Guns[0];
            SelectedGun = EditedGun;
        }

        private void GetAllGuns()
        {
            Properties.Settings properties = new Properties.Settings();
            BLC.DataAcces dataAcces = null;
            try
            {
                dataAcces = new BLC.DataAcces(properties.DAO);
            }
            catch (NullReferenceException) { Console.WriteLine("Creating DAO Failed!"); }

            List<IProducer> producers = (List<IProducer>)dataAcces.Producers;
            foreach (var gun in dataAcces.Guns)
            {
                Guns.Add(new GunViewModel(gun, producers));
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

        public RelayCommand SaveGunCommand
        {
            get => _saveGunCommand;
        }

        private void SaveGun()
        {
            if (!Guns.Contains(EditedGun))
            {
                Guns.Add(EditedGun);
                EditedGun = null;
            }
            EditedGun = null;
        }

        private bool CanSaveGun()
        {
            if (EditedGun != null && !EditedGun.HasErrors)
            {
                return true;
            }
            return false;
        }

        private RelayCommand _addNewGunCommand;

        public RelayCommand AddNewGunCommand
        {
            get => _addNewGunCommand;
        }

        private void AddNewGun()
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
