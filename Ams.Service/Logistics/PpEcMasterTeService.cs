using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 技术
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 11:44:01
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcMasterTeService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcMasterTeService : BaseService<PpEcMasterTe>, IPpEcMasterTeService
    {
        /// <summary>
        /// 查询技术列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcMasterTeDto> GetList(PpEcMasterTeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("EcmIssueDate desc")
                .Where(predicate.ToExpression())
                .ToPage<PpEcMasterTe, PpEcMasterTeDto>(parm);

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
            int count = Count(it => it. EcmSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        public PpEcMasterTe GetInfo(long EcmSfId)
        {
            var response = Queryable()
                .Where(x => x.EcmSfId == EcmSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加技术
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcMasterTe AddPpEcMasterTe(PpEcMasterTe model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改技术
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcMasterTe(PpEcMasterTe model)
        {
            return Update(model, true, "修改技术");
        }

        /// <summary>
        /// 导入技术
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcMasterTe(List<PpEcMasterTe> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.EcmIssueDate.IsEmpty(), "发行日期不能为空")
                .SplitError(x => x.Item.EcmNo.IsEmpty(), "设变No.不能为空")
                .SplitError(x => x.Item.EcmStated.IsEmpty(), "设变状态不能为空")
                .SplitError(x => x.Item.EcmTitle.IsEmpty(), "标题不能为空")
                .SplitError(x => x.Item.EcmContent.IsEmpty(), "内容不能为空")
                .SplitError(x => x.Item.EcmLeader.IsEmpty(), "担当不能为空")
                .SplitError(x => x.Item.EcmLossAmount.IsEmpty(), "损失金额不能为空")
                .SplitError(x => x.Item.EcmManageCategory.IsEmpty(), "管理区分不能为空")
                .SplitError(x => x.Item.EcmEnteredDept.IsEmpty(), "输入部门不能为空")
                .SplitError(x => x.Item.EcmEnteredDate.IsEmpty(), "输入日不能为空")
                .SplitError(x => x.Item.EcmSopStated.IsEmpty(), "SOP更新否不能为空")
                .SplitError(x => x.Item.EcmImplStated.IsEmpty(), "实施标记不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
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
        /// 导出技术
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcMasterTeDto> ExportList(PpEcMasterTeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcMasterTeDto()
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
        private static Expressionable<PpEcMasterTe> QueryExp(PpEcMasterTeQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcMasterTe>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmNo), it => it.EcmNo == parm.EcmNo);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmTitle), it => it.EcmTitle == parm.EcmTitle);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmContent), it => it.EcmContent == parm.EcmContent);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmLeader), it => it.EcmLeader == parm.EcmLeader);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmEnteredDept), it => it.EcmEnteredDept == parm.EcmEnteredDept);
            return predicate;
        }
    }
}