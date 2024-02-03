using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 公司科目
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:11:12)
    /// </summary>
    public interface ICorpTitleService : IBaseService<CorpTitle>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<CorpTitleDto> GetList(CorpTitleQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="FctSFID"></param>
        /// <returns></returns>
        CorpTitle GetInfo(long FctSFID);

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
        CorpTitle AddCorpTitle(CorpTitle parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateCorpTitle(CorpTitle parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportCorpTitle(List<CorpTitle> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<CorpTitleDto> ExportList(CorpTitleQueryDto parm);
    }
}
