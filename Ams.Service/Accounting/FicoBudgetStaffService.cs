//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 人员预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/14 13:41:08
    /// </summary>
    [AppService(ServiceType = typeof(IFicoBudgetStaffService), ServiceLifetime = LifeTime.Transient)]
    public class FicoBudgetStaffService : BaseService<FicoBudgetStaff>, IFicoBudgetStaffService
    {
        /// <summary>
        /// 查询人员预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetStaffDto> GetList(FicoBudgetStaffQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mj005 desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoBudgetStaff, FicoBudgetStaffDto>(parm);

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
        public FicoBudgetStaff GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加人员预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoBudgetStaff AddFicoBudgetStaff(FicoBudgetStaff model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改人员预算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoBudgetStaff(FicoBudgetStaff model)
        {
            return Update(model, true, "修改人员预算");
        }

        /// <summary>
        /// 导入人员预算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoBudgetStaff(List<FicoBudgetStaff> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mj004.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.Mj005.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mj006.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.Mj007.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.Mj010.IsEmpty(), "保有不能为空")
                .SplitError(x => x.Item.Mj011.IsEmpty(), "现有不能为空")
                .SplitError(x => x.Item.Mj012.IsEmpty(), "预算不能为空")
                .SplitError(x => x.Item.Mj013.IsEmpty(), "启用不能为空")
                .SplitError(x => x.Item.Mj014.IsEmpty(), "审核不能为空")
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
        /// 导出人员预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoBudgetStaffDto> ExportList(FicoBudgetStaffQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoBudgetStaffDto()
                {
                    //查询字典: <部门ID> 
                    DeptIdLabel = it.DeptId.GetConfigValue<SysDictData>("sql_dept_list"),
                    //查询字典: <财年> 
                    Mj004Label = it.Mj004.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月> 
                    Mj005Label = it.Mj005.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <公司> 
                    Mj006Label = it.Mj006.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <科目> 
                    Mj007Label = it.Mj007.GetConfigValue<SysDictData>("sql_budget_title"),
                    //查询字典: <类别> 
                    Mj009Label = it.Mj009.GetConfigValue<SysDictData>("sys_costs_type"),
                    //查询字典: <启用> 
                    Mj013Label = it.Mj013.GetConfigValue<SysDictData>("sys_is_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoBudgetStaff> QueryExp(FicoBudgetStaffQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetStaff>();

            //查询字段: <部门ID> 
            predicate = predicate.AndIF(parm.DeptId != -1, it => it.DeptId == parm.DeptId);
            //查询字段: <财年> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj004), it => it.Mj004 == parm.Mj004);
            //查询字段: <年月> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj005), it => it.Mj005 == parm.Mj005);
            //查询字段: <公司> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj006), it => it.Mj006 == parm.Mj006);
            //查询字段: <科目> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj007), it => it.Mj007 == parm.Mj007);
            //查询字段: <名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj008), it => it.Mj008.Contains(parm.Mj008));
            //查询字段: <审核> 
            predicate = predicate.AndIF(parm.Mj014 != -1, it => it.Mj014 == parm.Mj014);
            return predicate;
        }
    }
}