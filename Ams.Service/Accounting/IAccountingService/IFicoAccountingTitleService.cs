using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 会计科目
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2023/12/26 7:53:53)
    /// </summary>
    public interface IFicoAccountingTitleService : IBaseService<FicoAccountingTitle>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoAccountingTitleDto> GetList(FicoAccountingTitleQueryDto parm);
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="FtSFID"></param>
        /// <returns></returns>
        FicoAccountingTitle GetInfo(long FtSFID);

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
        FicoAccountingTitle AddFicoAccountingTitle(FicoAccountingTitle parm);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoAccountingTitle(FicoAccountingTitle parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoAccountingTitle(List<FicoAccountingTitle> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoAccountingTitleDto> ExportList(FicoAccountingTitleQueryDto parm);
    }
}
