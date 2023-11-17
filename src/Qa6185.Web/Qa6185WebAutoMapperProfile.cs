using Qa6185.Web.Pages.MyEntities;
using Volo.Abp.AutoMapper;
using Qa6185.MyEntities;
using AutoMapper;

namespace Qa6185.Web;

public class Qa6185WebAutoMapperProfile : Profile
{
    public Qa6185WebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project

        CreateMap<MyEntityDto, MyEntityUpdateViewModel>();
        CreateMap<MyEntityUpdateViewModel, MyEntityUpdateDto>();
        CreateMap<MyEntityCreateViewModel, MyEntityCreateDto>();
    }
}