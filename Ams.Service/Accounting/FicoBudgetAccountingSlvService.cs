using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 预算科目
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 8:38:32
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetAccountingSlvService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetAccountingSlvService : BaseService<FicoBudgetAccountingSlv>, IFicoBudgetAccountingSlvService
    {
        /// <summary>
        /// 查询预算科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetAccountingSlvDto> GetList(FicoBudgetAccountingSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetAccountingSlv, FicoBudgetAccountingSlvDto>(parm);

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
            int count = Count(it => it. FbasSfid.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbasSfid"></param>
        /// <returns></returns>
        public FicoBudgetAccountingSlv GetInfo(long FbasSfid)
        {
            var response = Queryable()
                .Where(x => x.FbasSfid == FbasSfid)
                .First();

            return response;
        }
        /// <summary>
        /// 添加预算科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetAccountingSlv AddFicoBudgetAccountingSlv(FicoBudgetAccountingSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改预算科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetAccountingSlv(FicoBudgetAccountingSlv model)
        {
            return Update(model, true, "修改预算科目");
        }

        /// <summary>
        /// 导入预算科目
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetAccountingSlv(List<FicoBudgetAccountingSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbasSfid.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.FbasParentSfid.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.FbasSpras.IsEmpty(), "语言Key不能为空")
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
        /// 导出预算科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetAccountingSlvDto> ExportList(FicoBudgetAccountingSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetAccountingSlvDto()
                {
                    FbasXspeaLabel = it.FbasXspea.GetConfigValue<SysDictData>("sys_freeze_flag"),
                    FbasMitkzLabel = it.FbasMitkz.GetConfigValue<SysDictData>("sys_normal_whether"),
                    FbasWaersLabel = it.FbasWaers.GetConfigValue<SysDictData>("sys_ccy_type"),
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
        private static Expressionable<FicoBudgetAccountingSlv> QueryExp(FicoBudgetAccountingSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetAccountingSlv>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasFdpls), it => it.FbasFdpls.Contains(parm.FbasFdpls));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasSatext), it => it.FbasSatext.Contains(parm.FbasSatext));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasLtext), it => it.FbasLtext.Contains(parm.FbasLtext));
            predicate = predicate.AndIF(parm.FbasXspea != null, it => it.FbasXspea == parm.FbasXspea);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasMitkz), it => it.FbasMitkz == parm.FbasMitkz);
            predicate = predicate.AndIF(parm.FbasWaers != null, it => it.FbasWaers == parm.FbasWaers);
            return predicate;
        }
    }
}