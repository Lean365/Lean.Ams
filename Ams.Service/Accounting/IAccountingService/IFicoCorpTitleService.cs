using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 公司科目
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:26:58
    /// </summary>
    public interface IFicoCorpTitleService : IBaseService<FicoCorpTitle>
    {
        /// <summary>
        /// 获取公司科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoCorpTitleDto> GetList(FicoCorpTitleQueryDto parm);

        /// <summary>
        /// 获取公司科目信息
        /// </summary>
        /// <param name="FctSFID"></param>
        /// <returns></returns>
        FicoCorpTitle GetInfo(long FctSFID);

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
        FicoCorpTitle AddFicoCorpTitle(FicoCorpTitle parm);

        /// <summary>
        /// 更新
        /// 公司科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoCorpTitle(FicoCorpTitle parm);


        /// <summary>
        /// 批量导入
        /// 公司科目
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoCorpTitle(List<FicoCorpTitle> list);

        /// <summary>
        /// 导出
        /// 公司科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoCorpTitleDto> ExportList(FicoCorpTitleQueryDto parm);
    }
}
