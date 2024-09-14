//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 销售商
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:56
    /// </summary>
    [AppService(ServiceType = typeof(IMmVendorService), ServiceLifetime = LifeTime.Transient)]
    public class MmVendorService : BaseService<MmVendor>, IMmVendorService
    {
        /// <summary>
        /// 查询销售商列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmVendorDto> GetList(MmVendorQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mg006 asc")
                .Where(predicate.ToExpression())
                .ToPage<MmVendor, MmVendorDto>(parm);

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
        public MmVendor GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加销售商
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmVendor AddMmVendor(MmVendor model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改销售商
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmVendor(MmVendor model)
        {
            return Update(model, true, "修改销售商");
        }

        /// <summary>
        /// 导入销售商
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmVendor(List<MmVendor> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mg002.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Mg003.IsEmpty(), "购买组织不能为空")
                .SplitError(x => x.Item.Mg004.IsEmpty(), "行业类别不能为空")
                .SplitError(x => x.Item.Mg005.IsEmpty(), "企业性质不能为空")
                .SplitError(x => x.Item.Mg006.IsEmpty(), "供应商代码不能为空")
                .SplitError(x => x.Item.Mg051.IsEmpty(), "交易冻结不能为空")
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
        /// 导出销售商
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmVendorDto> ExportList(MmVendorQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmVendorDto()
                {
                    //查询字典: <购买组织> 
                    Mg003Label = it.Mg003.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <行业类别> 
                    Mg004Label = it.Mg004.GetConfigValue<SysDictData>("sys_ind_type"),
                    //查询字典: <企业性质> 
                    Mg005Label = it.Mg005.GetConfigValue<SysDictData>("sys_nature_list"),
                    //查询字典: <税别> 
                    Mg015Label = it.Mg015.GetConfigValue<SysDictData>("sys_tax_type"),
                    //查询字典: <采购组> 
                    Mg017Label = it.Mg017.GetConfigValue<SysDictData>("sys_pur_group"),
                    //查询字典: <交易币种> 
                    Mg019Label = it.Mg019.GetConfigValue<SysDictData>("sql_global_currency"),
                    //查询字典: <付款条件> 
                    Mg020Label = it.Mg020.GetConfigValue<SysDictData>("sys_payment_terms"),
                    //查询字典: <付款方式> 
                    Mg021Label = it.Mg021.GetConfigValue<SysDictData>("sys_payment_method"),
                    //查询字典: <统驭科目> 
                    Mg022Label = it.Mg022.GetConfigValue<SysDictData>("sql_mitkz_list"),
                    //查询字典: <贸易条件> 
                    Mg023Label = it.Mg023.GetConfigValue<SysDictData>("sys_terms_trade"),
                    //查询字典: <装运条件> 
                    Mg024Label = it.Mg024.GetConfigValue<SysDictData>("sys_cond_shipment"),
                    //查询字典: <运输方式> 
                    Mg025Label = it.Mg025.GetConfigValue<SysDictData>("sys_transport_method"),
                    //查询字典: <供应商等级> 
                    Mg026Label = it.Mg026.GetConfigValue<SysDictData>("sys_grade_list"),
                    //查询字典: <供应商信用> 
                    Mg027Label = it.Mg027.GetConfigValue<SysDictData>("sys_credit_list"),
                    //查询字典: <国家地区> 
                    Mg031Label = it.Mg031.GetConfigValue<SysDictData>("sql_global_country"),
                    //查询字典: <州省> 
                    Mg032Label = it.Mg032.GetConfigValue<SysDictData>("sql_global_state"),
                    //查询字典: <市> 
                    Mg033Label = it.Mg033.GetConfigValue<SysDictData>("sql_global_city"),
                    //查询字典: <交易冻结> 
                    Mg051Label = it.Mg051.GetConfigValue<SysDictData>("sys_freeze_flag"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<MmVendor> QueryExp(MmVendorQueryDto parm)
        {
            var predicate = Expressionable.Create<MmVendor>();

            //查询字段: <购买组织> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg003), it => it.Mg003 == parm.Mg003);
            //查询字段: <行业类别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg004), it => it.Mg004 == parm.Mg004);
            //查询字段: <企业性质> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg005), it => it.Mg005 == parm.Mg005);
            //查询字段: <供应商代码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg006), it => it.Mg006.Contains(parm.Mg006));
            //查询字段: <供应商简称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg008), it => it.Mg008.Contains(parm.Mg008));
            //查询字段: <供应商名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg010), it => it.Mg010.Contains(parm.Mg010));
            //查询字段: <税别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg015), it => it.Mg015 == parm.Mg015);
            //查询字段: <采购组> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg017), it => it.Mg017 == parm.Mg017);
            //查询字段: <交易币种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg019), it => it.Mg019 == parm.Mg019);
            //查询字段: <付款条件> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg020), it => it.Mg020 == parm.Mg020);
            //查询字段: <付款方式> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg021), it => it.Mg021 == parm.Mg021);
            //查询字段: <统驭科目> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg022), it => it.Mg022 == parm.Mg022);
            //查询字段: <贸易条件> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg023), it => it.Mg023 == parm.Mg023);
            //查询字段: <供应商等级> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg026), it => it.Mg026 == parm.Mg026);
            //查询字段: <国家地区> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mg031), it => it.Mg031 == parm.Mg031);
            //查询字段: <交易冻结> 
            predicate = predicate.AndIF(parm.Mg051 != -1, it => it.Mg051 == parm.Mg051);
            return predicate;
        }
    }
}