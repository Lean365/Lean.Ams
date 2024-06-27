using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 生产班组service接口
    /// </summary>
    public interface IPpLineService : IBaseService<PpLine>
    {
        PagedInfo<PpLineDto> GetList(PpLineQueryDto parm);

        PpLine GetInfo(long PlSFID);


        PpLine AddPpLine(PpLine parm);
        int UpdatePpLine(PpLine parm);

        (string, object, object) ImportPpLine(List<PpLine> list);

    }
}
