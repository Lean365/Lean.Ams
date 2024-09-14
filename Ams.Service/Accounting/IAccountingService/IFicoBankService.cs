using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 银行
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:43:04
    /// </summary>
    public interface IFicoBankService : IBaseService<FicoBank>
    {
        /// <summary>
        /// 获取银行列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBankDto> GetList(FicoBankQueryDto parm);

        /// <summary>
        /// 获取银行信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoBank GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 银行
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBank AddFicoBank(FicoBank parm);

        /// <summary>
        /// 更新
        /// 银行
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBank(FicoBank parm);


        /// <summary>
        /// 批量导入
        /// 银行
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBank(List<FicoBank> list);

        /// <summary>
        /// 导出
        /// 银行
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBankDto> ExportList(FicoBankQueryDto parm);
    }
}
