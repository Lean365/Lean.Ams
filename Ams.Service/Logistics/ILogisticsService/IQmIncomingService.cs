using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 进料检验
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:45:51
    /// </summary>
    public interface IQmIncomingService : IBaseService<QmIncoming>
    {
        /// <summary>
        /// 获取进料检验列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmIncomingDto> GetList(QmIncomingQueryDto parm);

        /// <summary>
        /// 获取进料检验信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        QmIncoming GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 进料检验
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmIncoming AddQmIncoming(QmIncoming parm);

        /// <summary>
        /// 更新
        /// 进料检验
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmIncoming(QmIncoming parm);


        /// <summary>
        /// 批量导入
        /// 进料检验
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmIncoming(List<QmIncoming> list);

        /// <summary>
        /// 导出
        /// 进料检验
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmIncomingDto> ExportList(QmIncomingQueryDto parm);
    }
}
