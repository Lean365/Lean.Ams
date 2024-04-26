namespace Ams.Kernel.Model.Routine
{
    /// <summary>
    /// 文件存储
    /// 数据实体类：routine_filestorage
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Tenant("0")]
    [SugarTable("routine_filestorage", "文件存储")]
    public class FileStorage : SysBase
    {
        /// <summary>
        /// 自增id
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true)]
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
        /// 存储类型
        /// </summary>
        public int? StoreType { get; set; }

        /// <summary>
        /// 访问路径
        /// </summary>
        public string AccessUrl { get; set; }

        /// <summary>
        /// 文件存储实体类
        /// </summary>
        public FileStorage()
        { }

        /// <summary>
        /// 文件存储实体类
        /// </summary>
        /// <param name="originFileName"></param>
        /// <param name="fileName"></param>
        /// <param name="ext"></param>
        /// <param name="fileSize"></param>
        /// <param name="storePath"></param>
        /// <param name="create_by"></param>
        public FileStorage(string originFileName, string fileName, string ext, string fileSize, string storePath, string create_by)
        {
            StorePath = storePath;//仓库位置
            RealName = originFileName;//
            FileName = fileName;//文件名
            FileExt = ext;//扩展名
            FileSize = fileSize;//大小
            Create_by = create_by;//创建人员
            Create_time = DateTime.Now;//上传时间
        }
    }
}