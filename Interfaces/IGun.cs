using System;
using Pogodski.GunCatalog.Core;

namespace Pogodski.GunCatalog.Interfaces
{
    public interface IGun
    {
        IProducer Producer { get; set; }
        string Model { get; set; }
        double Caliber { get; set; }
        int ClipSize { get; set; }

        GunType Type { get; set; }

    }
}
