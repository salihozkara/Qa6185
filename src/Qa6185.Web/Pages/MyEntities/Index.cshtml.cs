using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Qa6185.MyEntities;
using Qa6185.Shared;

namespace Qa6185.Web.Pages.MyEntities
{
    public abstract class IndexModelBase : AbpPageModel
    {
        public string? NameFilter { get; set; }
        public string? Property2Filter { get; set; }

        protected IMyEntitiesAppService _myEntitiesAppService;

        public IndexModelBase(IMyEntitiesAppService myEntitiesAppService)
        {
            _myEntitiesAppService = myEntitiesAppService;
        }

        public virtual async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}