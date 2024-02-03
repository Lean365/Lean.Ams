using Ams.Infrastructure;
using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Enums;
using Ams.Infrastructure.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Ams.Common;
using Ams.Kernel.Model.Routine;
using Ams.Kernel.Services.IService.System;
using Ams.Kernel.Services.IService.Routine;
using Ams.Kernel.Model;
namespace Ams.Kernel.Services.Routine
{
    /// <summary>
    /// 文件管理
    /// Service业务层处理
    /// @author Lean365(Davis.Cheng)
    /// @date 2021-12-15
    /// </summary>
    [AppService(ServiceType = typeof(IFileStorageService), ServiceLifetime = LifeTime.Transient)]
    public class FileStorageService : BaseService<FileStorage>, IFileStorageService
    {
        private string domainUrl = AppSettings.GetConfig("ALIYUN_OSS:domainUrl");
        private readonly ISysConfigService SysConfigService;
        private OptionsSetting OptionsSetting;
        public FileStorageService(ISysConfigService sysConfigService, IOptions<OptionsSetting> options)
        {
            SysConfigService = sysConfigService;
            OptionsSetting = options.Value;
        }
        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it.RealName.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }
        /// <summary>
        /// 存储本地
        /// </summary>
        /// <param name="fileDir">存储文件夹</param>
        /// <param name="rootPath">存储根目录</param>
        /// <param name="fileName">自定文件名</param>
        /// <param name="formFile">上传的文件流</param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<FileStorage> SaveFileToLocal(string rootPath, string fileName, string fileDir, string userName, IFormFile formFile)
        {

            string fileExt = Path.GetExtension(formFile.FileName);
            fileName = (fileName.IsEmpty() ? HashFileName() : fileName) + fileExt;

            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(CheckEntryUnique(formFile.FileName.ToString())))
            {
                Console.WriteLine("提交数据异常,重复文件：" + formFile.FileName);
                throw new Exception("提交数据异常,重复文件：" + formFile.FileName);
                //return; //ToResponse(ApiResult.Error($"新增(New)固定资产 '{parm.FaSFID}'失败(failed)，输入的(The entered)固定资产已存在(already exists)"));
            }

            string filePath = GetdirPath(fileDir);
            string finalFilePath = Path.Combine(rootPath, filePath, fileName);
            double fileSize = Math.Round(formFile.Length / 1024.0, 2);

            if (!Directory.Exists(Path.GetDirectoryName(finalFilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(finalFilePath));
            }

            using (var stream = new FileStream(finalFilePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
            string uploadUrl = OptionsSetting.Upload.UploadUrl;
            string accessPath = string.Concat(filePath.Replace("\\", "/"), "/", fileName);
            Uri baseUri = new(uploadUrl);
            Uri fullUrl = new(baseUri, accessPath);
            FileStorage file = new(formFile.FileName, fileName, fileExt, fileSize + "kb", filePath, userName)
            {
                StoreType = (int)StoreType.LOCAL,
                FileType = formFile.ContentType,
                FileUrl = finalFilePath.Replace("\\", "/"),
                AccessUrl = fullUrl.AbsoluteUri
            };
            file.Id = await InsertFile(file);
            return file;
        }

        /// <summary>
        /// 上传文件到阿里云
        /// </summary>
        /// <param name="file"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public async Task<FileStorage> SaveFileToAliyun(FileStorage file, IFormFile formFile)
        {
            file.FileName = (file.FileName.IsEmpty() ? HashFileName() : file.FileName) + file.FileExt;
            file.StorePath = GetdirPath(file.StorePath);
            string finalPath = Path.Combine(file.StorePath, file.FileName);
            HttpStatusCode statusCode = AliyunOssHelper.PutObjectFromFile(formFile.OpenReadStream(), finalPath, "");
            if (statusCode != HttpStatusCode.OK) return file;

            file.StorePath = file.StorePath;
            file.FileUrl = finalPath;
            file.AccessUrl = string.Concat(domainUrl, "/", file.StorePath.Replace("\\", "/"), "/", file.FileName);
            file.Id = await InsertFile(file);

            return file;
        }

        /// <summary>
        /// 获取文件存储目录
        /// </summary>
        /// <param name="storePath"></param>
        /// <param name="byTimeStore">是否按年月日存储</param>
        /// <returns></returns>
        public string GetdirPath(string storePath = "", bool byTimeStore = true)
        {
            DateTime date = DateTime.Now;
            string timeDir = "uploads/"+ date.ToString("yyyy/MMdd");

            if (!string.IsNullOrEmpty(storePath))
            {
                timeDir = Path.Combine(storePath, timeDir);
            }
            return timeDir;
        }
        
        /// <summary>
        /// 哈希文件名算法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string HashFileName(string str = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                str = Guid.NewGuid().ToString().ToLower();
            }
            return BitConverter.ToString(MD5.HashData(Encoding.Default.GetBytes(str)), 4, 8).Replace("-", "");
        }
        /// <summary>
        /// 添加文件使用雪花ID
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Task<long> InsertFile(FileStorage file)
        {
            return Insertable(file).ExecuteReturnSnowflakeIdAsync();//单条插入返回雪花ID;
        }
    }
}
