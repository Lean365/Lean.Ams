using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 物料信息
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 14:13:37
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
        public MmMarb GetInfo(long SfId)
        {
            var response = Queryable()
                .Where(x => x.SfId == SfId)
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
                .SplitError(x => x.Item.SfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.Werks.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Matnr.IsEmpty(), "物料号不能为空")
                .SplitError(x => x.Item.Mbrsh.IsEmpty(), "行业领域不能为空")
                .SplitError(x => x.Item.Mtart.IsEmpty(), "物料类型不能为空")
                .SplitError(x => x.Item.Meins.IsEmpty(), "基本计量单位不能为空")
                .SplitError(x => x.Item.Matkl.IsEmpty(), "物料组不能为空")
                .SplitError(x => x.Item.Ekgrp.IsEmpty(), "采购组不能为空")
                .SplitError(x => x.Item.Beskz.IsEmpty(), "采购类型不能为空")
                .SplitError(x => x.Item.Sobsl.IsEmpty(), "特殊采购类型不能为空")
                .SplitError(x => x.Item.Insmk.IsEmpty(), "过帐到检验库存不能为空")
                .SplitError(x => x.Item.Prctr.IsEmpty(), "利润中心不能为空")
                .SplitError(x => x.Item.Xchpf.IsEmpty(), "批次管理需求的标识不能为空")
                .SplitError(x => x.Item.Bklas.IsEmpty(), "评估类不能为空")
                .SplitError(x => x.Item.Waers.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.Lgpro.IsEmpty(), "发货库存地点不能为空")
                .SplitError(x => x.Item.Lgfsb.IsEmpty(), "外部采购的缺省仓储位置不能为空")
                .SplitError(x => x.Item.Lvorm.IsEmpty(), "在工厂级标记要删除的物料不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
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
                    WerksLabel = it.Werks.GetConfigValue<SysDictData>("sys_plant_list"),
                    MbrshLabel = it.Mbrsh.GetConfigValue<SysDictData>("sys_ind_type"),
                    MtartLabel = it.Mtart.GetConfigValue<SysDictData>("sys_matl_type"),
                    MeinsLabel = it.Meins.GetConfigValue<SysDictData>("sys_unit_list"),
                    MatklLabel = it.Matkl.GetConfigValue<SysDictData>("sys_matl_group"),
                    EkgrpLabel = it.Ekgrp.GetConfigValue<SysDictData>("sys_pur_group"),
                    BeskzLabel = it.Beskz.GetConfigValue<SysDictData>("sys_pur_type"),
                    SobslLabel = it.Sobsl.GetConfigValue<SysDictData>("sys_pur_spec"),
                    SchgtLabel = it.Schgt.GetConfigValue<SysDictData>("sys_normal_whether"),
                    PrctrLabel = it.Prctr.GetConfigValue<SysDictData>("sql_prctr_list"),
                    BklasLabel = it.Bklas.GetConfigValue<SysDictData>("sys_val_type"),
                    WaersLabel = it.Waers.GetConfigValue<SysDictData>("sys_ccy_type"),
                    LgproLabel = it.Lgpro.GetConfigValue<SysDictData>("sys_sloc_list"),
                    LvormLabel = it.Lvorm.GetConfigValue<SysDictData>("sys_eol_list"),
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
        private static Expressionable<MmMarb> QueryExp(MmMarbQueryDto parm)
        {
            var predicate = Expressionable.Create<MmMarb>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Werks), it => it.Werks == parm.Werks);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Matnr), it => it.Matnr.Contains(parm.Matnr));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mbrsh), it => it.Mbrsh == parm.Mbrsh);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mtart), it => it.Mtart == parm.Mtart);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Meins), it => it.Meins == parm.Meins);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Matkl), it => it.Matkl == parm.Matkl);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ekgrp), it => it.Ekgrp == parm.Ekgrp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Beskz), it => it.Beskz == parm.Beskz);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Sobsl), it => it.Sobsl == parm.Sobsl);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Insmk), it => it.Insmk == parm.Insmk);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Prctr), it => it.Prctr == parm.Prctr);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Xchpf), it => it.Xchpf == parm.Xchpf);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Bklas), it => it.Bklas == parm.Bklas);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Waers), it => it.Waers == parm.Waers);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Lgpro), it => it.Lgpro == parm.Lgpro);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Lgfsb), it => it.Lgfsb == parm.Lgfsb);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Lvorm), it => it.Lvorm == parm.Lvorm);
            return predicate;
        }
    }
}