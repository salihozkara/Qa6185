using Qa6185.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qa6185.MyEntities;

namespace Qa6185.Web.Pages.MyEntities
{
    public abstract class CreateModalModelBase : Qa6185PageModel
    {
        [BindProperty]
        public MyEntityCreateViewModel MyEntity { get; set; }

        protected IMyEntitiesAppService _myEntitiesAppService;

        public CreateModalModelBase(IMyEntitiesAppService myEntitiesAppService)
        {
            _myEntitiesAppService = myEntitiesAppService;

            MyEntity = new();
        }

        public virtual async Task OnGetAsync()
        {
            MyEntity = new MyEntityCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _myEntitiesAppService.CreateAsync(ObjectMapper.Map<MyEntityCreateViewModel, MyEntityCreateDto>(MyEntity));
            return NoContent();
        }
    }

    public class MyEntityCreateViewModel : MyEntityCreateDto
    {
    }
}