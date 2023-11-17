using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Qa6185.MyEntities
{
    public abstract class MyEntityUpdateDtoBase : IHasConcurrencyStamp
    {
        public string? Name { get; set; }
        public string? Property2 { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}