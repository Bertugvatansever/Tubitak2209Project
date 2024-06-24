using Gat.BusinessLayer.Abstract;
using Gat.Core.Entity;
using Gat.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Concrete
{
    public class AdressService : IAdressService
    {
        private IAdressRepository _adresRepository;

        public AdressService(IAdressRepository adresRepository)
        {
            _adresRepository = adresRepository;
        }

        public void Add(Adress item)
        {
            _adresRepository.Add(item);
        }

        public void Delete(int id)
        {
            _adresRepository.Delete(id);
        }

        public Adress GetByID(int id)
        {
            return _adresRepository.Get(id);
        }

        public List<Adress> GetList()
        {
            return _adresRepository.GetAll();   
        }

        public void Update(Adress item)
        {
            _adresRepository.Update(item);  
        }
    }
}
