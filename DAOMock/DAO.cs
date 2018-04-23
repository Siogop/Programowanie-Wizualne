using Pogodski.GunCatalog.Interfaces;
using System.Collections.Generic;

namespace Pogodski.GunCatalog.DAOMock2
{
    public class DAO:IDAO
    {
        private List<IProducer> producers;
        private List<IGun> guns;

        public DAO()
        {
            producers = new List<IProducer>()
            {
                new Pogodski.GunCatalog.DAOMock2.BO.Producer {Name="FN_Herstal", Country="Belgium"},
                new Pogodski.GunCatalog.DAOMock2.BO.Producer {Name="Nexter", Country="France"},
                new Pogodski.GunCatalog.DAOMock2.BO.Producer {Name="Israel_Weapon_Industries", Country="Israel"},
            };

            guns = new List<IGun>()
            {
                new Pogodski.GunCatalog.DAOMock2.BO.Gun {Model="Five-Seven", Producer=producers[0], Type=Pogodski.GunCatalog.Core.GunType.Pistol, Caliber=5.7, ClipSize=20},
                new Pogodski.GunCatalog.DAOMock2.BO.Gun {Model="Famas", Producer=producers[1], Type=Pogodski.GunCatalog.Core.GunType.AssaultRifle, Caliber=5.56, ClipSize=25},
                new Pogodski.GunCatalog.DAOMock2.BO.Gun {Model="Galil", Producer=producers[2], Type=Pogodski.GunCatalog.Core.GunType.AssaultRifle, Caliber=7.62, ClipSize=25},
                new Pogodski.GunCatalog.DAOMock2.BO.Gun {Model="P90", Producer=producers[0], Type=Pogodski.GunCatalog.Core.GunType.SubmachineGun, Caliber=5.7, ClipSize=50}
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
