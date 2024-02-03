using Ams.Kernel;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ams.Kernel.Model.Dto.System;

namespace Ams.Report.Logistics.pp
{
    /// <summary>
    /// 业务层接口
    /// service接口
    /// </summary>
    public interface IProductionStatsService : IBaseService<OutputMaster>
    {
        /// <summary>
        /// 查找当前表中最大ID
        /// </summary>
        /// <returns></returns>
        string QueryMaxSfid();

        /// <summary>
        /// 本月生产台数
        /// </summary>
        /// <returns></returns>
        int QueryMonthlyProductionQty(OutputMasterQueryDto parm);

        /// <summary>
        /// 按月统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthOutput(OutputMasterQueryDto parm);
        /// <summary>
        /// 月度OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportMonthOutputList(OutputMasterQueryDto parm);
        /// <summary>
        /// 按月，班组统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthLineOutput(OutputMasterQueryDto parm);


        /// <summary>
        /// 按月，班组统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthLineOutputBar(OutputMasterQueryDto parm);

        /// <summary>
        /// 当月，班组统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountCurrentMonthOutputBar(OutputMasterQueryDto parm);
        /// <summary>
        /// 月度OPH-班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportMonthLineOutputList(OutputMasterQueryDto parm);
        /// <summary>
        /// 按月，机种统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthModelOutput(OutputMasterQueryDto parm);
        /// <summary>
        /// 月度OPH-机种
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportMonthModelOutputList(OutputMasterQueryDto parm);

        /// <summary>
        /// 按年统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearOutput(OutputMasterQueryDto parm);
        /// <summary>
        /// 年度OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportYearOutputList(OutputMasterQueryDto parm);
        /// <summary>
        /// 按年，班组统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearLineOutput(OutputMasterQueryDto parm);
        /// <summary>
        /// 年度OPH-班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportYearLineOutputList(OutputMasterQueryDto parm);
        /// <summary>
        /// 按年，机种统计OPH
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearModelOutput(OutputMasterQueryDto parm);
        /// <summary>
        /// 年度OPH-机种
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic ExportYearModelOutputList(OutputMasterQueryDto parm);
        /// <summary>
        /// 按月统计Ec
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthEc(OutputMasterQueryDto parm);
        /// <summary>
        /// 按月统计不良
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthDefective(OutputMasterQueryDto parm);
        /// <summary>
        /// 按月统计工数
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthLaborhours(OutputMasterQueryDto parm);

        /// <summary>
        /// 按月统计IQC进货
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthIncoming(OutputMasterQueryDto parm);
        /// <summary>
        /// 按月统计QA出货
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthOutgoing(OutputMasterQueryDto parm);
        /// <summary>
        /// 按月统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthSales(OutputMasterQueryDto parm);
        /// <summary>
        /// 按月,国家统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthAreaSales(OutputMasterQueryDto parm);
        /// <summary>
        /// 按月,仕向统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthRegionSales(OutputMasterQueryDto parm);

        /// <summary>
        /// 按年统计Ec
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearEc(OutputMasterQueryDto parm);
        /// <summary>
        /// 按年统计不良
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearDefective(OutputMasterQueryDto parm);
        /// <summary>
        /// 按年统计工数
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearLaborhours(OutputMasterQueryDto parm);

        /// <summary>
        /// 按年统计IQC进货
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearIncoming(OutputMasterQueryDto parm);
        /// <summary>
        /// 按年统计QA出货
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearOutgoing(OutputMasterQueryDto parm);
        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearSales(OutputMasterQueryDto parm);
        /// <summary>
        /// 按年,国家统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearAreaSales(OutputMasterQueryDto parm);
        /// <summary>
        /// 按年,仕向统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearRegionSales(OutputMasterQueryDto parm);

    }
}