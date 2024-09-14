using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 不合格联络
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:41:22
    /// </summary>
    public interface IQmUnqLetterService : IBaseService<QmUnqLetter>
    {
        /// <summary>
        /// 获取不合格联络列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmUnqLetterDto> GetList(QmUnqLetterQueryDto parm);

        /// <summary>
        /// 获取不合格联络信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        QmUnqLetter GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 不合格联络
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        QmUnqLetter AddQmUnqLetter(QmUnqLetter parm);

        /// <summary>
        /// 更新
        /// 不合格联络
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateQmUnqLetter(QmUnqLetter parm);


        /// <summary>
        /// 批量导入
        /// 不合格联络
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportQmUnqLetter(List<QmUnqLetter> list);

        /// <summary>
        /// 导出
        /// 不合格联络
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<QmUnqLetterDto> ExportList(QmUnqLetterQueryDto parm);
    }
}
