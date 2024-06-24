using Gat.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Abstract
{
    public interface IAdressService
    {
        Adress GetByID(int id);
        List<Adress> GetList();
        void Add(Adress item);
        void Update(Adress item);
        void Delete(int id);
    }
}
