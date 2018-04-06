using Pogodski.GunCatalog.Interfaces;
using System.Collections.Generic;

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
        public DataAcces()
        {
            DAO = (IDAO)new DAOMock.DAO();
        }
    }
}
