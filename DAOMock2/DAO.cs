using System.Collections.Generic;
using Pogodski.GunCatalog.Interfaces;



namespace Pogodski.GunCatalog.DAOMock2
{
    public class DAO : IDAO
    {
        private List<IProducer> producers;
        private List<IGun> guns;

        public DAO()
        {
            producers = new List<IProducer>()
            {
                new Pogodski.GunCatalog.DAOMock2.BO.Producer {Name="FN_Herstal", Country="Belgium"},
                new Pogodski.GunCatalog.DAOMock2.BO.Producer {Name="Heckler_&_Koch", Country="Germany"},
                new Pogodski.GunCatalog.DAOMock2.BO.Producer {Name="Israel_Weapon_Industries", Country="Israel"},
            };

            guns = new List<IGun>()
            {
                new Pogodski.GunCatalog.DAOMock2.BO.Gun {Model="AWP", Producer=producers[0], Type=Pogodski.GunCatalog.Core.GunType.SniperRifle, Caliber=6, ClipSize=10},
                new Pogodski.GunCatalog.DAOMock2.BO.Gun {Model="P2000", Producer=producers[1], Type=Pogodski.GunCatalog.Core.GunType.Pistol, Caliber=9, ClipSize=10},
                new Pogodski.GunCatalog.DAOMock2.BO.Gun {Model="Negev", Producer=producers[2], Type=Pogodski.GunCatalog.Core.GunType.MachineGun, Caliber=5.56, ClipSize=35},
            };
        }
        public IEnumerable<IGun> GetAllGuns()
        {
            return guns;
        }
        public IEnumerable<IProducer> GetAllProducers()
        {
            return producers;
        }
    }
}
