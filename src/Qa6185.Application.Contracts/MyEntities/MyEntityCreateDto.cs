using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Qa6185.MyEntities
{
    public abstract class MyEntityCreateDtoBase
    {
        public string? Name { get; set; }
        public string? Property2 { get; set; }
    }
}