using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 源物料
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:18:11
    /// </summary>
    [AppService(ServiceType = typeof(IPpSourceMaterialService), ServiceLifetime = LifeTime.Transient)]
    public class PpSourceMaterialService : BaseService<PpSourceMaterial>, IPpSourceMaterialService
    {
        /// <summary>
        /// 查询源物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceMaterialDto> GetList(PpSourceMaterialQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpSourceMaterial, PpSourceMaterialDto>(parm);

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
            int count = Count(it => it. SfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        public PpSourceMaterial GetInfo(long SfId)
        {
            var response = Queryable()
                .Where(x => x.SfId == SfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加源物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpSourceMaterial AddPpSourceMaterial(PpSourceMaterial model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改源物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpSourceMaterial(PpSourceMaterial model)
        {
            return Update(model, true, "修改源物料");
        }

        /// <summary>
        /// 导入源物料
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpSourceMaterial(List<PpSourceMaterial> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.SfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.Zcadz002.IsEmpty(), "品目不能为空")
                .SplitError(x => x.Item.Zcadz013.IsEmpty(), "最小起订量不能为空")
                .SplitError(x => x.Item.Zcadz015.IsEmpty(), "舍入值不能为空")
                .SplitError(x => x.Item.Zcadz018.IsEmpty(), "自制天数不能为空")
                .SplitError(x => x.Item.Zcadz026.IsEmpty(), "移动平均价格/周期单价不能为空")
                .SplitError(x => x.Item.Zcadz033.IsEmpty(), "库存不能为空")
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
        /// 导出源物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceMaterialDto> ExportList(PpSourceMaterialQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpSourceMaterialDto()
                {
                    Zcadz001Label = it.Zcadz001.GetConfigValue<SysDictData>("sys_plant_list"),
                    Zcadz003Label = it.Zcadz003.GetConfigValue<SysDictData>("sys_ind_type"),
                    Zcadz004Label = it.Zcadz004.GetConfigValue<SysDictData>("sys_matl_type"),
                    Zcadz006Label = it.Zcadz006.GetConfigValue<SysDictData>("sys_unit_list"),
                    Zcadz008Label = it.Zcadz008.GetConfigValue<SysDictData>("sys_matl_group"),
                    Zcadz009Label = it.Zcadz009.GetConfigValue<SysDictData>("sys_pur_group"),
                    Zcadz010Label = it.Zcadz010.GetConfigValue<SysDictData>("sys_pur_type"),
                    Zcadz011Label = it.Zcadz011.GetConfigValue<SysDictData>("sys_pur_spec"),
                    Zcadz012Label = it.Zcadz012.GetConfigValue<SysDictData>("sys_normal_whether"),
                    Zcadz025Label = it.Zcadz025.GetConfigValue<SysDictData>("sys_val_type"),
                    Zcadz027Label = it.Zcadz027.GetConfigValue<SysDictData>("sys_ccy_type"),
                    Zcadz030Label = it.Zcadz030.GetConfigValue<SysDictData>("sys_sloc_list"),
                    Zcadz034Label = it.Zcadz034.GetConfigValue<SysDictData>("sys_eol_list"),
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
        private static Expressionable<PpSourceMaterial> QueryExp(PpSourceMaterialQueryDto parm)
        {
            var predicate = Expressionable.Create<PpSourceMaterial>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz002), it => it.Zcadz002.Contains(parm.Zcadz002));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz003), it => it.Zcadz003 == parm.Zcadz003);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz004), it => it.Zcadz004 == parm.Zcadz004);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz005), it => it.Zcadz005.Contains(parm.Zcadz005));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz006), it => it.Zcadz006 == parm.Zcadz006);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz008), it => it.Zcadz008 == parm.Zcadz008);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz009), it => it.Zcadz009 == parm.Zcadz009);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz010), it => it.Zcadz010 == parm.Zcadz010);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz011), it => it.Zcadz011 == parm.Zcadz011);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz019), it => it.Zcadz019 == parm.Zcadz019);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz022), it => it.Zcadz022 == parm.Zcadz022);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz025), it => it.Zcadz025 == parm.Zcadz025);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz027), it => it.Zcadz027 == parm.Zcadz027);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz030), it => it.Zcadz030 == parm.Zcadz030);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz031), it => it.Zcadz031 == parm.Zcadz031);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz032), it => it.Zcadz032.Contains(parm.Zcadz032));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zcadz034), it => it.Zcadz034 == parm.Zcadz034);
            return predicate;
        }
    }
}