﻿using Ams.Model.Logistics.Dto;
using Ams.Statistics.Logistics.IService;
using SqlSugar;

namespace Ams.Statistics.Logistics.Service
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IPcbaOutputStatiService), ServiceLifetime = LifeTime.Transient)]
    public class PcbaOutputStatiService : BaseService<PpOutputPcbaMa>, IPcbaOutputStatiService
    {
        /// <summary>
        /// 查询最大ID
        /// </summary>
        /// <returns></returns>
        public string GetMaxSfId()
        {
            string? MaxSfId;
            var db = Context;
            long SfId = db.Queryable<PpOutputPcbaMa>().Max(it => it.Id).ParseToLong();//异步
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
        public int GetMonthlyOutputQty(PpOutputPcbaMaQueryDto parm)
        {
            int MonthlyQty;
            var db = Context;
            var predicate = QueryExpCurrent(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                // .Where((x1, x2) => Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM") == DateTime.Now.ToString("yyyy-MM"))
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
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
        public List<Dictionary<string, object>> GetListMonthOutput(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)) * 100, 2),
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
        public dynamic ExportListMonthOutput(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)) * 100, 2),
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
        public List<Dictionary<string, object>> GetListMonthLineOutput(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    Mma009 = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    x2.Mda003,
                    x1.Mca005,
                    x1.Mca006,
                    x1.Mca007,
                    //x1.Mma013,
                    //x1.Mma011,
                    //x1.Mma012
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    MfgLine = x2.Mda003,
                    MfgLot = x1.Mca005,
                    MfgModel = x1.Mca006,
                    MfgItem = x1.Mca007,
                    //StdTime = x1.Mma013,
                    //Direct = x1.Mma011,
                    //Indirect = x1.Mma012,
                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb004 > 0, x2.Mmb004, 0)), //实际工数,
                    //InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)), //投入工数,
                    //RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 1)), 2), //实际ST,
                    //RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际ST差异,
                    //RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际台数差异,

                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 1)) * 100, 2),
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
        public List<Dictionary<string, object>> GetListMonthLineOutputBar(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    Mma009 = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    x2.Mda003,
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    MfgLine = x2.Mda003,

                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb004 > 0, x2.Mmb004, 0)), //实际工数,
                    //InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)), //投入工数,
                    //RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 1)), 2), //实际ST,
                    //RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际ST差异,
                    //RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际台数差异,

                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 1)) * 100, 2),
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
        public List<Dictionary<string, object>> GetListCurrentMonthLineOutputBar(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExpCurrent(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    Mma009 = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    x2.Mda003,
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    MfgLine = x2.Mda003,

                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb004 > 0, x2.Mmb004, 0)), //实际工数,
                    //InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)), //投入工数,
                    //RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 1)), 2), //实际ST,
                    //RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际ST差异,
                    //RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际台数差异,

                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 1)) * 100, 2),
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
        public dynamic ExportListMonthLineOutput(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    Mma009 = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    x2.Mda003,
                    x1.Mca005,
                    x1.Mca006,
                    x1.Mca007,
                    //x1.Mma013,
                    //x1.Mma011,
                    //x1.Mma012
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    MfgLine = x2.Mda003,
                    MfgLot = x1.Mca005,
                    MfgModel = x1.Mca006,
                    MfgItem = x1.Mca007,
                    //StdTime = x1.Mma013,
                    //Direct = x1.Mma011,
                    //Indirect = x1.Mma012,
                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb004 > 0, x2.Mmb004, 0)), //实际工数,
                    //InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)), //投入工数,
                    //RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 1)), 2), //实际ST,
                    //RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际ST差异,
                    //RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际台数差异,

                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 1)) * 100, 2),
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
        public List<Dictionary<string, object>> GetListMonthModelOutput(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    Mma009 = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    x1.Mca006,
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    MfgModel = x1.Mca006,
                    //StdTime = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.Mma013 > 0, x1.Mma013, 0)), //求和,
                    // StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    //RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb004 > 0, x2.Mmb004, 0)), //实际工数,

                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //Direct = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.Mma011 > 0, x1.Mma011, 0)), //求和,
                    //RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 1)), 2), //实际ST,
                    //RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际ST差异,
                    //RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际台数差异,
                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 1)) * 100, 2),
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
        public dynamic ExportListMonthModelOutput(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    Mma009 = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    x1.Mca006
                })
                .Select((x1, x2) => new
                {
                    生産日付Date = Convert.ToDateTime(x1.Mca010).ToString("yyyy-MM"),
                    生産モデルModel = x1.Mca006,
                    //標準ST = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.Mma013 > 0, x1.Mma013, 0)), //求和,
                    //計画台数Qty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    //生産工数Workhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb004 > 0, x2.Mmb004, 0)), //实际工数,

                    实绩台数Qty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //直接人员Direct = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.Mma011 > 0, x1.Mma011, 0)), //求和,
                    //实绩STWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 1)), 2), //实际ST,
                    //ST差异Diff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际ST差异,
                    //台数差异Diff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际台数差异,
                    //达成率Rate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 1)) * 100, 2),
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
        public List<Dictionary<string, object>> GetListYearOutput(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.Mca010).ToString("yyyy"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mca010).ToString("yyyy"),
                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)) * 100, 2),
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
        public dynamic ExportListYearOutput(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.Mca010).ToString("yyyy"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mca010).ToString("yyyy"),
                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)) * 100, 2),
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
        public List<Dictionary<string, object>> GetListYearLineOutput(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    Mma009 = Convert.ToDateTime(x1.Mca010).ToString("yyyy"),
                    x2.Mda003,
                    x1.Mca005,
                    x1.Mca006,
                    x1.Mca007,
                    //x1.Mma013,
                    //x1.Mma011,
                    //x1.Mma012
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mca010).ToString("yyyy"),
                    MfgLine = x2.Mda003,
                    MfgLot = x1.Mca005,
                    MfgModel = x1.Mca006,
                    MfgItem = x1.Mca007,
                    //StdTime = x1.Mma013,
                    //Direct = x1.Mma011,
                    //Indirect = x1.Mma012,
                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb004 > 0, x2.Mmb004, 0)), //实际工数,
                    //InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)), //投入工数,
                    //RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 1)), 2), //实际ST,
                    //RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际ST差异,
                    //RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际台数差异,

                    // AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 1)) * 100, 2),
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
        public dynamic ExportListYearLineOutput(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    Mma009 = Convert.ToDateTime(x1.Mca010).ToString("yyyy"),
                    x2.Mda003,
                    x1.Mca005,
                    x1.Mca006,
                    x1.Mca007,
                    //x1.Mma013,
                    //x1.Mma011,
                    //x1.Mma012
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mca010).ToString("yyyy"),
                    MfgLine = x2.Mda003,
                    MfgLot = x1.Mca005,
                    MfgModel = x1.Mca006,
                    MfgItem = x1.Mca007,
                    //StdTime = x1.Mma013,
                    //Direct = x1.Mma011,
                    //Indirect = x1.Mma012,
                    // StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb004 > 0, x2.Mmb004, 0)), //实际工数,
                    //InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)), //投入工数,
                    //RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 1)), 2), //实际ST,
                    //RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际ST差异,
                    //RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际台数差异,

                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 1)) * 100, 2),
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
        public List<Dictionary<string, object>> GetListYearModelOutput(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    Mma009 = Convert.ToDateTime(x1.Mca010).ToString("yyyy"),
                    x1.Mca006
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mca010).ToString("yyyy"),
                    MfgModel = x1.Mca006,
                    //StdTime = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.Mma013 > 0, x1.Mma013, 0)), //求和,
                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    //RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb004 > 0, x2.Mmb004, 0)), //实际工数,

                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //Direct = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.Mma011 > 0, x1.Mma011, 0)), //求和,
                    //RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 1)), 2), //实际ST,
                    //RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际ST差异,
                    //RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际台数差异,
                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 1)) * 100, 2),
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
        public dynamic ExportListYearModelOutput(PpOutputPcbaMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputPcbaSlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpOutputPcbaSlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    Mma009 = Convert.ToDateTime(x1.Mca010).ToString("yyyy"),
                    x1.Mca006
                })
                .Select((x1, x2) => new
                {
                    生産日付Date = Convert.ToDateTime(x1.Mca010).ToString("yyyy"),
                    生産モデルModel = x1.Mca006,
                    //標準ST = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.Mma013 > 0, x1.Mma013, 0)), //求和,
                    //計画台数Qty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    //生産工数Workhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb004 > 0, x2.Mmb004, 0)), //实际工数,

                    实绩台数Qty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)),
                    //直接人员Direct = SqlFunc.AggregateAvg(SqlFunc.IIF(x1.Mma011 > 0, x1.Mma011, 0)), //求和,
                    //实绩STWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 1)), 2), //实际ST,
                    //ST差异Diff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际ST差异,
                    //台数差异Diff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际台数差异,
                    //达成率Rate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mda007 > 0, x2.Mda007, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 1)) * 100, 2),
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
        private static Expressionable<PpOutputPcbaMa> QueryExp(PpOutputPcbaMaQueryDto parm)
        {
            var predicate = Expressionable.Create<PpOutputPcbaMa>();

            predicate = predicate.AndIF(parm.BeginMca010 != null, it => it.Mca010 >= parm.BeginMca010);
            predicate = predicate.AndIF(parm.EndMca010 != null, it => it.Mca010 <= parm.EndMca010);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mca003), it => it.Mca003 == parm.Mca003);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mca005), it => it.Mca005.Contains(parm.Mca005));
            return predicate;
        }

        /// <summary>
        /// 当月查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpOutputPcbaMa> QueryExpCurrent(PpOutputPcbaMaQueryDto parm)
        {
            var predicate = Expressionable.Create<PpOutputPcbaMa>();

            predicate = predicate.AndIF(parm.BeginMca010 != null, it => it.Mca010 >= parm.BeginMca010);
            predicate = predicate.AndIF(parm.EndMca010 != null, it => it.Mca010 <= parm.EndMca010);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mma010), it => it.Mma010 == parm.Mma010);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mma007), it => it.Mma007.Contains(parm.Mma007));
            return predicate;
        }
    }
}