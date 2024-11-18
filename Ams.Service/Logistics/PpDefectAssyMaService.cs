//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 不良
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:19:09
    /// </summary>
    [AppService(ServiceType = typeof(IPpDefectAssyMaService), ServiceLifetime = LifeTime.Transient)]
    public class PpDefectAssyMaService : BaseService<PpDefectAssyMa>, IPpDefectAssyMaService
    {
        /// <summary>
        /// 查询不良列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpDefectAssyMaDto> GetList(PpDefectAssyMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpDefectAssySlvNav) //填充子对象
                //.OrderBy("Mea006 desc")
                .Where(predicate.ToExpression())
                .ToPage<PpDefectAssyMa, PpDefectAssyMaDto>(parm);

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
        public PpDefectAssyMa GetInfo(long Id)
        {
            var response = Queryable()
                .Includes(x => x.PpDefectAssySlvNav) //填充子对象
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加不良
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpDefectAssyMa AddPpDefectAssyMa(PpDefectAssyMa model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpDefectAssySlvNav).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改不良
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpDefectAssyMa(PpDefectAssyMa model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpDefectAssySlvNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入不良
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpDefectAssyMa(List<PpDefectAssyMa> list)
        {
            list.ForEach(it =>
            {
                it.Create_by = HttpContextExtension.GetName(App.HttpContext);
                it.Remark = it.Remark.IsEmpty() ? "数据由<" + HttpContextExtension.GetName(App.HttpContext) + ">用户,批量导入" : it.Remark;
            });
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mea002.IsEmpty(), "生产订单不能为空")
                .SplitError(x => x.Item.Mea003.IsEmpty(), "订单数量不能为空")
                .SplitError(x => x.Item.Mea008.IsEmpty(), "生产实绩不能为空")
                .SplitError(x => x.Item.Mea009.IsEmpty(), "无不良数不能为空")
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
        /// 导出不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpDefectAssyMaDto> ExportList(PpDefectAssyMaQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpDefectAssyMaDto()
                {
                    //查询字典: <生产订单>
                    Mea002Label = it.Mea002.GetConfigValue<SysDictData>("sql_moc_oph"),
                    //查询字典: <不良类别>
                    //Mfa003Label = it.Mfa003.GetConfigValue<SysDictData>("sql_bad_dist"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpDefectAssyMa> QueryExp(PpDefectAssyMaQueryDto parm)
        {
            var predicate = Expressionable.Create<PpDefectAssyMa>();

            //查询字段: <生产订单>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mea002), it => it.Mea002 == parm.Mea002);
            //查询字段: <生产批次>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mea004), it => it.Mea004.Contains(parm.Mea004));
            //查询字段: <生产机种>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mea005), it => it.Mea005.Contains(parm.Mea005));
            //查询字段: <生产日期>
            //predicate = predicate.AndIF(parm.BeginMea006 == null, it => it.Mea006 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMea006 != null, it => it.Mea006 >= parm.BeginMea006);
            //predicate = predicate.AndIF(parm.EndMea006 != null, it => it.Mea006 <= parm.EndMea006);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMea006 == null, it => it.Mea006 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMea006 == null, it => it.Mea006 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMea006 != null, it => it.Mea006 >= parm.BeginMea006);
            predicate = predicate.AndIF(parm.EndMea006 != null, it => it.Mea006 <= parm.EndMea006);
            //查询字段: <生产班组>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mea007), it => it.Mea007.Contains(parm.Mea007));
            return predicate;
        }
    }
}