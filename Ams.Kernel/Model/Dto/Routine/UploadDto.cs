using Microsoft.AspNetCore.Http;

namespace Ams.Kernel.Model.Dto
{
    /// <summary>
    /// 上传
    /// 输入输出对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class UploadDto
    {
        /// <summary>
        /// 自定文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 存储目录
        /// </summary>
        public string FileDir { get; set; }

        /// <summary>
        /// 文件名生成类型 1 原文件名 2 自定义 3 自动生成
        /// </summary>
        public int FileNameType { get; set; }

        /// <summary>
        /// 文件
        /// </summary>
        public IFormFile File { get; set; }
    }
}