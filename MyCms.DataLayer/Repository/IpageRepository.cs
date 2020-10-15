using System;
using System.Collections.Generic;
using System.Text;
namespace MyCms.DataLayer.Repository
{
    public interface IpageRepository
    {

        IEnumerable<Page> GetAllPage();
        Page GetPageById(int pageid);
        void InsertPage(Page page);
        void UpdatePage(Page page);
        void DeletePage(Page page);
        void DeletePage(int pageid);
        bool PageExists(int pageid);
        IEnumerable<Page> GetTopPage(int take=4);
        IEnumerable<Page> GetLastPage(int take = 4);
        IEnumerable<Page> GetPageinSlider();
        IEnumerable<Page> GetPageBygroupid(int groupid);
        IEnumerable<Page> Search(string q);

        void Save();

    }
}
