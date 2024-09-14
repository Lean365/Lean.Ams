using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 公司代码
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:19:56
    /// </summary>
    public interface IInstCorpService : IBaseService<InstCorp>
    {
        /// <summary>
        /// 获取公司代码列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstCorpDto> GetList(InstCorpQueryDto parm);

        /// <summary>
        /// 获取公司代码信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        InstCorp GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 公司代码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        InstCorp AddInstCorp(InstCorp parm);

        /// <summary>
        /// 更新
        /// 公司代码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateInstCorp(InstCorp parm);


        /// <summary>
        /// 批量导入
        /// 公司代码
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportInstCorp(List<InstCorp> list);

        /// <summary>
        /// 导出
        /// 公司代码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstCorpDto> ExportList(InstCorpQueryDto parm);
    }
}
