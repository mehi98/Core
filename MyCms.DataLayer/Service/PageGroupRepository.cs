using Microsoft.EntityFrameworkCore;
using MyCms.DataLayer.Context;
using MyCms.DataLayer.PageGroup;
using MyCms.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCms.DataLayer.Service
{
    public class PageGroupRepository : IPageGroupRepository
    {

        private MyWebContext DB;
        public PageGroupRepository(MyWebContext db)
        {
            this.DB = db;
        }

      

        public IEnumerable<PageGroup.PageGroup> GetAllPageGroup()
        {
            return DB.pageGroups.ToList();
        }

        public PageGroup.PageGroup GetPageGroupById(int Groupid)
        {
            return DB.pageGroups.Find(Groupid);
        }

        public void InsertPageGroup(PageGroup.PageGroup pageGroup)
        {
            DB.pageGroups.Add(pageGroup);
        }
        public void UpdatePageGroup(PageGroup.PageGroup pageGroup)
        {
            DB.Entry(pageGroup).State = EntityState.Modified;
        }
        public void DeletePageGroup(PageGroup.PageGroup pageGroup)
        {
            DB.Entry(pageGroup).State = EntityState.Deleted;

        }

        public void DeletePageGroup(int Groupid)
        {
            var page = GetPageGroupById(Groupid);
            DeletePageGroup(page);
        }
        public bool PageGroupExists(int Groupid)
        {
            return DB.pageGroups.Any(p => p.GroupID == Groupid);
            
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public List<ShowGroupsViewModel> GetGroupforsaid()
        {
            return DB.pageGroups.Select(g => new ShowGroupsViewModel() {
                PageCount = g.Pages.Count,
                Groupid=g.GroupID,
                GroupTitle=g.GroupTitle

            }).ToList();
        }
    }
} 