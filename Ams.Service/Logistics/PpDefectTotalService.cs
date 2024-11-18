//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 不良统计
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:19:12
    /// </summary>
    [AppService(ServiceType = typeof(IPpDefectTotalService), ServiceLifetime = LifeTime.Transient)]
    public class PpDefectTotalService : BaseService<PpDefectTotal>, IPpDefectTotalService
    {
        /// <summary>
        /// 查询不良统计列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpDefectTotalDto> GetList(PpDefectTotalQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Me005 desc")
                .Where(predicate.ToExpression())
                .ToPage<PpDefectTotal, PpDefectTotalDto>(parm);

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
        public PpDefectTotal GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加不良统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpDefectTotal AddPpDefectTotal(PpDefectTotal model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改不良统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpDefectTotal(PpDefectTotal model)
        {
            return Update(model, true, "修改不良统计");
        }

        /// <summary>
        /// 导入不良统计
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpDefectTotal(List<PpDefectTotal> list)
        {
            list.ForEach(it =>
            {
                it.Create_by = HttpContextExtension.GetName(App.HttpContext);
                it.Remark = it.Remark.IsEmpty() ? "数据由<"+HttpContextExtension.GetName(App.HttpContext)+">用户,批量导入" : it.Remark;
            });
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Me007.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.Me008.IsEmpty(), "生产不能为空")
                .SplitError(x => x.Item.Me009.IsEmpty(), "无不良数不能为空")
                .SplitError(x => x.Item.Me010.IsEmpty(), "不良总数不能为空")
                .SplitError(x => x.Item.Me011.IsEmpty(), "直行率不能为空")
                .SplitError(x => x.Item.Me012.IsEmpty(), "不良率不能为空")
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
        /// 导出不良统计
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpDefectTotalDto> ExportList(PpDefectTotalQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpDefectTotalDto()
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
        private static Expressionable<PpDefectTotal> QueryExp(PpDefectTotalQueryDto parm)
        {
            var predicate = Expressionable.Create<PpDefectTotal>();

            //查询字段: <批次> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me002), it => it.Me002.Contains(parm.Me002));
            //查询字段: <机种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me003), it => it.Me003.Contains(parm.Me003));
            //查询字段: <班组> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me004), it => it.Me004.Contains(parm.Me004));
            //查询字段: <日期> 
            //predicate = predicate.AndIF(parm.BeginMe005 == null, it => it.Me005 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMe005 != null, it => it.Me005 >= parm.BeginMe005);
            //predicate = predicate.AndIF(parm.EndMe005 != null, it => it.Me005 <= parm.EndMe005);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMe005 == null, it => it.Me005 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMe005 == null, it => it.Me005 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMe005 != null, it => it.Me005 >= parm.BeginMe005);
            predicate = predicate.AndIF(parm.EndMe005 != null, it => it.Me005 <= parm.EndMe005);
            return predicate;
        }
    }
}