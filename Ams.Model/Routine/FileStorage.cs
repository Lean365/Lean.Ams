namespace Ams.Model.Routine
{
    /// <summary>
    /// 文件存储
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [Tenant("0")]
    [SugarTable("routine_file_storage", "文件存储")]
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
        [SugarColumn(ColumnName = "RealName", ColumnDescription = "原文件", Length = 400)]
        public string RealName { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [SugarColumn(ColumnName = "FileType", ColumnDescription = "文件类型", Length = 400)]
        public string FileType { get; set; }

        /// <summary>
        /// 存储文件名
        /// </summary>
        [SugarColumn(ColumnName = "FileName", ColumnDescription = "文件名", Length = 400)]
        public string FileName { get; set; }

        /// <summary>
        /// 文件存储地址 eg：/uploads/20220202
        /// </summary>
        [SugarColumn(ColumnName = "FileUrl", ColumnDescription = "存储地址", Length = 400)]
        public string FileUrl { get; set; }

        /// <summary>
        /// 仓库位置 eg：/uploads
        /// </summary>
        [SugarColumn(ColumnName = "StorePath", ColumnDescription = "仓库位置", Length = 400)]
        public string StorePath { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        [SugarColumn(ColumnName = "FileSize", ColumnDescription = "文件大小", Length = 400)]
        public string FileSize { get; set; }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        [SugarColumn(ColumnName = "FileExt", ColumnDescription = "扩展名", Length = 6)]
        public string FileExt { get; set; }

        /// <summary>
        /// 存储类型
        /// </summary>
        [SugarColumn(ColumnName = "StoreType", ColumnDescription = "存储类型", DefaultValue = "0")]
        public int? StoreType { get; set; }

        /// <summary>
        /// 访问路径
        /// </summary>
        [SugarColumn(ColumnName = "AccessUrl", ColumnDescription = "访问路径", Length = 400)]
        public string AccessUrl { get; set; }

        /// <summary>
        /// 所属模块
        /// </summary>
        [SugarColumn(ColumnName = "UseModule", ColumnDescription = "所属模块", Length = 400)]
        public string UseModule { get; set; }

        public FileStorage()
        { }

        public FileStorage(string originFileName, string fileName, string ext, string fileSize, string storePath, string create_by)
        {
            StorePath = storePath;
            RealName = originFileName;
            FileName = fileName;
            FileExt = ext;
            FileSize = fileSize;
            Create_by = create_by;
            Create_time = DateTime.Now;
        }
    }
}