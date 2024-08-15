using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 工厂物料
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:45:06
    /// </summary>
    [AppService(ServiceType = typeof(IMmMarcService), ServiceLifetime = LifeTime.Transient)]
    public class MmMarcService : BaseService<MmMarc>, IMmMarcService
    {
        /// <summary>
        /// 查询工厂物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMarcDto> GetList(MmMarcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<MmMarc, MmMarcDto>(parm);

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
            int count = Count(it => it.SfId.ToString() == enterString);
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
        public MmMarc GetInfo(long SfId)
        {
            var response = Queryable()
                .Where(x => x.SfId == SfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加工厂物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmMarc AddMmMarc(MmMarc model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改工厂物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmMarc(MmMarc model)
        {
            return Update(model, true, "修改工厂物料");
        }

        /// <summary>
        /// 导入工厂物料
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmMarc(List<MmMarc> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.SfId.IsEmpty(), "ID主键不能为空")
                .SplitError(x => x.Item.Matnr.IsEmpty(), "物料号不能为空")
                .SplitError(x => x.Item.Werks.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Lvorm.IsEmpty(), "在工厂级标记要删除的物料不能为空")
                .SplitError(x => x.Item.Ekgrp.IsEmpty(), "采购组不能为空")
                .SplitError(x => x.Item.Beskz.IsEmpty(), "采购类型不能为空")
                .SplitError(x => x.Item.Sobsl.IsEmpty(), "特殊采购类型不能为空")
                .SplitError(x => x.Item.Insmk.IsEmpty(), "过帐到检验库存不能为空")
                .SplitError(x => x.Item.Kautb.IsEmpty(), "标识: 允许自动采购订单不能为空")
                .SplitError(x => x.Item.Kordb.IsEmpty(), "标识: 源清单要求不能为空")
                .SplitError(x => x.Item.Prctr.IsEmpty(), "利润中心不能为空")
                .SplitError(x => x.Item.Lgpro.IsEmpty(), "发货库存地点不能为空")
                .SplitError(x => x.Item.Lgfsb.IsEmpty(), "外部采购的缺省仓储位置不能为空")
                .SplitError(x => x.Item.Schgt.IsEmpty(), "标识：散装物料不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
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
        /// 导出工厂物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMarcDto> ExportList(MmMarcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmMarcDto()
                {
                    WerksLabel = it.Werks.GetConfigValue<SysDictData>("sys_plant_list"),
                    LvormLabel = it.Lvorm.GetConfigValue<SysDictData>("sys_is_deleted"),
                    EkgrpLabel = it.Ekgrp.GetConfigValue<SysDictData>("sys_pur_group"),
                    BeskzLabel = it.Beskz.GetConfigValue<SysDictData>("sys_pur_type"),
                    SobslLabel = it.Sobsl.GetConfigValue<SysDictData>("sys_pur_spec"),
                    InsmkLabel = it.Insmk.GetConfigValue<SysDictData>("sys_normal_whether"),
                    PrctrLabel = it.Prctr.GetConfigValue<SysDictData>("sql_prctr_list"),
                    LgproLabel = it.Lgpro.GetConfigValue<SysDictData>("sys_sloc_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<MmMarc> QueryExp(MmMarcQueryDto parm)
        {
            var predicate = Expressionable.Create<MmMarc>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Matnr), it => it.Matnr.Contains(parm.Matnr));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Werks), it => it.Werks == parm.Werks);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Lvorm), it => it.Lvorm == parm.Lvorm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ekgrp), it => it.Ekgrp == parm.Ekgrp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Beskz), it => it.Beskz == parm.Beskz);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Sobsl), it => it.Sobsl == parm.Sobsl);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Insmk), it => it.Insmk == parm.Insmk);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Kautb), it => it.Kautb == parm.Kautb);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Kordb), it => it.Kordb == parm.Kordb);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Prctr), it => it.Prctr == parm.Prctr);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Lgpro), it => it.Lgpro == parm.Lgpro);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Lgfsb), it => it.Lgfsb == parm.Lgfsb);
            return predicate;
        }
    }
}