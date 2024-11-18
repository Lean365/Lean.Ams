using Ams.Service.DataBase.Dto;

namespace Ams.Service.DataBase
{
    /// <summary>
    /// 依赖空接口（禁止外部继承）
    /// </summary>
    public interface IPrivateDependency
    {
    }

    /// <summary>
    /// 瞬时服务注册依赖
    /// </summary>
    public interface ITransient : IPrivateDependency
    {
    }

    public interface IDataBaseManageService : ITransient
    {
        List<DbTableInfo> GetTableInfoList();

        List<DbColumnInfoOutput> GetColumnInfosByTableName(string tableName);

        void TableAdd(DbTableInfoInput input);

        void TableEdit(EditTableInput input);

        void TableDelete(DbTableInfo input);

        void ColumnAdd(DbColumnInfoInput input);

        void ColumnEdit(EditColumnInput input);

        void ColumnDelete(DbColumnInfoOutput input);

        void CreateEntity(CreateEntityInput input);
    }
}