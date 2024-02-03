using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 物料评估
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 15:30:16)
    /// </summary>
    public interface IMbewService : IBaseService<Mbew>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MbewDto> GetList(MbewQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="MbewSFID"></param>
        /// <returns></returns>
        Mbew GetInfo(long MbewSFID);

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
        Mbew AddMbew(Mbew parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateMbew(Mbew parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportMbew(List<Mbew> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MbewDto> ExportList(MbewQueryDto parm);
    }
}
