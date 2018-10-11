using Pogodski.GunCatalog.Interfaces;

namespace Pogodski.GunCatalog.DAOMock2.BO
{
    public class Gun : IGun
    {
        public IProducer Producer { get; set; }
        public string Model { get; set; }
        public double Caliber { get; set; }
        public int ClipSize { get; set; }
        public Pogodski.GunCatalog.Core.GunType Type { get; set; }
    }
}
