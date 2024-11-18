namespace Ams.Service.SqlSugar
{
    #region 输入参数

    public class CreateEntityInput
    {
        /// <summary>
        ///
        /// </summary>
        /// <example>student</example>
        public string TableName { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <example>Student</example>
        public string EntityName { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <example>AutoIncrementEntity</example>
        public string BaseClassName { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <example>Magic.Application</example>
        public string Position { get; set; }
    }

    public class DbColumnInfoInput
    {
        public string TableName
        {
            get;
            set;
        }

        public string DbColumnName
        {
            get;
            set;
        }

        public string DataType
        {
            get;
            set;
        }

        public int Length
        {
            get;
            set;
        }

        public string ColumnDescription
        {
            get;
            set;
        }

        public int IsNullable
        {
            get;
            set;
        }

        public int IsIdentity
        {
            get;
            set;
        }

        public int IsPrimarykey
        {
            get;
            set;
        }

        public int DecimalDigits
        {
            get;
            set;
        }
    }

    public class DbTableInfoInput
    {
        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public List<DbColumnInfoInput> DbColumnInfoList { get; set; }
    }

    public class EditColumnInput
    {
        public string TableName { get; set; }
        public string OldName { get; set; }
        public string DbColumnName { get; set; }
        public string ColumnDescription { get; set; }
    }

    public class EditTableInput
    {
        public string Name { get; set; }

        public string OldName { get; set; }

        public string Description { get; set; }
    }

    #endregion 输入参数

    #region 输出参数

    public class DbColumnInfoOutput
    {
        public string TableName
        {
            get;
            set;
        }

        public int TableId
        {
            get;
            set;
        }

        public string DbColumnName
        {
            get;
            set;
        }

        public string PropertyName
        {
            get;
            set;
        }

        public string DataType
        {
            get;
            set;
        }

        public int Length
        {
            get;
            set;
        }

        public string ColumnDescription
        {
            get;
            set;
        }

        public string DefaultValue
        {
            get;
            set;
        }

        public bool IsNullable
        {
            get;
            set;
        }

        public bool IsIdentity
        {
            get;
            set;
        }

        public bool IsPrimarykey
        {
            get;
            set;
        }

        public object Value
        {
            get;
            set;
        }

        public int DecimalDigits
        {
            get;
            set;
        }

        public int Scale
        {
            get;
            set;
        }

        public bool IsArray
        {
            get;
            set;
        }

        internal bool IsJson
        {
            get;
            set;
        }
    }

    #endregion 输出参数
}