using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 返工改修
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:26
    /// </summary>
    [AppService(ServiceType = typeof(IQmCostReworkService), ServiceLifetime = LifeTime.Transient)]
    public class QmCostReworkService : BaseService<QmCostRework>, IQmCostReworkService
    {
        /// <summary>
        /// 查询返工改修列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCostReworkDto> GetList(QmCostReworkQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmCostRework, QmCostReworkDto>(parm);

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
            int count = Count(it => it. QcrdSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QcrdSfId"></param>
        /// <returns></returns>
        public QmCostRework GetInfo(long QcrdSfId)
        {
            var response = Queryable()
                .Where(x => x.QcrdSfId == QcrdSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加返工改修
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmCostRework AddQmCostRework(QmCostRework model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改返工改修
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmCostRework(QmCostRework model)
        {
            return Update(model, true, "修改返工改修");
        }

        /// <summary>
        /// 导入返工改修
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmCostRework(List<QmCostRework> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.QcrdSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.Qcrd001.IsEmpty(), "日期不能为空")
                .SplitError(x => x.Item.Qcrd004.IsEmpty(), "直接人员赁率不能为空")
                .SplitError(x => x.Item.Qcrd005.IsEmpty(), "间接人员赁率不能为空")
                .SplitError(x => x.Item.Qcrd007.IsEmpty(), "检讨?调查?试验费用不能为空")
                .SplitError(x => x.Item.Qcrd008.IsEmpty(), "检讨会使用时间(分)不能为空")
                .SplitError(x => x.Item.Qcrd009.IsEmpty(), "直接人员参加人数不能为空")
                .SplitError(x => x.Item.Qcrd010.IsEmpty(), "间接人员参加人数不能为空")
                .SplitError(x => x.Item.Qcrd011.IsEmpty(), "调查评价试验工作时间(分)不能为空")
                .SplitError(x => x.Item.Qcrd012.IsEmpty(), "交通费、旅费不能为空")
                .SplitError(x => x.Item.Qcrd013.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Qcrd014.IsEmpty(), "其他作业時間(分)不能为空")
                .SplitError(x => x.Item.Qcrd015.IsEmpty(), "其他设备购入费,工程费,搬运费不能为空")
                .SplitError(x => x.Item.Qcrd016.IsEmpty(), "需要不良改修对应不能为空")
                .SplitError(x => x.Item.Qcrd020.IsEmpty(), "选别?改修费用不能为空")
                .SplitError(x => x.Item.Qcrd021.IsEmpty(), "选别?改修时间(分)不能为空")
                .SplitError(x => x.Item.Qcrd022.IsEmpty(), "再检查时间(分)不能为空")
                .SplitError(x => x.Item.Qcrd023.IsEmpty(), "交通费、旅费不能为空")
                .SplitError(x => x.Item.Qcrd024.IsEmpty(), "仓库管理费不能为空")
                .SplitError(x => x.Item.Qcrd025.IsEmpty(), "选别?改修其他费用不能为空")
                .SplitError(x => x.Item.Qcrd027.IsEmpty(), "向顾客的费用请求不能为空")
                .SplitError(x => x.Item.Qcrd030.IsEmpty(), "请求费用不能为空")
                .SplitError(x => x.Item.Qcrd031.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Qcrd035.IsEmpty(), "选别?改修费用不能为空")
                .SplitError(x => x.Item.Qcrd036.IsEmpty(), "选别?改修时间(分)不能为空")
                .SplitError(x => x.Item.Qcrd037.IsEmpty(), "再检查时间(分)不能为空")
                .SplitError(x => x.Item.Qcrd038.IsEmpty(), "交通费、旅费不能为空")
                .SplitError(x => x.Item.Qcrd039.IsEmpty(), "仓库管理费不能为空")
                .SplitError(x => x.Item.Qcrd040.IsEmpty(), "选别?改修其他费用不能为空")
                .SplitError(x => x.Item.Qcrd042.IsEmpty(), "向顾客的费用请求不能为空")
                .SplitError(x => x.Item.Qcrd045.IsEmpty(), "请求费用不能为空")
                .SplitError(x => x.Item.Qcrd046.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Qcrd050.IsEmpty(), "选别?改修费用不能为空")
                .SplitError(x => x.Item.Qcrd051.IsEmpty(), "选别?改修时间(分)不能为空")
                .SplitError(x => x.Item.Qcrd052.IsEmpty(), "再检查时间(分)不能为空")
                .SplitError(x => x.Item.Qcrd053.IsEmpty(), "交通费、旅费不能为空")
                .SplitError(x => x.Item.Qcrd054.IsEmpty(), "仓库管理费不能为空")
                .SplitError(x => x.Item.Qcrd055.IsEmpty(), "选别?改修其他费用不能为空")
                .SplitError(x => x.Item.Qcrd057.IsEmpty(), "向顾客的费用请求不能为空")
                .SplitError(x => x.Item.Qcrd060.IsEmpty(), "请求费用不能为空")
                .SplitError(x => x.Item.Qcrd061.IsEmpty(), "其他费用不能为空")
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
        /// 导出返工改修
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCostReworkDto> ExportList(QmCostReworkQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmCostReworkDto()
                {
                    Qcrd028Label = it.Qcrd028.GetConfigValue<SysDictData>("sql_cus_list"),
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
        private static Expressionable<QmCostRework> QueryExp(QmCostReworkQueryDto parm)
        {
            var predicate = Expressionable.Create<QmCostRework>();

            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQcrd001 == null, it => it.Qcrd001 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQcrd001 == null, it => it.Qcrd001 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQcrd001 != null, it => it.Qcrd001 >= parm.BeginQcrd001);
            predicate = predicate.AndIF(parm.EndQcrd001 != null, it => it.Qcrd001 <= parm.EndQcrd001);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Qcrd002), it => it.Qcrd002 == parm.Qcrd002);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Qcrd003), it => it.Qcrd003 == parm.Qcrd003);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQcrd018 == null, it => it.Qcrd018 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQcrd018 == null, it => it.Qcrd018 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQcrd018 != null, it => it.Qcrd018 >= parm.BeginQcrd018);
            predicate = predicate.AndIF(parm.EndQcrd018 != null, it => it.Qcrd018 <= parm.EndQcrd018);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Qcrd028), it => it.Qcrd028 == parm.Qcrd028);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQcrd033 == null, it => it.Qcrd033 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQcrd033 == null, it => it.Qcrd033 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQcrd033 != null, it => it.Qcrd033 >= parm.BeginQcrd033);
            predicate = predicate.AndIF(parm.EndQcrd033 != null, it => it.Qcrd033 <= parm.EndQcrd033);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQcrd048 == null, it => it.Qcrd048 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQcrd048 == null, it => it.Qcrd048 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQcrd048 != null, it => it.Qcrd048 >= parm.BeginQcrd048);
            predicate = predicate.AndIF(parm.EndQcrd048 != null, it => it.Qcrd048 <= parm.EndQcrd048);
            return predicate;
        }
    }
}