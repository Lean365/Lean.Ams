using Ams.Infrastructure.Helper;

namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 文件存储Controller
    /// </summary>
    [Verify]
    [Route("routine/file/stroage")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class FileStorageController : BaseController
    {
        /// <summary>
        /// 文件存储接口
        /// </summary>
        private readonly IFileStorageService _FileStorageService;

        public FileStorageController(IFileStorageService FileStorageService)
        {
            _FileStorageService = FileStorageService;
        }

        /// <summary>
        /// 查询文件存储列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:file:list")]
        public IActionResult QueryFileStorage([FromQuery] FileStorageQueryDto parm)
        {
            var predicate = Expressionable.Create<FileStorage>();

            predicate = predicate.AndIF(parm.BeginCreate_time != null, it => it.Create_time >= parm.BeginCreate_time);
            predicate = predicate.AndIF(parm.EndCreate_time != null, it => it.Create_time <= parm.EndCreate_time);
            predicate = predicate.AndIF(parm.StoreType != null, m => m.StoreType == parm.StoreType);
            predicate = predicate.AndIF(parm.FileId != null, m => m.Id == parm.FileId);

            var response = _FileStorageService.GetPages(predicate.ToExpression(), parm, x => x.Id, OrderByType.Desc);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询文件存储详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "routine:file:query")]
        public IActionResult GetFileStorage(long Id)
        {
            var response = _FileStorageService.GetFirst(x => x.Id == Id);

            return SUCCESS(response);
        }

        /// <summary>
        /// 删除文件存储
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "routine:file:delete")]
        [Log(Title = "文件存储", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFileStorage(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            //TODO 删除本地资源
            foreach (var id in idsArr)
            {
                FileUtil.DeleteFile(_FileStorageService.GetById(id).FileUrl.Substring(0, _FileStorageService.GetById(id).FileUrl.LastIndexOf("/") + 1), _FileStorageService.GetById(id).FileName);
            }
            var response = _FileStorageService.Delete(idsArr);
            return ToResponse(response);
        }

        /// <summary>
        /// 文件存储导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "文件存储")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:file:export")]
        public IActionResult Export()
        {
            var list = _FileStorageService.GetAll();

            string sFileName = ExportExcel(list, "FileStorage", "文件存储");
            return SUCCESS(new { path = "/export/" + sFileName, fileName = sFileName });
        }
    }
}