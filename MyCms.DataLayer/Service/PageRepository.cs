using Microsoft.EntityFrameworkCore;
using MyCms.DataLayer.Context;
using MyCms.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCms.DataLayer.Service
{
    public class PageRepository : IpageRepository
    {

        private MyWebContext DB;
        public PageRepository(MyWebContext db)
        {
            this.DB = db;
        }
        public IEnumerable<Page> GetAllPage()
        {
            return DB.pages.ToList();
        }

        public Page GetPageById(int pageid)
        {
            return DB.pages.Find(pageid);
        }

        public void InsertPage(Page page)
        {
            DB.Add(page);
        }
        public void UpdatePage(Page page)
        {
            DB.Entry(page).State = EntityState.Modified;
        }
        public void DeletePage(Page page)
        {
            DB.Entry(page).State = EntityState.Deleted;

        }

        public void DeletePage(int pageid)
        {
            var page = GetPageById(pageid);
            DeletePage(page);
        }
        public void Save()
        {
            DB.SaveChanges();
        }

        public bool PageExists(int pageid)
        {
          return DB.pages.Any(p => p.PageID == pageid);
        }
        

        public IEnumerable<Page> GetTopPage(int take = 4)
        {
            return DB.pages.OrderByDescending(p => p.PageVisit).Take(take).ToList();

        }

        public IEnumerable<Page> GetLastPage(int take = 4)
        {
            return DB.pages.OrderByDescending(p => p.CreateDate).Take(take).ToList();
        }

        public IEnumerable<Page> GetPageinSlider()
        {
            return DB.pages.Where(p => p.ShowInSlider).ToList();
        }

        public IEnumerable<Page> GetPageBygroupid(int groupid)
        {
            return DB.pages.Where(p => p.GroupID == groupid).ToList();
        }

        public IEnumerable<Page> Search(string q)
        {
            var list = DB.pages.Where(p => p.PageTitle.Contains(q) || p.PageTags.Contains(q) || p.ShortDescription.Contains(q)).ToList();
            return list.Distinct().ToList();
        }
    }
}
