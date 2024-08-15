using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 生产班组
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 14:45:07
    /// </summary>
    [AppService(ServiceType = typeof(IPpLineService), ServiceLifetime = LifeTime.Transient)]
    public class PpLineService : BaseService<PpLine>, IPpLineService
    {
        /// <summary>
        /// 查询生产班组列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpLineDto> GetList(PpLineQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpLine, PpLineDto>(parm);

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
            int count = Count(it => it. PlSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PlSfId"></param>
        /// <returns></returns>
        public PpLine GetInfo(long PlSfId)
        {
            var response = Queryable()
                .Where(x => x.PlSfId == PlSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加生产班组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpLine AddPpLine(PpLine model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改生产班组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpLine(PpLine model)
        {
            return Update(model, true, "修改生产班组");
        }

        /// <summary>
        /// 导入生产班组
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpLine(List<PpLine> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PlSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.PlLineType.IsEmpty(), "班组类别不能为空")
                .SplitError(x => x.Item.PlLineCode.IsEmpty(), "班组代码不能为空")
                .SplitError(x => x.Item.PlLineLangCode.IsEmpty(), "翻译Key不能为空")
                .SplitError(x => x.Item.PlLineName.IsEmpty(), "班组名称不能为空")
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
        /// 导出生产班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpLineDto> ExportList(PpLineQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpLineDto()
                {
                    PlLineTypeLabel = it.PlLineType.GetConfigValue<SysDictData>("sys_line_type"),
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
        private static Expressionable<PpLine> QueryExp(PpLineQueryDto parm)
        {
            var predicate = Expressionable.Create<PpLine>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PlLineType), it => it.PlLineType == parm.PlLineType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PlLineCode), it => it.PlLineCode.Contains(parm.PlLineCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PlLineName), it => it.PlLineName.Contains(parm.PlLineName));
            return predicate;
        }
    }
}