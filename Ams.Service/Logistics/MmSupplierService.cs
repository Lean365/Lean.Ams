//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 供应商
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:53
    /// </summary>
    [AppService(ServiceType = typeof(IMmSupplierService), ServiceLifetime = LifeTime.Transient)]
    public class MmSupplierService : BaseService<MmSupplier>, IMmSupplierService
    {
        /// <summary>
        /// 查询供应商列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmSupplierDto> GetList(MmSupplierQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mf006 asc")
                .Where(predicate.ToExpression())
                .ToPage<MmSupplier, MmSupplierDto>(parm);

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
        public MmSupplier GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmSupplier AddMmSupplier(MmSupplier model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改供应商
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmSupplier(MmSupplier model)
        {
            return Update(model, true, "修改供应商");
        }

        /// <summary>
        /// 导入供应商
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmSupplier(List<MmSupplier> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mf002.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Mf003.IsEmpty(), "购买组织不能为空")
                .SplitError(x => x.Item.Mf004.IsEmpty(), "行业类别不能为空")
                .SplitError(x => x.Item.Mf005.IsEmpty(), "企业性质不能为空")
                .SplitError(x => x.Item.Mf006.IsEmpty(), "供应商代码不能为空")
                .SplitError(x => x.Item.Mf045.IsEmpty(), "交易冻结不能为空")
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
        /// 导出供应商
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmSupplierDto> ExportList(MmSupplierQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmSupplierDto()
                {
                    //查询字典: <购买组织> 
                    Mf003Label = it.Mf003.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <行业类别> 
                    Mf004Label = it.Mf004.GetConfigValue<SysDictData>("sys_ind_type"),
                    //查询字典: <企业性质> 
                    Mf005Label = it.Mf005.GetConfigValue<SysDictData>("sys_nature_list"),
                    //查询字典: <税别> 
                    Mf013Label = it.Mf013.GetConfigValue<SysDictData>("sys_tax_type"),
                    //查询字典: <采购组> 
                    Mf015Label = it.Mf015.GetConfigValue<SysDictData>("sys_pur_group"),
                    //查询字典: <交易币种> 
                    Mf016Label = it.Mf016.GetConfigValue<SysDictData>("sql_global_currency"),
                    //查询字典: <付款条件> 
                    Mf017Label = it.Mf017.GetConfigValue<SysDictData>("sys_payment_terms"),
                    //查询字典: <付款方式> 
                    Mf018Label = it.Mf018.GetConfigValue<SysDictData>("sys_payment_method"),
                    //查询字典: <统驭科目> 
                    Mf019Label = it.Mf019.GetConfigValue<SysDictData>("sql_mitkz_list"),
                    //查询字典: <贸易条件> 
                    Mf020Label = it.Mf020.GetConfigValue<SysDictData>("sys_terms_trade"),
                    //查询字典: <装运条件> 
                    Mf021Label = it.Mf021.GetConfigValue<SysDictData>("sys_cond_shipment"),
                    //查询字典: <运输方式> 
                    Mf022Label = it.Mf022.GetConfigValue<SysDictData>("sys_transport_method"),
                    //查询字典: <供应商等级> 
                    Mf023Label = it.Mf023.GetConfigValue<SysDictData>("sys_grade_list"),
                    //查询字典: <供应商信用> 
                    Mf024Label = it.Mf024.GetConfigValue<SysDictData>("sys_credit_list"),
                    //查询字典: <国家地区> 
                    Mf028Label = it.Mf028.GetConfigValue<SysDictData>("sql_global_country"),
                    //查询字典: <州省> 
                    Mf029Label = it.Mf029.GetConfigValue<SysDictData>("sql_global_state"),
                    //查询字典: <市> 
                    Mf030Label = it.Mf030.GetConfigValue<SysDictData>("sql_global_city"),
                    //查询字典: <交易冻结> 
                    Mf045Label = it.Mf045.GetConfigValue<SysDictData>("sys_freeze_flag"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<MmSupplier> QueryExp(MmSupplierQueryDto parm)
        {
            var predicate = Expressionable.Create<MmSupplier>();

            //查询字段: <购买组织> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf003), it => it.Mf003 == parm.Mf003);
            //查询字段: <行业类别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf004), it => it.Mf004 == parm.Mf004);
            //查询字段: <企业性质> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf005), it => it.Mf005 == parm.Mf005);
            //查询字段: <供应商代码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf006), it => it.Mf006.Contains(parm.Mf006));
            //查询字段: <供应商简称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf008), it => it.Mf008.Contains(parm.Mf008));
            //查询字段: <供应商名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf009), it => it.Mf009.Contains(parm.Mf009));
            //查询字段: <税别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf013), it => it.Mf013 == parm.Mf013);
            //查询字段: <采购组> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf015), it => it.Mf015 == parm.Mf015);
            //查询字段: <交易币种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf016), it => it.Mf016 == parm.Mf016);
            //查询字段: <付款条件> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf017), it => it.Mf017 == parm.Mf017);
            //查询字段: <付款方式> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf018), it => it.Mf018 == parm.Mf018);
            //查询字段: <统驭科目> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf019), it => it.Mf019 == parm.Mf019);
            //查询字段: <贸易条件> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf020), it => it.Mf020 == parm.Mf020);
            //查询字段: <供应商等级> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf023), it => it.Mf023 == parm.Mf023);
            //查询字段: <国家地区> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mf028), it => it.Mf028 == parm.Mf028);
            //查询字段: <交易冻结> 
            predicate = predicate.AndIF(parm.Mf045 != -1, it => it.Mf045 == parm.Mf045);
            return predicate;
        }
    }
}