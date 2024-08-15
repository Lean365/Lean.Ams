﻿using Ams.Common;

namespace Ams.Service.Kernel
{
    /// <summary>
    /// 字典数据类
    /// </summary>
    [AppService(ServiceType = typeof(ISysDictDataService), ServiceLifetime = LifeTime.Transient)]
    public class SysDictDataService : BaseService<SysDictData>, ISysDictDataService
    {
        /// <summary>
        /// 查询字典数据
        /// </summary>
        /// <param name="dictData"></param>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        public PagedInfo<SysDictData> SelectDictDataList(SysDictData dictData, PagerInfo pagerInfo)
        {
            //return SysDictDataRepository.SelectDictDataList(dictData, pagerInfo);
            var exp = Expressionable.Create<SysDictData>();
            exp.AndIF(!string.IsNullOrEmpty(dictData.DictLabel), it => it.DictLabel.Contains(dictData.DictLabel));
            exp.AndIF(dictData.IsStatus != -1, it => it.IsStatus == dictData.IsStatus);
            exp.AndIF(!string.IsNullOrEmpty(dictData.DictType), it => it.DictType == dictData.DictType);
            return GetPages(exp.ToExpression(), pagerInfo);
        }

        /// <summary>
        /// 根据字典类别查询
        /// </summary>
        /// <param name="dictType"></param>
        /// <returns></returns>
        public List<SysDictData> SelectDictDataByType(string dictType)
        {
            string CK = $"SelectDictDataByType_{dictType}";

            var list = Queryable()
                .WithCache(CK, 60 * 10)
                .Where(f => f.IsStatus == 0 && f.DictType == dictType)
            .OrderBy(it => it.SortingNum)
            .ToList();

            return list;
        }

        public List<SysDictDataDto> SelectDictDataByTypes(string[] dictTypes)
        {
            string CK = $"SelectDictDataByTypes_{dictTypes}";

            var list = Queryable()
            .WithCache(CK, 60 * 30)
            .Where(f => f.IsStatus == 0 && dictTypes.Contains(f.DictType))
            .OrderBy(it => it.SortingNum)
            .Select((it) => new SysDictDataDto()
            {
                Label = it.DictLabel,
                Value = it.DictValue
            }, true)
            .ToList();

            return list;
        }

        /// <summary>
        /// 根据字典数据ID查询信息
        /// </summary>
        /// <param name="dictCode"></param>
        /// <returns></returns>
        public SysDictData SelectDictDataById(long dictCode)
        {
            string CK = $"SelectDictDataByCode_{dictCode}";
            if (CacheHelper.GetCache(CK) is not SysDictData list)
            {
                list = GetFirst(f => f.DictCode == dictCode);
                CacheHelper.SetCache(CK, list, 5);
            }
            return list;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public long InsertDictData(SysDictData dict)
        {
            return Insertable(dict).ExecuteReturnBigIdentity();
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public long UpdateDictData(SysDictData dict)
        {
            var result = Update(w => w.DictCode == dict.DictCode, it => new SysDictData()
            {
                Remark = dict.Remark,
                Update_time = DateTime.Now,
                SortingNum = dict.SortingNum,
                DictLabel = dict.DictLabel,
                DictValue = dict.DictValue,
                IsStatus = dict.IsStatus,
                CssClass = dict.CssClass,
                ListClass = dict.ListClass,
                LangKey = dict.LangKey,
                ExtLabel = dict.ExtLabel,
                ExtValue = dict.ExtValue
            });

            CacheHelper.Remove($"SelectDictDataByCode_{dict.DictCode}");
            return result;
        }

        /// <summary>
        /// 批量删除字典数据信息
        /// </summary>
        /// <param name="dictCodes"></param>
        /// <returns></returns>
        public int DeleteDictDataByIds(long[] dictCodes)
        {
            return Delete(dictCodes);
        }

        /// <summary>
        /// 同步修改字典类别
        /// </summary>
        /// <param name="old_dictType">旧字典类别</param>
        /// <param name="new_dictType">新字典类别</param>
        /// <returns></returns>
        public int UpdateDictDataType(string old_dictType, string new_dictType)
        {
            //只更新DictType字段根据where条件
            return Context.Updateable<SysDictData>()
                .SetColumns(t => new SysDictData() { DictType = new_dictType })
                .Where(f => f.DictType == old_dictType)
                .ExecuteCommand();
        }

        /// <summary>
        /// 根据字典类别查询自定义sql
        /// </summary>
        /// <param name="sysDictType"></param>
        /// <returns></returns>
        public List<SysDictDataDto> SelectDictDataByCustomSql(SysDictType sysDictType)
        {
            return Context.Ado.SqlQuery<SysDictDataDto>(sysDictType?.CustomSql).ToList();
        }
    }
}