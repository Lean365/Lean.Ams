using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// PP客诉
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:14:58
    /// </summary>
    public interface IQmComplaintsPpService : IBaseService<QmComplaintsPp>
    {
        /// <summary>
        /// 获取PP客诉列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmComplaintsPpDto> GetList(QmComplaintsPpQueryDto parm);

        /// <summary>
        /// 获取PP客诉信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        QmComplaintsPp GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// PP客诉
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmComplaintsPp AddQmComplaintsPp(QmComplaintsPp parm);

        /// <summary>
        /// 更新
        /// PP客诉
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmComplaintsPp(QmComplaintsPp parm);


        /// <summary>
        /// 批量导入
        /// PP客诉
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmComplaintsPp(List<QmComplaintsPp> list);

        /// <summary>
        /// 导出
        /// PP客诉
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmComplaintsPpDto> ExportList(QmComplaintsPpQueryDto parm);
    }
}
