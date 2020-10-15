using Microsoft.AspNetCore.Mvc;
using MyCms.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCms.Web.ViewComponents
{
    public class ShowTopNews:ViewComponent
    {
        private IpageRepository pageRepository;
        public ShowTopNews(IpageRepository PageRepository)
        {
            this.pageRepository = PageRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ShowTopNews", pageRepository.GetTopPage()));
        }
    }
}
