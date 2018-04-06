using Pogodski.GunCatalog.Interfaces;

namespace Pogodski.GunCatalog.DAOMock.BO
{
    public class Gun : IGun
    {
        public IProducer Producer { get; set; }
        public string Model { get; set; }
        public int DamagePerSecond { get; set; }
        public int ClipSize { get; set; }
        public float ArmorPenetration { get; set; }
        public Pogodski.GunCatalog.Core.GunType Type { get; set; }
    }
}
