//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 生产班组
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:06:17
    /// </summary>
    [AppService(ServiceType = typeof(IPpMasterWorkshopService), ServiceLifetime = LifeTime.Transient)]
    public class PpMasterWorkshopService : BaseService<PpMasterWorkshop>, IPpMasterWorkshopService
    {
        /// <summary>
        /// 查询生产班组列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpMasterWorkshopDto> GetList(PpMasterWorkshopQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Md002 asc")
                .Where(predicate.ToExpression())
                .ToPage<PpMasterWorkshop, PpMasterWorkshopDto>(parm);

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
        public PpMasterWorkshop GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加生产班组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpMasterWorkshop AddPpMasterWorkshop(PpMasterWorkshop model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改生产班组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpMasterWorkshop(PpMasterWorkshop model)
        {
            return Update(model, true, "修改生产班组");
        }

        /// <summary>
        /// 导入生产班组
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpMasterWorkshop(List<PpMasterWorkshop> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Md002.IsEmpty(), "班组类别不能为空")
                .SplitError(x => x.Item.Md003.IsEmpty(), "班组代码不能为空")
                .SplitError(x => x.Item.Md005.IsEmpty(), "班组名称不能为空")
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
        /// 导出生产班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpMasterWorkshopDto> ExportList(PpMasterWorkshopQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpMasterWorkshopDto()
                {
                    //查询字典: <班组类别> 
                    Md002Label = it.Md002.GetConfigValue<SysDictData>("sys_line_type"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpMasterWorkshop> QueryExp(PpMasterWorkshopQueryDto parm)
        {
            var predicate = Expressionable.Create<PpMasterWorkshop>();

            //查询字段: <班组类别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md002), it => it.Md002 == parm.Md002);
            //查询字段: <班组代码> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md003), it => it.Md003.Contains(parm.Md003));
            //查询字段: <班组名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md005), it => it.Md005.Contains(parm.Md005));
            return predicate;
        }
    }
}