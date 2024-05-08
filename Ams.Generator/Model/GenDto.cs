using System.Collections.Generic;
using Ams.Kernel.Model.Generator;

namespace Ams.Generator.Model
{
    /// <summary>
    /// 生成器数据
    /// 传输对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2004-02-01
    /// </summary>
    public class GenDto
    {
        /// <summary>
        /// vue版本
        /// </summary>
        public int VueVersion { get; set; }

        public long TableId { get; set; }

        /// <summary>
        /// 是否预览代码
        /// </summary>
        public bool IsPreview { get; set; }

        /// <summary>
        /// 生成代码的数据库类型 0、mysql 1、sqlserver
        /// </summary>
        public int DbType { get; set; }

        /// <summary>
        /// 生成的按钮功能
        /// </summary>
        public int[] CheckedBtn { get; set; } = System.Array.Empty<int>();

        public GenTable GenTable { get; set; }

        /// <summary>
        /// 主表属性
        /// </summary>
        public GenOption GenOptions { get; set; }

        /// <summary>
        /// 子表属性
        /// </summary>
        public GenOption SubTableOptions { get; set; }

        #region 存储路径

        /// <summary>
        /// 代码模板预览存储路径存放
        /// </summary>
        public List<GenCode> GenCodes { get; set; } = new List<GenCode>();

        /// <summary>
        /// 代码生成路径
        /// </summary>
        public string GenCodePath { get; set; } = string.Empty;

        /// <summary>
        /// 代码生成压缩包路径
        /// </summary>
        public string ZipPath { get; set; }

        /// <summary>
        /// 代码生成压缩包名称
        /// </summary>
        public string ZipFileName { get; set; }

        /// <summary>
        /// 生成代码方式（0zip压缩包 1自定义路径）
        /// </summary>
        public string GenType { get; set; }

        public string GenPath { get; set; } = "";

        /// <summary>
        /// vue代码路径
        /// </summary>
        public string VueParentPath { get; set; }

        /// <summary>
        /// uniapp存储路径
        /// </summary>
        public string AppVuePath { get; set; } = "Lean365n-app";

        #endregion 存储路径

        public GenReplaceDto ReplaceDto { get; set; }
    }

    public class GenCode
    {
        public int Type { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }

        public GenCode(int type, string title, string path, string content)
        {
            Type = type;
            Title = title;
            Path = path;
            Content = content;
        }
    }
}