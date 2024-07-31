using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 序列号扫描
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:55:51
    /// </summary>
    [AppService(ServiceType = typeof(IQmSerialService), ServiceLifetime = LifeTime.Transient)]
    public class QmSerialService : BaseService<QmSerial>, IQmSerialService
    {
        /// <summary>
        /// 查询序列号扫描列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmSerialDto> GetList(QmSerialQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmSerial, QmSerialDto>(parm);

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
            int count = Count(it => it. QmserSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QmserSfId"></param>
        /// <returns></returns>
        public QmSerial GetInfo(long QmserSfId)
        {
            var response = Queryable()
                .Where(x => x.QmserSfId == QmserSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加序列号扫描
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmSerial AddQmSerial(QmSerial model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改序列号扫描
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmSerial(QmSerial model)
        {
            return Update(model, true, "修改序列号扫描");
        }

        /// <summary>
        /// 导入序列号扫描
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmSerial(List<QmSerial> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.QmserSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.QminScan.IsEmpty(), "入库序列号不能为空")
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
        /// 导出序列号扫描
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmSerialDto> ExportList(QmSerialQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmSerialDto()
                {
                    QmoutTransportLabel = it.QmoutTransport.GetConfigValue<SysDictData>("sys_transport_method"),
                    QmoutRegionLabel = it.QmoutRegion.GetConfigValue<SysDictData>("sql_sap_region"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmSerial> QueryExp(QmSerialQueryDto parm)
        {
            var predicate = Expressionable.Create<QmSerial>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QminScan), it => it.QminScan == parm.QminScan);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQminDate == null, it => it.QminDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQminDate == null, it => it.QminDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQminDate != null, it => it.QminDate >= parm.BeginQminDate);
            predicate = predicate.AndIF(parm.EndQminDate != null, it => it.QminDate <= parm.EndQminDate);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQminTime == null, it => it.QminTime >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQminTime == null, it => it.QminTime >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQminTime != null, it => it.QminTime >= parm.BeginQminTime);
            predicate = predicate.AndIF(parm.EndQminTime != null, it => it.QminTime <= parm.EndQminTime);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutBill), it => it.QmoutBill.Contains(parm.QmoutBill));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutTransport), it => it.QmoutTransport == parm.QmoutTransport);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQmoutDate == null, it => it.QmoutDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQmoutDate == null, it => it.QmoutDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQmoutDate != null, it => it.QmoutDate >= parm.BeginQmoutDate);
            predicate = predicate.AndIF(parm.EndQmoutDate != null, it => it.QmoutDate <= parm.EndQmoutDate);
            return predicate;
        }
    }
}