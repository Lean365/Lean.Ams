//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 加班预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/14 12:09:13
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetOvertimeService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetOvertimeService : BaseService<FicoBudgetOvertime>, IFicoBudgetOvertimeService
    {
        /// <summary>
        /// 查询加班预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetOvertimeDto> GetList(FicoBudgetOvertimeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mi005 desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetOvertime, FicoBudgetOvertimeDto>(parm);

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
            int count = Count(it => it. Id.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public FicoBudgetOvertime GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加加班预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetOvertime AddFicoBudgetOvertime(FicoBudgetOvertime model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改加班预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetOvertime(FicoBudgetOvertime model)
        {
            return Update(model, true, "修改加班预算");
        }

        /// <summary>
        /// 导入加班预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetOvertime(List<FicoBudgetOvertime> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mi004.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.Mi005.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mi006.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.Mi007.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.Mi009.IsEmpty(), "必要工数不能为空")
                .SplitError(x => x.Item.Mi010.IsEmpty(), "保有人数不能为空")
                .SplitError(x => x.Item.Mi011.IsEmpty(), "间接人数不能为空")
                .SplitError(x => x.Item.Mi012.IsEmpty(), "上班天数不能为空")
                .SplitError(x => x.Item.Mi014.IsEmpty(), "保有工数不能为空")
                .SplitError(x => x.Item.Mi015.IsEmpty(), "工数差异不能为空")
                .SplitError(x => x.Item.Mi016.IsEmpty(), "投入加班不能为空")
                .SplitError(x => x.Item.Mi017.IsEmpty(), "平均投入加班不能为空")
                .SplitError(x => x.Item.Mi018.IsEmpty(), "间接加班不能为空")
                .SplitError(x => x.Item.Mi019.IsEmpty(), "投入总加班不能为空")
                .SplitError(x => x.Item.Mi020.IsEmpty(), "启用标记不能为空")
                .SplitError(x => x.Item.Mi021.IsEmpty(), "审核不能为空")
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
        public PagedInfo<FicoBudgetOvertimeDto> ExportList(FicoBudgetOvertimeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetOvertimeDto()
                {
                    //查询字典: <部门ID> 
                    DeptIdLabel = it.DeptId.GetConfigValue<SysDictData>("sql_dept_list"),
                    //查询字典: <财年> 
                    Mi004Label = it.Mi004.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月> 
                    Mi005Label = it.Mi005.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <公司> 
                    Mi006Label = it.Mi006.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <科目> 
                    Mi007Label = it.Mi007.GetConfigValue<SysDictData>("sql_budget_title"),
                    //查询字典: <启用标记> 
                    Mi020Label = it.Mi020.GetConfigValue<SysDictData>("sys_is_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetOvertime> QueryExp(FicoBudgetOvertimeQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetOvertime>();

            //查询字段: <部门ID> 
            predicate = predicate.AndIF(parm.DeptId != -1, it => it.DeptId == parm.DeptId);
            //查询字段: <财年> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mi004), it => it.Mi004 == parm.Mi004);
            //查询字段: <年月> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mi005), it => it.Mi005 == parm.Mi005);
            //查询字段: <公司> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mi006), it => it.Mi006 == parm.Mi006);
            //查询字段: <科目> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mi007), it => it.Mi007 == parm.Mi007);
            //查询字段: <名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mi008), it => it.Mi008.Contains(parm.Mi008));
            //查询字段: <审核> 
            predicate = predicate.AndIF(parm.Mi021 != -1, it => it.Mi021 == parm.Mi021);
            return predicate;
        }
    }
}