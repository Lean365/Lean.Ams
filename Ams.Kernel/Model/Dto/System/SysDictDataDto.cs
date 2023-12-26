using System.Collections.Generic;
using Ams.Kernel.Model.System;
using Ams.Model;
namespace Ams.Kernel.Model.Dto.System
{
    public class SysDictDataDto
    {
        public string DictType { get; set; }
        public string ColumnName { get; set; }
        public string Remark { get; set; }
        public List<SysDictData> List { get; set; }
    }
}
