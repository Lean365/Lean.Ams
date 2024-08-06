using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 利润中心
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 14:40:21
    /// </summary>
    public interface IFicoProfitCenterService : IBaseService<FicoProfitCenter>
    {
        /// <summary>
        /// 获取利润中心列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoProfitCenterDto> GetList(FicoProfitCenterQueryDto parm);

        /// <summary>
        /// 获取利润中心信息
        /// </summary>
        /// <param name="FpSfId"></param>
        /// <returns></returns>
        FicoProfitCenter GetInfo(long FpSfId);

        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="Prctr"></param>
        /// <param name="Kokrs"></param>
        /// <returns></returns>
        public string CheckInputUnique(string Prctr, string Kokrs);

        /// <summary>
        /// 新增
        /// 利润中心
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoProfitCenter AddFicoProfitCenter(FicoProfitCenter parm);

        /// <summary>
        /// 更新
        /// 利润中心
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoProfitCenter(FicoProfitCenter parm);

        /// <summary>
        /// 批量导入
        /// 利润中心
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoProfitCenter(List<FicoProfitCenter> list);

        /// <summary>
        /// 导出
        /// 利润中心
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoProfitCenterDto> ExportList(FicoProfitCenterQueryDto parm);
    }
}