using System.Collections.Generic;

namespace Ams.Generator.Model
{
    /// <summary>
    /// 导入生成器
    /// 表数据传输对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2004-02-01
    /// <summary>
    public class GenImportTableDto
    {
        public int FrontTpl { get; set; }
        public string DbName { get; set; }
        public List<GenTables> Tables { get; set; }
    }

    public class GenTables
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}