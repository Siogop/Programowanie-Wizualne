using System;


namespace Pogodski.GunCatalog
{
    public class Program
    {
        static void Main(string[] args)
        {
            Pogodski.GunCatalog.BLC.DataAcces dataAcces = new BLC.DataAcces();
            foreach (var p in dataAcces.Producers)
            {
                Console.WriteLine($"Origin: {p.Country}");
            }
            foreach (var b in dataAcces.Guns)
            {
                Console.WriteLine($"Model: {b.Model} Producer: {b.Producer.Country} DPS: {b.DamagePerSecond} Armor penetration: {b.ArmorPenetration} Clip size: {b.ClipSize}");
            }

            Console.ReadKey();
        }
    }
}
