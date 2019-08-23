using DataAccessLayer;
using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOrganization.Controllers
{
    public class ImageController : Controller
    {
        IImageRepository<Images> _imageRepository;

        public ImageController(IImageRepository<Images> imageRepository)
        {
            _imageRepository = imageRepository;
        }

        // GET: Image
        public ActionResult Index()
        {
            List<Images> model = _imageRepository.List();
            return View(model);
        }
    }
}