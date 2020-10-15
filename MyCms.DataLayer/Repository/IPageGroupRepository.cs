using System;
using System.Collections.Generic;
using System.Text;

namespace MyCms.DataLayer.Repository
{
    public interface IPageGroupRepository
    {

        IEnumerable<PageGroup.PageGroup> GetAllPageGroup();
        PageGroup.PageGroup GetPageGroupById(int Groupid);
        void InsertPageGroup(PageGroup.PageGroup pageGroup);
        void UpdatePageGroup(PageGroup.PageGroup pageGroup);
        void DeletePageGroup(PageGroup.PageGroup pageGroup);
        void DeletePageGroup(int Groupid);
        bool PageGroupExists(int Groupid);
        List<ShowGroupsViewModel> GetGroupforsaid(); 
        void Save();
    }
}
