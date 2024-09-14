//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 检测项目
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:48:49
    /// </summary>
    [AppService(ServiceType = typeof(IQmInspItemService), ServiceLifetime = LifeTime.Transient)]
    public class QmInspItemService : BaseService<QmInspItem>, IQmInspItemService
    {
        /// <summary>
        /// 查询检测项目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmInspItemDto> GetList(QmInspItemQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mh002 asc")
                .Where(predicate.ToExpression())
                .ToPage<QmInspItem, QmInspItemDto>(parm);

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
        public QmInspItem GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加检测项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmInspItem AddQmInspItem(QmInspItem model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改检测项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmInspItem(QmInspItem model)
        {
            return Update(model, true, "修改检测项目");
        }

        /// <summary>
        /// 导入检测项目
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmInspItem(List<QmInspItem> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mh002.IsEmpty(), "项目代码不能为空")
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
        /// 导出检测项目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmInspItemDto> ExportList(QmInspItemQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmInspItemDto()
                {
                    //查询字典: <检查工具> 
                    Mh005Label = it.Mh005.GetConfigValue<SysDictData>("sys_insp_means"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmInspItem> QueryExp(QmInspItemQueryDto parm)
        {
            var predicate = Expressionable.Create<QmInspItem>();

            //查询字段: <项目代码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh002), it => it.Mh002.Contains(parm.Mh002));
            //查询字段: <项目名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh003), it => it.Mh003.Contains(parm.Mh003));
            //查询字段: <项目类别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh004), it => it.Mh004.Contains(parm.Mh004));
            //查询字段: <检查工具> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mh005), it => it.Mh005 == parm.Mh005);
            return predicate;
        }
    }
}