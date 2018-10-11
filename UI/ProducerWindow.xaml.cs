using Pogodski.GunCatalog.Interfaces;
using Pogodski.GunCatalog.UI.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pogodski.GunCatalog.UI
{
    /// <summary>
    /// Logika interakcji dla klasy ProducerWindow.xaml
    /// </summary>
    public partial class ProducerWindow : Window
    {
        public ObservableCollection<IProducer> Producers { get; set; }
        public ListCollectionView view;
        public ProducerWindow()
        {
            var setting = new Settings();
            Pogodski.GunCatalog.BLC.DataAcces dataAcces = new BLC.DataAcces(setting.DAO);
            Producers = new ObservableCollection<IProducer>(dataAcces.Producers);
            InitializeComponent();
            view = (ListCollectionView)CollectionViewSource.GetDefaultView(Producers);
        }
    }
}
