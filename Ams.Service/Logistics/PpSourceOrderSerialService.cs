using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 源订单序列号
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:20:55
    /// </summary>
    [AppService(ServiceType = typeof(IPpSourceOrderSerialService), ServiceLifetime = LifeTime.Transient)]
    public class PpSourceOrderSerialService : BaseService<PpSourceOrderSerial>, IPpSourceOrderSerialService
    {
        /// <summary>
        /// 查询源订单序列号列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceOrderSerialDto> GetList(PpSourceOrderSerialQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpSourceOrderSerial, PpSourceOrderSerialDto>(parm);

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
            int count = Count(it => it. SfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        public PpSourceOrderSerial GetInfo(string SfId)
        {
            var response = Queryable()
                .Where(x => x.SfId == SfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加源订单序列号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpSourceOrderSerial AddPpSourceOrderSerial(PpSourceOrderSerial model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改源订单序列号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpSourceOrderSerial(PpSourceOrderSerial model)
        {
            return Update(model, true, "修改源订单序列号");
        }

        /// <summary>
        /// 导入源订单序列号
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpSourceOrderSerial(List<PpSourceOrderSerial> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.SfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.Serialc002.IsEmpty(), "生产订单不能为空")
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
        /// 导出源订单序列号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceOrderSerialDto> ExportList(PpSourceOrderSerialQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpSourceOrderSerialDto()
                {
                    Serialc001Label = it.Serialc001.GetConfigValue<SysDictData>("sys_plant_list"),
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
        private static Expressionable<PpSourceOrderSerial> QueryExp(PpSourceOrderSerialQueryDto parm)
        {
            var predicate = Expressionable.Create<PpSourceOrderSerial>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Serialc002), it => it.Serialc002.Contains(parm.Serialc002));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Serialc003), it => it.Serialc003.Contains(parm.Serialc003));
            return predicate;
        }
    }
}