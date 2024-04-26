using Ams.Model.System;
using SqlSugar.IOC;

namespace Ams.Kernel.SqlSugar
{
    /// <summary>
    /// 初始化表结构
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class InitTable
    {
        /// <summary>
        /// 创建人员db、表
        /// </summary>
        public static void InitDb(bool init)
        {
            var db = DbScoped.SugarScope;
            //TODO 可在此处单独更新人员某个表的结构
            //例如：db.CodeFirst.InitTables(typeof(SentItems));

            if (!init) return;
            //建库：如果不存在创建人员数据库存在不会重复创建人员
            db.DbMaintenance.CreateDatabase();// 注意 ：Oracle和个别国产库需不支持该方法，需要手动建库

            //27个表,建议先使用下面方法初始化表，方便排查问题
            db.CodeFirst.InitTables(typeof(SysUser));
            db.CodeFirst.InitTables(typeof(SysRole));
            db.CodeFirst.InitTables(typeof(SysDept));
            db.CodeFirst.InitTables(typeof(SysPost));
            db.CodeFirst.InitTables(typeof(FileStorage));
            db.CodeFirst.InitTables(typeof(SysConfig));
            db.CodeFirst.InitTables(typeof(Notice));
            db.CodeFirst.InitTables(typeof(LoginLog));
            db.CodeFirst.InitTables(typeof(OperLog));
            db.CodeFirst.InitTables(typeof(SysMenu));
            db.CodeFirst.InitTables(typeof(SysRoleMenu));
            db.CodeFirst.InitTables(typeof(SysRoleDept));
            db.CodeFirst.InitTables(typeof(SysUserRole));
            db.CodeFirst.InitTables(typeof(SysUserPost));
            db.CodeFirst.InitTables(typeof(TasksQz));
            db.CodeFirst.InitTables(typeof(TasksQzLog));
            db.CodeFirst.InitTables(typeof(SysLocale));
            db.CodeFirst.InitTables(typeof(GenTable));
            db.CodeFirst.InitTables(typeof(GenTableColumn));
            db.CodeFirst.InitTables(typeof(Article));
            db.CodeFirst.InitTables(typeof(ArticleCategory));
            db.CodeFirst.InitTables(typeof(SysDictData));
            db.CodeFirst.InitTables(typeof(SysDictType));
            db.CodeFirst.InitTables(typeof(DiffLog));
            db.CodeFirst.InitTables(typeof(EmailTpl));
            db.CodeFirst.InitTables(typeof(SmsLog));
            db.CodeFirst.InitTables(typeof(SentItems));
            //db.CodeFirst.InitTables(typeof(OnlineLog));
        }

        public static void InitNewTb()
        {
            var db = DbScoped.SugarScope;
            var t1 = db.DbMaintenance.IsAnyTable(typeof(OnlineLog).Name);
            if (!t1)
            {
                db.CodeFirst.InitTables(typeof(OnlineLog));
            }
        }
    }
}