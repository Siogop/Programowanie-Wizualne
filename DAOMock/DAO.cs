using Pogodski.GunCatalog.Interfaces;
using System.Collections.Generic;

namespace Pogodski.GunCatalog.DAOMock
{
    public class DAO:IDAO
    {
        private List<IProducer> producers;
        private List<IGun> guns;

        public DAO()
        {
            producers = new List<IProducer>()
            {
                new Pogodski.GunCatalog.DAOMock.BO.Producer {Country="Italy"},
                new Pogodski.GunCatalog.DAOMock.BO.Producer {Country="Poland"},
                new Pogodski.GunCatalog.DAOMock.BO.Producer {Country="USA"},
                new Pogodski.GunCatalog.DAOMock.BO.Producer {Country="France"}
            };

            guns = new List<IGun>()
            {
                new Pogodski.GunCatalog.DAOMock.BO.Gun {Model="pistolecik", Producer=producers[0], Type=Pogodski.GunCatalog.Core.GunType.Pistol, DamagePerSecond=180, ArmorPenetration=50, ClipSize=10},
                new Pogodski.GunCatalog.DAOMock.BO.Gun {Model="karabinek", Producer=producers[1], Type=Pogodski.GunCatalog.Core.GunType.AssaultRifle, DamagePerSecond=300, ArmorPenetration=80, ClipSize=25},
                new Pogodski.GunCatalog.DAOMock.BO.Gun {Model="innyKarabinek", Producer=producers[2], Type=Pogodski.GunCatalog.Core.GunType.AssaultRifle, DamagePerSecond=280, ArmorPenetration=75, ClipSize=30},
                new Pogodski.GunCatalog.DAOMock.BO.Gun {Model="strzelba", Producer=producers[2], Type=Pogodski.GunCatalog.Core.GunType.Shotgun, DamagePerSecond=400, ArmorPenetration=75, ClipSize=7}
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
