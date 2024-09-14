using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 生产工单
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:05:47
    /// </summary>
    public interface IPpMasterProdorderService : IBaseService<PpMasterProdorder>
    {
        /// <summary>
        /// 获取生产工单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpMasterProdorderDto> GetList(PpMasterProdorderQueryDto parm);

        /// <summary>
        /// 获取生产工单信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpMasterProdorder GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 生产工单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpMasterProdorder AddPpMasterProdorder(PpMasterProdorder parm);

        /// <summary>
        /// 更新
        /// 生产工单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpMasterProdorder(PpMasterProdorder parm);


        /// <summary>
        /// 批量导入
        /// 生产工单
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpMasterProdorder(List<PpMasterProdorder> list);

        /// <summary>
        /// 导出
        /// 生产工单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpMasterProdorderDto> ExportList(PpMasterProdorderQueryDto parm);
    }
}
