//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 抽样标准
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:39:16
    /// </summary>
    [AppService(ServiceType = typeof(IQmInspAqlService), ServiceLifetime = LifeTime.Transient)]
    public class QmInspAqlService : BaseService<QmInspAql>, IQmInspAqlService
    {
        /// <summary>
        /// 查询抽样标准列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmInspAqlDto> GetList(QmInspAqlQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mg002 asc")
                .Where(predicate.ToExpression())
                .ToPage<QmInspAql, QmInspAqlDto>(parm);

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
        public QmInspAql GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加抽样标准
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmInspAql AddQmInspAql(QmInspAql model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改抽样标准
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmInspAql(QmInspAql model)
        {
            return Update(model, true, "修改抽样标准");
        }

        /// <summary>
        /// 导入抽样标准
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmInspAql(List<QmInspAql> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mg002.IsEmpty(), "查检水平不能为空")
                .SplitError(x => x.Item.Mg003.IsEmpty(), "批量范围不能为空")
                .SplitError(x => x.Item.Mg004.IsEmpty(), "最小值不能为空")
                .SplitError(x => x.Item.Mg005.IsEmpty(), "最大值不能为空")
                .SplitError(x => x.Item.Mg007.IsEmpty(), "抽样数不能为空")
                .SplitError(x => x.Item.Mg008.IsEmpty(), "合格项不能为空")
                .SplitError(x => x.Item.Mg009.IsEmpty(), "不合格项不能为空")
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
        /// 导出抽样标准
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmInspAqlDto> ExportList(QmInspAqlQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmInspAqlDto()
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
        private static Expressionable<QmInspAql> QueryExp(QmInspAqlQueryDto parm)
        {
            var predicate = Expressionable.Create<QmInspAql>();

            return predicate;
        }
    }
}