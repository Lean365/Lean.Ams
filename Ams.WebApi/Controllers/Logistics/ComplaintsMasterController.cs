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
    /// 主客诉管理
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 17:38:17)
    /// </summary>
    [Verify]
    [Route("logistics/ComplaintsMaster")]
    [ApiExplorerSettings(GroupName = "logistics")]
    public class ComplaintsMasterController : BaseController
    {
        /// <summary>
        /// 主客诉管理接口
        /// </summary>
        private readonly IComplaintsMasterService _ComplaintsMasterService;

        public ComplaintsMasterController(IComplaintsMasterService ComplaintsMasterService)
        {
            _ComplaintsMasterService = ComplaintsMasterService;
        }

        /// <summary>
        /// 查询主客诉管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:list")]
        public IActionResult QueryComplaintsMaster([FromQuery] ComplaintsMasterQueryDto parm)
        {
            var response = _ComplaintsMasterService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询主客诉管理详情
        /// </summary>
        /// <param name="QmcmSFID"></param>
        /// <returns></returns>
        [HttpGet("{QmcmSFID}")]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:query")]
        public IActionResult GetComplaintsMaster(long QmcmSFID)
        {
            var response = _ComplaintsMasterService.GetInfo(QmcmSFID);
            
            var info = response.Adapt<ComplaintsMasterDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加主客诉管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:add")]
        [Log(Title = "主客诉管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddComplaintsMaster([FromBody] ComplaintsMasterDto parm)
        {
            var modal = parm.Adapt<ComplaintsMaster>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_ComplaintsMasterService.CheckEntryUnique(parm.QmcmSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)主客诉管理 '{parm.QmcmSFID}'失败(failed)，输入的(The entered)主客诉管理已存在(already exists)"));
            }
            var response = _ComplaintsMasterService.AddComplaintsMaster(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新主客诉管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:edit")]
        [Log(Title = "主客诉管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateComplaintsMaster([FromBody] ComplaintsMasterDto parm)
        {
            var modal = parm.Adapt<ComplaintsMaster>().ToUpdate(HttpContext);
            var response = _ComplaintsMasterService.UpdateComplaintsMaster(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除主客诉管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:delete")]
        [Log(Title = "主客诉管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteComplaintsMaster([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_ComplaintsMasterService.Delete(idArr, "删除主客诉管理"));
        }

        /// <summary>
        /// 导出主客诉管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "主客诉管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "qm:complaintsmaster:export")]
        public IActionResult Export([FromQuery] ComplaintsMasterQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _ComplaintsMasterService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "主客诉管理", "主客诉管理","export/logistics");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}