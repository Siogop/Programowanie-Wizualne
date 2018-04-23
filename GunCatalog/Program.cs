using System;
using GunCatalog.Properties;
using System.Reflection;

namespace Pogodski.GunCatalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var setting = new Settings();
            Console.WriteLine(setting.DAO);

            Pogodski.GunCatalog.BLC.DataAcces dataAcces = new BLC.DataAcces(setting.DAO);
            foreach (var p in dataAcces.Producers)
            {
                Console.WriteLine($"Name: {p.Name} Origin: {p.Country}");
            }
            foreach (var b in dataAcces.Guns)
            {
                Console.WriteLine($"Model: {b.Model} Producer: {b.Producer.Country} Caliber: {b.Caliber} Clip size: {b.ClipSize}");
            }

            Console.ReadKey();
        }
    }
}
