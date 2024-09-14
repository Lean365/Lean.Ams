using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 出货检验
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:38:43
    /// </summary>
    public interface IQmOutgoingService : IBaseService<QmOutgoing>
    {
        /// <summary>
        /// 获取出货检验列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmOutgoingDto> GetList(QmOutgoingQueryDto parm);

        /// <summary>
        /// 获取出货检验信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        QmOutgoing GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 出货检验
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmOutgoing AddQmOutgoing(QmOutgoing parm);

        /// <summary>
        /// 更新
        /// 出货检验
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmOutgoing(QmOutgoing parm);


        /// <summary>
        /// 批量导入
        /// 出货检验
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmOutgoing(List<QmOutgoing> list);

        /// <summary>
        /// 导出
        /// 出货检验
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmOutgoingDto> ExportList(QmOutgoingQueryDto parm);
    }
}
