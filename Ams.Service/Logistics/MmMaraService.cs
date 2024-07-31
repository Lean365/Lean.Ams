using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 常规物料
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:37:36
    /// </summary>
    [AppService(ServiceType = typeof(IMmMaraService), ServiceLifetime = LifeTime.Transient)]
    public class MmMaraService : BaseService<MmMara>, IMmMaraService
    {
        /// <summary>
        /// 查询常规物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMaraDto> GetList(MmMaraQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<MmMara, MmMaraDto>(parm);

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
        public MmMara GetInfo(long SfId)
        {
            var response = Queryable()
                .Where(x => x.SfId == SfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加常规物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmMara AddMmMara(MmMara model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改常规物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmMara(MmMara model)
        {
            return Update(model, true, "修改常规物料");
        }

        /// <summary>
        /// 导入常规物料
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmMara(List<MmMara> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.SfId.IsEmpty(), "ID主键不能为空")
                .SplitError(x => x.Item.Matnr.IsEmpty(), "物料号不能为空")
                .SplitError(x => x.Item.Lvorm.IsEmpty(), "在客户级标记要删除的物料不能为空")
                .SplitError(x => x.Item.Mtart.IsEmpty(), "物料类型不能为空")
                .SplitError(x => x.Item.Mbrsh.IsEmpty(), "行业领域不能为空")
                .SplitError(x => x.Item.Matkl.IsEmpty(), "物料组不能为空")
                .SplitError(x => x.Item.Meins.IsEmpty(), "基本计量单位不能为空")
                .SplitError(x => x.Item.Gewei.IsEmpty(), "重量单位不能为空")
                .SplitError(x => x.Item.Voleh.IsEmpty(), "体积单位不能为空")
                .SplitError(x => x.Item.Mstae.IsEmpty(), "跨工厂物料状态不能为空")
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
        /// 导出常规物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMaraDto> ExportList(MmMaraQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmMaraDto()
                {
                    LvormLabel = it.Lvorm.GetConfigValue<SysDictData>("sys_is_deleted"),
                    MtartLabel = it.Mtart.GetConfigValue<SysDictData>("sys_matl_type"),
                    MbrshLabel = it.Mbrsh.GetConfigValue<SysDictData>("sys_ind_type"),
                    MatklLabel = it.Matkl.GetConfigValue<SysDictData>("sys_matl_group"),
                    MeinsLabel = it.Meins.GetConfigValue<SysDictData>("sys_unit_list"),
                    MstaeLabel = it.Mstae.GetConfigValue<SysDictData>("sys_eol_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<MmMara> QueryExp(MmMaraQueryDto parm)
        {
            var predicate = Expressionable.Create<MmMara>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Matnr), it => it.Matnr.Contains(parm.Matnr));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Lvorm), it => it.Lvorm == parm.Lvorm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mtart), it => it.Mtart == parm.Mtart);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mbrsh), it => it.Mbrsh == parm.Mbrsh);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Matkl), it => it.Matkl == parm.Matkl);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Meins), it => it.Meins == parm.Meins);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Gewei), it => it.Gewei == parm.Gewei);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Voleh), it => it.Voleh == parm.Voleh);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mstae), it => it.Mstae == parm.Mstae);
            return predicate;
        }
    }
}