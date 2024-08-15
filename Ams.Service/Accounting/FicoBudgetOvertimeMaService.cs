using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 加班预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:25:44
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetOvertimeMaService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetOvertimeMaService : BaseService<FicoBudgetOvertimeMa>, IFicoBudgetOvertimeMaService
    {
        /// <summary>
        /// 查询加班预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetOvertimeMaDto> GetList(FicoBudgetOvertimeMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.FicoBudgetOvertimeSlvNav) //填充子对象
                //.OrderBy("FboFy desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetOvertimeMa, FicoBudgetOvertimeMaDto>(parm);

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
            int count = Count(it => it.FboSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FboSfId"></param>
        /// <returns></returns>
        public FicoBudgetOvertimeMa GetInfo(long FboSfId)
        {
            var response = Queryable()
                .Includes(x => x.FicoBudgetOvertimeSlvNav) //填充子对象
                .Where(x => x.FboSfId == FboSfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加加班预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetOvertimeMa AddFicoBudgetOvertimeMa(FicoBudgetOvertimeMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.FicoBudgetOvertimeSlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改加班预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetOvertimeMa(FicoBudgetOvertimeMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.FicoBudgetOvertimeSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入加班预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetOvertimeMa(List<FicoBudgetOvertimeMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FboSfId.IsEmpty(), "ID不能为空")
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
        /// 导出加班预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetOvertimeMaDto> ExportList(FicoBudgetOvertimeMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetOvertimeMaDto()
                {
                    FboFyLabel = it.FboFy.GetConfigValue<SysDictData>("sql_fy_list"),
                    FboCorpLabel = it.FboCorp.GetConfigValue<SysDictData>("sys_crop_list"),
                    FboDeptLabel = it.FboDept.GetConfigValue<SysDictData>("sql_dept_name"),
                    // FbosYmLabel = it.FbosYm.GetConfigValue<SysDictData>("sql_ym_list"),
                    //FbosTitleLabel = it.FbosTitle.GetConfigValue<SysDictData>("sql_budget_title"),
                    //FbosFlagLabel = it.FbosFlag.GetConfigValue<SysDictData>("sys_is_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetOvertimeMa> QueryExp(FicoBudgetOvertimeMaQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetOvertimeMa>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FboFy), it => it.FboFy == parm.FboFy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FboCorp), it => it.FboCorp == parm.FboCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FboDept), it => it.FboDept == parm.FboDept);
            return predicate;
        }
    }
}