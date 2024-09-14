using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 公司科目
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:35:01
    /// </summary>
    public interface IFicoAccountingCorpService : IBaseService<FicoAccountingCorp>
    {
        /// <summary>
        /// 获取公司科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoAccountingCorpDto> GetList(FicoAccountingCorpQueryDto parm);

        /// <summary>
        /// 获取公司科目信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoAccountingCorp GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 公司科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoAccountingCorp AddFicoAccountingCorp(FicoAccountingCorp parm);

        /// <summary>
        /// 更新
        /// 公司科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoAccountingCorp(FicoAccountingCorp parm);


        /// <summary>
        /// 批量导入
        /// 公司科目
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoAccountingCorp(List<FicoAccountingCorp> list);

        /// <summary>
        /// 导出
        /// 公司科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoAccountingCorpDto> ExportList(FicoAccountingCorpQueryDto parm);
    }
}
