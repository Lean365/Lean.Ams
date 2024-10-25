//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Repository;

namespace Ams.Service.Admin
{
    /// <summary>
    /// 表名称
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:06
    /// </summary>
    [AppService(ServiceType = typeof(ISysTableService), ServiceLifetime = LifeTime.Transient)]
    public class SysTableService : BaseService<SysTable>, ISysTableService
    {
        /// <summary>
        /// 查询表名称列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SysTableDto> GetList(SysTableQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Tb002 asc")
                .Where(predicate.ToExpression())
                .ToPage<SysTable, SysTableDto>(parm);

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
        public SysTable GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加表名称
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SysTable AddSysTable(SysTable model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改表名称
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSysTable(SysTable model)
        {
            return Update(model, true, "修改表名称");
        }

        /// <summary>
        /// 导入表名称
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportSysTable(List<SysTable> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Tb002.IsEmpty(), "表名不能为空")
                .SplitError(x => x.Item.Ref04.IsEmpty(), "预留1不能为空")
                .SplitError(x => x.Item.Ref05.IsEmpty(), "预留2不能为空")
                .SplitError(x => x.Item.Ref06.IsEmpty(), "预留3不能为空")
                .SplitError(x => x.Item.Udf51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.Udf52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.Udf53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.Udf54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.Udf55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.Udf56.IsEmpty(), "自定义6不能为空")
                //.SplitError(x => x.Item.Is_deleted.IsEmpty(), "软删除不能为空")
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
        /// 导出表名称
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SysTableDto> ExportList(SysTableQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new SysTableDto()
                {
                    // IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_Is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<SysTable> QueryExp(SysTableQueryDto parm)
        {
            var predicate = Expressionable.Create<SysTable>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Tb002), it => it.Tb002.Contains(parm.Tb002));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Tb003), it => it.Tb003.Contains(parm.Tb003));
            return predicate;
        }
    }
}