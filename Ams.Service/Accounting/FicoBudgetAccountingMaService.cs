using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 预算科目
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/7 8:08:11
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetAccountingMaService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetAccountingMaService : BaseService<FicoBudgetAccountingMa>, IFicoBudgetAccountingMaService
    {
        /// <summary>
        /// 查询预算科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetAccountingMaDto> GetList(FicoBudgetAccountingMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.FicoBudgetAccountingSlvNav) //填充子对象
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetAccountingMa, FicoBudgetAccountingMaDto>(parm);

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
        public FicoBudgetAccountingMa GetInfo(long FbasSfId)
        {
            var response = Queryable()
                .Includes(x => x.FicoBudgetAccountingSlvNav) //填充子对象
                .Where(x => x.FbasSfId == FbasSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加预算科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetAccountingMa AddFicoBudgetAccountingMa(FicoBudgetAccountingMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.FicoBudgetAccountingSlvNav).ExecuteReturnEntity();
        }
        /// <summary>
        /// 修改预算科目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetAccountingMa(FicoBudgetAccountingMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.FicoBudgetAccountingSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入预算科目
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetAccountingMa(List<FicoBudgetAccountingMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FbasSfId.IsEmpty(), "ID不能为空")
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
        public PagedInfo<FicoBudgetAccountingMaDto> ExportList(FicoBudgetAccountingMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetAccountingMaDto()
                {
                    FbasBukrsLabel = it.FbasBukrs.GetConfigValue<SysDictData>("sys_crop_list"),
                    FbasWaersLabel = it.FbasWaers.GetConfigValue<SysDictData>("sys_ccy_type"),
                    FbasGvtypLabel = it.FbasGvtyp.GetConfigValue<SysDictData>("sys_exp_type"),
                    FbasMitkzLabel = it.FbasMitkz.GetConfigValue<SysDictData>("sys_conrol_title"),
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
        private static Expressionable<FicoBudgetAccountingMa> QueryExp(FicoBudgetAccountingMaQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetAccountingMa>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasBukrs), it => it.FbasBukrs == parm.FbasBukrs);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasFipls), it => it.FbasFipls.Contains(parm.FbasFipls));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasWaers), it => it.FbasWaers == parm.FbasWaers);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasSaknr), it => it.FbasSaknr == parm.FbasSaknr);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasStext), it => it.FbasStext.Contains(parm.FbasStext));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasLtext), it => it.FbasLtext.Contains(parm.FbasLtext));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasGvtyp), it => it.FbasGvtyp == parm.FbasGvtyp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FbasMitkz), it => it.FbasMitkz == parm.FbasMitkz);
            predicate = predicate.AndIF(parm.FbasXspea != null, it => it.FbasXspea == parm.FbasXspea);
            return predicate;
        }
    }
}