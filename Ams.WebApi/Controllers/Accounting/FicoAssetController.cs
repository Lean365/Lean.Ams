using Microsoft.AspNetCore.Mvc;
using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;
using MiniExcelLibs;


namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 固定资产
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/4 15:23:24
    /// </summary>
    [Verify]
    [Route("Accounting/FicoAsset")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoAssetController : BaseController
    {
        /// <summary>
        /// 固定资产接口
        /// </summary>
        private readonly IFicoAssetService _FicoAssetService;

        public FicoAssetController(IFicoAssetService FicoAssetService)
        {
            _FicoAssetService = FicoAssetService;
        }

        /// <summary>
        /// 查询固定资产列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:asset:list")]
        public IActionResult QueryFicoAsset([FromQuery] FicoAssetQueryDto parm)
        {
            var response = _FicoAssetService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询固定资产详情
        /// </summary>
        /// <param name="FaSFID"></param>
        /// <returns></returns>
        [HttpGet("{FaSFID}")]
        [ActionPermissionFilter(Permission = "fico:asset:query")]
        public IActionResult GetFicoAsset(long FaSFID)
        {
            var response = _FicoAssetService.GetInfo(FaSFID);
            
            var info = response.Adapt<FicoAssetDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加固定资产
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:asset:add")]
        [Log(Title = "固定资产", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoAsset([FromBody] FicoAssetDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoAssetService.CheckInputUnique(parm.FaSFID.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增固定资产 '{parm.FaSFID}'失败(Add failed)，输入的固定资产已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoAsset>().ToCreate(HttpContext);

            var response = _FicoAssetService.AddFicoAsset(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新固定资产
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:asset:edit")]
        [Log(Title = "固定资产", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoAsset([FromBody] FicoAssetDto parm)
        {
            var modal = parm.Adapt<FicoAsset>().ToUpdate(HttpContext);
            var response = _FicoAssetService.UpdateFicoAsset(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除固定资产
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:asset:delete")]
        [Log(Title = "固定资产", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoAsset([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoAssetService.Delete(idArr, "删除固定资产"));
        }

        /// <summary>
        /// 导出固定资产
        /// </summary>
        /// <returns></returns>
        [Log(Title = "固定资产", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:asset:export")]
        public IActionResult Export([FromQuery] FicoAssetQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoAssetService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "固定资产", "固定资产");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "固定资产导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:asset:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoAssetDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoAssetDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoAssetService.ImportFicoAsset(list.Adapt<List<FicoAsset>>()));
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
            var result = DownloadImportTemplate(new List<FicoAssetDto>() { }, "FicoAsset");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}