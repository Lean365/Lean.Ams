using Ams.Kernel.Model.Monitor;
using Ams.Kernel.Model.Routine;
using Ams.Kernel.Model.System;
using Ams.Kernel.Model.System.Generate;
using SqlSugar.IOC;

namespace Ams.Kernel.SqlSugar
{
    /// <summary>
    /// 初始化表
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public class InitTable
    {
        /// <summary>
        /// 创建db、表
        /// </summary>
        public static void InitDb()
        {
            var db = DbScoped.SugarScope;
            //建库：如果不存在创建数据库存在不会重复创建
            db.DbMaintenance.CreateDatabase();// 注意 ：Oracle和个别国产库需不支持该方法，需要手动建库

            //var baseType = typeof(SysBase);
            //var entityes = AssemblyUtils.GetAllTypes().Where(p => !p.IsAbstract && p != baseType && p.GetCustomAttribute<SugarTable>() != null).ToArray();
            //db.CodeFirst.InitTables(entityes);

            //27个表,建议先使用下面方法初始化表，方便排查问题
            db.CodeFirst.InitTables(typeof(SysUser));
            db.CodeFirst.InitTables(typeof(SysRole));
            db.CodeFirst.InitTables(typeof(SysDept));
            db.CodeFirst.InitTables(typeof(SysPost));
            db.CodeFirst.InitTables(typeof(FileStorage));
            db.CodeFirst.InitTables(typeof(SysConfig));
            db.CodeFirst.InitTables(typeof(Notices));
            db.CodeFirst.InitTables(typeof(LogLogin));
            db.CodeFirst.InitTables(typeof(LogOper));
            db.CodeFirst.InitTables(typeof(SysMenu));
            //db.CodeFirst.InitTables(typeof(SysRegion));
            db.CodeFirst.InitTables(typeof(SysRoleMenu));
            db.CodeFirst.InitTables(typeof(SysRoleDept));
            db.CodeFirst.InitTables(typeof(SysUserRole));
            db.CodeFirst.InitTables(typeof(SysUserPost));
            db.CodeFirst.InitTables(typeof(TasksQz));
            db.CodeFirst.InitTables(typeof(LogTasks));
            db.CodeFirst.InitTables(typeof(SysLocaleLang));
            db.CodeFirst.InitTables(typeof(GenTable));
            db.CodeFirst.InitTables(typeof(GenTableColumn));
            db.CodeFirst.InitTables(typeof(Article));
            db.CodeFirst.InitTables(typeof(ArticleCategory));
            db.CodeFirst.InitTables(typeof(SysDictData));
            db.CodeFirst.InitTables(typeof(SysDictType));
            db.CodeFirst.InitTables(typeof(LogDiff));
            db.CodeFirst.InitTables(typeof(EmailTpl));
            db.CodeFirst.InitTables(typeof(LogSms));
            db.CodeFirst.InitTables(typeof(Email));
        }
    }
}