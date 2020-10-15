using Microsoft.AspNetCore.Mvc;
using MyCms.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCms.Web.ViewComponents
{
    public class ShowGroupComponent:ViewComponent
    {
        private IPageGroupRepository _groupRepository;

        public ShowGroupComponent(IPageGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ShowGroupComponent",
                _groupRepository.GetGroupforsaid()));
        }
    }
}
