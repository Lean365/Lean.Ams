using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 抽样标准
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:39:24
    /// </summary>
    public interface IQmCheckAqlService : IBaseService<QmCheckAql>
    {
        /// <summary>
        /// 获取抽样标准列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmCheckAqlDto> GetList(QmCheckAqlQueryDto parm);

        /// <summary>
        /// 获取抽样标准信息
        /// </summary>
        /// <param name="QcaSfId"></param>
        /// <returns></returns>
        QmCheckAql GetInfo(long QcaSfId);
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
        QmCheckAql AddQmCheckAql(QmCheckAql parm);

        /// <summary>
        /// 更新
        /// 抽样标准
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmCheckAql(QmCheckAql parm);


        /// <summary>
        /// 批量导入
        /// 抽样标准
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmCheckAql(List<QmCheckAql> list);

        /// <summary>
        /// 导出
        /// 抽样标准
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmCheckAqlDto> ExportList(QmCheckAqlQueryDto parm);
    }
}
