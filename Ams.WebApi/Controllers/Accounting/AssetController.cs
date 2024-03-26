using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Filters;
using Microsoft.AspNetCore.Mvc;
using Ams.Kernel.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 固定资产
    /// API控制器
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/3/18 16:31:28)
    /// </summary>
    [Verify]
    [Route("accounting/Asset")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class AssetController : BaseController
    {
        /// <summary>
        /// 固定资产接口
        /// </summary>
        private readonly IAssetService _AssetService;

        public AssetController(IAssetService AssetService)
        {
            _AssetService = AssetService;
        }

        /// <summary>
        /// 查询固定资产列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:asset:list")]
        public IActionResult QueryAsset([FromQuery] AssetQueryDto parm)
        {
            var response = _AssetService.GetList(parm);
            return SUCCESS(response,TIME_FORMAT_YYYMMDD);
        }


        /// <summary>
        /// 查询固定资产详情
        /// </summary>
        /// <param name="FaSFID"></param>
        /// <returns></returns>
        [HttpGet("{FaSFID}")]
        [ActionPermissionFilter(Permission = "fico:asset:query")]
        public IActionResult GetAsset(long FaSFID)
        {
            var response = _AssetService.GetInfo(FaSFID);
            
            var info = response.Adapt<AssetDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加固定资产
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:asset:add")]
        [Log(Title = "固定资产", BusinessType = BusinessType.INSERT)]
        public IActionResult AddAsset([FromBody] AssetDto parm)
        {
            var modal = parm.Adapt<Asset>().ToCreate(HttpContext);
           
            // 校验输入项目唯一性
            if (UserConstants.NOT_UNIQUE.Equals(_AssetService.CheckEntryUnique(parm.FaSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增(New)固定资产 '{parm.FaSFID}'失败(failed)，输入的(The entered)固定资产已存在(already exists)"));
            }
            var response = _AssetService.AddAsset(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新固定资产
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:asset:edit")]
        [Log(Title = "固定资产", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateAsset([FromBody] AssetDto parm)
        {
            var modal = parm.Adapt<Asset>().ToUpdate(HttpContext);
            var response = _AssetService.UpdateAsset(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除固定资产
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:asset:delete")]
        [Log(Title = "固定资产", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteAsset([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_AssetService.Delete(idArr, "删除固定资产"));
        }

        /// <summary>
        /// 导出固定资产
        /// </summary>
        /// <returns></returns>
        [Log(Title = "固定资产", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:asset:export")]
        public IActionResult Export([FromQuery] AssetQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _AssetService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "固定资产", "固定资产","export/accounting");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入固定资产
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "固定资产导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:asset:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<AssetDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<AssetDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_AssetService.ImportAsset(list.Adapt<List<Asset>>()));
        }

        /// <summary>
        /// 固定资产导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "固定资产模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<AssetDto>() { }, "AssetTpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}