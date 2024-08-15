using Ams.Model.Logistics.Dto;
using Ams.Statistics.Logistics.IService;
using SqlSugar;

namespace Ams.Statistics.Logistics.Service
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IOutputStatiService), ServiceLifetime = LifeTime.Transient)]
    public class OutputStatiService : BaseService<PpOutputAssyMaster>, IOutputStatiService
    {
        /// <summary>
        /// 查询最大ID
        /// </summary>
        /// <returns></returns>
        public string GetMaxSfId()
        {
            string? MaxSfId;
            var db = Context;
            long SfId = db.Queryable<PpOutputAssyMaster>().Max(it => it.PomSfId).ParseToLong();//异步
            if (!string.IsNullOrEmpty(SfId.ToString()) && SfId != 0)
            {
                MaxSfId = (SfId + 1).ToString();
            }
            else
            {
                MaxSfId = SnowFlakeSingle.instance.NextId().ToString();
            }

            return MaxSfId;
        }

        /// <summary>
        /// 查询当月生产台数
        /// </summary>
        /// <returns></returns>
        public int GetMonthlyOutputQty(PpOutputAssyMasterQueryDto parm)
        {
            int MonthlyQty;
            var db = Context;
            var predicate = QueryExpCurrent(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                // .Where((x1, x2) => Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM") == DateTime.Now.ToString("yyyy-MM"))
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                }).ToList();
            if (response.Count == 0)
            {
                MonthlyQty = 0;
            }
            else
            {
                MonthlyQty = response[0].RealOutputQty;
            }

            return MonthlyQty;
        }

        /// <summary>
        /// 按月统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListMonthOutput(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)) * 100, 2),
                })
                .ToDictionaryList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 导出月度OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic ExportListMonthOutput(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)) * 100, 2),
                }).ToList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 按月,班组统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListMonthLineOutput(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    x1.PomLine,
                    x1.PomLot,
                    x1.PomModel,
                    x1.PomItem,
                    x1.PomStdTime,
                    x1.PomDirect,
                    x1.PomIndirect
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    MfgLine = x1.PomLine,
                    MfgLot = x1.PomLot,
                    MfgModel = x1.PomModel,
                    MfgItem = x1.PomItem,
                    StdTime = x1.PomStdTime,
                    Direct = x1.PomDirect,
                    Indirect = x1.PomIndirect,
                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0)), //实际工数,
                    InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)), //投入工数,
                    RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 1)), 2), //实际ST,
                    RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际ST差异,
                    RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际台数差异,

                    AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 1)) * 100, 2),
                }).ToDictionaryList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 按月,班组统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListMonthLineOutputBar(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    x1.PomLine,
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    MfgLine = x1.PomLine,

                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0)), //实际工数,
                    InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)), //投入工数,
                    RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 1)), 2), //实际ST,
                    RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际ST差异,
                    RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际台数差异,

                    AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 1)) * 100, 2),
                }).ToDictionaryList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 当月,班组统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListCurrentMonthLineOutputBar(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExpCurrent(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    x1.PomLine,
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    MfgLine = x1.PomLine,

                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0)), //实际工数,
                    InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)), //投入工数,
                    RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 1)), 2), //实际ST,
                    RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际ST差异,
                    RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际台数差异,

                    AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 1)) * 100, 2),
                }).ToDictionaryList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 导出月度OPH-班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic ExportListMonthLineOutput(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    x1.PomLine,
                    x1.PomLot,
                    x1.PomModel,
                    x1.PomItem,
                    x1.PomStdTime,
                    x1.PomDirect,
                    x1.PomIndirect
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    MfgLine = x1.PomLine,
                    MfgLot = x1.PomLot,
                    MfgModel = x1.PomModel,
                    MfgItem = x1.PomItem,
                    StdTime = x1.PomStdTime,
                    Direct = x1.PomDirect,
                    Indirect = x1.PomIndirect,
                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0)), //实际工数,
                    InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)), //投入工数,
                    RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 1)), 2), //实际ST,
                    RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际ST差异,
                    RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际台数差异,

                    AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 1)) * 100, 2),
                }).ToList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 按月，机种统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListMonthModelOutput(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    x1.PomModel
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    MfgModel = x1.PomModel,
                    StdTime = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.PomStdTime > 0, x1.PomStdTime, 0)), //求和,
                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0)), //实际工数,

                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    Direct = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.PomDirect > 0, x1.PomDirect, 0)), //求和,
                    RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 1)), 2), //实际ST,
                    RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际ST差异,
                    RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际台数差异,
                    AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 1)) * 100, 2),
                }).ToDictionaryList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 导出月度OPH-机种
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic ExportListMonthModelOutput(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    x1.PomModel
                })
                .Select((x1, x2) => new
                {
                    生産日付Date = Convert.ToDateTime(x1.PomDate).ToString("yyyy-MM"),
                    生産モデルModel = x1.PomModel,
                    標準ST = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.PomStdTime > 0, x1.PomStdTime, 0)), //求和,
                    計画台数Qty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    生産工数Workhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0)), //实际工数,

                    实绩台数Qty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    直接人员Direct = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.PomDirect > 0, x1.PomDirect, 0)), //求和,
                    实绩STWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 1)), 2), //实际ST,
                    ST差异Diff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际ST差异,
                    台数差异Diff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际台数差异,
                    达成率Rate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 1)) * 100, 2),
                }).ToList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 按年统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListYearOutput(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomDate).ToString("yyyy"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy"),
                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)) * 100, 2),
                }).ToDictionaryList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 导出年度OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic ExportListYearOutput(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomDate).ToString("yyyy"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy"),
                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)) * 100, 2),
                }).ToList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 按年,班组统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListYearLineOutput(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy"),
                    x1.PomLine,
                    x1.PomLot,
                    x1.PomModel,
                    x1.PomItem,
                    x1.PomStdTime,
                    x1.PomDirect,
                    x1.PomIndirect
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy"),
                    MfgLine = x1.PomLine,
                    MfgLot = x1.PomLot,
                    MfgModel = x1.PomModel,
                    MfgItem = x1.PomItem,
                    StdTime = x1.PomStdTime,
                    Direct = x1.PomDirect,
                    Indirect = x1.PomIndirect,
                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0)), //实际工数,
                    InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)), //投入工数,
                    RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 1)), 2), //实际ST,
                    RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际ST差异,
                    RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际台数差异,

                    AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 1)) * 100, 2),
                }).ToDictionaryList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 导出年度OPH-班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic ExportListYearLineOutput(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy"),
                    x1.PomLine,
                    x1.PomLot,
                    x1.PomModel,
                    x1.PomItem,
                    x1.PomStdTime,
                    x1.PomDirect,
                    x1.PomIndirect
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy"),
                    MfgLine = x1.PomLine,
                    MfgLot = x1.PomLot,
                    MfgModel = x1.PomModel,
                    MfgItem = x1.PomItem,
                    StdTime = x1.PomStdTime,
                    Direct = x1.PomDirect,
                    Indirect = x1.PomIndirect,
                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0)), //实际工数,
                    InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)), //投入工数,
                    RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 1)), 2), //实际ST,
                    RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际ST差异,
                    RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际台数差异,

                    AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 1)) * 100, 2),
                }).ToList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 按年，机种统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListYearModelOutput(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy"),
                    x1.PomModel
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy"),
                    MfgModel = x1.PomModel,
                    StdTime = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.PomStdTime > 0, x1.PomStdTime, 0)), //求和,
                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0)), //实际工数,

                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    Direct = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.PomDirect > 0, x1.PomDirect, 0)), //求和,
                    RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 1)), 2), //实际ST,
                    RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际ST差异,
                    RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际台数差异,
                    AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 1)) * 100, 2),
                }).ToDictionaryList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 导年月度OPH-机种
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic ExportListYearModelOutput(PpOutputAssyMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputAssySlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfId == x2.PosParentSfId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomDate = Convert.ToDateTime(x1.PomDate).ToString("yyyy"),
                    x1.PomModel
                })
                .Select((x1, x2) => new
                {
                    生産日付Date = Convert.ToDateTime(x1.PomDate).ToString("yyyy"),
                    生産モデルModel = x1.PomModel,
                    標準ST = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.PomStdTime > 0, x1.PomStdTime, 0)), //求和,
                    計画台数Qty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    生産工数Workhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0)), //实际工数,

                    实绩台数Qty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    直接人员Direct = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.PomDirect > 0, x1.PomDirect, 0)), //求和,
                    实绩STWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 1)), 2), //实际ST,
                    ST差异Diff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际ST差异,
                    台数差异Diff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际台数差异,
                    达成率Rate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 1)) * 100, 2),
                }).ToList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpOutputAssyMaster> QueryExp(PpOutputAssyMasterQueryDto parm)
        {
            var predicate = Expressionable.Create<PpOutputAssyMaster>();

            predicate = predicate.AndIF(parm.BeginPomDate != null, it => it.PomDate >= parm.BeginPomDate);
            predicate = predicate.AndIF(parm.EndPomDate != null, it => it.PomDate <= parm.EndPomDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomLine), it => it.PomLine == parm.PomLine);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomModel), it => it.PomModel.Contains(parm.PomModel));
            return predicate;
        }

        /// <summary>
        /// 当月查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpOutputAssyMaster> QueryExpCurrent(PpOutputAssyMasterQueryDto parm)
        {
            var predicate = Expressionable.Create<PpOutputAssyMaster>();

            predicate = predicate.AndIF(parm.BeginPomDate != null, it => it.PomDate >= parm.BeginPomDate);
            predicate = predicate.AndIF(parm.EndPomDate != null, it => it.PomDate <= parm.EndPomDate);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomLine), it => it.PomLine == parm.PomLine);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomModel), it => it.PomModel.Contains(parm.PomModel));
            return predicate;
        }
    }
}