using System.Collections.Generic;
using Pogodski.GunCatalog.Interfaces;



namespace Pogodski.GunCatalog.DAOMock2
{
    public class DAO : IDAO
    {
        private List<IProducer> _producers;
        private List<IGun> _guns;

        public DAO()
        {
            _producers = new List<IProducer>()
            {
                new Pogodski.GunCatalog.DAOMock2.BO.Producer {Name="FN_Herstal", Country="Belgium"},
                new Pogodski.GunCatalog.DAOMock2.BO.Producer {Name="Heckler_&_Koch", Country="Germany"},
                new Pogodski.GunCatalog.DAOMock2.BO.Producer {Name="Israel_Weapon_Industries", Country="Israel"},
            };

            _guns = new List<IGun>()
            {
                new Pogodski.GunCatalog.DAOMock2.BO.Gun {Model="AWP", Producer=_producers[0], Type=Pogodski.GunCatalog.Core.GunType.SniperRifle, Caliber=6, ClipSize=10},
                new Pogodski.GunCatalog.DAOMock2.BO.Gun {Model="P2000", Producer=_producers[1], Type=Pogodski.GunCatalog.Core.GunType.Pistol, Caliber=9, ClipSize=10},
                new Pogodski.GunCatalog.DAOMock2.BO.Gun {Model="Negev", Producer=_producers[2], Type=Pogodski.GunCatalog.Core.GunType.MachineGun, Caliber=5.56, ClipSize=35},
            };
        }
        public IEnumerable<IGun> GetAllGuns()
        {
            return _guns;
        }
        public IEnumerable<IProducer> GetAllProducers()
        {
            return _producers;
        }
        public IGun AddNewGun()
        {
            IGun gun = new BO.Gun();
            gun.Model = "";
            gun.Caliber = 0.0f;
            gun.ClipSize = 0;
            return gun;
        }
        public IProducer AddNewProducer()
        {
            IProducer producer = new BO.Producer();
            producer.Name = "";
            producer.Country = "";
            return producer;
        }
        public void SaveGun(IGun gun)
        {
            _guns.Add(gun);
        }
        public void SaveGun(IGun gun, int index)
        {
            _guns[index] = gun;
        }
        public void SaveProducer(IProducer producer)
        {
            _producers.Add(producer);
        }
        public void SaveProducer(IProducer producer, int index)
        {
            _producers[index] = producer;
        }
    }
}
