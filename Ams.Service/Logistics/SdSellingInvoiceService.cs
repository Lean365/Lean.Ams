//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 销售凭证
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/7 16:16:45
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
                //.OrderBy("Mc004 desc")
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
            int count = Count(it => it. Id.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SdSellingInvoice GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
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
            list.ForEach(it =>
            {
                it.Create_by = HttpContextExtension.GetName(App.HttpContext);
                it.Remark = it.Remark.IsEmpty() ? "数据由<"+HttpContextExtension.GetName(App.HttpContext)+">用户,批量导入" : it.Remark;
            });
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mc002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Mc003.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.Mc004.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mc005.IsEmpty(), "销售凭证不能为空")
                .SplitError(x => x.Item.Mc006.IsEmpty(), "凭证明细不能为空")
                .SplitError(x => x.Item.Mc007.IsEmpty(), "客户不能为空")
                .SplitError(x => x.Item.Mc008.IsEmpty(), "机种名称不能为空")
                .SplitError(x => x.Item.Mc009.IsEmpty(), "利润中心不能为空")
                .SplitError(x => x.Item.Mc010.IsEmpty(), "销售物料不能为空")
                .SplitError(x => x.Item.Mc011.IsEmpty(), "科目代码不能为空")
                .SplitError(x => x.Item.Mc012.IsEmpty(), "销售数量不能为空")
                .SplitError(x => x.Item.Mc013.IsEmpty(), "销售单位不能为空")
                .SplitError(x => x.Item.Mc014.IsEmpty(), "原币销售额不能为空")
                .SplitError(x => x.Item.Mc015.IsEmpty(), "原币币种不能为空")
                .SplitError(x => x.Item.Mc016.IsEmpty(), "本币销售额不能为空")
                .SplitError(x => x.Item.Mc017.IsEmpty(), "本币币种不能为空")
                .SplitError(x => x.Item.Mc018.IsEmpty(), "参考凭证不能为空")
                .SplitError(x => x.Item.Mc019.IsEmpty(), "参考明细不能为空")
                .SplitError(x => x.Item.Mc020.IsEmpty(), "过账日期不能为空")
                .SplitError(x => x.Item.Mc026.IsEmpty(), "物料类型不能为空")
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
                    //查询字典: <工厂> 
                    Mc002Label = it.Mc002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <期间> 
                    Mc003Label = it.Mc003.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月> 
                    Mc004Label = it.Mc004.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <客户> 
                    Mc007Label = it.Mc007.GetConfigValue<SysDictData>("sql_cus_list"),
                    //查询字典: <利润中心> 
                    Mc009Label = it.Mc009.GetConfigValue<SysDictData>("sql_prctr_list"),
                    //查询字典: <物料类型> 
                    Mc026Label = it.Mc026.GetConfigValue<SysDictData>("sys_matl_category"),
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

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc002), it => it.Mc002 == parm.Mc002);
            //查询字段: <期间> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc003), it => it.Mc003 == parm.Mc003);
            //查询字段: <年月> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc004), it => it.Mc004 == parm.Mc004);
            //查询字段: <客户> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc007), it => it.Mc007 == parm.Mc007);
            //查询字段: <机种名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc008), it => it.Mc008.Contains(parm.Mc008));
            //查询字段: <利润中心> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc009), it => it.Mc009 == parm.Mc009);
            //查询字段: <销售物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc010), it => it.Mc010.Contains(parm.Mc010));
            //查询字段: <物料类型> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc026), it => it.Mc026 == parm.Mc026);
            return predicate;
        }
    }
}