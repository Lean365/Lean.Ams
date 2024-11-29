using System;
using System.Collections.Generic;
using System.Linq;
using Ams.CodeGenerator.Model;
using Ams.Infrastructure;
using Ams.Infrastructure.Model;
using Ams.Model;
using SqlSugar;

namespace Ams.CodeGenerator.Service
{
    public class CodeGeneratorService : DbProvider
    {
        /// <summary>
        /// 获取所有数据库名
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllDataBases()
        {
            //var db = GetSugarDbContext();
            ////Oracle库特殊处理
            //DbConfigs configs = AppSettings.Get<DbConfigs>(nameof(GlobalConstant.CodeGenDbConfig));
            //if (configs.DbType == 3)
            //{
            //    return new List<string>() { configs?.DbName };
            //}
            //var templist = db.DbMaintenance.GetDataBaseList(db);
            //return templist.FindAll(f => !f.Contains("schema"));

            //读取配置文件中数据库名称(AppSettings.json)
            //string connStr = AppSettings.GetConfig(GenConstants.Gen_conn);
            //string[] AppSettoArrey = connStr.Split(';'); //字符串转数组
            //string AppSetName = AppSettoArrey[4];
            //int sindex = AppSettoArrey[4].IndexOf('=') + 1;
            //int eindex = AppSettoArrey[4].Length - AppSettoArrey[4].IndexOf('=') - 1;
            //var AppSetDataBase = AppSetName.Substring(sindex, eindex);
            //读取配置文件中数据库名称
            string connDbName = AppSettings.GetConfig(GenConstants.Gen_dbname);
            var db = GetSugarDbContext();
            ////Oracle库特殊处理
            //DbConfigs configs = AppSettings.Get<DbConfigs>(nameof(GlobalConstant.CodeGenDbConfig));
            //if (configs.DbType == 3)
            //{
            //    return new List<string>() { configs?.DbName };
            //}
            //var templist = db.DbMaintenance.GetDataBaseList(db);

            //return templist.FindAll(f => !f.Contains("schema"));
            //Oracle库特殊处理
            DbConfigs configs = AppSettings.Get<DbConfigs>(nameof(GenConstants.CodeGenDbConfig));
            if (configs.DbType == 3)
            {
                return new List<string>() { configs?.DbName };
            }
            var templist = db.DbMaintenance.GetDataBaseList(db);

            //return templist.FindAll(f => !f.Contains("schema"));

            //只读取当前数据库
            var Currentdatabase = (from s in templist
                                   where s.Contains(connDbName)
                                   select s).ToList();

            return Currentdatabase;
            //var db = GetSugarDbContext();
            ////Oracle库特殊处理
            //DbConfigs configs = AppSettings.Get<DbConfigs>(nameof(GlobalConstant.CodeGenDbConfig));
            //if (configs.DbType == 3)
            //{
            //    return new List<string>() { configs?.DbName };
            //}
            //var templist = db.DbMaintenance.GetDataBaseList(db);

            //return templist.FindAll(f => !f.Contains("schema"));
        }

        /// <summary>
        /// 获取所有表
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public List<DbTableInfo> GetAllTables(string dbName, string tableName, PagerInfo pager)
        {
            var tableList = GetSugarDbContext(dbName).DbMaintenance.GetTableInfoList(true);
            if (!string.IsNullOrEmpty(tableName))
            {
                tableList = tableList.Where(f => f.Name.ToLower().Contains(tableName.ToLower())).ToList();
            }
            //tableList = tableList.Where(f => !new string[] { "gen", "sys_" }.Contains(f.Name)).ToList();
            //tableList = tableList.Where(f => !f.Name.Contains("sys_")).ToList();
            tableList = tableList.Where(f => !f.Name.Contains("gen_")).ToList();
            pager.TotalNum = tableList.Count;
            return tableList.Skip(pager.PageSize * (pager.PageNum - 1)).Take(pager.PageSize).OrderBy(f => f.Name).ToList();
        }

        /// <summary>
        /// 判断数据表存在否
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int GetTableExists(string tableName)
        {
            int result;
            var db = GetSugarDbContext();
            //var tableList = GetSugarDbContext(dbName).DbMaintenance.GetTableInfoList(true);
            //bool tableExists = tableList.Any(t => t.Name == tableName);

            // 判断表是否存在
            bool tableExists = db.DbMaintenance.IsAnyTable(tableName);

            if (tableExists)
            {
                result = 1;
                ApiResult.Error($"表 {tableName} 存在。");
                Console.WriteLine($"表 {tableName} 存在。");
            }
            else
            {
                result = 0;
                ApiResult.Success($"表 {tableName} 不存在。");
                Console.WriteLine($"可以新建表 {tableName} 。");
            }

            return result;
        }

        /// <summary>
        /// 新建数据表
        /// </summary>
        /// <param name="createTableSql"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int CreateTable(string createTableSql, string tableName)
        {
            var db = GetSugarDbContext();
            int result;
            try
            {
                // 执行创建表的SQL语句
                result = db.Ado.ExecuteCommand(createTableSql);

                // 判断执行状态
                if (result == -1)
                {
                    ApiResult.Error($"SQL语句执行成功，{tableName}表已创建。");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"SQL语句执行成功，{tableName}表已创建。\n{createTableSql}");
                    // 进一步检查表是否真的创建成功
                    //bool tableExists = db.DbMaintenance.IsAnyTable(tableName);
                    //if (tableExists)
                    //{
                    //    //result = -1;
                    //    ApiResult.Error($"SQL语句执行成功，{tableName}表已创建。");
                    //    Console.WriteLine($"SQL语句执行成功，{tableName}表已创建。");
                    //}
                    //else
                    //{
                    //    result = -2;
                    //    ApiResult.Success($"SQL语句执行成功，但{tableName}表未找到，可能存在异常情况。");
                    //    Console.WriteLine($"SQL语句执行成功，但{tableName}表未找到，可能存在异常情况。");
                    //}
                }
                else
                {
                    result = 0;
                    ApiResult.Error($"新建{tableName}表的SQL语句执行失败，执行结果返回值非 -1。");
                    Console.WriteLine($"新建{tableName}表的SQL语句执行失败，执行结果返回值非 -1。");
                }
            }
            catch (Exception ex)
            {
                result = 0;
                ApiResult.Error($"新建{tableName}表的SQL语句执行出错: {ex.Message}");
                Console.WriteLine($"新建{tableName}表的SQL语句执行出错: {ex.Message}");
            }
            //db.Ado.ExecuteCommand(createTableSql);
            //try
            //{
            //    int result = db.Ado.SqlQuery<dynamic>(createTableSql);
            //}
            //catch (ex)
            //{
            //    Console.WriteLine("CREATE TABLE语句执行出错: " + ex.Message);
            //}
            //if (result > 0)
            //{
            //    Console.WriteLine("Update successful, affected rows: " + result);
            //}
            //else
            //{
            //    Console.WriteLine("No rows affected.");
            //}
            //利用CodeFirst初始化表结构
            //db.CodeFirst.InitTables(typeof(YourEntityClass));

            return result;
        }

        /// <summary>
        /// 获取单表数据
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DbTableInfo GetTableInfo(string dbName, string tableName)
        {
            var tableList = GetSugarDbContext(dbName).DbMaintenance.GetTableInfoList(true);
            if (!string.IsNullOrEmpty(tableName))
            {
                return tableList.Where(f => f.Name.Equals(tableName, System.StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }

            return null;
        }

        /// <summary>
        /// 获取列信息
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<DbColumnInfo> GetColumnInfo(string dbName, string tableName)
        {
            return GetSugarDbContext(dbName).DbMaintenance.GetColumnInfosByTableName(tableName, true);
        }

        /// <summary>
        /// 获取Oracle所有序列
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public List<OracleSeq> GetAllOracleSeqs(string dbName)
        {
            string sql = "SELECT * FROM USER_SEQUENCES";
            var seqs = GetSugarDbContext(dbName).Ado.SqlQuery<OracleSeq>(sql);

            return seqs.ToList();
        }
    }
}