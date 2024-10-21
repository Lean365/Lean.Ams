//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 人员预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/16 13:50:58
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
                // .LeftJoin<FicoBudgetAccounting>((u, budAccount) => u.Mj007 == budAccount.Md006)
                //.OrderBy("Mj004 desc")
                .Where(predicate.ToExpression())
                //.Select((u, dept) => new FicoBudgetStaff
                //{
                //    Id = u.Id.SelectAll(),
                //    Mj007 = dept.Md006,
                //})
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
            int count = Count(it => it.Id.ToString() == enterString);
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
                .SplitError(x => x.Item.Mj003.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.Mj004.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mj005.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.Mj006.IsEmpty(), "部门不能为空")
                .SplitError(x => x.Item.Mj007.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.Mj010.IsEmpty(), "人员类别不能为空")
                .SplitError(x => x.Item.Mj011.IsEmpty(), "保有不能为空")
                .SplitError(x => x.Item.Mj012.IsEmpty(), "现有不能为空")
                .SplitError(x => x.Item.Mj013.IsEmpty(), "预算不能为空")
                .SplitError(x => x.Item.Mj014.IsEmpty(), "职级不能为空")
                .SplitError(x => x.Item.Mj015.IsEmpty(), "月薪不能为空")
                .SplitError(x => x.Item.Mj016.IsEmpty(), "金额不能为空")
                .SplitError(x => x.Item.Mj017.IsEmpty(), "启用不能为空")
                .SplitError(x => x.Item.Mj018.IsEmpty(), "审核不能为空")
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
                    //查询字典: <财年>
                    Mj003Label = it.Mj003.GetConfigValue<SysDictData>("sql_attr_list"),
                    //查询字典: <年月>
                    Mj004Label = it.Mj004.GetConfigValue<SysDictData>("sql_ymdt_list"),
                    //查询字典: <公司>
                    Mj005Label = it.Mj005.GetConfigValue<SysDictData>("sql_corp_list"),
                    //查询字典: <部门>
                    Mj006Label = it.Mj006.GetConfigValue<SysDictData>("sql_dept_list"),
                    //查询字典: <科目>
                    Mj007Label = it.Mj007.GetConfigValue<SysDictData>("sql_budget_details"),
                    //查询字典: <费用类别>
                    Mj008Label = it.Mj008.GetConfigValue<SysDictData>("sys_costs_type"),
                    //查询字典: <人员类别>
                    Mj010Label = it.Mj010.GetConfigValue<SysDictData>("sys_pers_type"),
                    //查询字典: <职级>
                    Mj014Label = it.Mj014.GetConfigValue<SysDictData>("sql_posts_list"),
                    //查询字典: <启用>
                    Mj017Label = it.Mj017.GetConfigValue<SysDictData>("sys_is_status"),
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

            //查询字段: <财年>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj003), it => it.Mj003 == parm.Mj003);
            //查询字段: <年月>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj004), it => it.Mj004 == parm.Mj004);
            //查询字段: <公司>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj005), it => it.Mj005 == parm.Mj005);
            //查询字段: <部门>
            predicate = predicate.AndIF(parm.Mj006 != -1, it => it.Mj006 == parm.Mj006);
            //查询字段: <科目>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj007), it => it.Mj007 == parm.Mj007);
            //查询字段: <原因>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj009), it => it.Mj009.Contains(parm.Mj009));
            //查询字段: <职级>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj014), it => it.Mj014 == parm.Mj014);
            //查询字段: <审核>
            predicate = predicate.AndIF(parm.Mj018 != -1, it => it.Mj018 == parm.Mj018);
            return predicate;
        }
    }
}