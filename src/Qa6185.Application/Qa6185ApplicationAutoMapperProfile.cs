using System;
using Qa6185.Shared;
using Volo.Abp.AutoMapper;
using Qa6185.MyEntities;
using AutoMapper;

namespace Qa6185;

public class Qa6185ApplicationAutoMapperProfile : Profile
{
    public Qa6185ApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<MyEntity, MyEntityDto>();
        CreateMap<MyEntity, MyEntityExcelDto>();
    }
}