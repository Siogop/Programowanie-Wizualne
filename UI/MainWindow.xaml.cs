using Pogodski.GunCatalog.Interfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.Properties;

namespace Pogodski.GunCatalog.UI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<IGun> Guns { get; set; }
        public ListCollectionView view;
        public MainWindow()
        {
            Settings settings = new Settings();
            Pogodski.GunCatalog.BLC.DataAcces dataAcces = new BLC.DataAcces(settings.DAO);
            Guns = new ObservableCollection<IGun>(dataAcces.Guns);
            InitializeComponent();
            view = (ListCollectionView)CollectionViewSource.GetDefaultView(Guns);
        }
    }
}
