using Ams.Model;
using Ams.Kernel.Model.Generator;

namespace Ams.Kernel.Services.IService.Generator
{
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
