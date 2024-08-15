using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 实际对比
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:50:08
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetActualContService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetActualContService : BaseService<FicoBudgetActualCont>, IFicoBudgetActualContService
    {
        /// <summary>
        /// 查询实际对比列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetActualContDto> GetList(FicoBudgetActualContQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("FbLfmon desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetActualCont, FicoBudgetActualContDto>(parm);

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
            int count = Count(it => it. FbSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbSfId"></param>
        /// <returns></returns>
        public FicoBudgetActualCont GetInfo(long FbSfId)
        {
            var response = Queryable()
                .Where(x => x.FbSfId == FbSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加实际对比
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetActualCont AddFicoBudgetActualCont(FicoBudgetActualCont model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改实际对比
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetActualCont(FicoBudgetActualCont model)
        {
            return Update(model, true, "修改实际对比");
        }

        /// <summary>
        /// 导入实际对比
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetActualCont(List<FicoBudgetActualCont> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbSfId.IsEmpty(), "ID不能为空")
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
        /// 导出实际对比
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetActualContDto> ExportList(FicoBudgetActualContQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetActualContDto()
                {
                    FbLfgjaLabel = it.FbLfgja.GetConfigValue<SysDictData>("sql_fy_list"),
                    FbLfmonLabel = it.FbLfmon.GetConfigValue<SysDictData>("sql_ym_list"),
                    FbBukrsLabel = it.FbBukrs.GetConfigValue<SysDictData>("sys_crop_list"),
                    FbStatypLabel = it.FbStatyp.GetConfigValue<SysDictData>("sys_stat_type"),
                    FbKotypLabel = it.FbKotyp.GetConfigValue<SysDictData>("sys_costs_type"),
                    FbWerksLabel = it.FbWerks.GetConfigValue<SysDictData>("sys_ccy_type"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetActualCont> QueryExp(FicoBudgetActualContQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetActualCont>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbLfgja), it => it.FbLfgja == parm.FbLfgja);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbLfmon), it => it.FbLfmon == parm.FbLfmon);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbBukrs), it => it.FbBukrs == parm.FbBukrs);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbStatyp), it => it.FbStatyp == parm.FbStatyp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbKtosl), it => it.FbKtosl.Contains(parm.FbKtosl));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbKotyp), it => it.FbKotyp == parm.FbKotyp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbKonto), it => it.FbKonto.Contains(parm.FbKonto));
            return predicate;
        }
    }
}