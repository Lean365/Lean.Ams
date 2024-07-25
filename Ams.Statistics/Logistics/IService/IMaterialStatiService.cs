using Ams.Model.Logistics.Dto;

namespace Ams.Statistics.Logistics.IService
{
    /// <summary>
    /// 物料
    /// 业务层接口
    /// </summary>
    public interface IMaterialStatiService : IBaseService<MmMara>
    {
        /// <summary>
        /// 按类型生成物料号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic GetNewMaterialNumber(MmMaraQueryDto parm);
    }
}