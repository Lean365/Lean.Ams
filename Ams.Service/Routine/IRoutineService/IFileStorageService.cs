﻿using Microsoft.AspNetCore.Http;

namespace Ams.Service.Routine.IRoutineService
{
    public interface IFileStorageService : IBaseService<FileStorage>
    {
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<long> InsertFile(FileStorage file);

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileDir"></param>
        /// <param name="fileName"></param>
        /// <param name="formFile"></param>
        /// <param name="rootPath"></param>
        /// <param name="userName"></param>
        /// <returns>文件对象</returns>
        Task<FileStorage> SaveFileToLocal(string rootPath, string fileName, string fileDir, string userName, IFormFile formFile);

        /// <summary>
        /// 上传文件到阿里云
        /// </summary>
        /// <param name="file"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
        Task<FileStorage> SaveFileToAliyun(FileStorage file, IFormFile formFile);

        /// <summary>
        /// 按时间来创建文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <param name="byTimeStore"></param>
        /// <returns>eg: 2020/11/3</returns>
        string GetdirPath(string path = "", bool byTimeStore = true);

        /// <summary>
        /// 取文件名的MD5值(16位)
        /// </summary>
        /// <param name="str">文件名，不包括扩展名</param>
        /// <returns></returns>
        string HashFileName(string str = null);
    }
}