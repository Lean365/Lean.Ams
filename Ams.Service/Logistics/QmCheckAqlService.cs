using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 抽样标准
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:39:24
    /// </summary>
    [AppService(ServiceType = typeof(IQmCheckAqlService), ServiceLifetime = LifeTime.Transient)]
    public class QmCheckAqlService : BaseService<QmCheckAql>, IQmCheckAqlService
    {
        /// <summary>
        /// 查询抽样标准列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCheckAqlDto> GetList(QmCheckAqlQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmCheckAql, QmCheckAqlDto>(parm);

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
            int count = Count(it => it. QcaSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QcaSfId"></param>
        /// <returns></returns>
        public QmCheckAql GetInfo(long QcaSfId)
        {
            var response = Queryable()
                .Where(x => x.QcaSfId == QcaSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加抽样标准
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmCheckAql AddQmCheckAql(QmCheckAql model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改抽样标准
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmCheckAql(QmCheckAql model)
        {
            return Update(model, true, "修改抽样标准");
        }

        /// <summary>
        /// 导入抽样标准
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmCheckAql(List<QmCheckAql> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.QcaSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.QcaLevel.IsEmpty(), "查检水平不能为空")
                .SplitError(x => x.Item.QcaRange.IsEmpty(), "批量范围不能为空")
                .SplitError(x => x.Item.QcaRangeMinmum.IsEmpty(), "最小值不能为空")
                .SplitError(x => x.Item.QcaRangeMaximum.IsEmpty(), "最大值不能为空")
                .SplitError(x => x.Item.QcaSamplesCode.IsEmpty(), "样本码不能为空")
                .SplitError(x => x.Item.QcaSamplesQty.IsEmpty(), "抽样数不能为空")
                .SplitError(x => x.Item.QcaAcQty.IsEmpty(), "合格项不能为空")
                .SplitError(x => x.Item.QcaReQty.IsEmpty(), "不合格项不能为空")
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
        /// 导出抽样标准
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCheckAqlDto> ExportList(QmCheckAqlQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmCheckAqlDto()
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
        private static Expressionable<QmCheckAql> QueryExp(QmCheckAqlQueryDto parm)
        {
            var predicate = Expressionable.Create<QmCheckAql>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QcaLevel), it => it.QcaLevel.Contains(parm.QcaLevel));
            return predicate;
        }
    }
}