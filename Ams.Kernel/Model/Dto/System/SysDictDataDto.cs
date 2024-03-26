using Ams.Kernel.Model.System;

namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 字典数据
    /// 输入输出对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public class SysDictDataDto
    {
        public string DictType { get; set; }
        public string ColumnName { get; set; }
        public string Remark { get; set; }
        public List<SysDictData> List { get; set; }
    }
}