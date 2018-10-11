using Pogodski.GunCatalog.Core;
using Pogodski.GunCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pogodski.GunCatalog.UI.ViewModel
{
    public class GunViewModel : ViewModelBase
    {
        private IGun _gun;
        public IGun Gun
        {
            get => _gun;
        }
        private ObservableCollection<IProducer> _producers;
        public ObservableCollection<IProducer> Producers
        {
            get => _producers;
        }
        public GunViewModel(IGun gun, List<IProducer> producers)
        {
            _gun = gun;
            _producers = new ObservableCollection<IProducer>(producers);
        }
        [Required(ErrorMessage = "Model is required")]
        public string Model
        {
            get => _gun.Model;
            set
            {
                _gun.Model = value;
                Validate();
                OnPropertyChanged("Model");
            }
        }
        [Required(ErrorMessage = "Producer is required")]
        public IProducer Producer
        {
            get => _gun.Producer;
            set
            {
                _gun.Producer = value;
                Validate();
                OnPropertyChanged("Producer");
            }
        }
        [Required(ErrorMessage = "Caliber is required")]
        [Range(0,100, ErrorMessage = "Isn't it an overkill?")]
        public double Caliber
        {
            get => _gun.Caliber;
            set
            {
                _gun.Caliber = value;
                Validate();
                OnPropertyChanged("Caliber");
            }
        }
        [Required(ErrorMessage = "Clipsize is required")]
        [Range(0, 500, ErrorMessage = "Clipsize must be between 0 and 500")]
        public int ClipSize
        {
            get => _gun.ClipSize;
            set
            {
                _gun.ClipSize = value;
                Validate();
                OnPropertyChanged("ClipSize");
            }
        }
        public GunType Type
        {
            get => _gun.Type;
            set
            {
                _gun.Type = value;
                Validate();
                OnPropertyChanged("Type");
            }
        }
        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);

            foreach (var kv in _errors.ToList())
            {
                if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                {
                    _errors.Remove(kv.Key);
                    OnErrorChanged(kv.Key);
                }
            }

            var q = from e in validationResults
                    from m in e.MemberNames
                    group e by m into g
                    select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);
                OnErrorChanged(prop.Key);
            }
        }
    }
}
