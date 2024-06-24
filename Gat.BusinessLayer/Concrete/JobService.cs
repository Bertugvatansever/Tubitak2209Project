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
    public class JobService : IJobService
    {
        private IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public void Add(Job item)
        {
            _jobRepository.Add(item);   
        }

        public void Delete(int id)
        {
            _jobRepository.Delete(id);
        }

        public Job GetByID(int id)
        {
            return _jobRepository.Get(id);
        }

        public List<Job> GetJobsByUserId(int id)
        {
            return _jobRepository.GetJobsByUserId(id);
        }

        public List<Job> GetList()
        {
            return _jobRepository.GetAll();
        }

        public void Update(Job item)
        {
            _jobRepository.Update(item);
        }
    }
}
