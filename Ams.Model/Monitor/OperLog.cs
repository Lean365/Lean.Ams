﻿namespace Ams.Model.Monitor
{
    /// <summary>
    /// 操作日志
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("monitor_oper", "操作日志")]
    [Tenant("0")]
    public class OperLog : SysBase
    {
        /// <summary>
        /// 操作id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long OperId { get; set; }

        /// <summary>
        /// 操作模块
        /// </summary>
        [SugarColumn(Length = 80)]
        public string Title { get; set; }

        /// <summary>
        /// 业务类型（0其它 1新增 2修改 3删除 4=授权,5=导出,6=导入,7=强退,8=生成代码,9=清空数据）
        /// </summary>
        [SugarColumn(DefaultValue = "0")]
        public int BusinessType { get; set; }

        /// <summary>
        /// 业务类型数组
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        [ExcelIgnore]
        public int[] BusinessTypes { get; set; }

        /// <summary>
        /// 请求方法
        /// </summary>
        [SugarColumn(Length = 200)]
        public string Method { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        [SugarColumn(Length = 20)]
        public string RequestMethod { get; set; }

        /// <summary>
        /// 操作类别（0其它 1后台用户 2手机端用户）
        /// </summary>
        //@Excel(name = "操作类别", readConverterExp = "0=其它,1=后台用户,2=手机端用户")
        [SugarColumn(DefaultValue = "0")]
        public int OperatorType { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        [SugarColumn(Length = 20)]
        public string OperName { get; set; }

        /// <summary>
        /// 请求url
        /// </summary>
        [SugarColumn(Length = 200)]
        public string OperUrl { get; set; }

        /// <summary>
        /// 操作地址
        /// </summary>
        [SugarColumn(Length = 20)]
        public string OperIp { get; set; }

        /// <summary>
        /// 操作地点
        /// </summary>
        [SugarColumn(Length = 200)]
        public string OperLocation { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        [SugarColumn(Length = 4000)]
        public string OperParam { get; set; }

        /// <summary>
        /// 返回参数
        /// </summary>
        [SugarColumn(ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string JsonResult { get; set; }

        /// <summary>
        /// 操作状态（0正常 1异常）
        /// </summary>
        [SugarColumn(DefaultValue = "0")]
        public int IsStatus { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [SugarColumn(Length = 4000)]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperTime { get; set; }

        /// <summary>
        /// 操作用时
        /// </summary>
        public long Elapsed { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(Length = 200)]
        public string DeptName { get; set; }
    }
}