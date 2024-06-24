using Gat.BusinessLayer.Abstract;
using Gat.BusinessLayer.Concrete;
using Gat.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class JobController : Controller
    {
        
        private IHttpContextAccessor _httpContextAccessor;
        private IJobService _jobService;
        private IWebHostEnvironment _hostingEnvironment;

        public JobController( IHttpContextAccessor httpContextAccessor, IJobService jobService, IWebHostEnvironment hostingEnvironment)
        {
            this._jobService = jobService;
            this._httpContextAccessor = httpContextAccessor;
            this._hostingEnvironment = hostingEnvironment;
        }

        //Gat sitesi için olan actionlar

        public IActionResult Index()
        {
            var jobList = _jobService.GetList();
            ViewBag.JobCount= jobList.Count;
            return View(jobList);
        }

        public IActionResult JobDetails(int id)
        {
            var job = _jobService.GetByID(id);
            return View(job);
        }

        // satıcı paneli için olan controller

        public IActionResult SellerJobList()
        {
            int? sellerUserId = _httpContextAccessor.HttpContext.Session.GetInt32("SellerUserId");
            var jobList = _jobService.GetJobsByUserId((int)sellerUserId);
            return View(jobList);
        }

        [HttpGet]
        public IActionResult SellerAddJob() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult SellerAddJob(Job item, IFormFile JobImage)
        {
            item.UserId = _httpContextAccessor.HttpContext.Session.GetInt32("SellerUserId");

            if (JobImage != null && JobImage.Length > 0)
            {
                // Resmi bir yere kaydet, örneğin wwwroot içine
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "ImageJob", JobImage.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    JobImage.CopyTo(stream);
                }

                // Resmin yolunu veritabanına kaydet
                item.JobImage = "/imagejob/" + JobImage.FileName;
            }

            _jobService.Add(item);
            return RedirectToAction("SellerJobList");
        }

        [HttpGet]
        public IActionResult SellerUpdateJob(int id)
        {
           var job= _jobService.GetByID(id);
            return View(job);
        }
        [HttpPost]
        public IActionResult SellerUpdateJob(Job item, IFormFile JobImage)
        {
            if (JobImage != null && JobImage.Length > 0)
            {
                // Resmi bir yere kaydet, örneğin wwwroot içine
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "ImageJob", JobImage.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    JobImage.CopyTo(stream);
                }

                // Resmin yolunu veritabanına kaydet
                item.JobImage = "/imagejob/" + JobImage.FileName;
            }

            _jobService.Update(item);
            return RedirectToAction("SellerJobList");
        }

        public IActionResult SellerDeleteJob(int id)
        {
            _jobService.Delete(id);

            return RedirectToAction("SellerJobList");
        }
    }
}
