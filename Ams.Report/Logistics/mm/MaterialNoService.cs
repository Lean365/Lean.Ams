using Ams.Infrastructure.Attribute;
using Ams.Kernel;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams.Report.Logistics.mm
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IMaterialNoService), ServiceLifetime = LifeTime.Transient)]
    public class MaterialNoService : BaseService<Marb>, IMaterialNoService
    {
        /// <summary>
        /// 按物料生成物料号码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic QueryMaterialNo(MarbQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .Max(it => it.MmMatItem);//最大订单号
            //.ToPage<Order, OrderDto>(parm);
            // .Max(it => it.MoOrderNo)
            if (response == null)
            {
                return "0000000000";

            }

            return response;



        }
        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Marb> QueryExp(MarbQueryDto parm)
        {

            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）
            var predicate = Expressionable.Create<Marb>();
            //predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.CreateTime >= firstDayOfYear);
            //predicate = predicate.AndIF(parm.EndMoOrderDate == null, it => it.CreateTime <= lastDayOfYear);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatItem), it => it.MmMatItem == parm.MmMatItem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatItem), it => it.MmMatItem.Substring(0, 2).Contains(parm.MmMatItem));
            return predicate;
        }
    }
}
