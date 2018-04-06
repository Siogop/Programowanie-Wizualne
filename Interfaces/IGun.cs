using System;
using Pogodski.GunCatalog.Core;

namespace Pogodski.GunCatalog.Interfaces
{
    public interface IGun
    {
        IProducer Producer { get; set; }
        string Model { get; set; }
        int DamagePerSecond { get; set; }
        int ClipSize { get; set; }
        float ArmorPenetration { get; set; }

        GunType Type { get; set; }

    }
}
