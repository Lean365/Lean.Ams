using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;


namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 从客诉管理
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 17:05:54)
    /// </summary>
    [Verify]
    [Route("logistics/ComplaintsSlave")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class ComplaintsSlaveController : BaseController
    {
        /// <summary>
        /// 从客诉管理接口
        /// </summary>
        private readonly IComplaintsSlaveService _ComplaintsSlaveService;

        public ComplaintsSlaveController(IComplaintsSlaveService ComplaintsSlaveService)
        {
            _ComplaintsSlaveService = ComplaintsSlaveService;
        }

        /// <summary>
        /// 查询从客诉管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:complaintsslave:list")]
        public IActionResult QueryComplaintsSlave([FromQuery] ComplaintsSlaveQueryDto parm)
        {
            var response = _ComplaintsSlaveService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询从客诉管理详情
        /// </summary>
        /// <param name="QmcsSFID"></param>
        /// <returns></returns>
        [HttpGet("{QmcsSFID}")]
        [ActionPermissionFilter(Permission = "qm:complaintsslave:query")]
        public IActionResult GetComplaintsSlave(long QmcsSFID)
        {
            var response = _ComplaintsSlaveService.GetInfo(QmcsSFID);
            
            var info = response.Adapt<ComplaintsSlaveDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加从客诉管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:complaintsslave:add")]
        [Log(Title = "从客诉管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddComplaintsSlave([FromBody] ComplaintsSlaveDto parm)
        {
            var modal = parm.Adapt<ComplaintsSlave>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_ComplaintsSlaveService.CheckEntryUnique(parm.QmcsSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)从客诉管理 '{parm.QmcsSFID}'失败(failed)，输入的(The entered)从客诉管理已存在(already exists)"));
            }
            var response = _ComplaintsSlaveService.AddComplaintsSlave(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新从客诉管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:complaintsslave:edit")]
        [Log(Title = "从客诉管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateComplaintsSlave([FromBody] ComplaintsSlaveDto parm)
        {
            var modal = parm.Adapt<ComplaintsSlave>().ToUpdate(HttpContext);
            var response = _ComplaintsSlaveService.UpdateComplaintsSlave(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除从客诉管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:complaintsslave:delete")]
        [Log(Title = "从客诉管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteComplaintsSlave([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_ComplaintsSlaveService.Delete(idArr, "删除从客诉管理"));
        }

        /// <summary>
        /// 导出从客诉管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "从客诉管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:complaintsslave:export")]
        public IActionResult Export([FromQuery] ComplaintsSlaveQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _ComplaintsSlaveService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "从客诉管理", "从客诉管理","export/logistics");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}