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
    public class EditModalModel : EditModalModelBase
    {
        public EditModalModel(IMyEntitiesAppService myEntitiesAppService)
            : base(myEntitiesAppService)
        {
        }
    }
}