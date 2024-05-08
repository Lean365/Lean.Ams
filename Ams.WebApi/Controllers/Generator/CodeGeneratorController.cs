using Ams.Generator;
using Ams.Generator.Model;
using Ams.Generator.Service;
using Ams.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SqlSugar;

namespace Ams.WebApi.Controllers.Generator
{
    /// <summary>
    /// 代码生成
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("tool/gen")]
    [ApiExplorerSettings(GroupName = "tool")]
    public class GeneratorController : BaseController
    {
        private readonly GenService _GenService = new GenService();
        private readonly IGenTableService _GenTableService;
        private readonly IGenTableColumnService _GenTableColumnService;
        private readonly ISysMenuService _SysMenuService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly OptionsSetting _OptionsSetting;

        public GeneratorController(
            IGenTableService GenTableService,
            IGenTableColumnService GenTableColumnService,
            IWebHostEnvironment WebHostEnvironment,
            IOptions<OptionsSetting> OptionsSetting,
            ISysMenuService SysMenuService)
        {
            _GenTableService = GenTableService;
            _GenTableColumnService = GenTableColumnService;
            _WebHostEnvironment = WebHostEnvironment;
            _SysMenuService = SysMenuService;
            _OptionsSetting = OptionsSetting.Value;
        }

        /// <summary>
        /// 获取所有数据库的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("getDbList")]
        [ActionPermissionFilter(Permission = "tool:gen:list")]
        public IActionResult GetListDataBase()
        {
            var dbList = _GenService.GetAllDataBases();
            var defaultDb = dbList?[0];
            return SUCCESS(new { dbList, defaultDb });
        }

        /// <summary>
        ///获取所有表根据数据库名
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="tableName">表名</param>
        /// <param name="pager">分页信息</param>
        /// <returns></returns>
        [HttpGet("getTableList")]
        [ActionPermissionFilter(Permission = "tool:gen:list")]
        public IActionResult FindListTable(string dbName, string? tableName, PagerInfo pager)
        {
            List<DbTableInfo> list = _GenService.GetAllTables(dbName, tableName, pager);
            var page = new PagedInfo<DbTableInfo>
            {
                TotalNum = pager.TotalNum,
                PageSize = pager.PageSize,
                PageIndex = pager.PageNum,
                Result = list
            };
            return SUCCESS(page);
        }

        /// <summary>
        /// 查询生成表数据
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="pagerInfo">分页信息</param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "tool:gen:list")]
        public IActionResult GetGenTable(string? tableName, PagerInfo pagerInfo)
        {
            //查询原表数据，部分字段映射到代码生成表字段
            var rows = _GenTableService.GetGenTables(new GenTable() { TableName = tableName }, pagerInfo);

            return SUCCESS(rows, TIME_FORMAT_FULL);
        }

        /// <summary>
        /// 修改代码生成业务查询
        /// </summary>
        /// <param name="tableId">genTable表id</param>
        /// <returns></returns>
        [HttpGet("{tableId}")]
        [ActionPermissionFilter(Permission = "tool:gen:query")]
        public IActionResult GetColumnList(long tableId)
        {
            var tableInfo = _GenTableService.GetGenTableInfo(tableId);
            var tables = _GenTableService.GetGenTableAll();
            return SUCCESS(new { info = tableInfo, tables });
        }

        /// <summary>
        /// 根据表id查询表列
        /// </summary>
        /// <param name="tableId">genTable表id</param>
        /// <returns></returns>
        [HttpGet("column/{tableId}")]
        [ActionPermissionFilter(Permission = "tool:gen:query")]
        public IActionResult GetTableColumnList(long tableId)
        {
            var tableColumns = _GenTableColumnService.GenTableColumns(tableId);

            return SUCCESS(new { columns = tableColumns });
        }

        /// <summary>
        /// 删除代码生成
        /// </summary>
        /// <param name="tableIds"></param>
        /// <returns></returns>
        [Log(Title = "代码生成", BusinessType = BusinessType.DELETE)]
        [HttpDelete("{tableIds}")]
        [ActionPermissionFilter(Permission = "tool:gen:delete")]
        public IActionResult Remove(string tableIds)
        {
            long[] tableId = Tools.SpitLongArrary(tableIds);

            int result = _GenTableService.DeleteGenTableByIds(tableId);
            return SUCCESS(result);
        }

        /// <summary>
        /// 导入表结构（保存）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("importTable")]
        [Log(Title = "代码生成", BusinessType = BusinessType.IMPORT)]
        [ActionPermissionFilter(Permission = "tool:gen:import")]
        public IActionResult ImportTableSave([FromBody] GenImportTableDto dto)
        {
            if (string.IsNullOrEmpty(dto.DbName) || dto.Tables == null)
            {
                throw new CustomException("表或数据库不能为空");
            }

            int result = 0;
            foreach (var table in dto.Tables)
            {
                List<GenOracleSeq> seqs = new();
                GenInitTableDto initTableDto = new()
                {
                    DbName = dto.DbName,
                    UserName = HttpContext.GetName(),
                    TableName = table.Name,
                    Desc = table.Description,
                    CodeGen = _OptionsSetting.CodeGen,
                    FrontTpl = dto.FrontTpl,
                };

                GenTable genTable = GenTool.InitTable(initTableDto);
                genTable.TableId = _GenTableService.ImportGenTable(genTable);
                if (_OptionsSetting.CodeGenDbConfig.DbType == 3)
                {
                    seqs = _GenService.GetAllGenOracleSeqs(table.Name);
                }
                if (genTable.TableId > 0)
                {
                    //保存列信息
                    List<DbColumnInfo> dbColumnInfos = _GenService.GetColumnInfo(dto.DbName, table.Name);
                    List<GenTableColumn> genTableColumns = GenTool.InitGenTableColumn(genTable, dbColumnInfos, seqs, _OptionsSetting.CodeGen);
                    _GenTableColumnService.DeleteGenTableColumnByTableName(table.Name);
                    _GenTableColumnService.InsertGenTableColumn(genTableColumns);
                    genTable.Columns = genTableColumns;
                    result++;
                }
            }

            return ToResponse(result);
        }

        /// <summary>
        /// 修改保存代码生成业务
        /// </summary>
        /// <param name="genTableDto">请求参数实体</param>
        /// <returns></returns>
        [HttpPut]
        [Log(Title = "代码生成", BusinessType = BusinessType.GENCODE, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "tool:gen:update")]
        public IActionResult EditSave([FromBody] GenTableDto genTableDto)
        {
            if (genTableDto == null) throw new CustomException("请求参数错误");
            if (genTableDto.BusinessName.Equals(genTableDto.ModuleName, StringComparison.OrdinalIgnoreCase))
            {
                return ToResponse(ResultCode.CUSTOM_ERROR, "模块名不能和业务名一样");
            }
            var genTable = genTableDto.Adapt<GenTable>().ToUpdate(HttpContext);

            //将前端额外参数转成字符串存入Options中
            genTable.Options = genTableDto.Params.Adapt<CodeOptions>();
            DbResult<bool> result = _GenTableService.UseTran(() =>
            {
                int rows = _GenTableService.UpdateGenTable(genTable);
                if (rows > 0)
                {
                    _GenTableColumnService.UpdateGenTableColumn(genTable.Columns);
                }
            });

            return SUCCESS(result.IsSuccess);
        }

        /// <summary>
        /// 预览代码
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="tableId"></param>
        /// <returns></returns>
        [HttpPost("preview/{tableId}")]
        [ActionPermissionFilter(Permission = "tool:gen:preview")]
        public IActionResult Preview([FromQuery] GenDto dto, [FromRoute] int tableId = 0)
        {
            dto.TableId = tableId;
            if (dto == null || dto.TableId <= 0)
            {
                throw new CustomException(ResultCode.CUSTOM_ERROR, "请求参数为空");
            }
            var genTableInfo = _GenTableService.GetGenTableInfo(dto.TableId);

            dto.DbType = _OptionsSetting.CodeGenDbConfig.DbType;
            dto.GenTable = genTableInfo;
            dto.IsPreview = true;

            GenTool.Generator(dto);

            return SUCCESS(dto.GenCodes);
        }

        /// <summary>
        /// 生成代码（下载方式）
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        /// <returns></returns>
        [HttpPost("genCode")]
        [Log(Title = "代码生成", BusinessType = BusinessType.GENCODE)]
        [ActionPermissionFilter(Permission = "tool:gen:code")]
        public IActionResult Generator([FromBody] GenDto dto)
        {
            if (dto == null || dto.TableId <= 0)
            {
                throw new CustomException(ResultCode.CUSTOM_ERROR, "请求参数为空");
            }

            dto.DbType = _OptionsSetting.CodeGenDbConfig.DbType;
            dto.GenTable = _GenTableService.GetGenTableInfo(dto.TableId);
            //生成压缩包
            string zipReturnFileName = $"Lean365.NET-{dto.GenTable.TableName}-{DateTime.Now:MMddHHmmss}.zip";

            //生成代码到指定文件夹
            GenTool.Generator(dto);
            if (dto.GenTable.Options.GeneratorMenu)
            {
                _SysMenuService.AddSysMenu(dto.GenTable, dto.ReplaceDto.PermissionPrefix, dto.ReplaceDto.ShowBtnEdit, dto.ReplaceDto.ShowBtnExport, dto.ReplaceDto.ShowBtnImport);
            }
            if (dto.GenTable.GenType == "1")//自定义路径
            {
                var genPath = dto.GenTable.GenPath;
                string parentPath;
                string tempPath = _WebHostEnvironment.ContentRootPath;

                if (ComputerHelper.IsUnix())
                {
                    parentPath = Path.Combine(_WebHostEnvironment.WebRootPath, "Generatorcode");
                }
                else
                {
                    parentPath = tempPath[..tempPath.LastIndexOf(@"\")];
                }
                Console.WriteLine("代码生成路径" + parentPath);
                //代码生成文件夹路径
                dto.GenCodePath = genPath.IsEmpty() || genPath.Equals("/") ? parentPath : genPath;
            }
            else
            {
                dto.ZipPath = Path.Combine(_WebHostEnvironment.WebRootPath, "Generatorcode");
                dto.GenCodePath = Path.Combine(dto.ZipPath, DateTime.Now.ToString("yyyyMMdd"));
            }

            //写入文件
            foreach (var item in dto.GenCodes)
            {
                item.Path = Path.Combine(dto.GenCodePath, item.Path);
                FileUtil.WriteAndSave(item.Path, item.Content);
            }
            if (dto.GenTable.GenType != "1")
            {
                //压缩文件
                FileUtil.ZipGenCode(dto.ZipPath, dto.GenCodePath, zipReturnFileName);
            }
            return SUCCESS(new { path = "/Generatorcode/" + zipReturnFileName, fileName = dto.ZipFileName });
        }

        /// <summary>
        /// 同步数据库
        /// </summary>
        /// <param name="tableId"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "tool:gen:update")]
        [Log(Title = "代码生成", BusinessType = BusinessType.UPDATE)]
        [HttpGet("synchDb/{tableId}")]
        public IActionResult SynchDb(string tableName, long tableId = 0)
        {
            if (string.IsNullOrEmpty(tableName) || tableId <= 0) throw new CustomException("参数错误");
            GenTable table = _GenTableService.GetGenTableInfo(tableId);
            if (table == null) { throw new CustomException("同步数据失败，原表结构不存在"); }
            table.Update_by = HttpContext.GetName();

            var codeGen = AppSettings.Get<CodeGen>("codeGen");
            List<DbColumnInfo> dbColumnInfos = _GenService.GetColumnInfo(table.DbName, tableName);
            List<GenTableColumn> dbTableColumns = GenTool.InitGenTableColumn(table, dbColumnInfos, codeGen: codeGen);

            bool result = _GenTableService.SynchDb(tableId, table, dbTableColumns);
            return SUCCESS(result);
        }
    }
}