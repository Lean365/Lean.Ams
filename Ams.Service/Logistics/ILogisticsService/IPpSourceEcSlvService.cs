using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 从源设变
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:08:51
    /// </summary>
    public interface IPpSourceEcSlvService : IBaseService<PpSourceEcSlv>
    {
        /// <summary>
        /// 获取从源设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceEcSlvDto> GetList(PpSourceEcSlvQueryDto parm);

        /// <summary>
        /// 获取从源设变信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpSourceEcSlv GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 从源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpSourceEcSlv AddPpSourceEcSlv(PpSourceEcSlv parm);

        /// <summary>
        /// 更新
        /// 从源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpSourceEcSlv(PpSourceEcSlv parm);


        /// <summary>
        /// 批量导入
        /// 从源设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpSourceEcSlv(List<PpSourceEcSlv> list);

        /// <summary>
        /// 导出
        /// 从源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceEcSlvDto> ExportList(PpSourceEcSlvQueryDto parm);
    }
}
