﻿namespace Ams.Service.Kernel.IKernelService
{
    /// <summary>
    ///
    /// </summary>
    public interface ISysDictTypeService
    {
        public List<SysDictType> GetAll();

        public PagedInfo<SysDictType> SelectDictTypeList(SysDictType dictType, PagerInfo pager);

        /// <summary>
        /// 校验字典类别称是否唯一
        /// </summary>
        /// <param name="dictType">字典类别</param>
        /// <returns></returns>
        public string CheckDictTypeUnique(SysDictType dictType);

        /// <summary>
        /// 批量删除字典数据信息
        /// </summary>
        /// <param name="dictIds"></param>
        /// <returns></returns>
        public int DeleteDictTypeByIds(long[] dictIds);

        /// <summary>
        /// 插入字典类别
        /// </summary>
        /// <param name="sysDictType"></param>
        /// <returns></returns>
        public long InsertDictType(SysDictType sysDictType);

        /// <summary>
        /// 修改字典类别
        /// </summary>
        /// <param name="sysDictType"></param>
        /// <returns></returns>
        public int UpdateDictType(SysDictType sysDictType);

        /// <summary>
        /// 获取字典信息
        /// </summary>
        /// <param name="dictId"></param>
        /// <returns></returns>
        SysDictType GetInfo(long dictId);

        List<SysDictDataDto> SelectDictDataByCustomSql(string dictType);
    }
}