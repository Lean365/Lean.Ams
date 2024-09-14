//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 标准工时
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:31:00
    /// </summary>
    [AppService(ServiceType = typeof(IPpMasterManhoursService), ServiceLifetime = LifeTime.Transient)]
    public class PpMasterManhoursService : BaseService<PpMasterManhours>, IPpMasterManhoursService
    {
        /// <summary>
        /// 查询标准工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpMasterManhoursDto> GetList(PpMasterManhoursQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mb003 asc")
                .Where(predicate.ToExpression())
                .ToPage<PpMasterManhours, PpMasterManhoursDto>(parm);

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
        public PpMasterManhours GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加标准工时
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpMasterManhours AddPpMasterManhours(PpMasterManhours model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改标准工时
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpMasterManhours(PpMasterManhours model)
        {
            return Update(model, true, "修改标准工时");
        }

        /// <summary>
        /// 导入标准工时
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpMasterManhours(List<PpMasterManhours> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mb002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Mb003.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.Mb008.IsEmpty(), "标准点数不能为空")
                .SplitError(x => x.Item.Mb010.IsEmpty(), "点数换算汇率不能为空")
                .SplitError(x => x.Item.Mb011.IsEmpty(), "标准工时不能为空")
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
        /// 导出标准工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpMasterManhoursDto> ExportList(PpMasterManhoursQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpMasterManhoursDto()
                {
                    //查询字典: <工厂> 
                    Mb002Label = it.Mb002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <工作中心> 
                    Mb007Label = it.Mb007.GetConfigValue<SysDictData>("sys_work_center"),
                    //查询字典: <点数换算汇率> 
                    Mb010Label = it.Mb010.GetConfigValue<SysDictData>("sys_short_convert"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpMasterManhours> QueryExp(PpMasterManhoursQueryDto parm)
        {
            var predicate = Expressionable.Create<PpMasterManhours>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb002), it => it.Mb002 == parm.Mb002);
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb003), it => it.Mb003.Contains(parm.Mb003));
            //查询字段: <机种名> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb004), it => it.Mb004.Contains(parm.Mb004));
            //查询字段: <物料描述> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb006), it => it.Mb006.Contains(parm.Mb006));
            //查询字段: <工作中心> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb007), it => it.Mb007 == parm.Mb007);
            //查询字段: <生效日期> 
            //predicate = predicate.AndIF(parm.BeginMb013 == null, it => it.Mb013 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMb013 != null, it => it.Mb013 >= parm.BeginMb013);
            //predicate = predicate.AndIF(parm.EndMb013 != null, it => it.Mb013 <= parm.EndMb013);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMb013 == null, it => it.Mb013 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMb013 == null, it => it.Mb013 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMb013 != null, it => it.Mb013 >= parm.BeginMb013);
            predicate = predicate.AndIF(parm.EndMb013 != null, it => it.Mb013 <= parm.EndMb013);
            return predicate;
        }
    }
}