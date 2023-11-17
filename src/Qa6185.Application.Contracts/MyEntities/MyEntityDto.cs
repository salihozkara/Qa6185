using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Qa6185.MyEntities
{
    public abstract class MyEntityDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string? Name { get; set; }
        public string? Property2 { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}