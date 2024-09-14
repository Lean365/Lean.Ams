//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 源工时
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:39:17
    /// </summary>
    [AppService(ServiceType = typeof(IPpSourceManhoursService), ServiceLifetime = LifeTime.Transient)]
    public class PpSourceManhoursService : BaseService<PpSourceManhours>, IPpSourceManhoursService
    {
        /// <summary>
        /// 查询源工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceManhoursDto> GetList(PpSourceManhoursQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Zc003 asc")
                .Where(predicate.ToExpression())
                .ToPage<PpSourceManhours, PpSourceManhoursDto>(parm);

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
        public PpSourceManhours GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加源工时
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpSourceManhours AddPpSourceManhours(PpSourceManhours model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改源工时
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpSourceManhours(PpSourceManhours model)
        {
            return Update(model, true, "修改源工时");
        }

        /// <summary>
        /// 导入源工时
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpSourceManhours(List<PpSourceManhours> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Zc002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Zc003.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.Zc006.IsEmpty(), "标准值不能为空")
                .SplitError(x => x.Item.Zc008.IsEmpty(), "标准值不能为空")
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
        /// 导出源工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceManhoursDto> ExportList(PpSourceManhoursQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpSourceManhoursDto()
                {
                    //查询字典: <工厂> 
                    Zc002Label = it.Zc002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <工作中心> 
                    Zc004Label = it.Zc004.GetConfigValue<SysDictData>("sys_work_center"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpSourceManhours> QueryExp(PpSourceManhoursQueryDto parm)
        {
            var predicate = Expressionable.Create<PpSourceManhours>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zc002), it => it.Zc002 == parm.Zc002);
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zc003), it => it.Zc003.Contains(parm.Zc003));
            //查询字段: <工作中心> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zc004), it => it.Zc004 == parm.Zc004);
            return predicate;
        }
    }
}