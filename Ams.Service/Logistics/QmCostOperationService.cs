using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 品质业务
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:02
    /// </summary>
    [AppService(ServiceType = typeof(IQmCostOperationService), ServiceLifetime = LifeTime.Transient)]
    public class QmCostOperationService : BaseService<QmCostOperation>, IQmCostOperationService
    {
        /// <summary>
        /// 查询品质业务列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCostOperationDto> GetList(QmCostOperationQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmCostOperation, QmCostOperationDto>(parm);

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
            int count = Count(it => it. QcodSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QcodSfId"></param>
        /// <returns></returns>
        public QmCostOperation GetInfo(long QcodSfId)
        {
            var response = Queryable()
                .Where(x => x.QcodSfId == QcodSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加品质业务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmCostOperation AddQmCostOperation(QmCostOperation model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改品质业务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmCostOperation(QmCostOperation model)
        {
            return Update(model, true, "修改品质业务");
        }

        /// <summary>
        /// 导入品质业务
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmCostOperation(List<QmCostOperation> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.QcodSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.Qcod001.IsEmpty(), "日期不能为空")
                .SplitError(x => x.Item.Qcod002.IsEmpty(), "间接赁率不能为空")
                .SplitError(x => x.Item.Qcod003.IsEmpty(), "IQC检查费用不能为空")
                .SplitError(x => x.Item.Qcod004.IsEmpty(), "检查时间不能为空")
                .SplitError(x => x.Item.Qcod005.IsEmpty(), "差旅费不能为空")
                .SplitError(x => x.Item.Qcod006.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Qcod008.IsEmpty(), "初期检定?定期检定业务费用不能为空")
                .SplitError(x => x.Item.Qcod009.IsEmpty(), "作业时间不能为空")
                .SplitError(x => x.Item.Qcod010.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Qcod012.IsEmpty(), "测定器校正业务费用不能为空")
                .SplitError(x => x.Item.Qcod013.IsEmpty(), "校正时间不能为空")
                .SplitError(x => x.Item.Qcod014.IsEmpty(), "外部委托，搬运费不能为空")
                .SplitError(x => x.Item.Qcod015.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Qcod017.IsEmpty(), "其他通常费用不能为空")
                .SplitError(x => x.Item.Qcod018.IsEmpty(), "通常作业时间不能为空")
                .SplitError(x => x.Item.Qcod019.IsEmpty(), "通常其他费用不能为空")
                .SplitError(x => x.Item.Qcod021.IsEmpty(), "出货检查费用不能为空")
                .SplitError(x => x.Item.Qcod022.IsEmpty(), "检查时间不能为空")
                .SplitError(x => x.Item.Qcod023.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Qcod025.IsEmpty(), "信赖性评价?ORT业务费用不能为空")
                .SplitError(x => x.Item.Qcod026.IsEmpty(), "评价时间不能为空")
                .SplitError(x => x.Item.Qcod027.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Qcod029.IsEmpty(), "顾客品质要求对应业务费用不能为空")
                .SplitError(x => x.Item.Qcod030.IsEmpty(), "评价作业时间不能为空")
                .SplitError(x => x.Item.Qcod031.IsEmpty(), "评价其他费用不能为空")
                .SplitError(x => x.Item.Qcod033.IsEmpty(), "其他通常业务费用不能为空")
                .SplitError(x => x.Item.Qcod034.IsEmpty(), "通常业务作业时间不能为空")
                .SplitError(x => x.Item.Qcod035.IsEmpty(), "通常业务其他费用不能为空")
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
        /// 导出品质业务
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCostOperationDto> ExportList(QmCostOperationQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmCostOperationDto()
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
        private static Expressionable<QmCostOperation> QueryExp(QmCostOperationQueryDto parm)
        {
            var predicate = Expressionable.Create<QmCostOperation>();

            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQcod001 == null, it => it.Qcod001 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQcod001 == null, it => it.Qcod001 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQcod001 != null, it => it.Qcod001 >= parm.BeginQcod001);
            predicate = predicate.AndIF(parm.EndQcod001 != null, it => it.Qcod001 <= parm.EndQcod001);
            return predicate;
        }
    }
}