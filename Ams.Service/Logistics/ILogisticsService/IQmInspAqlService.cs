using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 抽样标准
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:39:16
    /// </summary>
    public interface IQmInspAqlService : IBaseService<QmInspAql>
    {
        /// <summary>
        /// 获取抽样标准列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmInspAqlDto> GetList(QmInspAqlQueryDto parm);

        /// <summary>
        /// 获取抽样标准信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        QmInspAql GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 抽样标准
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmInspAql AddQmInspAql(QmInspAql parm);

        /// <summary>
        /// 更新
        /// 抽样标准
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmInspAql(QmInspAql parm);


        /// <summary>
        /// 批量导入
        /// 抽样标准
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmInspAql(List<QmInspAql> list);

        /// <summary>
        /// 导出
        /// 抽样标准
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmInspAqlDto> ExportList(QmInspAqlQueryDto parm);
    }
}
