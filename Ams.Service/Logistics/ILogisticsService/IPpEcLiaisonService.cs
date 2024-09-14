using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 技联
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/13 10:18:56
    /// </summary>
    public interface IPpEcLiaisonService : IBaseService<PpEcLiaison>
    {
        /// <summary>
        /// 获取技联列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcLiaisonDto> GetList(PpEcLiaisonQueryDto parm);

        /// <summary>
        /// 获取技联信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpEcLiaison GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 技联
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcLiaison AddPpEcLiaison(PpEcLiaison parm);

        /// <summary>
        /// 更新
        /// 技联
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcLiaison(PpEcLiaison parm);


        /// <summary>
        /// 批量导入
        /// 技联
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcLiaison(List<PpEcLiaison> list);

        /// <summary>
        /// 导出
        /// 技联
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcLiaisonDto> ExportList(PpEcLiaisonQueryDto parm);
    }
}
