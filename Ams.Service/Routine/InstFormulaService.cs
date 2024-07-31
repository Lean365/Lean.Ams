using Ams.Model.Routine.Dto;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 计算公式
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 10:24:50
    /// </summary>
    [AppService(ServiceType = typeof(IInstFormulaService), ServiceLifetime = LifeTime.Transient)]
    public class InstFormulaService : BaseService<InstFormula>, IInstFormulaService
    {
        /// <summary>
        /// 查询计算公式列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstFormulaDto> GetList(InstFormulaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<InstFormula, InstFormulaDto>(parm);

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
            int count = Count(it => it.IfType.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="IfSfId"></param>
        /// <returns></returns>
        public InstFormula GetInfo(long IfSfId)
        {
            var response = Queryable()
                .Where(x => x.IfSfId == IfSfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加计算公式
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InstFormula AddInstFormula(InstFormula model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改计算公式
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateInstFormula(InstFormula model)
        {
            return Update(model, true, "修改计算公式");
        }

        /// <summary>
        /// 导入计算公式
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportInstFormula(List<InstFormula> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.IfSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.IfType.IsEmpty(), "类别不能为空")
                .SplitError(x => x.Item.IfLangKey.IsEmpty(), "语言不能为空")
                .SplitError(x => x.Item.IfFormula.IsEmpty(), "公式不能为空")
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
        /// 导出计算公式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstFormulaDto> ExportList(InstFormulaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new InstFormulaDto()
                {
                    IfTypeLabel = it.IfType.GetConfigValue<SysDictData>("sys_calc_type"),
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
        private static Expressionable<InstFormula> QueryExp(InstFormulaQueryDto parm)
        {
            var predicate = Expressionable.Create<InstFormula>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IfType), it => it.IfType == parm.IfType);
            return predicate;
        }
    }
}