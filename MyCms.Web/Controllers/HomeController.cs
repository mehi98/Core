using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCms.DataLayer.Repository;

namespace MyCms.Web.Controllers
{
    public class HomeController : Controller
    {
        private IpageRepository pageRepository;
        public HomeController(IpageRepository PageRepository)
        {
            this.pageRepository = PageRepository;
        }
        public IActionResult Index()
        {
            ViewData["Slider"] = pageRepository.GetPageinSlider();
            return View(pageRepository.GetLastPage());
        }
    }
}