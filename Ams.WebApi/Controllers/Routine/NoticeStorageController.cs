using Microsoft.AspNetCore.SignalR;

namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 系统通知
    /// </summary>
    [Verify]
    [Route("routine/notice/storage")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class NoticeStorageController : BaseController
    {
        /// <summary>
        /// 通知公告接口
        /// </summary>
        private readonly INoticeStorageService _NoticeStorageService;

        private readonly IHubContext<MessageHub> _hubContext;

        public NoticeStorageController(INoticeStorageService NoticeStorageService, IHubContext<MessageHub> hubContext)
        {
            _NoticeStorageService = NoticeStorageService;
            _hubContext = hubContext;
        }

        /// <summary>
        /// 查询通知公告列表(移动端用)
        /// </summary>
        /// <returns></returns>
        [HttpGet("queryNotice")]
        public IActionResult QueryNotice([FromQuery] NoticeStorageQueryDto parm)
        {
            var response = _NoticeStorageService.GetNoticeStorages();
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询通知公告列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:notice:list")]
        public IActionResult QueryNoticeStorage([FromQuery] NoticeStorageQueryDto parm)
        {
            PagedInfo<NoticeStorage> response = _NoticeStorageService.GetPageList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询通知公告详情
        /// </summary>
        /// <param name="NoticeId"></param>
        /// <returns></returns>
        [HttpGet("{NoticeId}")]
        public IActionResult GetNoticeStorage(int NoticeId)
        {
            var response = _NoticeStorageService.GetFirst(x => x.NoticeId == NoticeId);

            return SUCCESS(response);
        }

        /// <summary>
        /// 添加通知公告
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:notice:add")]
        [Log(Title = "发布通告", BusinessType = BusinessType.ADD, IsSaveRequestData = false)]
        public IActionResult AddNoticeStorage([FromBody] NoticeStorageDto parm)
        {
            var modal = parm.Adapt<NoticeStorage>().ToCreate(HttpContext);

            int result = _NoticeStorageService.InsertReturnIdentity(modal);

            return SUCCESS(result);
        }

        /// <summary>
        /// 更新通知公告
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:notice:edit")]
        [Log(Title = "修改公告", BusinessType = BusinessType.EDIT, IsSaveRequestData = false)]
        public IActionResult UpdateNoticeStorage([FromBody] NoticeStorageDto parm)
        {
            var model = parm.Adapt<NoticeStorage>().ToUpdate(HttpContext);

            var response = _NoticeStorageService.Update(model);

            return SUCCESS(response);
        }

        /// <summary>
        /// 发送通知公告
        /// </summary>
        /// <returns></returns>
        [HttpPut("send/{NoticeId}")]
        [ActionPermissionFilter(Permission = "routine:notice:send")]
        [Log(Title = "发送通知公告", BusinessType = BusinessType.SEND)]
        public IActionResult SendNotice(int NoticeId = 0)
        {
            if (NoticeId <= 0)
            {
                throw new CustomException("请求实体不能为空");
            }
            var response = _NoticeStorageService.GetFirst(x => x.NoticeId == NoticeId);
            if (response != null && response.IsStatus == 0)
            {
                _hubContext.Clients.All.SendAsync(HubsConstant.ReceiveNotice, response.NoticeTitle, response.NoticeContent);
            }
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除通知公告
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "routine:notice:delete")]
        [Log(Title = "通知公告", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteNoticeStorage(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _NoticeStorageService.Delete(idsArr);

            return SUCCESS(response);
        }

        /// <summary>
        /// 导出通知公告
        /// </summary>
        /// <returns></returns>
        [Log(Title = "通知公告", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:notice:export")]
        public IActionResult Export([FromQuery] NoticeStorageQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _NoticeStorageService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "通知公告", "通知公告");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}