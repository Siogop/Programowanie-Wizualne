using System;

namespace Pogodski.GunCatalog.Interfaces
{
    public interface IProducer
    {
        string Name { get; set; }
        string Country { get; set; }
    }
}
