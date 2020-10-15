using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCms.DataLayer;
using MyCms.DataLayer.Context;
using MyCms.DataLayer.Repository;

namespace MyCms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private IpageRepository PageRepository;
        private IPageGroupRepository PageGroupRepository;
        public PagesController(IpageRepository pageRepository,IPageGroupRepository pageGroupRepository)
        {
            this.PageGroupRepository = pageGroupRepository;
            this.PageRepository = pageRepository;
        }

        // GET: Admin/Pages
        public async Task<IActionResult> Index()
        {
          return View (PageRepository.GetAllPage());
        }

        // GET: Admin/Pages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = PageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // GET: Admin/Pages/Create
        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(PageGroupRepository.GetAllPageGroup(), "GroupID", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PageID,GroupID,PageTitle,ShortDescription,PageVisit,ImageName,PageTags,ShowInSlider,CreateDate")] Page page,IFormFile Imgup)
        {
            if (ModelState.IsValid)
            {
                page.PageVisit = 0;
                page.CreateDate = DateTime.Now;
                if (Imgup!=null)
                {
                    page.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(Imgup.FileName);
                    string savepath = Path.Combine(
                        Directory.GetCurrentDirectory(),"WWWroot/Image",page.ImageName);
                    using (var stream = new FileStream(savepath, FileMode.Create))
                    {
                       await Imgup.CopyToAsync(stream);

                    }
                }
                PageRepository.InsertPage(page);
                PageRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(PageGroupRepository.GetAllPageGroup(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = PageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(PageGroupRepository.GetAllPageGroup(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PageID,GroupID,PageTitle,ShortDescription,PageVisit,ImageName,PageTags,ShowInSlider,CreateDate")] Page page, IFormFile Imgup)
        {
            if (id != page.PageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Imgup != null)
                    {
                        if (page.ImageName==null) {
                            page.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(Imgup.FileName);
                        }

                        string savepath = Path.Combine(
                            Directory.GetCurrentDirectory(), "WWWroot/Image", page.ImageName);
                        using (var stream = new FileStream(savepath, FileMode.Create))
                        {
                            await Imgup.CopyToAsync(stream);

                        }
                    }

                    PageRepository.UpdatePage(page);
                    PageRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.PageID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(PageGroupRepository.GetAllPageGroup(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = PageRepository.GetPageById(id.Value);
               
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            PageRepository.DeletePage(id);
            PageRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id)
        {
            return PageRepository.PageExists(id);
        }
    }
}
