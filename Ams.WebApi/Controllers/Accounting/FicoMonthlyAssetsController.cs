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
    /// @Date: 2024/7/26 16:56:51
    /// </summary>
    [Verify]
    [Route("Accounting/FicoMonthlyAssets")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoMonthlyAssetsController : BaseController
    {
        /// <summary>
        /// 固定资产接口
        /// </summary>
        private readonly IFicoMonthlyAssetsService _FicoMonthlyAssetsService;

        public FicoMonthlyAssetsController(IFicoMonthlyAssetsService FicoMonthlyAssetsService)
        {
            _FicoMonthlyAssetsService = FicoMonthlyAssetsService;
        }

        /// <summary>
        /// 查询固定资产列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:monthlyassets:list")]
        public IActionResult QueryFicoMonthlyAssets([FromQuery] FicoMonthlyAssetsQueryDto parm)
        {
            var response = _FicoMonthlyAssetsService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询固定资产详情
        /// </summary>
        /// <param name="FaSfid"></param>
        /// <returns></returns>
        [HttpGet("{FaSfid}")]
        [ActionPermissionFilter(Permission = "fico:monthlyassets:query")]
        public IActionResult GetFicoMonthlyAssets(long FaSfid)
        {
            var response = _FicoMonthlyAssetsService.GetInfo(FaSfid);
            
            var info = response.Adapt<FicoMonthlyAssetsDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加固定资产
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:monthlyassets:add")]
        [Log(Title = "固定资产", BusinessType = BusinessType.INSERT)]
        public IActionResult AddFicoMonthlyAssets([FromBody] FicoMonthlyAssetsDto parm)
        {
           // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoMonthlyAssetsService.CheckInputUnique(parm.FaSfid.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增固定资产 '{parm.FaSfid}'失败(Add failed)，输入的固定资产已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoMonthlyAssets>().ToCreate(HttpContext);

            var response = _FicoMonthlyAssetsService.AddFicoMonthlyAssets(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新固定资产
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:monthlyassets:edit")]
        [Log(Title = "固定资产", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateFicoMonthlyAssets([FromBody] FicoMonthlyAssetsDto parm)
        {
            var modal = parm.Adapt<FicoMonthlyAssets>().ToUpdate(HttpContext);
            var response = _FicoMonthlyAssetsService.UpdateFicoMonthlyAssets(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除固定资产
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:monthlyassets:delete")]
        [Log(Title = "固定资产", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoMonthlyAssets([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoMonthlyAssetsService.Delete(idArr, "删除固定资产"));
        }

        /// <summary>
        /// 导出固定资产
        /// </summary>
        /// <returns></returns>
        [Log(Title = "固定资产", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:monthlyassets:export")]
        public IActionResult Export([FromQuery] FicoMonthlyAssetsQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoMonthlyAssetsService.ExportList(parm).Result;
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
        [ActionPermissionFilter(Permission = "fico:monthlyassets:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<FicoMonthlyAssetsDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoMonthlyAssetsDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoMonthlyAssetsService.ImportFicoMonthlyAssets(list.Adapt<List<FicoMonthlyAssets>>()));
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
            var result = DownloadImportTemplate(new List<FicoMonthlyAssetsImportTpl>() { }, "FicoMonthlyAssets_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}