using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCms.DataLayer.Repository;

namespace MyCms.Web.Controllers
{
    public class NewsController : Controller
    {
        private IpageRepository pageRepository;
        public NewsController(IpageRepository PageRepository)
        {
            this.pageRepository = PageRepository;
        }
        [Route("News/{newsid}")]
        public IActionResult Shownews(int newsid)
        {
            var page = pageRepository.GetPageById(newsid);
            if (page != null)
            {
                page.PageVisit += 1;
                pageRepository.UpdatePage(page);
                pageRepository.Save();

            }
            return View(page);
        }
        [Route("Group/{groupId}/{Title}")]
        public IActionResult Getpagebygroupid(int groupId,string Title)
        {
            ViewData["GroupTitle"] = Title;

            return View(pageRepository.GetPageBygroupid(groupId));
        }
        [Route("Search")]
        public IActionResult Search(string q)
        {
            return View(pageRepository.Search(q));
        }
    }
}