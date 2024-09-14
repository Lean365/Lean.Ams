//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/14 8:48:00
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcMasterService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcMasterService : BaseService<PpEcMaster>, IPpEcMasterService
    {
        /// <summary>
        /// 查询设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcMasterDto> GetList(PpEcMasterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpEcSlaveNav) //填充子对象
                //.OrderBy("Mb003 asc")
                .Where(predicate.ToExpression())
                .ToPage<PpEcMaster, PpEcMasterDto>(parm);

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
            int count = Count(it => it.Id.ToString() == enterString);
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
        public PpEcMaster GetInfo(long Id)
        {
            var response = Queryable()
                .Includes(x => x.PpEcSlaveNav) //填充子对象
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcMaster AddPpEcMaster(PpEcMaster model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpEcSlaveNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcMaster(PpEcMaster model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpEcSlaveNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcMaster(List<PpEcMaster> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mb003.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.Mb005.IsEmpty(), "设变状态不能为空")
                .SplitError(x => x.Item.Mb010.IsEmpty(), "单位成本不能为空")
                .SplitError(x => x.Item.Mb011.IsEmpty(), "模具费用不能为空")
                .SplitError(x => x.Item.Mb013.IsEmpty(), "管理区分不能为空")
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
        /// 导出设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcMasterDto> ExportList(PpEcMasterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcMasterDto()
                {
                    //查询字典: <设变状态>
                    Mb005Label = it.Mb005.GetConfigValue<SysDictData>("sys_ec_status"),
                    //查询字典: <担当>
                    Mb008Label = it.Mb008.GetConfigValue<SysDictData>("sql_ec_group"),
                    //查询字典: <管理区分>
                    Mb013Label = it.Mb013.GetConfigValue<SysDictData>("sys_ec_mgtype"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpEcMaster> QueryExp(PpEcMasterQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcMaster>();

            //查询字段: <发行日期>
            //predicate = predicate.AndIF(parm.BeginMb002 == null, it => it.Mb002 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMb002 != null, it => it.Mb002 >= parm.BeginMb002);
            //predicate = predicate.AndIF(parm.EndMb002 != null, it => it.Mb002 <= parm.EndMb002);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMb002 == null, it => it.Mb002 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            //predicate = predicate.AndIF(parm.BeginMb002 == null, it => it.Mb002 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMb002 != null, it => it.Mb002 >= parm.BeginMb002);
            predicate = predicate.AndIF(parm.EndMb002 != null, it => it.Mb002 <= parm.EndMb002);
            //查询字段: <设变No.>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb003), it => it.Mb003.Contains(parm.Mb003));
            //查询字段: <标题>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb006), it => it.Mb006.Contains(parm.Mb006));
            //查询字段: <内容>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb007), it => it.Mb007.Contains(parm.Mb007));
            //查询字段: <担当>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb008), it => it.Mb008 == parm.Mb008);
            //查询字段: <管理区分>
            predicate = predicate.AndIF(parm.Mb013 != -1, it => it.Mb013 == parm.Mb013);
            //查询字段: <输入日>
            //predicate = predicate.AndIF(parm.BeginMb023 == null, it => it.Mb023 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMb023 != null, it => it.Mb023 >= parm.BeginMb023);
            //predicate = predicate.AndIF(parm.EndMb023 != null, it => it.Mb023 <= parm.EndMb023);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMb023 == null, it => it.Mb023 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            //predicate = predicate.AndIF(parm.BeginMb023 == null, it => it.Mb023 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMb023 != null, it => it.Mb023 >= parm.BeginMb023);
            predicate = predicate.AndIF(parm.EndMb023 != null, it => it.Mb023 <= parm.EndMb023);
            return predicate;
        }
    }
}