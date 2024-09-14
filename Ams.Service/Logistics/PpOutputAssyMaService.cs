//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics;
using Ams.Model.Logistics.Dto;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 组立OPH
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:21:13
    /// </summary>
    [AppService(ServiceType = typeof(IPpOutputAssyMaService), ServiceLifetime = LifeTime.Transient)]
    public class PpOutputAssyMaService : BaseService<PpOutputAssyMa>, IPpOutputAssyMaService
    {
        /// <summary>
        /// 查询组立OPH列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputAssyMaDto> GetList(PpOutputAssyMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpOutputAssySlvNav) //填充子对象
                //.OrderBy("Mma009 desc")
                .Where(predicate.ToExpression())
                .ToPage<PpOutputAssyMa, PpOutputAssyMaDto>(parm);

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
        public PpOutputAssyMa GetInfo(long Id)
        {
            var response = Queryable()
                .Includes(x => x.PpOutputAssySlvNav) //填充子对象
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加组立OPH
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpOutputAssyMa AddPpOutputAssyMa(PpOutputAssyMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpOutputAssySlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改组立OPH
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpOutputAssyMa(PpOutputAssyMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpOutputAssySlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入组立OPH
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpOutputAssyMa(List<PpOutputAssyMa> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mma003.IsEmpty(), "工单号码不能为空")
                .SplitError(x => x.Item.Mma004.IsEmpty(), "工单数量不能为空")
                .SplitError(x => x.Item.Mma010.IsEmpty(), "生产班组不能为空")
                .SplitError(x => x.Item.Mma011.IsEmpty(), "直接人数不能为空")
                .SplitError(x => x.Item.Mma012.IsEmpty(), "间接人数不能为空")
                .SplitError(x => x.Item.Mma013.IsEmpty(), "标准工时不能为空")
                .SplitError(x => x.Item.Mma014.IsEmpty(), "标准产能不能为空")
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
        /// 导出组立OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpOutputAssyMaDto> ExportList(PpOutputAssyMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpOutputAssyMaDto()
                {
                    //查询字典: <工单号码>
                    Mma003Label = it.Mma003.GetConfigValue<SysDictData>("sql_moc_assy"),
                    //查询字典: <生产班组>
                    Mma010Label = it.Mma010.GetConfigValue<SysDictData>("sql_assy_line"),
                    ////查询字典: <停线>
                    //Mmb005Label = it.Mmb005.GetConfigValue<SysDictData>("sql_line_stop"),
                    ////查询字典: <未达成>
                    //Mmb007Label = it.Mmb007.GetConfigValue<SysDictData>("sql_non_conf"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpOutputAssyMa> QueryExp(PpOutputAssyMaQueryDto parm)
        {
            var predicate = Expressionable.Create<PpOutputAssyMa>();

            //查询字段: <工单号码>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mma003), it => it.Mma003.Contains(parm.Mma003));
            //查询字段: <生产批次>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mma006), it => it.Mma006.Contains(parm.Mma006));
            //查询字段: <机种名>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mma007), it => it.Mma007.Contains(parm.Mma007));
            //查询字段: <物料>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mma008), it => it.Mma008.Contains(parm.Mma008));
            //查询字段: <生产日期>
            //predicate = predicate.AndIF(parm.BeginMma009 == null, it => it.Mma009 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMma009 != null, it => it.Mma009 >= parm.BeginMma009);
            //predicate = predicate.AndIF(parm.EndMma009 != null, it => it.Mma009 <= parm.EndMma009);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMma009 == null, it => it.Mma009 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMma009 == null, it => it.Mma009 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMma009 != null, it => it.Mma009 >= parm.BeginMma009);
            predicate = predicate.AndIF(parm.EndMma009 != null, it => it.Mma009 <= parm.EndMma009);
            //查询字段: <生产班组>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mma010), it => it.Mma010 == parm.Mma010);
            return predicate;
        }
    }
}