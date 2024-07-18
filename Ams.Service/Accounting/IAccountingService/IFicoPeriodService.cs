using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 财务期间
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:53
    /// </summary>
    public interface IFicoPeriodService : IBaseService<FicoPeriod>
    {
        /// <summary>
        /// 获取财务期间列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoPeriodDto> GetList(FicoPeriodQueryDto parm);

        /// <summary>
        /// 获取财务期间信息
        /// </summary>
        /// <param name="FpSFID"></param>
        /// <returns></returns>
        FicoPeriod GetInfo(long FpSFID);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 财务期间
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoPeriod AddFicoPeriod(FicoPeriod parm);

        /// <summary>
        /// 更新
        /// 财务期间
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoPeriod(FicoPeriod parm);


        /// <summary>
        /// 批量导入
        /// 财务期间
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoPeriod(List<FicoPeriod> list);

        /// <summary>
        /// 导出
        /// 财务期间
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoPeriodDto> ExportList(FicoPeriodQueryDto parm);
    }
}
