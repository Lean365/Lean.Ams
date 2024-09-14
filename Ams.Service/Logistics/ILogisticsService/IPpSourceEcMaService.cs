using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 主源设变
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:09:51
    /// </summary>
    public interface IPpSourceEcMaService : IBaseService<PpSourceEcMa>
    {
        /// <summary>
        /// 获取主源设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceEcMaDto> GetList(PpSourceEcMaQueryDto parm);

        /// <summary>
        /// 获取主源设变信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpSourceEcMa GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 主源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpSourceEcMa AddPpSourceEcMa(PpSourceEcMa parm);

        /// <summary>
        /// 更新
        /// 主源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpSourceEcMa(PpSourceEcMa parm);


        /// <summary>
        /// 批量导入
        /// 主源设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpSourceEcMa(List<PpSourceEcMa> list);

        /// <summary>
        /// 导出
        /// 主源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceEcMaDto> ExportList(PpSourceEcMaQueryDto parm);
    }
}
