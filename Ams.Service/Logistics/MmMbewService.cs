using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 物料评估
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:50:11
    /// </summary>
    [AppService(ServiceType = typeof(IMmMbewService), ServiceLifetime = LifeTime.Transient)]
    public class MmMbewService : BaseService<MmMbew>, IMmMbewService
    {
        /// <summary>
        /// 查询物料评估列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMbewDto> GetList(MmMbewQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<MmMbew, MmMbewDto>(parm);

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
        public MmMbew GetInfo(long SfId)
        {
            var response = Queryable()
                .Where(x => x.SfId == SfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加物料评估
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmMbew AddMmMbew(MmMbew model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改物料评估
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmMbew(MmMbew model)
        {
            return Update(model, true, "修改物料评估");
        }

        /// <summary>
        /// 导入物料评估
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmMbew(List<MmMbew> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.SfId.IsEmpty(), "ID主键不能为空")
                .SplitError(x => x.Item.Matnr.IsEmpty(), "物料号不能为空")
                .SplitError(x => x.Item.Bwkey.IsEmpty(), "评估范围不能为空")
                .SplitError(x => x.Item.Bklas.IsEmpty(), "评估类不能为空")
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
        /// 导出物料评估
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMbewDto> ExportList(MmMbewQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmMbewDto()
                {
                    BwkeyLabel = it.Bwkey.GetConfigValue<SysDictData>("sys_plant_list"),
                    BklasLabel = it.Bklas.GetConfigValue<SysDictData>("sys_val_type"),
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
        private static Expressionable<MmMbew> QueryExp(MmMbewQueryDto parm)
        {
            var predicate = Expressionable.Create<MmMbew>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Matnr), it => it.Matnr.Contains(parm.Matnr));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Bwkey), it => it.Bwkey == parm.Bwkey);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Bklas), it => it.Bklas == parm.Bklas);
            predicate = predicate.AndIF(parm.Lfgja != null, it => it.Lfgja == parm.Lfgja);
            predicate = predicate.AndIF(parm.Lfmon != null, it => it.Lfmon == parm.Lfmon);
            return predicate;
        }
    }
}