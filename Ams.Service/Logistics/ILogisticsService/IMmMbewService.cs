using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 物料评估
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:30:25
    /// </summary>
    public interface IMmMbewService : IBaseService<MmMbew>
    {
        /// <summary>
        /// 获取物料评估列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmMbewDto> GetList(MmMbewQueryDto parm);

        /// <summary>
        /// 获取物料评估信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        MmMbew GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 物料评估
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        MmMbew AddMmMbew(MmMbew parm);

        /// <summary>
        /// 更新
        /// 物料评估
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateMmMbew(MmMbew parm);


        /// <summary>
        /// 批量导入
        /// 物料评估
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportMmMbew(List<MmMbew> list);

        /// <summary>
        /// 导出
        /// 物料评估
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmMbewDto> ExportList(MmMbewQueryDto parm);
    }
}
