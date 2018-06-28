using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pogodski.GunCatalog.UI.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region INotifyDataErrorInfo
        public bool HasErrors => _errors.Count > 0;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            return null;
        }
        #endregion

        protected Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        protected void RemoveErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
            }
        }

        protected void AddError(string propertyName, string errorMsg)
        {
            List<string> propertyErrors = null;
            if (_errors.ContainsKey(propertyName))
            {
                propertyErrors = _errors[propertyName];
            }
            else
            {
                propertyErrors = new List<string>();
                _errors.Add(propertyName, propertyErrors);
            }
            propertyErrors.Add(errorMsg);
        }

        protected void OnErrorChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
