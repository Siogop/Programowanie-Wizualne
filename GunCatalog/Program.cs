using System;


namespace Pogodski.GunCatalog
{
    public class Program
    {
        static void Main(string[] args)
        {
            Pogodski.GunCatalog.BLC.DataProvider dataProvider = new BLC.DataProvider();
            foreach (var p in dataProvider.Producers)
            {
                Console.WriteLine($"Origin: {p.Country}");
            }
            foreach (var b in dataProvider.Guns)
            {
                Console.WriteLine($"Model: {b.Model} Producer: {b.Producer.Country} DPS: {b.DamagePerSecond} Armor penetration: {b.ArmorPenetration} Clip size: {b.ClipSize}");
            }

            Console.ReadKey();
        }
    }
}
