using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 组立不良ma
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:00:50
    /// </summary>
    [AppService(ServiceType = typeof(IPpRepairAssyMaService), ServiceLifetime = LifeTime.Transient)]
    public class PpRepairAssyMaService : BaseService<PpRepairAssyMa>, IPpRepairAssyMaService
    {
        /// <summary>
        /// 查询组立不良ma列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairAssyMaDto> GetList(PpRepairAssyMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpDefectAssyRepairSlvNav) //填充子对象
                .Where(predicate.ToExpression())
                .ToPage<PpRepairAssyMa, PpRepairAssyMaDto>(parm);

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
            int count = Count(it => it.PpdSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PpdSfId"></param>
        /// <returns></returns>
        public PpRepairAssyMa GetInfo(long PpdSfId)
        {
            var response = Queryable()
                .Includes(x => x.PpDefectAssyRepairSlvNav) //填充子对象
                .Where(x => x.PpdSfId == PpdSfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加组立不良ma
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpRepairAssyMa AddPpRepairAssyMa(PpRepairAssyMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpDefectAssyRepairSlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改组立不良ma
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpRepairAssyMa(PpRepairAssyMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpDefectAssyRepairSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入组立不良ma
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpRepairAssyMa(List<PpRepairAssyMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PpdSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.PpdOrderQty.IsEmpty(), "订单数量不能为空")
                .SplitError(x => x.Item.PpdRealQty.IsEmpty(), "生产实绩不能为空")
                .SplitError(x => x.Item.PpdNobadQty.IsEmpty(), "无不良数不能为空")
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
        /// 导出组立不良ma
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairAssyMaDto> ExportList(PpRepairAssyMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpRepairAssyMaDto()
                {
                    PpdLineNameLabel = it.PpdLineName.GetConfigValue<SysDictData>("sql_line_list"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                    //PpdBadTypeLabel = it.PpdBadType.GetConfigValue<SysDictData>("sql_bad_dist"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpRepairAssyMa> QueryExp(PpRepairAssyMaQueryDto parm)
        {
            var predicate = Expressionable.Create<PpRepairAssyMa>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PpdOrderNo), it => it.PpdOrderNo == parm.PpdOrderNo);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PpdLot), it => it.PpdLot.Contains(parm.PpdLot));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PpdModel), it => it.PpdModel.Contains(parm.PpdModel));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginPpdDate == null, it => it.PpdDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginPpdDate == null, it => it.PpdDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginPpdDate != null, it => it.PpdDate >= parm.BeginPpdDate);
            predicate = predicate.AndIF(parm.EndPpdDate != null, it => it.PpdDate <= parm.EndPpdDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PpdLineName), it => it.PpdLineName == parm.PpdLineName);
            return predicate;
        }
    }
}