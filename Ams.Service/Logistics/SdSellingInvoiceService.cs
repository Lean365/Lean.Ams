using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 销售凭证
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 13:36:22
    /// </summary>
    [AppService(ServiceType = typeof(ISdSellingInvoiceService), ServiceLifetime = LifeTime.Transient)]
    public class SdSellingInvoiceService : BaseService<SdSellingInvoice>, ISdSellingInvoiceService
    {
        /// <summary>
        /// 查询销售凭证列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdSellingInvoiceDto> GetList(SdSellingInvoiceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<SdSellingInvoice, SdSellingInvoiceDto>(parm);

            return response;
        }
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString)
        {
            int count = Count(it => it. SsiSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="SsiSfId"></param>
        /// <returns></returns>
        public SdSellingInvoice GetInfo(long SsiSfId)
        {
            var response = Queryable()
                .Where(x => x.SsiSfId == SsiSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加销售凭证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SdSellingInvoice AddSdSellingInvoice(SdSellingInvoice model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改销售凭证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSdSellingInvoice(SdSellingInvoice model)
        {
            return Update(model, true, "修改销售凭证");
        }

        /// <summary>
        /// 导入销售凭证
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportSdSellingInvoice(List<SdSellingInvoice> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.SsiSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.SsiPlnt.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.SsiFy.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.SsiYm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.SsiAccdocno.IsEmpty(), "销售凭证不能为空")
                .SplitError(x => x.Item.SsiAccdoclineno.IsEmpty(), "凭证明细不能为空")
                .SplitError(x => x.Item.SsiCustomercode.IsEmpty(), "客户不能为空")
                .SplitError(x => x.Item.SsiPrctr.IsEmpty(), "利润中心不能为空")
                .SplitError(x => x.Item.SsiSalesitem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.SsiAccountcode.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.SsiSalesqty.IsEmpty(), "销售数量不能为空")
                .SplitError(x => x.Item.SsiSalesunit.IsEmpty(), "销售单位不能为空")
                .SplitError(x => x.Item.SsiOriginalamount.IsEmpty(), "原币销售额不能为空")
                .SplitError(x => x.Item.SsiOriginalccy.IsEmpty(), "原币币种不能为空")
                .SplitError(x => x.Item.SsiLocalamount.IsEmpty(), "本币销售额不能为空")
                .SplitError(x => x.Item.SsiLocalccy.IsEmpty(), "本币币种不能为空")
                .SplitError(x => x.Item.SsiRefdocno.IsEmpty(), "参考凭证不能为空")
                .SplitError(x => x.Item.SsiRefdoclineno.IsEmpty(), "参考明细不能为空")
                .SplitError(x => x.Item.SsiPostingdate.IsEmpty(), "过账日期不能为空")
                .SplitError(x => x.Item.SsiPostinguser.IsEmpty(), "用户不能为空")
                .SplitError(x => x.Item.SsiEntrydate.IsEmpty(), "输入日期不能为空")
                .SplitError(x => x.Item.SsiEntrytime.IsEmpty(), "输入时间不能为空")
                .SplitError(x => x.Item.SsiOrigin.IsEmpty(), "来源不能为空")
                .SplitError(x => x.Item.SsiPgroup.IsEmpty(), "产品组不能为空")
                .SplitError(x => x.Item.SsiAccdoctype.IsEmpty(), "凭证类型不能为空")
                .SplitError(x => x.Item.SsiAccdoctext.IsEmpty(), "凭证名称不能为空")
                .SplitError(x => x.Item.IsDeleted.IsEmpty(), "软删除不能为空")
                //.WhereColumns(it => it.UserName)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();//插入可插入部分;

            string msg = $"插入{x.InsertList.Count} 更新{x.UpdateList.Count} 错误数据{x.ErrorList.Count} 不计算数据{x.IgnoreList.Count} 删除数据{x.DeleteList.Count} 总共{x.TotalList.Count}";                    
            Console.WriteLine(msg);

            //输出错误信息               
            foreach (var item in x.ErrorList)
            {
                Console.WriteLine("错误" + item.StorageMessage);
            }
            foreach (var item in x.IgnoreList)
            {
                Console.WriteLine("忽略" + item.StorageMessage);
            }

            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 导出销售凭证
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdSellingInvoiceDto> ExportList(SdSellingInvoiceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new SdSellingInvoiceDto()
                {
                    SsiPlntLabel = it.SsiPlnt.GetConfigValue<SysDictData>("sys_plant_list"),
                    SsiFyLabel = it.SsiFy.GetConfigValue<SysDictData>("sql_fy_list"),
                    SsiYmLabel = it.SsiYm.GetConfigValue<SysDictData>("sql_ym_list"),
                    SsiCustomercodeLabel = it.SsiCustomercode.GetConfigValue<SysDictData>("sql_cus_list"),
                    SsiPrctrLabel = it.SsiPrctr.GetConfigValue<SysDictData>("sql_prctr_list"),
                    SsiOriginalccyLabel = it.SsiOriginalccy.GetConfigValue<SysDictData>("sys_ccy_type"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<SdSellingInvoice> QueryExp(SdSellingInvoiceQueryDto parm)
        {
            var predicate = Expressionable.Create<SdSellingInvoice>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SsiPlnt), it => it.SsiPlnt == parm.SsiPlnt);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SsiFy), it => it.SsiFy == parm.SsiFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SsiYm), it => it.SsiYm == parm.SsiYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SsiCustomercode), it => it.SsiCustomercode == parm.SsiCustomercode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SsiPrctr), it => it.SsiPrctr == parm.SsiPrctr);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SsiSalesitem), it => it.SsiSalesitem == parm.SsiSalesitem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SsiOriginalccy), it => it.SsiOriginalccy == parm.SsiOriginalccy);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginSsiPostingdate == null, it => it.SsiPostingdate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginSsiPostingdate == null, it => it.SsiPostingdate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginSsiPostingdate != null, it => it.SsiPostingdate >= parm.BeginSsiPostingdate);
            predicate = predicate.AndIF(parm.EndSsiPostingdate != null, it => it.SsiPostingdate <= parm.EndSsiPostingdate);
            return predicate;
        }
    }
}