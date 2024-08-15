using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 原因类别
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:12:48
    /// </summary>
    [AppService(ServiceType = typeof(IPpCauseTypeService), ServiceLifetime = LifeTime.Transient)]
    public class PpCauseTypeService : BaseService<PpCauseType>, IPpCauseTypeService
    {
        /// <summary>
        /// 查询原因类别列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpCauseTypeDto> GetList(PpCauseTypeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpCauseType, PpCauseTypeDto>(parm);

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
            int count = Count(it => it. CtSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="CtSfId"></param>
        /// <returns></returns>
        public PpCauseType GetInfo(long CtSfId)
        {
            var response = Queryable()
                .Where(x => x.CtSfId == CtSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加原因类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpCauseType AddPpCauseType(PpCauseType model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改原因类别
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpCauseType(PpCauseType model)
        {
            return Update(model, true, "修改原因类别");
        }

        /// <summary>
        /// 导入原因类别
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpCauseType(List<PpCauseType> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.CtSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.CtCauseType.IsEmpty(), "原因类别不能为空")
                .SplitError(x => x.Item.CtCauseLangCode.IsEmpty(), "翻译Key不能为空")
                .SplitError(x => x.Item.CtCauseText.IsEmpty(), "原因名称不能为空")
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
        /// 导出原因类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpCauseTypeDto> ExportList(PpCauseTypeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpCauseTypeDto()
                {
                    CtCauseTypeLabel = it.CtCauseType.GetConfigValue<SysDictData>("sys_cause_category"),
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
        private static Expressionable<PpCauseType> QueryExp(PpCauseTypeQueryDto parm)
        {
            var predicate = Expressionable.Create<PpCauseType>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.CtCauseType), it => it.CtCauseType == parm.CtCauseType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.CtCauseText), it => it.CtCauseText.Contains(parm.CtCauseText));
            return predicate;
        }
    }
}