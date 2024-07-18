using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 利润中心
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:26:49
    /// </summary>
    public interface IFicoPrctrService : IBaseService<FicoPrctr>
    {
        /// <summary>
        /// 获取利润中心列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoPrctrDto> GetList(FicoPrctrQueryDto parm);

        /// <summary>
        /// 获取利润中心信息
        /// </summary>
        /// <param name="FpSFID"></param>
        /// <returns></returns>
        FicoPrctr GetInfo(long FpSFID);

        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);

        /// <summary>
        /// 新增
        /// 利润中心
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoPrctr AddFicoPrctr(FicoPrctr parm);

        /// <summary>
        /// 更新
        /// 利润中心
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoPrctr(FicoPrctr parm);


        /// <summary>
        /// 批量导入
        /// 利润中心
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoPrctr(List<FicoPrctr> list);

        /// <summary>
        /// 导出
        /// 利润中心
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoPrctrDto> ExportList(FicoPrctrQueryDto parm);
    }
}
