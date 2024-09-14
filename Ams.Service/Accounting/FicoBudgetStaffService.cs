//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;
using System.Collections.Generic;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 人员预算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:56:20
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
        /// 查询人员预算树列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<FicoBudgetStaff> GetTreeList(FicoBudgetStaffQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoBudgetStaff>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj004), it => it.Mj004 == parm.Mj004);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj005), it => it.Mj005 == parm.Mj005);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj006), it => it.Mj006 == parm.Mj006);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj007), it => it.Mj007.Contains(parm.Mj007));

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToTree(it => it.Children, it => it.ParentId, 0);

            return response;
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
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mj004.IsEmpty(), "财年不能为空")
                .SplitError(x => x.Item.Mj005.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.Mj006.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.Mj007.IsEmpty(), "科目不能为空")
                .SplitError(x => x.Item.Mj010.IsEmpty(), "保有不能为空")
                .SplitError(x => x.Item.Mj011.IsEmpty(), "现有不能为空")
                .SplitError(x => x.Item.Mj012.IsEmpty(), "预算不能为空")
                .SplitError(x => x.Item.Mj013.IsEmpty(), "启用不能为空")
                .SplitError(x => x.Item.Mj014.IsEmpty(), "审核不能为空")
                .SplitError(x => x.Item.Ref04.IsEmpty(), "预留1不能为空")
                .SplitError(x => x.Item.Ref05.IsEmpty(), "预留2不能为空")
                .SplitError(x => x.Item.Ref06.IsEmpty(), "预留3不能为空")
                .SplitError(x => x.Item.Udf51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.Udf52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.Udf53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.Udf54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.Udf55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.Udf56.IsEmpty(), "自定义6不能为空")
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
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj004), it => it.Mj004 == parm.Mj004);
            //查询字段: <年月> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj005), it => it.Mj005 == parm.Mj005);
            //查询字段: <公司> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj006), it => it.Mj006 == parm.Mj006);
            //查询字段: <科目> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mj007), it => it.Mj007.Contains(parm.Mj007));
            return predicate;
        }
    }
}