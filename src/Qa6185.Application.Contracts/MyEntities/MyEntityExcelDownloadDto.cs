using Volo.Abp.Application.Dtos;
using System;

namespace Qa6185.MyEntities
{
    public abstract class MyEntityExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? Property2 { get; set; }

        public MyEntityExcelDownloadDtoBase()
        {

        }
    }
}