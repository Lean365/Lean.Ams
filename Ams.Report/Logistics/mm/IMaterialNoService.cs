using Ams.Kernel;
using Ams.Model.Dto;
using Ams.Model.Logistics;

namespace Ams.Report.Logistics.mm
{
    /// <summary>
    /// 物料
    /// 业务层接口
    /// </summary>
    public interface IMaterialNoService : IBaseService<Marb>
    {
        /// <summary>
        /// 按类型生成物料号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic QueryMaterialNo(MarbQueryDto parm);
    }
}
