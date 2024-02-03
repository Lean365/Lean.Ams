using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 会计科目
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public interface IAccountingTitleService : IBaseService<AccountingTitle>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<AccountingTitleDto> GetList(AccountingTitleQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="FatSFID"></param>
        /// <returns></returns>
        AccountingTitle GetInfo(long FatSFID);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        AccountingTitle AddAccountingTitle(AccountingTitle parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateAccountingTitle(AccountingTitle parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportAccountingTitle(List<AccountingTitle> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<AccountingTitleDto> ExportList(AccountingTitleQueryDto parm);
    }
}
