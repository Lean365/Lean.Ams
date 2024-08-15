﻿using Ams.Model.Logistics.Dto;
using Ams.Statistics.Logistics.IService;
using SqlSugar;

namespace Ams.Statistics.Logistics.Service
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IOrderStatiService), ServiceLifetime = LifeTime.Transient)]
    public class OrderStatiService : BaseService<PpOrder>, IOrderStatiService
    {
        /// <summary>
        /// 查询最大ID
        /// </summary>
        /// <returns></returns>
        public dynamic GetMaxOrderNumber(string Type)
        {
            string? MaxID;
            var db = Context;
            long SfId = db.Queryable<PpOrder>().Where(s => s.MoType == Type).Max(it => it.MoNumber).ParseToLong();//异步
            if (!string.IsNullOrEmpty(SfId.ToString()) && SfId != 0)
            {
                MaxID = (SfId + 1).ToString();
            }
            else
            {
                MaxID = SnowFlakeSingle.instance.NextId().ToString();
            }

            return MaxID;
        }

        /// <summary>
        /// 按类型生成订单号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic GetNewOrderNumber(PpOrderQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .Max(it => it.MoNumber);//获取最大
            //.ToPage<Order, OrderDto>(parm);
            // .Max(it => it.MoOrderNo)
            if (response == null)
            {
                if (parm.MoType == "ZDTC")
                {
                    return response = "640000";
                }
                if (parm.MoType == "ZDTF")
                {
                    return response = "670000";
                }
                if (parm.MoType == "ZDTG")
                {
                    return response = "740000";
                }
                if (parm.MoType == "ZDTH")
                {
                    return response = "770000";
                }
            }
            else
            {
                return response = (response + 1).ToString();
            }

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpOrder> QueryExp(PpOrderQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）
            var predicate = Expressionable.Create<PpOrder>();
            //predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.CreateTime >= firstDayOfYear);
            //predicate = predicate.AndIF(parm.EndMoOrderDate == null, it => it.CreateTime <= lastDayOfYear);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MoType), it => it.MoType == parm.MoType);

            return predicate;
        }
    }
}