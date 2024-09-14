//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 设变明细
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/13 8:13:42
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcSlaveService : BaseService<PpEcSlave>, IPpEcSlaveService
    {
        /// <summary>
        /// 查询设变明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveDto> GetList(PpEcSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpEcSlave, PpEcSlaveDto>(parm);

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
        public PpEcSlave GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加设变明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcSlave AddPpEcSlave(PpEcSlave model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改设变明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcSlave(PpEcSlave model)
        {
            return Update(model, true, "修改设变明细");
        }

        /// <summary>
        /// 导入设变明细
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcSlave(List<PpEcSlave> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mc003.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.Mc004.IsEmpty(), "机种不能为空")
                .SplitError(x => x.Item.Mc011.IsEmpty(), "旧品库存不能为空")
                .SplitError(x => x.Item.Mc012.IsEmpty(), "用量不能为空")
                .SplitError(x => x.Item.Mc016.IsEmpty(), "新品库存不能为空")
                .SplitError(x => x.Item.Mc017.IsEmpty(), "用量不能为空")
                .SplitError(x => x.Item.Mc030.IsEmpty(), "SOP不能为空")
                .SplitError(x => x.Item.Mc031.IsEmpty(), "实施标记不能为空")
                .SplitError(x => x.Item.Mc032.IsEmpty(), "部管不能为空")
                .SplitError(x => x.Item.Mc033.IsEmpty(), "Pcba不能为空")
                .SplitError(x => x.Item.Mc034.IsEmpty(), "组立不能为空")
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
        /// 导出设变明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcSlaveDto> ExportList(PpEcSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcSlaveDto()
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
        private static Expressionable<PpEcSlave> QueryExp(PpEcSlaveQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcSlave>();

            return predicate;
        }
    }
}