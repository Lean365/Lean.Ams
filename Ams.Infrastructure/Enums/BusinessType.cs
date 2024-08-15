namespace Ams.Infrastructure.Enums
{
    /// <summary>
    /// 业务操作类型
    /// 0-访问 1-新增 2-审计 3-修改头像 4-修改 5-生成代码 6-代码编辑 7-代码导入（表结构） 8-复制 9-创建 10-删除
    /// 11-下载 12-删除（表） 13-编辑 14-清空（表） 15-导出 16-强制退出 17-授权 18-导入 19-插入 20-修改
    /// 21-新建 22-其他 23-修改密码 24-预览 25-打印 26-处理 27-发布 28-查询 29-只读 30-接收 31-刷新 32-拒绝 33-重载 34-撤销
    /// 35-角色菜单 36-运行 37-选择 38-发送 39-显示 40-修改排序 41-启动 42-修改状态 43-停止 44-同步 45-截断 46-更新 47-上传 48-查看
    /// 49-写入
    /// </summary>
    public enum BusinessType
    {
        /// <summary>
        /// 访问
        /// </summary>
        ACCESS = 0,

        /// <summary>
        /// 新增
        /// </summary>
        ADD = 1,

        /// <summary>
        /// 审计
        /// </summary>
        AUDIT = 2,

        /// <summary>
        /// 修改头像
        /// </summary>
        AVATAR = 3,

        /// <summary>
        /// 修改
        /// </summary>
        CHANGE = 4,

        /// <summary>
        /// 生成代码
        /// </summary>
        CODE = 5,

        /// <summary>
        /// 代码编辑
        /// </summary>
        CODEEDIT = 6,

        /// <summary>
        /// 代码导入（表结构）
        /// </summary>
        CODEIMPORT = 7,

        /// <summary>
        /// 复制
        /// </summary>
        COPY = 8,

        /// <summary>
        /// 创建
        /// </summary>
        CREATE = 9,

        /// <summary>
        /// 删除
        /// </summary>
        DELETE = 10,

        /// <summary>
        /// 下载
        /// </summary>
        DOWNLOAD = 11,

        /// <summary>
        /// 删除（表）
        /// </summary>
        DROP = 12,

        /// <summary>
        /// 编辑
        /// </summary>
        EDIT = 13,

        /// <summary>
        /// 清空（表）
        /// </summary>
        EMPTY = 14,

        /// <summary>
        /// 导出
        /// </summary>
        EXPORT = 15,

        /// <summary>
        /// 强制退出
        /// </summary>
        FORCED = 16,

        /// <summary>
        /// 授权
        /// </summary>
        GRANT = 17,

        /// <summary>
        /// 导入
        /// </summary>
        IMPORT = 18,

        /// <summary>
        /// 插入
        /// </summary>
        INSERT = 19,

        /// <summary>
        /// 修改
        /// </summary>
        MODIFY = 20,

        /// <summary>
        /// 新建
        /// </summary>
        NEW = 21,

        /// <summary>
        /// 其他
        /// </summary>
        OTHER = 22,

        /// <summary>
        /// 修改密码
        /// </summary>
        PASSWORD = 23,

        /// <summary>
        /// 预览
        /// </summary>
        PREVIEW = 24,

        /// <summary>
        /// 打印
        /// </summary>
        PRINT = 25,

        /// <summary>
        /// 处理
        /// </summary>
        PROCESS = 26,

        /// <summary>
        /// 发布
        /// </summary>
        PUBLISH = 27,

        /// <summary>
        /// 查询
        /// </summary>
        QUERY = 28,

        /// <summary>
        /// 只读
        /// </summary>
        READ = 29,

        /// <summary>
        /// 接收
        /// </summary>
        RECEIVE = 30,

        /// <summary>
        /// 刷新
        /// </summary>
        REFRESH = 31,

        /// <summary>
        /// 拒绝
        /// </summary>
        REJECT = 32,

        /// <summary>
        /// 重载
        /// </summary>
        RELOAD = 33,

        /// <summary>
        /// 撤销
        /// </summary>
        REVOKE = 34,

        /// <summary>
        /// 角色菜单
        /// </summary>
        ROLEMENU = 35,

        /// <summary>
        /// 运行
        /// </summary>
        RUN = 36,

        /// <summary>
        /// 选择
        /// </summary>
        SELECT = 37,

        /// <summary>
        /// 发送
        /// </summary>
        SEND = 38,

        /// <summary>
        /// 显示
        /// </summary>
        SHOW = 39,

        /// <summary>
        /// 修改排序
        /// </summary>
        SORT = 40,

        /// <summary>
        /// 启动
        /// </summary>
        START = 41,

        /// <summary>
        /// 修改状态
        /// </summary>
        STATUS = 42,

        /// <summary>
        /// 停止
        /// </summary>
        STOP = 43,

        /// <summary>
        /// 同步
        /// </summary>
        SYNC = 44,

        /// <summary>
        /// 截断
        /// </summary>
        TRUNCATE = 45,

        /// <summary>
        /// 更新
        /// </summary>
        UPDATE = 46,

        /// <summary>
        /// 上传
        /// </summary>
        UPLOAD = 47,

        /// <summary>
        /// 查看
        /// </summary>
        VIEW = 48,

        /// <summary>
        /// 写入
        /// </summary>
        WRITE = 49,
    }
}