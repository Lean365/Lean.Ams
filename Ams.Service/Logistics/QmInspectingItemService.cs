using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 检测项目
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:07:59
    /// </summary>
    [AppService(ServiceType = typeof(IQmInspectingItemService), ServiceLifetime = LifeTime.Transient)]
    public class QmInspectingItemService : BaseService<QmInspectingItem>, IQmInspectingItemService
    {
        /// <summary>
        /// 查询检测项目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmInspectingItemDto> GetList(QmInspectingItemQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmInspectingItem, QmInspectingItemDto>(parm);

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
            int count = Count(it => it. QminsItemSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QminsItemSfId"></param>
        /// <returns></returns>
        public QmInspectingItem GetInfo(long QminsItemSfId)
        {
            var response = Queryable()
                .Where(x => x.QminsItemSfId == QminsItemSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加检测项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmInspectingItem AddQmInspectingItem(QmInspectingItem model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改检测项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmInspectingItem(QmInspectingItem model)
        {
            return Update(model, true, "修改检测项目");
        }

        /// <summary>
        /// 导入检测项目
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmInspectingItem(List<QmInspectingItem> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.QminsItemSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.QminsItemCode.IsEmpty(), "项目代码不能为空")
                .SplitError(x => x.Item.QminsItemName.IsEmpty(), "项目名称不能为空")
                .SplitError(x => x.Item.QminsItemType.IsEmpty(), "项目类别不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
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
        /// 导出检测项目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmInspectingItemDto> ExportList(QmInspectingItemQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmInspectingItemDto()
                {
                    QminsItemTypeLabel = it.QminsItemType.GetConfigValue<SysDictData>("sys_insp_type"),
                    QminsItemQcToolLabel = it.QminsItemQcTool.GetConfigValue<SysDictData>("sys_insp_means"),
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
        private static Expressionable<QmInspectingItem> QueryExp(QmInspectingItemQueryDto parm)
        {
            var predicate = Expressionable.Create<QmInspectingItem>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QminsItemCode), it => it.QminsItemCode.Contains(parm.QminsItemCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QminsItemName), it => it.QminsItemName.Contains(parm.QminsItemName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QminsItemType), it => it.QminsItemType == parm.QminsItemType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QminsItemQcTool), it => it.QminsItemQcTool == parm.QminsItemQcTool);
            return predicate;
        }
    }
}