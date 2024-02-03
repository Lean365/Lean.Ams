using Aliyun.OSS;
using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;
using JinianNet.JNTemplate;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.X509;
using SqlSugar;
using System.Collections.Generic;
using System.Linq;
namespace Ams.Report.Logistics.pp
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IProductionStatsService), ServiceLifetime = LifeTime.Transient)]
    public class OutputStatisticsService : BaseService<OutputMaster>, IProductionStatsService
    {

        /// <summary>
        /// 查询最大ID
        /// </summary>
        /// <returns></returns>
        public string QueryMaxSfid()
        {
            string? MaxSfid;
            var db = Context;
            long Sfid = db.Queryable<OutputMaster>().Max(it => it.PomSfid).ParseToLong();//异步
            if (!string.IsNullOrEmpty(Sfid.ToString())&& Sfid!=0)
            {
                MaxSfid = (Sfid + 1).ToString();
            }
            else
            {
                MaxSfid = SnowFlakeSingle.instance.NextId().ToString();
            }

            return MaxSfid;
        }

        /// <summary>
        /// 查询当月生产台数
        /// </summary>
        /// <returns></returns>
        public int QueryMonthlyProductionQty(OutputMasterQueryDto parm)
        {
            int MonthlyQty;
            var db = Context;
            var predicate = QueryExpCurrent(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
               // .Where((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM") == DateTime.Now.ToString("yyyy-MM"))
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
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
        public List<Dictionary<string, object>> QueryCountMonthOutput(OutputMasterQueryDto parm)
        {
            
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        public  dynamic ExportMonthOutputList(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        public List<Dictionary<string, object>> QueryCountMonthLineOutput(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) =>new
                {
                    PomMfgDate=Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    x1.PomMfgLine,
                    x1.PomMfgLot,
                    x1.PomMfgModel,
                    x1.PomMfgItem,
                    x1.PomStdTime,
                    x1.PomDirect,
                    x1.PomIndirect
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    MfgLine=x1.PomMfgLine,
                    MfgLot=x1.PomMfgLot,
                    MfgModel=x1.PomMfgModel,
                    MfgItem=x1.PomMfgItem,
                    StdTime=x1.PomStdTime,
                    Direct=x1.PomDirect,
                    Indirect=x1.PomIndirect,
                    StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0)),
                    RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0))- SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0)), //实际工数,
                    InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)), //投入工数,
                    RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0))/ SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 1)),2), //实际ST,
                    RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际ST差异,
                    RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosRealOutput > 0, x2.PosRealOutput, 0))- SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.PomStdOutput > 0, x1.PomStdOutput, 0)), //实际台数差异,

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
        public List<Dictionary<string, object>> QueryCountMonthLineOutputBar(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomMfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    x1.PomMfgLine,

                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    MfgLine = x1.PomMfgLine,

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
        public List<Dictionary<string, object>> QueryCountCurrentMonthOutputBar(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExpCurrent(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomMfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    x1.PomMfgLine,

                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    MfgLine = x1.PomMfgLine,

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
        public dynamic ExportMonthLineOutputList(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomMfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    x1.PomMfgLine,
                    x1.PomMfgLot,
                    x1.PomMfgModel,
                    x1.PomMfgItem,
                    x1.PomStdTime,
                    x1.PomDirect,
                    x1.PomIndirect
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    MfgLine = x1.PomMfgLine,
                    MfgLot = x1.PomMfgLot,
                    MfgModel = x1.PomMfgModel,
                    MfgItem = x1.PomMfgItem,
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
        public List<Dictionary<string, object>> QueryCountMonthModelOutput(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new {
                    PomMfgDate=Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    x1.PomMfgModel
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    MfgModel = x1.PomMfgModel,
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
        public dynamic ExportMonthModelOutputList(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new {
                    PomMfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    x1.PomMfgModel
                })
                .Select((x1, x2) => new
                {
                    生産日付Date = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    生産モデルModel = x1.PomMfgModel,
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
        public List<Dictionary<string, object>> QueryCountYearOutput(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy"),
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
        public dynamic ExportYearOutputList(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy"),
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
        public List<Dictionary<string, object>> QueryCountYearLineOutput(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomMfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy"),
                    x1.PomMfgLine,
                    x1.PomMfgLot,
                    x1.PomMfgModel,
                    x1.PomMfgItem,
                    x1.PomStdTime,
                    x1.PomDirect,
                    x1.PomIndirect
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy"),
                    MfgLine = x1.PomMfgLine,
                    MfgLot = x1.PomMfgLot,
                    MfgModel = x1.PomMfgModel,
                    MfgItem = x1.PomMfgItem,
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
        public dynamic ExportYearLineOutputList(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    PomMfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy"),
                    x1.PomMfgLine,
                    x1.PomMfgLot,
                    x1.PomMfgModel,
                    x1.PomMfgItem,
                    x1.PomStdTime,
                    x1.PomDirect,
                    x1.PomIndirect
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy"),
                    MfgLine = x1.PomMfgLine,
                    MfgLot = x1.PomMfgLot,
                    MfgModel = x1.PomMfgModel,
                    MfgItem = x1.PomMfgItem,
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
        public List<Dictionary<string, object>> QueryCountYearModelOutput(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new {
                    PomMfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy"),
                    x1.PomMfgModel
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy"),
                    MfgModel = x1.PomMfgModel,
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
        public dynamic ExportYearModelOutputList(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new {
                    PomMfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy"),
                    x1.PomMfgModel
                })
                .Select((x1, x2) => new
                {
                    生産日付Date = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy"),
                    生産モデルModel = x1.PomMfgModel,
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
        /// 按月统计Ec
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountMonthEc(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按月统计不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountMonthDefective(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按月统计工数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountMonthLaborhours(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
                    DownTime = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0)), //求和,
                    RealWorkhours = ((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0))),
                    InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0)),
                    TimeRate = SqlFunc.Round(((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 0))- SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosDownTime > 0, x2.PosDownTime, 0))) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.PosInputsWorkhours > 0, x2.PosInputsWorkhours, 1)) * 100, 2),

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
        /// 按月统计IQC进货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountMonthIncoming(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按月统计QA出货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountMonthOutgoing(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按月统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountMonthSales(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按月,国家统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountMonthAreaSales(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按月,仕向统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountMonthRegionSales(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按年统计Ec
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountYearEc(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按年统计不良
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountYearDefective(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按年统计工数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountYearLaborhours(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按年统计IQC进货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountYearIncoming(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按年统计QA出货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountYearOutgoing(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按年统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountYearSales(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按年国家统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountYearAreaSales(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 按年仕向统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountYearRegionSales(OutputMasterQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<OutputSlave>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页 
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.PomSfid == x2.PosParentSfid)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM"),
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
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<OutputMaster> QueryExp(OutputMasterQueryDto parm)
        {

            var predicate = Expressionable.Create<OutputMaster>();

            predicate = predicate.AndIF(parm.BeginPomMfgDate != null, it => it.PomMfgDate >= parm.BeginPomMfgDate);
            predicate = predicate.AndIF(parm.EndPomMfgDate != null, it => it.PomMfgDate <= parm.EndPomMfgDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomMfgLine), it => it.PomMfgLine == parm.PomMfgLine);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomMfgModel), it => it.PomMfgModel.Contains(parm.PomMfgModel));
            return predicate;
        }

        /// <summary>
        /// 当月查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<OutputMaster> QueryExpCurrent(OutputMasterQueryDto parm)
        {


            var predicate = Expressionable.Create<OutputMaster>();

            predicate = predicate.AndIF(parm.BeginPomMfgDate != null, it => it.PomMfgDate >= parm.BeginPomMfgDate);
            predicate = predicate.AndIF(parm.EndPomMfgDate != null, it => it.PomMfgDate <= parm.EndPomMfgDate);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomMfgLine), it => it.PomMfgLine == parm.PomMfgLine);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PomMfgModel), it => it.PomMfgModel.Contains(parm.PomMfgModel));
            return predicate;
        }
    }
}
