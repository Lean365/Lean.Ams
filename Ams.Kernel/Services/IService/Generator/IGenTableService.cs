namespace Ams.Kernel.Services.IService.Generator
{
    /// <summary>
    /// 代码生成-生成表信息
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface IGenTableService : IBaseService<GenTable>
    {
        List<GenTable> SelectDbTableListByNamess(string[] tableNames);

        int ImportGenTable(GenTable tables);

        int DeleteGenTableByIds(long[] tableIds);

        int DeleteGenTableByTbName(string tableName);

        PagedInfo<GenTable> GetGenTables(GenTable genTable, PagerInfo pagerInfo);

        GenTable GetGenTableInfo(long tableId);

        bool SynchDb(long tableId, GenTable genTable, List<GenTableColumn> genTableColumns);

        List<GenTable> GetGenTableAll();

        int UpdateGenTable(GenTable genTable);
    }

    /// <summary>
    /// 代码生成-生成列字段
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface IGenTableColumnService : IBaseService<GenTableColumn>
    {
        int InsertGenTableColumn(List<GenTableColumn> tableColumn);

        int DeleteGenTableColumn(long tableId);

        int DeleteGenTableColumn(long[] tableIds);

        int DeleteGenTableColumnByTableName(string tableName);

        List<GenTableColumn> GenTableColumns(long tableId);

        int UpdateGenTableColumn(List<GenTableColumn> tableColumn);
    }
}