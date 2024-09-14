//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 工厂物料
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:30:16
    /// </summary>
    [AppService(ServiceType = typeof(IMmMarcService), ServiceLifetime = LifeTime.Transient)]
    public class MmMarcService : BaseService<MmMarc>, IMmMarcService
    {
        /// <summary>
        /// 查询工厂物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMarcDto> GetList(MmMarcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mc003 asc")
                .Where(predicate.ToExpression())
                .ToPage<MmMarc, MmMarcDto>(parm);

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
        public MmMarc GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加工厂物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmMarc AddMmMarc(MmMarc model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改工厂物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmMarc(MmMarc model)
        {
            return Update(model, true, "修改工厂物料");
        }

        /// <summary>
        /// 导入工厂物料
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmMarc(List<MmMarc> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mc019.IsEmpty(), "计划交货天数不能为空")
                .SplitError(x => x.Item.Mc020.IsEmpty(), "收货处理时间不能为空")
                .SplitError(x => x.Item.Mc022.IsEmpty(), "装配报废不能为空")
                .SplitError(x => x.Item.Mc026.IsEmpty(), "再订货点不能为空")
                .SplitError(x => x.Item.Mc027.IsEmpty(), "安全库存不能为空")
                .SplitError(x => x.Item.Mc028.IsEmpty(), "最小批量不能为空")
                .SplitError(x => x.Item.Mc029.IsEmpty(), "最大批量不能为空")
                .SplitError(x => x.Item.Mc030.IsEmpty(), "固定批量不能为空")
                .SplitError(x => x.Item.Mc033.IsEmpty(), "订购成本不能为空")
                .SplitError(x => x.Item.Mc047.IsEmpty(), "处理时间不能为空")
                .SplitError(x => x.Item.Mc048.IsEmpty(), "准备时间不能为空")
                .SplitError(x => x.Item.Mc049.IsEmpty(), "工序间不能为空")
                .SplitError(x => x.Item.Mc050.IsEmpty(), "基准数量不能为空")
                .SplitError(x => x.Item.Mc051.IsEmpty(), "厂内生产时间不能为空")
                .SplitError(x => x.Item.Mc052.IsEmpty(), "最大存储期间不能为空")
                .SplitError(x => x.Item.Mc056.IsEmpty(), "超量交货容差不能为空")
                .SplitError(x => x.Item.Mc058.IsEmpty(), "不足交货容差不能为空")
                .SplitError(x => x.Item.Mc059.IsEmpty(), "总计补货提前时间不能为空")
                .SplitError(x => x.Item.Mc061.IsEmpty(), "附加费不能为空")
                .SplitError(x => x.Item.Mc064.IsEmpty(), "样本不能为空")
                .SplitError(x => x.Item.Mc070.IsEmpty(), "活动性物质不能为空")
                .SplitError(x => x.Item.Mc071.IsEmpty(), "检查间隔不能为空")
                .SplitError(x => x.Item.Mc081.IsEmpty(), "对象标识不能为空")
                .SplitError(x => x.Item.Mc085.IsEmpty(), "准备时间不能为空")
                .SplitError(x => x.Item.Mc086.IsEmpty(), "基准数量不能为空")
                .SplitError(x => x.Item.Mc087.IsEmpty(), "处理时间不能为空")
                .SplitError(x => x.Item.Mc098.IsEmpty(), "在途库存不能为空")
                .SplitError(x => x.Item.Mc101.IsEmpty(), "计划的时界不能为空")
                .SplitError(x => x.Item.Mc103.IsEmpty(), "消耗期间:逆向不能为空")
                .SplitError(x => x.Item.Mc104.IsEmpty(), "消耗时期-向前不能为空")
                .SplitError(x => x.Item.Mc110.IsEmpty(), "成本核算批次不能为空")
                .SplitError(x => x.Item.Mc115.IsEmpty(), "组件报废不能为空")
                .SplitError(x => x.Item.Mc118.IsEmpty(), "间隔时间不能为空")
                .SplitError(x => x.Item.Mc124.IsEmpty(), "内部对象号不能为空")
                .SplitError(x => x.Item.Mc134.IsEmpty(), "乘数不能为空")
                .SplitError(x => x.Item.Mc146.IsEmpty(), "内部对象号不能为空")
                .SplitError(x => x.Item.Mc152.IsEmpty(), "调整期间不能为空")
                .SplitError(x => x.Item.Mc156.IsEmpty(), "空气浮力因子不能为空")
                .SplitError(x => x.Item.Mc159.IsEmpty(), "安全时间不能为空")
                .SplitError(x => x.Item.Mc164.IsEmpty(), "库存转移SV不能为空")
                .SplitError(x => x.Item.Mc165.IsEmpty(), "运输库存SP不能为空")
                .SplitError(x => x.Item.Mc171.IsEmpty(), "有约束的虚拟库存不能为空")
                .SplitError(x => x.Item.Mc172.IsEmpty(), "空缺库存销售价不能为空")
                .SplitError(x => x.Item.Mc184.IsEmpty(), "发布界限不能为空")
                .SplitError(x => x.Item.Mc185.IsEmpty(), "最小批量不能为空")
                .SplitError(x => x.Item.Mc186.IsEmpty(), "最大批量不能为空")
                .SplitError(x => x.Item.Mc187.IsEmpty(), "固定批量不能为空")
                .SplitError(x => x.Item.Mc188.IsEmpty(), "批尺寸增加不能为空")
                .SplitError(x => x.Item.Mc189.IsEmpty(), "该字段不再使用不能为空")
                .SplitError(x => x.Item.Mc198.IsEmpty(), "当前期间 (记帐期间)不能为空")
                .SplitError(x => x.Item.Mc199.IsEmpty(), "当前期间的会计年度不能为空")
                .SplitError(x => x.Item.Mc200.IsEmpty(), "最小安全库存不能为空")
                .SplitError(x => x.Item.Mc205.IsEmpty(), "评估收货锁定库存不能为空")
                .SplitError(x => x.Item.Mc223.IsEmpty(), "发货处理时间不能为空")
                .SplitError(x => x.Item.Mc226.IsEmpty(), "最小目标范围不能为空")
                .SplitError(x => x.Item.Mc227.IsEmpty(), "最大目标范围不能为空")
                .SplitError(x => x.Item.Mc228.IsEmpty(), "目标库存不能为空")
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
        /// 导出工厂物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMarcDto> ExportList(MmMarcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmMarcDto()
                {
                    //查询字典: <工厂> 
                    Mc004Label = it.Mc004.GetConfigValue<SysDictData>("sql_plant_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<MmMarc> QueryExp(MmMarcQueryDto parm)
        {
            var predicate = Expressionable.Create<MmMarc>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc004), it => it.Mc004 == parm.Mc004);
            //查询字段: <物料号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc003), it => it.Mc003.Contains(parm.Mc003));
            return predicate;
        }
    }
}