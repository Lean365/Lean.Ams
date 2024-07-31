using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 主源设变
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:08:51
    /// </summary>
    [AppService(ServiceType = typeof(IPpSourceEcMaService), ServiceLifetime = LifeTime.Transient)]
    public class PpSourceEcMaService : BaseService<PpSourceEcMa>, IPpSourceEcMaService
    {
        /// <summary>
        /// 查询主源设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceEcMaDto> GetList(PpSourceEcMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpSourceEcSlvNav) //填充子对象
                .Where(predicate.ToExpression())
                .ToPage<PpSourceEcMa, PpSourceEcMaDto>(parm);

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
        public PpSourceEcMa GetInfo(long SfId)
        {
            var response = Queryable()
                .Includes(x => x.PpSourceEcSlvNav) //填充子对象
                .Where(x => x.SfId == SfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加主源设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpSourceEcMa AddPpSourceEcMa(PpSourceEcMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpSourceEcSlvNav).ExecuteReturnEntity();
        }
        /// <summary>
        /// 修改主源设变
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpSourceEcMa(PpSourceEcMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpSourceEcSlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入主源设变
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpSourceEcMa(List<PpSourceEcMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.IsSolved.IsEmpty(), "处理标记不能为空")
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
        /// 导出主源设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceEcMaDto> ExportList(PpSourceEcMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpSourceEcMaDto()
                {
                    Zpabdz004Label = it.Zpabdz004.GetConfigValue<SysDictData>("sys_ec_status"),
                    IsSolvedLabel = it.IsSolved.GetConfigValue<SysDictData>("sys_normal_whether"),
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
        private static Expressionable<PpSourceEcMa> QueryExp(PpSourceEcMaQueryDto parm)
        {
            var predicate = Expressionable.Create<PpSourceEcMa>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zpabdz001), it => it.Zpabdz001.Contains(parm.Zpabdz001));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zpabdz003), it => it.Zpabdz003.Contains(parm.Zpabdz003));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zpabdz004), it => it.Zpabdz004 == parm.Zpabdz004);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginZpabdz005 == null, it => it.Zpabdz005 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginZpabdz005 == null, it => it.Zpabdz005 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginZpabdz005 != null, it => it.Zpabdz005 >= parm.BeginZpabdz005);
            predicate = predicate.AndIF(parm.EndZpabdz005 != null, it => it.Zpabdz005 <= parm.EndZpabdz005);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IsSolved), it => it.IsSolved == parm.IsSolved);
            return predicate;
        }
    }
}