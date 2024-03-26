using Ams.Kernel.Model.System;
using Ams.Model;

namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 数据字典
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public interface ISysDictDataService : IBaseService<SysDictData>
    {
        public PagedInfo<SysDictData> SelectDictDataList(SysDictData dictData, PagerInfo pagerInfo);

        public List<SysDictData> SelectDictDataByType(string dictType);

        public List<SysDictData> SelectDictDataByTypes(string[] dictTypes);

        public SysDictData SelectDictDataById(long dictCode);

        public long InsertDictData(SysDictData dict);

        public long UpdateDictData(SysDictData dict);

        public int DeleteDictDataByIds(long[] dictCodes);

        int UpdateDictDataType(string old_dictType, string new_dictType);

        List<SysDictData> SelectDictDataByCustomSql(SysDictType sysDictType);
    }
}