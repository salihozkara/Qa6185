using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Qa6185.MyEntities
{
    public abstract class MyEntityBase : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string? Name { get; set; }

        [CanBeNull]
        public virtual string? Property2 { get; set; }

        protected MyEntityBase()
        {

        }

        public MyEntityBase(Guid id, string? name = null, string? property2 = null)
        {

            Id = id;
            Name = name;
            Property2 = property2;
        }

    }
}