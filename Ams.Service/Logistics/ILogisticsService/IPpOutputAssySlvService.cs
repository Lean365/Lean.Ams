using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 组立明细
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:52
    /// </summary>
    public interface IPpOutputAssySlvService : IBaseService<PpOutputAssySlv>
    {
        /// <summary>
        /// 获取组立明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputAssySlvDto> GetList(PpOutputAssySlvQueryDto parm);

        /// <summary>
        /// 获取组立明细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpOutputAssySlv GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 组立明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpOutputAssySlv AddPpOutputAssySlv(PpOutputAssySlv parm);

        /// <summary>
        /// 更新
        /// 组立明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOutputAssySlv(PpOutputAssySlv parm);


        /// <summary>
        /// 批量导入
        /// 组立明细
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpOutputAssySlv(List<PpOutputAssySlv> list);

        /// <summary>
        /// 导出
        /// 组立明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputAssySlvDto> ExportList(PpOutputAssySlvQueryDto parm);
    }
}
