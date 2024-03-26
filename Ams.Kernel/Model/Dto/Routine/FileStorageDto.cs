using Ams.Model;

namespace Ams.Kernel.Model.Dto.Routine
{
    /// <summary>
    /// 文件存储
    /// 输入输出对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public class FileStorageDto
    {
        public long Id { get; set; }

        /// <summary>
        /// 文件原名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// 存储文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件存储地址 eg：/uploads/20220202
        /// </summary>
        public string FileUrl { get; set; }

        /// <summary>
        /// 仓库位置 eg：/uploads
        /// </summary>
        public string StorePath { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public string FileSize { get; set; }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string FileExt { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string Create_by { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? Create_time { get; set; }

        /// <summary>
        /// 存储类型
        /// </summary>
        public int? StoreType { get; set; }

        /// <summary>
        /// 访问路径
        /// </summary>
        public string AccessUrl { get; set; }

        public FileStorageDto()
        { }

        public FileStorageDto(string originFileName, string fileName, string ext, string fileSize, string storePath, string accessUrl, string create_by)
        {
            StorePath = storePath;
            RealName = originFileName;
            FileName = fileName;
            FileExt = ext;
            FileSize = fileSize;
            AccessUrl = accessUrl;
            Create_by = create_by;
            Create_time = DateTime.Now;
        }
    }

    /// <summary>
    /// 文件存储
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public class FileStorageQueryDto : PagerInfo
    {
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? StoreType { get; set; }
        public long? FileId { get; set; }
    }
}