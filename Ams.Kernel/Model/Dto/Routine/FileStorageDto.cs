namespace Ams.Model.System.Dto
{
    /// <summary>
    /// 文件存储
    /// 查询对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class FileStorageQueryDto : PagerInfo
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 存储类别
        /// </summary>
        public int? StoreType { get; set; }

        /// <summary>
        /// 文件ID
        /// </summary>
        public long? FileId { get; set; }
    }

    /// <summary>
    /// 文件存储
    /// 输入输出对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class FileStorageDto
    {
        /// <summary>
        /// ID
        /// </summary>
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
        /// 创建人员
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

        /// <summary>
        /// 文件存储
        /// </summary>
        public FileStorageDto()
        { }

        /// <summary>
        /// 文件存储
        /// </summary>
        /// <param name="originFileName"></param>
        /// <param name="fileName"></param>
        /// <param name="ext"></param>
        /// <param name="fileSize"></param>
        /// <param name="storePath"></param>
        /// <param name="accessUrl"></param>
        /// <param name="create_by"></param>
        public FileStorageDto(string originFileName, string fileName, string ext, string fileSize, string storePath, string accessUrl, string create_by)
        {
            StorePath = storePath;//仓库位置
            RealName = originFileName;//
            FileName = fileName;//存储文件名
            FileExt = ext;//文件扩展名
            FileSize = fileSize;//文件大小
            AccessUrl = accessUrl;//访问路径
            Create_by = create_by;//创建人员
            Create_time = DateTime.Now;//上传时间
        }
    }
}