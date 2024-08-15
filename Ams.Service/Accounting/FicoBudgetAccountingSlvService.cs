using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 明细科目
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 17:37:35
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetAccountingSlvService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetAccountingSlvService : BaseService<FicoBudgetAccountingSlv>, IFicoBudgetAccountingSlvService
    {
        /// <summary>
        /// 查询明细科目列表
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
            int count = Count(it => it. FbasSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FbasSfId"></param>
        /// <returns></returns>
        public FicoBudgetAccountingSlv GetInfo(long FbasSfId)
        {
            var response = Queryable()
                .Where(x => x.FbasSfId == FbasSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加明细科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetAccountingSlv AddFicoBudgetAccountingSlv(FicoBudgetAccountingSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改明细科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetAccountingSlv(FicoBudgetAccountingSlv model)
        {
            return Update(model, true, "修改明细科目");
        }

        /// <summary>
        /// 导入明细科目
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetAccountingSlv(List<FicoBudgetAccountingSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbasSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.FbasParentSfId.IsEmpty(), "父ID  不能为空")
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
        /// 导出明细科目
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
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasStext), it => it.FbasStext.Contains(parm.FbasStext));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasLtext), it => it.FbasLtext.Contains(parm.FbasLtext));
            return predicate;
        }
    }
}