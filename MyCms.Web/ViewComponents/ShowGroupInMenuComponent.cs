using Microsoft.AspNetCore.Mvc;
using MyCms.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCms.Web.ViewComponents
{
    public class ShowGroupInMenuComponent:ViewComponent
    {
        private IPageGroupRepository PageGroupRepository;
        public ShowGroupInMenuComponent(IPageGroupRepository pageGroupRepository)
        {
            this.PageGroupRepository = pageGroupRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ShowGroupInMenuComponent", PageGroupRepository.GetGroupforsaid()));
        }
    }
}
