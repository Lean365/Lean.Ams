using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 公积金
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:33:02
    /// </summary>
    public interface IRoutineEhrFundsService : IBaseService<RoutineEhrFunds>
    {
        /// <summary>
        /// 获取公积金列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrFundsDto> GetList(RoutineEhrFundsQueryDto parm);

        /// <summary>
        /// 获取公积金信息
        /// </summary>
        /// <param name="EfSfId"></param>
        /// <returns></returns>
        RoutineEhrFunds GetInfo(long EfSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 公积金
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        RoutineEhrFunds AddRoutineEhrFunds(RoutineEhrFunds parm);

        /// <summary>
        /// 更新
        /// 公积金
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineEhrFunds(RoutineEhrFunds parm);


        /// <summary>
        /// 批量导入
        /// 公积金
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineEhrFunds(List<RoutineEhrFunds> list);

        /// <summary>
        /// 导出
        /// 公积金
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrFundsDto> ExportList(RoutineEhrFundsQueryDto parm);
    }
}
