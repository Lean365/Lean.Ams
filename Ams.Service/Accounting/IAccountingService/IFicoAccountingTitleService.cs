using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 会计科目
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:53:13
    /// </summary>
    public interface IFicoAccountingTitleService : IBaseService<FicoAccountingTitle>
    {
        /// <summary>
        /// 获取会计科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoAccountingTitleDto> GetList(FicoAccountingTitleQueryDto parm);

        /// <summary>
        /// 获取会计科目信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoAccountingTitle GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 会计科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoAccountingTitle AddFicoAccountingTitle(FicoAccountingTitle parm);

        /// <summary>
        /// 更新
        /// 会计科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoAccountingTitle(FicoAccountingTitle parm);


        /// <summary>
        /// 批量导入
        /// 会计科目
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoAccountingTitle(List<FicoAccountingTitle> list);

        /// <summary>
        /// 导出
        /// 会计科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoAccountingTitleDto> ExportList(FicoAccountingTitleQueryDto parm);
    }
}
