using Ams.Model;
using Ams.Model.Admin.Dto;
using Ams.Model.Admin;
using Ams.Service;

namespace Ams.Service.Admin.IAdminService
{
    public interface ISysDictDataService : IBaseService<SysDictData>
    {
        public PagedInfo<SysDictData> SelectDictDataList(SysDictData dictData, PagerInfo pagerInfo);
        public List<SysDictData> SelectDictDataByType(string dictType);
        public List<SysDictDataDto> SelectDictDataByTypes(string[] dictTypes);
        public SysDictData SelectDictDataById(long dictCode);
        public long InsertDictData(SysDictData dict);
        public long UpdateDictData(SysDictData dict);
        public int DeleteDictDataByIds(long[] dictCodes);
        int UpdateDictDataType(string old_dictType, string new_dictType);
        List<SysDictDataDto> SelectDictDataByCustomSql(SysDictType sysDictType);
    }
}
