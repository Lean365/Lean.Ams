using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 工厂代码
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:16:10
    /// </summary>
    public interface IInstPlantService : IBaseService<InstPlant>
    {
        /// <summary>
        /// 获取工厂代码列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstPlantDto> GetList(InstPlantQueryDto parm);

        /// <summary>
        /// 获取工厂代码信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        InstPlant GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 工厂代码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        InstPlant AddInstPlant(InstPlant parm);

        /// <summary>
        /// 更新
        /// 工厂代码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateInstPlant(InstPlant parm);


        /// <summary>
        /// 批量导入
        /// 工厂代码
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportInstPlant(List<InstPlant> list);

        /// <summary>
        /// 导出
        /// 工厂代码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstPlantDto> ExportList(InstPlantQueryDto parm);
    }
}
