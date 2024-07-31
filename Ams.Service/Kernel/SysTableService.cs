using Ams.Model.Kernel.Dto;
using Ams.Model.Kernel;
using Ams.Service.Kernel.IKernelService;

namespace Ams.Service.Kernel
{
    /// <summary>
    /// 表名称
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 10:27:13
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
            int count = Count(it => it. TbId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="TbId"></param>
        /// <returns></returns>
        public SysTable GetInfo(long TbId)
        {
            var response = Queryable()
                .Where(x => x.TbId == TbId)
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
                .SplitError(x => x.Item.TbId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Tb001.IsEmpty(), "表名 不能为空")
                .SplitError(x => x.Item.Tb003.IsEmpty(), "序号 不能为空")
                .SplitError(x => x.Item.Tb006.IsEmpty(), "表名称不能为空")
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
        private static Expressionable<SysTable> QueryExp(SysTableQueryDto parm)
        {
            var predicate = Expressionable.Create<SysTable>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Tb001), it => it.Tb001.Contains(parm.Tb001));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Tb002), it => it.Tb002.Contains(parm.Tb002));
            return predicate;
        }
    }
}