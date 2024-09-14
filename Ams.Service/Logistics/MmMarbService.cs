//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 物料信息
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:22:47
    /// </summary>
    [AppService(ServiceType = typeof(IMmMarbService), ServiceLifetime = LifeTime.Transient)]
    public class MmMarbService : BaseService<MmMarb>, IMmMarbService
    {
        /// <summary>
        /// 查询物料信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMarbDto> GetList(MmMarbQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mb003 asc")
                .Where(predicate.ToExpression())
                .ToPage<MmMarb, MmMarbDto>(parm);

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
        public MmMarb GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加物料信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmMarb AddMmMarb(MmMarb model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改物料信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmMarb(MmMarb model)
        {
            return Update(model, true, "修改物料信息");
        }

        /// <summary>
        /// 导入物料信息
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmMarb(List<MmMarb> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mb002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Mb003.IsEmpty(), "物料号不能为空")
                .SplitError(x => x.Item.Mb004.IsEmpty(), "行业领域不能为空")
                .SplitError(x => x.Item.Mb005.IsEmpty(), "物料类型不能为空")
                .SplitError(x => x.Item.Mb028.IsEmpty(), "币种不能为空")
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
        /// 导出物料信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMarbDto> ExportList(MmMarbQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmMarbDto()
                {
                    //查询字典: <工厂> 
                    Mb002Label = it.Mb002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <行业领域> 
                    Mb004Label = it.Mb004.GetConfigValue<SysDictData>("sys_ind_type"),
                    //查询字典: <物料类型> 
                    Mb005Label = it.Mb005.GetConfigValue<SysDictData>("sys_matl_type"),
                    //查询字典: <基本单位> 
                    Mb007Label = it.Mb007.GetConfigValue<SysDictData>("sys_unit_list"),
                    //查询字典: <物料组> 
                    Mb009Label = it.Mb009.GetConfigValue<SysDictData>("sys_matl_group"),
                    //查询字典: <采购组> 
                    Mb010Label = it.Mb010.GetConfigValue<SysDictData>("sys_pur_group"),
                    //查询字典: <采购> 
                    Mb011Label = it.Mb011.GetConfigValue<SysDictData>("sys_pur_type"),
                    //查询字典: <特殊采购> 
                    Mb012Label = it.Mb012.GetConfigValue<SysDictData>("sys_pur_spec"),
                    //查询字典: <利润中心> 
                    Mb021Label = it.Mb021.GetConfigValue<SysDictData>("sql_prctr_list"),
                    //查询字典: <评估类> 
                    Mb026Label = it.Mb026.GetConfigValue<SysDictData>("sys_val_type"),
                    //查询字典: <币种> 
                    Mb028Label = it.Mb028.GetConfigValue<SysDictData>("sql_global_currency"),
                    //查询字典: <发货库存地点> 
                    Mb031Label = it.Mb031.GetConfigValue<SysDictData>("sys_sloc_list"),
                    //查询字典: <库存仓位> 
                    Mb033Label = it.Mb033.GetConfigValue<SysDictData>("sys_whse_location"),
                    //查询字典: <工厂级删除标记> 
                    Mb035Label = it.Mb035.GetConfigValue<SysDictData>("sys_eol_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<MmMarb> QueryExp(MmMarbQueryDto parm)
        {
            var predicate = Expressionable.Create<MmMarb>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb002), it => it.Mb002 == parm.Mb002);
            //查询字段: <物料号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb003), it => it.Mb003.Contains(parm.Mb003));
            //查询字段: <行业领域> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb004), it => it.Mb004 == parm.Mb004);
            //查询字段: <物料类型> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb005), it => it.Mb005 == parm.Mb005);
            //查询字段: <物料描述> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb006), it => it.Mb006.Contains(parm.Mb006));
            //查询字段: <基本单位> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb007), it => it.Mb007 == parm.Mb007);
            //查询字段: <物料组> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb009), it => it.Mb009 == parm.Mb009);
            //查询字段: <采购组> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb010), it => it.Mb010 == parm.Mb010);
            //查询字段: <采购> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb011), it => it.Mb011 == parm.Mb011);
            //查询字段: <特殊采购> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb012), it => it.Mb012 == parm.Mb012);
            //查询字段: <散装物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb013), it => it.Mb013.Contains(parm.Mb013));
            //查询字段: <利润中心> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb021), it => it.Mb021 == parm.Mb021);
            //查询字段: <批次管理> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb023), it => it.Mb023 == parm.Mb023);
            //查询字段: <评估类> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb026), it => it.Mb026 == parm.Mb026);
            //查询字段: <币种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb028), it => it.Mb028 == parm.Mb028);
            //查询字段: <发货库存地点> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb031), it => it.Mb031 == parm.Mb031);
            //查询字段: <工厂级删除标记> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb035), it => it.Mb035 == parm.Mb035);
            return predicate;
        }
    }
}