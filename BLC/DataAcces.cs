﻿using Pogodski.GunCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Pogodski.GunCatalog.BLC
{
    public class DataAcces
    {
        public IDAO DAO { get; set; }
        public IEnumerable<IGun> Guns
        {
            get { return DAO.GetAllGuns(); }
        }
        public IEnumerable<IProducer> Producers
        {
            get { return DAO.GetAllProducers(); }
        }
        public DataAcces(string setting)
        {
            var dllFile = new FileInfo(@"..\..\..\Libraries\" + setting);
            //Console.WriteLine(dllFile.FullName);
            Assembly a = Assembly.UnsafeLoadFrom(dllFile.FullName);
            Type type = null;
            foreach (var t in a.GetTypes())
            {
                if (t.GetInterface("Pogodski.GunCatalog.Interfaces.IDAO") != null)
                {

                    type = t;
                }
            }
            if (type != null)
            {
                DAO = (Interfaces.IDAO)Activator.CreateInstance(type, null);
            }
        }
    }
}
