using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// PO残清单
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:59:13
    /// </summary>
    public interface IMmPoResidueService : IBaseService<MmPoResidue>
    {
        /// <summary>
        /// 获取PO残清单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmPoResidueDto> GetList(MmPoResidueQueryDto parm);

        /// <summary>
        /// 获取PO残清单信息
        /// </summary>
        /// <param name="PrSfId"></param>
        /// <returns></returns>
        MmPoResidue GetInfo(long PrSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// PO残清单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        MmPoResidue AddMmPoResidue(MmPoResidue parm);

        /// <summary>
        /// 更新
        /// PO残清单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateMmPoResidue(MmPoResidue parm);


        /// <summary>
        /// 批量导入
        /// PO残清单
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportMmPoResidue(List<MmPoResidue> list);

        /// <summary>
        /// 导出
        /// PO残清单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmPoResidueDto> ExportList(MmPoResidueQueryDto parm);
    }
}
