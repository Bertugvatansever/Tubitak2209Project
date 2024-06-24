using Gat.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gat.BusinessLayer.Abstract
{
    public interface IJobService
    {
        Job GetByID(int id);
        List<Job> GetList();
        void Add(Job item);
        void Update(Job item);
        void Delete(int id);
        List<Job> GetJobsByUserId(int id);
    }
}
