using Qa6185.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Qa6185.MyEntities;

namespace Qa6185.Web.Pages.MyEntities
{
    public abstract class EditModalModelBase : Qa6185PageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public MyEntityUpdateViewModel MyEntity { get; set; }

        protected IMyEntitiesAppService _myEntitiesAppService;

        public EditModalModelBase(IMyEntitiesAppService myEntitiesAppService)
        {
            _myEntitiesAppService = myEntitiesAppService;

            MyEntity = new();
        }

        public virtual async Task OnGetAsync()
        {
            var myEntity = await _myEntitiesAppService.GetAsync(Id);
            MyEntity = ObjectMapper.Map<MyEntityDto, MyEntityUpdateViewModel>(myEntity);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _myEntitiesAppService.UpdateAsync(Id, ObjectMapper.Map<MyEntityUpdateViewModel, MyEntityUpdateDto>(MyEntity));
            return NoContent();
        }
    }

    public class MyEntityUpdateViewModel : MyEntityUpdateDto
    {
    }
}