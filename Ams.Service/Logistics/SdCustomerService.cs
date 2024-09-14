//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 顾客
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:25:01
    /// </summary>
    [AppService(ServiceType = typeof(ISdCustomerService), ServiceLifetime = LifeTime.Transient)]
    public class SdCustomerService : BaseService<SdCustomer>, ISdCustomerService
    {
        /// <summary>
        /// 查询顾客列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdCustomerDto> GetList(SdCustomerQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mb003 asc")
                .Where(predicate.ToExpression())
                .ToPage<SdCustomer, SdCustomerDto>(parm);

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
        public SdCustomer GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加顾客
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SdCustomer AddSdCustomer(SdCustomer model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改顾客
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSdCustomer(SdCustomer model)
        {
            return Update(model, true, "修改顾客");
        }

        /// <summary>
        /// 导入顾客
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportSdCustomer(List<SdCustomer> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mb002.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Mb003.IsEmpty(), "销售组织不能为空")
                .SplitError(x => x.Item.Mb004.IsEmpty(), "行业类别不能为空")
                .SplitError(x => x.Item.Mb005.IsEmpty(), "企业性质不能为空")
                .SplitError(x => x.Item.Mb006.IsEmpty(), "客户代码不能为空")
                .SplitError(x => x.Item.Mb039.IsEmpty(), "冻结标记不能为空")
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
        /// 导出顾客
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdCustomerDto> ExportList(SdCustomerQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new SdCustomerDto()
                {
                    //查询字典: <销售组织> 
                    Mb003Label = it.Mb003.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <行业类别> 
                    Mb004Label = it.Mb004.GetConfigValue<SysDictData>("sys_ind_type"),
                    //查询字典: <企业性质> 
                    Mb005Label = it.Mb005.GetConfigValue<SysDictData>("sys_nature_list"),
                    //查询字典: <税别> 
                    Mb012Label = it.Mb012.GetConfigValue<SysDictData>("sys_tax_type"),
                    //查询字典: <交易币种> 
                    Mb014Label = it.Mb014.GetConfigValue<SysDictData>("sql_global_currency"),
                    //查询字典: <付款条件> 
                    Mb015Label = it.Mb015.GetConfigValue<SysDictData>("sys_payment_terms"),
                    //查询字典: <付款方式> 
                    Mb016Label = it.Mb016.GetConfigValue<SysDictData>("sys_payment_method"),
                    //查询字典: <统驭科目> 
                    Mb017Label = it.Mb017.GetConfigValue<SysDictData>("sql_mitkz_list"),
                    //查询字典: <贸易条件> 
                    Mb018Label = it.Mb018.GetConfigValue<SysDictData>("sys_terms_trade"),
                    //查询字典: <装运条件> 
                    Mb019Label = it.Mb019.GetConfigValue<SysDictData>("sys_cond_shipment"),
                    //查询字典: <客户等级> 
                    Mb020Label = it.Mb020.GetConfigValue<SysDictData>("sys_grade_list"),
                    //查询字典: <客户信用> 
                    Mb021Label = it.Mb021.GetConfigValue<SysDictData>("sys_credit_list"),
                    //查询字典: <国家地区> 
                    Mb025Label = it.Mb025.GetConfigValue<SysDictData>("sql_global_country"),
                    //查询字典: <州省> 
                    Mb026Label = it.Mb026.GetConfigValue<SysDictData>("sql_global_state"),
                    //查询字典: <市> 
                    Mb027Label = it.Mb027.GetConfigValue<SysDictData>("sql_global_city"),
                    //查询字典: <冻结标记> 
                    Mb039Label = it.Mb039.GetConfigValue<SysDictData>("sys_freeze_flag"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<SdCustomer> QueryExp(SdCustomerQueryDto parm)
        {
            var predicate = Expressionable.Create<SdCustomer>();

            //查询字段: <销售组织> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb003), it => it.Mb003 == parm.Mb003);
            //查询字段: <行业类别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb004), it => it.Mb004 == parm.Mb004);
            //查询字段: <企业性质> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb005), it => it.Mb005 == parm.Mb005);
            //查询字段: <客户代码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb006), it => it.Mb006.Contains(parm.Mb006));
            //查询字段: <客户简称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb007), it => it.Mb007.Contains(parm.Mb007));
            //查询字段: <客户名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb008), it => it.Mb008.Contains(parm.Mb008));
            //查询字段: <交易币种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb014), it => it.Mb014 == parm.Mb014);
            //查询字段: <付款条件> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb015), it => it.Mb015 == parm.Mb015);
            //查询字段: <客户等级> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb020), it => it.Mb020 == parm.Mb020);
            //查询字段: <供应商> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb024), it => it.Mb024.Contains(parm.Mb024));
            //查询字段: <国家地区> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb025), it => it.Mb025 == parm.Mb025);
            return predicate;
        }
    }
}