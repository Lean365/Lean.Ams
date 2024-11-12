//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 客户
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/7 16:02:07
    /// </summary>
    [AppService(ServiceType = typeof(ISdClientService), ServiceLifetime = LifeTime.Transient)]
    public class SdClientService : BaseService<SdClient>, ISdClientService
    {
        /// <summary>
        /// 查询客户列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdClientDto> GetList(SdClientQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<SdClient, SdClientDto>(parm);

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
        public SdClient GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SdClient AddSdClient(SdClient model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSdClient(SdClient model)
        {
            return Update(model, true, "修改客户");
        }

        /// <summary>
        /// 导入客户
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportSdClient(List<SdClient> list)
        {
            list.ForEach(it =>
            {
                it.Create_by = HttpContextExtension.GetName(App.HttpContext);
                it.Remark = it.Remark.IsEmpty() ? HttpContextExtension.GetName(App.HttpContext)+"数据导入" : it.Remark;
            });
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Ma002.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Ma003.IsEmpty(), "销售组织不能为空")
                .SplitError(x => x.Item.Ma004.IsEmpty(), "行业类别不能为空")
                .SplitError(x => x.Item.Ma005.IsEmpty(), "企业性质不能为空")
                .SplitError(x => x.Item.Ma006.IsEmpty(), "客户代码不能为空")
                .SplitError(x => x.Item.Ma039.IsEmpty(), "冻结标记不能为空")
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
        /// 导出客户
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdClientDto> ExportList(SdClientQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new SdClientDto()
                {
                    //查询字典: <销售组织> 
                    Ma003Label = it.Ma003.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <行业类别> 
                    Ma004Label = it.Ma004.GetConfigValue<SysDictData>("sys_ind_type"),
                    //查询字典: <企业性质> 
                    Ma005Label = it.Ma005.GetConfigValue<SysDictData>("sys_nature_list"),
                    //查询字典: <税别> 
                    Ma012Label = it.Ma012.GetConfigValue<SysDictData>("sys_tax_type"),
                    //查询字典: <交易币种> 
                    Ma014Label = it.Ma014.GetConfigValue<SysDictData>("sql_global_currency"),
                    //查询字典: <付款条件> 
                    Ma015Label = it.Ma015.GetConfigValue<SysDictData>("sys_payment_terms"),
                    //查询字典: <付款方式> 
                    Ma016Label = it.Ma016.GetConfigValue<SysDictData>("sys_payment_method"),
                    //查询字典: <统驭科目> 
                    Ma017Label = it.Ma017.GetConfigValue<SysDictData>("sql_mitkz_list"),
                    //查询字典: <贸易条件> 
                    Ma018Label = it.Ma018.GetConfigValue<SysDictData>("sys_terms_trade"),
                    //查询字典: <装运条件> 
                    Ma019Label = it.Ma019.GetConfigValue<SysDictData>("sys_cond_shipment"),
                    //查询字典: <客户等级> 
                    Ma020Label = it.Ma020.GetConfigValue<SysDictData>("sys_grade_list"),
                    //查询字典: <客户信用> 
                    Ma021Label = it.Ma021.GetConfigValue<SysDictData>("sys_credit_list"),
                    //查询字典: <国家地区> 
                    Ma025Label = it.Ma025.GetConfigValue<SysDictData>("sql_global_country"),
                    //查询字典: <州省> 
                    Ma026Label = it.Ma026.GetConfigValue<SysDictData>("sql_global_state"),
                    //查询字典: <市> 
                    Ma027Label = it.Ma027.GetConfigValue<SysDictData>("sql_global_city"),
                    //查询字典: <冻结标记> 
                    Ma039Label = it.Ma039.GetConfigValue<SysDictData>("sys_freeze_flag"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<SdClient> QueryExp(SdClientQueryDto parm)
        {
            var predicate = Expressionable.Create<SdClient>();

            //查询字段: <销售组织> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma003), it => it.Ma003 == parm.Ma003);
            //查询字段: <行业类别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma004), it => it.Ma004 == parm.Ma004);
            //查询字段: <企业性质> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma005), it => it.Ma005 == parm.Ma005);
            //查询字段: <客户代码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma006), it => it.Ma006.Contains(parm.Ma006));
            //查询字段: <客户简称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma007), it => it.Ma007.Contains(parm.Ma007));
            //查询字段: <客户名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma008), it => it.Ma008.Contains(parm.Ma008));
            //查询字段: <税别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma012), it => it.Ma012 == parm.Ma012);
            //查询字段: <交易币种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma014), it => it.Ma014 == parm.Ma014);
            //查询字段: <付款条件> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma015), it => it.Ma015 == parm.Ma015);
            //查询字段: <付款方式> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma016), it => it.Ma016 == parm.Ma016);
            //查询字段: <统驭科目> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma017), it => it.Ma017 == parm.Ma017);
            //查询字段: <客户等级> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma020), it => it.Ma020 == parm.Ma020);
            //查询字段: <供应商> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma024), it => it.Ma024.Contains(parm.Ma024));
            //查询字段: <国家地区> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma025), it => it.Ma025 == parm.Ma025);
            //查询字段: <冻结标记> 
            predicate = predicate.AndIF(parm.Ma039 != -1, it => it.Ma039 == parm.Ma039);
            return predicate;
        }
    }
}