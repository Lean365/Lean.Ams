using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 品质业务
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:48:39
    /// </summary>
    public interface IQmCostOperationService : IBaseService<QmCostOperation>
    {
        /// <summary>
        /// 获取品质业务列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmCostOperationDto> GetList(QmCostOperationQueryDto parm);

        /// <summary>
        /// 获取品质业务信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        QmCostOperation GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 品质业务
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmCostOperation AddQmCostOperation(QmCostOperation parm);

        /// <summary>
        /// 更新
        /// 品质业务
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmCostOperation(QmCostOperation parm);


        /// <summary>
        /// 批量导入
        /// 品质业务
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmCostOperation(List<QmCostOperation> list);

        /// <summary>
        /// 导出
        /// 品质业务
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmCostOperationDto> ExportList(QmCostOperationQueryDto parm);
    }
}
