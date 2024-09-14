using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 组立OPH
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:21:13
    /// </summary>
    public interface IPpOutputAssyMaService : IBaseService<PpOutputAssyMa>
    {
        /// <summary>
        /// 获取组立OPH列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputAssyMaDto> GetList(PpOutputAssyMaQueryDto parm);

        /// <summary>
        /// 获取组立OPH信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpOutputAssyMa GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 组立OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpOutputAssyMa AddPpOutputAssyMa(PpOutputAssyMa parm);

        /// <summary>
        /// 更新
        /// 组立OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOutputAssyMa(PpOutputAssyMa parm);


        /// <summary>
        /// 批量导入
        /// 组立OPH
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpOutputAssyMa(List<PpOutputAssyMa> list);

        /// <summary>
        /// 导出
        /// 组立OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputAssyMaDto> ExportList(PpOutputAssyMaQueryDto parm);
    }
}
