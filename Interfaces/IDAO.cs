using System;
using System.Collections.Generic;

namespace Pogodski.GunCatalog.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IGun> GetAllGuns();
        IEnumerable<IProducer> GetAllProducers();
    }
}
