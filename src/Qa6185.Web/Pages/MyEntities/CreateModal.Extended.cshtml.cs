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
    public class CreateModalModel : CreateModalModelBase
    {
        public CreateModalModel(IMyEntitiesAppService myEntitiesAppService)
            : base(myEntitiesAppService)
        {
        }
    }
}