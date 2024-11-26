using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.WebApi.Controllers.Accounting
{
    /// <summary>
    /// 资产类别
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/12 16:16:33
    /// </summary>
    [Verify]
    [Route("Accounting/FicoAssetsCategory")]
    [ApiExplorerSettings(GroupName = "accounting")]
    public class FicoAssetsCategoryController(IFicoAssetsCategoryService FicoAssetsCategoryService) : BaseController
    {
        /// <summary>
        /// 资产类别接口
        /// </summary>
        private readonly IFicoAssetsCategoryService _FicoAssetsCategoryService = FicoAssetsCategoryService;

        //public FicoAssetsCategoryController(IFicoAssetsCategoryService FicoAssetsCategoryService)
        //{
        //    _FicoAssetsCategoryService = FicoAssetsCategoryService;
        //}

        /// <summary>
        /// 查询资产类别列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "fico:assetscategory:list")]
        public IActionResult QueryFicoAssetsCategory([FromQuery] FicoAssetsCategoryQueryDto parm)
        {
            var response = _FicoAssetsCategoryService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询资产类别详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "fico:assetscategory:query")]
        public IActionResult GetFicoAssetsCategory(long Id)
        {
            var response = _FicoAssetsCategoryService.GetInfo(Id);

            var info = response.Adapt<FicoAssetsCategoryDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加资产类别
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "fico:assetscategory:add")]
        [Log(Title = "资产类别", BusinessType = BusinessType.ADD)]
        public IActionResult AddFicoAssetsCategory([FromBody] FicoAssetsCategoryDto parm)
        {
            // 校验输入项目唯一性

            if (UserConstants.NOT_UNIQUE.Equals(_FicoAssetsCategoryService.CheckInputUnique(parm.Id.ToString())))
            {
                return ToResponse(ApiResult.Error($"新增资产类别 '{parm.Id}'失败(Add failed)，输入的资产类别已存在(The entered already exists)"));
            }
            var modal = parm.Adapt<FicoAssetsCategory>().ToCreate(HttpContext);

            var response = _FicoAssetsCategoryService.AddFicoAssetsCategory(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新资产类别
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "fico:assetscategory:edit")]
        [Log(Title = "资产类别", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateFicoAssetsCategory([FromBody] FicoAssetsCategoryDto parm)
        {
            var modal = parm.Adapt<FicoAssetsCategory>().ToUpdate(HttpContext);
            var response = _FicoAssetsCategoryService.UpdateFicoAssetsCategory(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除资产类别
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "fico:assetscategory:delete")]
        [Log(Title = "资产类别", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteFicoAssetsCategory([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<long>(ids);

            return ToResponse(_FicoAssetsCategoryService.Delete(idArr, "删除资产类别"));
        }

        /// <summary>
        /// 导出资产类别
        /// </summary>
        /// <returns></returns>
        [Log(Title = "资产类别导出", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "fico:assetscategory:export")]
        public IActionResult Export([FromQuery] FicoAssetsCategoryQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _FicoAssetsCategoryService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "资产类别", "资产类别");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 导入资产类别
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "资产类别导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "fico:assetscategory:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)//[FromForm(Name = "file")]
        {
            List<FicoAssetsCategoryDto> list = [];
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<FicoAssetsCategoryDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_FicoAssetsCategoryService.ImportFicoAssetsCategory(list.Adapt<List<FicoAssetsCategory>>()));
        }

        /// <summary>
        /// 资产类别
        /// 导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "资产类别模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportDataTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<FicoAssetsCategoryImportTpl>() { }, "FicoAssetsCategory_tpl");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}