using Ams.Kernel;
using Ams.Model.Accounting;
using Ams.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams.Report.Accounting.co
{
    /// <summary>
    /// 物料
    /// 业务层接口
    /// </summary>
    public interface IInventoryService : IBaseService<MonthlyInventory>
    {
        /// <summary>
        /// 上月库存
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        dynamic QueryInventoryAmount(MonthlyInventoryQueryDto parm);
    }
}
