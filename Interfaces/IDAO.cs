using System;
using System.Collections.Generic;

namespace Pogodski.GunCatalog.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IGun> GetAllGuns();
        IEnumerable<IProducer> GetAllProducers();
        IGun AddNewGun();
        IProducer AddNewProducer();
        void SaveGun(IGun gun);
        void SaveGun(IGun gun, int index);
        void SaveProducer(IProducer producer);
        void SaveProducer(IProducer producer, int index);
    }
}
