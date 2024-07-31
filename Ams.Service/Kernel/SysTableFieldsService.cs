using Ams.Model.Kernel.Dto;
using Ams.Service.Kernel.IKernelService;

namespace Ams.Service.Kernel
{
    /// <summary>
    /// 表字段
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 7:59:06
    /// </summary>
    [AppService(ServiceType = typeof(ISysTableFieldsService), ServiceLifetime = LifeTime.Transient)]
    public class SysTableFieldsService : BaseService<SysTableFields>, ISysTableFieldsService
    {
        /// <summary>
        /// 查询表字段列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SysTableFieldsDto> GetList(SysTableFieldsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<SysTableFields, SysTableFieldsDto>(parm);

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
            int count = Count(it => it.TfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="TfId"></param>
        /// <returns></returns>
        public SysTableFields GetInfo(long TfId)
        {
            var response = Queryable()
                .Where(x => x.TfId == TfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加表字段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SysTableFields AddSysTableFields(SysTableFields model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改表字段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSysTableFields(SysTableFields model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 导入表字段
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportSysTableFields(List<SysTableFields> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.TfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Tf001.IsEmpty(), "表名 不能为空")
                .SplitError(x => x.Item.Tf003.IsEmpty(), "字段编号 不能为空")
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
        /// 导出表字段
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SysTableFieldsDto> ExportList(SysTableFieldsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new SysTableFieldsDto()
                {
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<SysTableFields> QueryExp(SysTableFieldsQueryDto parm)
        {
            var predicate = Expressionable.Create<SysTableFields>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Tf001), it => it.Tf001.Contains(parm.Tf001));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Tf003), it => it.Tf003.Contains(parm.Tf003));
            return predicate;
        }
    }
}