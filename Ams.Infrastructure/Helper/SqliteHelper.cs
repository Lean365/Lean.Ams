using System.Data;
using Microsoft.Data.Sqlite;

namespace Ams.Infrastructure.Helper
{
    public class SqliteHelper
    {
        private readonly string _connectionString;

        /// <summary>
        /// 初始化 SqliteHelper 实例
        /// </summary>
        /// <param name="databasePath">SQLite 数据库文件路径</param>
        public SqliteHelper(string databasePath)
        {
            _connectionString = $"Data Source={databasePath};";
        }

        /// <summary>
        /// 执行非查询 SQL 命令（如 INSERT, UPDATE, DELETE）
        /// </summary>
        /// <param name="commandText">SQL 命令文本</param>
        /// <param name="parameters">SQL 参数</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string commandText, params SqliteParameter[] parameters)
        {
            using var connection = new SqliteConnection(_connectionString);
            using var command = new SqliteCommand(commandText, connection);
            command.Parameters.AddRange(parameters);

            connection.Open();
            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// 执行查询并返回第一行第一列的值
        /// </summary>
        /// <param name="commandText">SQL 查询文本</param>
        /// <param name="parameters">SQL 参数</param>
        /// <returns>查询结果的第一行第一列的值</returns>
        public object ExecuteScalar(string commandText, params SqliteParameter[] parameters)
        {
            using var connection = new SqliteConnection(_connectionString);
            using var command = new SqliteCommand(commandText, connection);
            command.Parameters.AddRange(parameters);

            connection.Open();
            return command.ExecuteScalar();
        }

        /// <summary>
        /// 执行查询并返回 DataTable
        /// </summary>
        /// <param name="commandText">SQL 查询文本</param>
        /// <param name="parameters">SQL 参数</param>
        /// <returns>包含查询结果的 DataTable</returns>
        public DataTable ExecuteDataTable(string commandText, params SqliteParameter[] parameters)
        {
            using var connection = new SqliteConnection(_connectionString);
            using var command = new SqliteCommand(commandText, connection);
            command.Parameters.AddRange(parameters);

            connection.Open();
            using var reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;
        }

        /// <summary>
        /// 执行查询并返回 SqliteDataReader
        /// </summary>
        /// <param name="commandText">SQL 查询文本</param>
        /// <param name="parameters">SQL 参数</param>
        /// <returns>SqliteDataReader 对象</returns>
        public SqliteDataReader ExecuteReader(string commandText, params SqliteParameter[] parameters)
        {
            var connection = new SqliteConnection(_connectionString);
            var command = new SqliteCommand(commandText, connection);
            command.Parameters.AddRange(parameters);

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //    // 初始化 SqliteHelper
        //    var dbPath = "path/to/your/database.db";
        //    var sqliteHelper = new SqliteHelper(dbPath);

        //    // 执行非查询操作
        //    int rowsAffected = sqliteHelper.ExecuteNonQuery(
        //        "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)",
        //        new SqliteParameter("@Name", "John Doe"),
        //        new SqliteParameter("@Email", "john@example.com")
        //    );

        //    // 执行标量查询
        //    object result = sqliteHelper.ExecuteScalar(
        //        "SELECT COUNT(*) FROM Users"
        //    );

        //    // 执行查询并获取 DataTable
        //    DataTable dataTable = sqliteHelper.ExecuteDataTable(
        //        "SELECT * FROM Users WHERE Age > @Age",
        //        new SqliteParameter("@Age", 18)
        //    );

        //// 使用 SqliteDataReader
        //using (var reader = sqliteHelper.ExecuteReader("SELECT * FROM Users"))
        //{
        //    while (reader.Read())
        //    {
        //        string name = reader["Name"].ToString();
        //    string email = reader["Email"].ToString();
        //    // 处理数据...
        //}
        //}
    }
}