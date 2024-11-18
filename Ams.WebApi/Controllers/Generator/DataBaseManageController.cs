using Ams.Service.DataBase;
using Furion.DynamicApiController;

namespace Ams.WebApi.Controllers.Generator
{
    /// <summary>
    /// 数据表管理
    /// </summary>
    [Verify]
    [Route("tool/db")]
    [ApiExplorerSettings(GroupName = "tool")]
    public class DataBaseManageController : IDynamicApiController
    {
        private readonly IDataBaseManageService _DataBaseManageService;

        public DataBaseManageController(IDataBaseManageService DataBaseManageService)
        {
            _DataBaseManageService = DataBaseManageService;
        }

        /// <summary>
        /// 添加列
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("/column/add")]
        public void ColumnAdd(Ams.Service.DataBase.Dto.DbColumnInfoInput input)
        {
            _DataBaseManageService.ColumnAdd(input);
        }

        /// <summary>
        /// 删除列
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("/column/delete")]
        public void ColumnDelete(Ams.Service.DataBase.Dto.DbColumnInfoOutput input)
        {
            _DataBaseManageService.ColumnDelete(input);
        }

        /// <summary>
        /// 编辑列
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("/column/edit")]
        public void ColumnEdit(Ams.Service.DataBase.Dto.EditColumnInput input)
        {
            _DataBaseManageService.ColumnEdit(input);
        }

        /// <summary>
        /// 获取表字段
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        [HttpGet("/dataBase/columnInfoList")]
        public List<Ams.Service.DataBase.Dto.DbColumnInfoOutput> GetColumnInfosByTableName(string tableName)
        {
            return _DataBaseManageService.GetColumnInfosByTableName(tableName);
        }

        /// <summary>
        /// 获取所有表
        /// </summary>
        /// <returns></returns>
        [HttpGet("/dataBase/tableInfoList")]
        public List<DbTableInfo> GetTableInfoList()
        {
            return _DataBaseManageService.GetTableInfoList();
        }

        /// <summary>
        /// 新增表
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("/table/add")]
        public void TableAdd(Ams.Service.DataBase.Dto.DbTableInfoInput input)
        {
            _DataBaseManageService.TableAdd(input);
        }

        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("/table/delete")]
        public void TableDelete(DbTableInfo input)
        {
            _DataBaseManageService.TableDelete(input);
        }

        /// <summary>
        /// 编辑表
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("/table/edit")]
        public void TableEdit(Ams.Service.DataBase.Dto.EditTableInput input)
        {
            _DataBaseManageService.TableEdit(input);
        }

        /// <summary>
        /// 生成实体
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("/table/createEntity")]
        public void CreateEntity(Ams.Service.DataBase.Dto.CreateEntityInput input)
        {
            _DataBaseManageService.CreateEntity(input);
        }
    }
}