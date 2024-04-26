using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Ams.Generator.Model;
using Ams.Infrastructure;
using Ams.Infrastructure.CustomExceptions;
using Ams.Infrastructure.Extensions;
using Ams.Infrastructure.Helper;
using Ams.Infrastructure.Model;
using Ams.Kernel.Model.Generator;
using JinianNet.JNTemplate;
using SqlSugar;

namespace Ams.Generator
{
    /// <summary>
    /// 代码生成器
    /// </remarks>
    /// </summary>
    public class GeneratorTool
    {
        private static readonly string CodeTemplateDir = "CodeGenTemplate";

        /// <summary>
        /// 代码生成器入口方法
        /// </summary>
        /// <param name="dto"></param>
        public static void Generate(GeneratorDto dto)
        {
            var genOptions = AppSettings.Get<CodeGen>("codeGen");
            dto.VueParentPath = "Ams.Vue3";
            if (!genOptions.VuePath.IsEmpty())
            {
                dto.VueParentPath = genOptions.VuePath;
            }
            dto.GenOptions = GenerateOption(dto.GenTable);
            if (dto.GenTable.SubTable != null)
            {
                dto.SubTableOptions = GenerateOption(dto.GenTable.SubTable);
            }
            if (dto.GenTable.SubTableName.IsNotEmpty() && dto.GenTable.SubTable == null)
            {
                throw new CustomException($"{dto.GenTable.SubTableName}子表不存在");
            }

            GeneratorReplaceDto GeneratorReplaceDto = new()
            {
                //程序版本
                EndVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                //表名对应C# 实体类名
                ModelTypeName = dto.GenTable.ClassName,
                //权限前缀
                PermissionPrefix = dto.GenTable?.Options?.PermissionPrefix,
                //语言前缀
                LocalePrefix = dto.GenTable?.Options?.PermissionPrefix.Replace(":", "."),
                //作者
                Author = dto.GenTable.FunctionAuthor,
                //创建时间
                CreateTime = DateTime.Now,
                ShowBtnAdd = dto.GenTable.Options.CheckedBtn.Any(f => f == 1),
                ShowBtnEdit = dto.GenTable.Options.CheckedBtn.Any(f => f == 2),
                ShowBtnDelete = dto.GenTable.Options.CheckedBtn.Any(f => f == 3),
                ShowBtnMultiDel = dto.GenTable.Options.CheckedBtn.Any(f => f == 4),
                ShowBtnImport = dto.GenTable.Options.CheckedBtn.Any(f => f == 5),
                ShowBtnExport = dto.GenTable.Options.CheckedBtn.Any(f => f == 6),
                ShowBtnView = dto.GenTable.Options.CheckedBtn.Any(f => f == 7),
                ShowBtnTruncate = dto.GenTable.Options.CheckedBtn.Any(f => f == 8),
                ShowBtnPreview = dto.GenTable.Options.CheckedBtn.Any(f => f == 9),
                ShowBtnPrint = dto.GenTable.Options.CheckedBtn.Any(f => f == 10),
                ShowBtnAudit = dto.GenTable.Options.CheckedBtn.Any(f => f == 11),
                ShowBtnRevoke = dto.GenTable.Options.CheckedBtn.Any(f => f == 12),
                ShowBtnNew = dto.GenTable.Options.CheckedBtn.Any(f => f == 13),
                ShowBtnInsert = dto.GenTable.Options.CheckedBtn.Any(f => f == 14),
                ShowBtnUpdate = dto.GenTable.Options.CheckedBtn.Any(f => f == 15),
                ShowBtnModify = dto.GenTable.Options.CheckedBtn.Any(f => f == 16),
                ViewFileName = dto.GenTable.BusinessName.FirstUpperCase(),
                OperBtnStyle = dto.GenTable.Options.OperBtnStyle,
                UseSnowflakeId = dto.GenTable.Options.UseSnowflakeId,
                EnableLog = dto.GenTable.Options.EnableLog
            };
            var columns = dto.GenTable.Columns;

            GeneratorReplaceDto.PKName = columns.Find(f => f.IsPk || f.IsIncrement)?.CsharpField ?? "Id";
            GeneratorReplaceDto.PKType = columns.Find(f => f.IsPk || f.IsIncrement)?.CsharpType ?? "int";

            GeneratorReplaceDto.UploadFile = columns.Any(f => f.HtmlType.Equals(GeneratorConstants.HTML_IMAGE_UPLOAD) || f.HtmlType.Equals(GeneratorConstants.HTML_FILE_UPLOAD)) ? 1 : 0;
            GeneratorReplaceDto.SelectMulti = columns.Any(f => f.HtmlType.Equals(GeneratorConstants.HTML_SELECT_MULTI)) ? 1 : 0;
            GeneratorReplaceDto.ShowEditor = columns.Any(f => f.HtmlType.Equals(GeneratorConstants.HTML_EDITOR)) ? 1 : 0;
            GeneratorReplaceDto.FistLowerPk = GeneratorReplaceDto.PKName.FirstLowerCase();
            InitJntTemplate(dto, GeneratorReplaceDto);

            GenerateModels(GeneratorReplaceDto, dto);
            GenerateService(GeneratorReplaceDto, dto);
            GenerateControllers(GeneratorReplaceDto, dto);
            if (dto.GenTable.Options.FrontTpl == 2)
            {
                GenerateVue3Views(GeneratorReplaceDto, dto);
            }
            else if (dto.GenTable.Options.FrontTpl == 1)
            {
                GenerateVueViews(GeneratorReplaceDto, dto);
            }
            else
            {
                GenerateAntDesignViews(GeneratorReplaceDto, dto);
            }
            if (dto.GenTable.Options.GenerateRepo == 1)
            {
                GenerateRepository(GeneratorReplaceDto, dto);
            }
            GenerateVueJs(dto);
            GenerateSql(dto);
            if (genOptions.ShowApp)
            {
                GenerateAppVueViews(GeneratorReplaceDto, dto);
                GenerateAppVueFormViews(GeneratorReplaceDto, dto);
                GenerateAppJs(dto);
            }
            dto.GeneratorReplaceDto = GeneratorReplaceDto;
        }

        private static GeneratorOption GenerateOption(GenTable genTable)
        {
            GeneratorOption _option = new()
            {
                BaseNamespace = genTable.BaseNameSpace,
                SubNamespace = genTable.ModuleName.FirstUpperCase()
            };
            _option.DtosNamespace = _option.BaseNamespace + "Model.Dto";
            _option.ModelsNamespace = _option.BaseNamespace + "Model";
            _option.RepositoriesNamespace = _option.BaseNamespace + "Repository";
            //_option.IRepositoriesNamespace = _option.BaseNamespace + "Repository";
            _option.IServicsNamespace = _option.BaseNamespace + "Service";
            _option.ServicesNamespace = _option.BaseNamespace + "Service";
            _option.ApiControllerNamespace = _option.BaseNamespace + "WebApi";
            return _option;
        }

        #region 读取模板

        /// <summary>
        /// 生成实体类Model
        /// </summary>
        /// <param name="GeneratorDto"></param>
        /// <param name="GeneratorReplaceDto">替换实体</param>
        private static void GenerateModels(GeneratorReplaceDto GeneratorReplaceDto, GeneratorDto GeneratorDto)
        {
            var path = Path.Combine(CodeTemplateDir, "csharp");
            var tpl = JnHelper.ReadTemplate(path, "TplModel.txt");
            var tplDto = JnHelper.ReadTemplate(path, "TplDto.txt");

            string fullPath = Path.Combine(GeneratorDto.GenOptions.ModelsNamespace, "Models", GeneratorDto.GenOptions.SubNamespace, GeneratorReplaceDto.ModelTypeName + ".cs");
            string fullPathDto = Path.Combine(GeneratorDto.GenOptions.ModelsNamespace, "Dto", GeneratorDto.GenOptions.SubNamespace, GeneratorReplaceDto.ModelTypeName + "Dto.cs");

            GeneratorDto.GenCodes.Add(new GenCode(1, "Model.cs", fullPath, tpl.Render()));
            GeneratorDto.GenCodes.Add(new GenCode(2, "Dto.cs", fullPathDto, tplDto.Render()));
        }

        /// <summary>
        /// 生成Repository层代码文件
        /// </summary>
        /// <param name="GeneratorDto"></param>
        /// <param name="GeneratorReplaceDto">替换实体</param>
        private static void GenerateRepository(GeneratorReplaceDto GeneratorReplaceDto, GeneratorDto GeneratorDto)
        {
            var tpl = JnHelper.ReadTemplate(Path.Combine(CodeTemplateDir, "csharp"), "TplRepository.txt");
            var result = tpl.Render();
            var fullPath = Path.Combine(GeneratorDto.GenOptions.RepositoriesNamespace, GeneratorDto.GenOptions.SubNamespace, $"{GeneratorReplaceDto.ModelTypeName}Repository.cs");

            GeneratorDto.GenCodes.Add(new GenCode(3, "Repository.cs", fullPath, result));
        }

        /// <summary>
        /// 生成Service文件
        /// </summary>
        private static void GenerateService(GeneratorReplaceDto GeneratorReplaceDto, GeneratorDto GeneratorDto)
        {
            var path = Path.Combine(CodeTemplateDir, "csharp");
            var tpl = JnHelper.ReadTemplate(path, "TplService.txt");
            var tpl2 = JnHelper.ReadTemplate(path, "TplIService.txt");

            var fullPath = Path.Combine(GeneratorDto.GenOptions.ServicesNamespace, GeneratorDto.GenOptions.SubNamespace, $"{GeneratorReplaceDto.ModelTypeName}Service.cs");
            var fullPath2 = Path.Combine(GeneratorDto.GenOptions.IServicsNamespace, GeneratorDto.GenOptions.SubNamespace, $"I{GeneratorDto.GenOptions.SubNamespace}Service", $"I{GeneratorReplaceDto.ModelTypeName}Service.cs");

            GeneratorDto.GenCodes.Add(new GenCode(4, "Service.cs", fullPath, tpl.Render()));
            GeneratorDto.GenCodes.Add(new GenCode(4, "IService.cs", fullPath2, tpl2.Render()));
        }

        /// <summary>
        /// 生成控制器ApiControllers文件
        /// </summary>
        private static void GenerateControllers(GeneratorReplaceDto GeneratorReplaceDto, GeneratorDto GeneratorDto)
        {
            var tpl = JnHelper.ReadTemplate(Path.Combine(CodeTemplateDir, "csharp"), "TplControllers.txt");
            tpl.Set("QueryCondition", GeneratorReplaceDto.QueryCondition);
            var result = tpl.Render();

            var fullPath = Path.Combine(GeneratorDto.GenOptions.ApiControllerNamespace, "Controllers", GeneratorDto.GenOptions.SubNamespace, $"{GeneratorReplaceDto.ModelTypeName}Controller.cs");
            GeneratorDto.GenCodes.Add(new GenCode(5, "Controller.cs", fullPath, result));
        }

        /// <summary>
        /// 生成Vue页面
        private static void GenerateVueViews(GeneratorReplaceDto GeneratorReplaceDto, GeneratorDto GeneratorDto)
        {
            string fileName = GeneratorDto.GenTable.TplCategory switch
            {
                "tree" => "TplTreeVue.txt",
                "select" => "TplVueSelect.txt",
                _ => "TplVue.txt",
            };
            var path = Path.Combine(CodeTemplateDir, "vue2");
            fileName = Path.Combine("vue2", fileName);
            GeneratorReplaceDto.VueViewListHtml = JnHelper.ReadTemplate(path, "TableList.txt").Render();
            GeneratorReplaceDto.VueQueryFormHtml = JnHelper.ReadTemplate(path, "QueryForm.txt").Render();
            GeneratorReplaceDto.VueViewFormHtml = JnHelper.ReadTemplate(path, "CurdForm.txt").Render();

            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, fileName);
            var fullPath = Path.Combine(GeneratorDto.VueParentPath, "src", "views", GeneratorDto.GenTable.ModuleName.FirstLowerCase(), $"{GeneratorReplaceDto.ViewFileName}.vue");

            GeneratorDto.GenCodes.Add(new GenCode(6, "index.vue", fullPath, tpl.Render()));
        }

        /// <summary>
        /// vue3
        /// </summary>
        /// <param name="GeneratorDto"></param>
        private static void GenerateVue3Views(GeneratorReplaceDto GeneratorReplaceDto, GeneratorDto GeneratorDto)
        {
            string fileName = GeneratorDto.GenTable.TplCategory switch
            {
                "tree" => "TreeVue.txt",
                _ => "Vue.txt",
            };
            fileName = Path.Combine("v3", fileName);
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, fileName);
            tpl.Set("treeCode", GeneratorDto.GenTable?.Options?.TreeCode?.FirstLowerCase());
            tpl.Set("treeName", GeneratorDto.GenTable?.Options?.TreeName?.FirstLowerCase());
            tpl.Set("treeParentCode", GeneratorDto.GenTable?.Options?.TreeParentCode?.FirstLowerCase());
            tpl.Set("options", GeneratorDto.GenTable?.Options);

            var result = tpl.Render();
            var fullPath = Path.Combine(GeneratorDto.VueParentPath, "src", "views", GeneratorDto.GenTable.ModuleName.FirstLowerCase(), $"{GeneratorReplaceDto.ViewFileName}.vue");
            GeneratorDto.GenCodes.Add(new GenCode(16, "index.vue", fullPath, result));
        }

        /// <summary>
        /// AntDesign
        /// </summary>
        /// <param name="GeneratorDto"></param>
        private static void GenerateAntDesignViews(GeneratorReplaceDto GeneratorReplaceDto, GeneratorDto GeneratorDto)
        {
            string fileName = GeneratorDto.GenTable.TplCategory switch
            {
                "tree" => "TreeVue.txt",
                _ => "Vue2.txt",
            };
            fileName = Path.Combine("antDesign", fileName);
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, fileName);
            tpl.Set("treeCode", GeneratorDto.GenTable?.Options?.TreeCode?.FirstLowerCase());
            tpl.Set("treeName", GeneratorDto.GenTable?.Options?.TreeName?.FirstLowerCase());
            tpl.Set("treeParentCode", GeneratorDto.GenTable?.Options?.TreeParentCode?.FirstLowerCase());
            tpl.Set("options", GeneratorDto.GenTable?.Options);

            var result = tpl.Render();
            var fullPath = Path.Combine(GeneratorDto.VueParentPath, "src", "views", GeneratorDto.GenTable.ModuleName.FirstLowerCase(), $"{GeneratorReplaceDto.ViewFileName}.vue");
            GeneratorDto.GenCodes.Add(new GenCode(16, "index.vue", fullPath, result));
        }

        /// <summary>
        /// 生成vue页面api
        /// </summary>
        /// <param name="GeneratorDto"></param>
        /// <returns></returns>
        public static void GenerateVueJs(GeneratorDto GeneratorDto)
        {
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, "TplVueApi.txt");
            var result = tpl.Render();

            string fileName;
            if (GeneratorDto.VueVersion == 3)
            {
                fileName = GeneratorDto.GenTable.BusinessName.ToLower() + ".js";//vue3 api引用目前只能小写
            }
            else
            {
                fileName = GeneratorDto.GenTable.BusinessName.FirstLowerCase() + ".js";
            }
            string fullPath = Path.Combine(GeneratorDto.VueParentPath, "src", "api", GeneratorDto.GenTable.ModuleName.FirstLowerCase(), fileName);

            GeneratorDto.GenCodes.Add(new GenCode(7, "api.js", fullPath, result));
        }

        /// <summary>
        /// 生成SQL
        /// </summary>
        /// <param name="GeneratorDto"></param>
        public static void GenerateSql(GeneratorDto GeneratorDto)
        {
            string tempName = GeneratorDto.DbType switch
            {
                0 => "MySqlTemplate",
                1 => "SqlTemplate",
                4 => "PgSql",
                _ => "Other",
            };
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, Path.Combine("sql", $"{tempName}.txt"));
            tpl.Set("parentId", GeneratorDto.GenTable?.Options?.ParentMenuId ?? 0);
            var result = tpl.Render();
            string fullPath = Path.Combine(GeneratorDto.GenCodePath, "sql", GeneratorDto.GenTable.BusinessName + ".sql");

            GeneratorDto.GenCodes.Add(new GenCode(8, "sql菜单信息", fullPath, result));
        }

        #endregion 读取模板

        #region app页面

        /// <summary>
        /// 列表页面
        /// </summary>
        /// <param name="GeneratorDto"></param>
        private static void GenerateAppVueViews(GeneratorReplaceDto GeneratorReplaceDto, GeneratorDto GeneratorDto)
        {
            var fileName = Path.Combine("app", "vue2.txt");
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, fileName);

            tpl.Set("options", GeneratorDto.GenTable?.Options);

            var result = tpl.Render();
            var fullPath = Path.Combine(GeneratorDto.AppVuePath, "pages", GeneratorDto.GenTable.ModuleName.FirstLowerCase(), $"{GeneratorReplaceDto.ViewFileName.FirstLowerCase()}", "index.vue");
            GeneratorDto.GenCodes.Add(new GenCode(20, "uniapp页面", fullPath, result));
        }

        private static void GenerateAppVueFormViews(GeneratorReplaceDto GeneratorReplaceDto, GeneratorDto GeneratorDto)
        {
            var fileName = Path.Combine("app", "form.txt");
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, fileName);

            tpl.Set("options", GeneratorDto.GenTable?.Options);

            var result = tpl.Render();
            var fullPath = Path.Combine(GeneratorDto.AppVuePath, "pages", GeneratorDto.GenTable.ModuleName.FirstLowerCase(), $"{GeneratorReplaceDto.ViewFileName.FirstLowerCase()}", "edit.vue");
            GeneratorDto.GenCodes.Add(new GenCode(20, "uniapp表单", fullPath, result));
        }

        /// <summary>
        /// 生成vue页面api
        /// </summary>
        /// <param name="GeneratorDto"></param>
        /// <returns></returns>
        public static void GenerateAppJs(GeneratorDto GeneratorDto)
        {
            var filePath = Path.Combine("app", "api.txt");
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, filePath);
            var result = tpl.Render();

            string fileName = GeneratorDto.GenTable.BusinessName.ToLower() + ".js";
            string fullPath = Path.Combine(GeneratorDto.AppVuePath, "api", GeneratorDto.GenTable.ModuleName.FirstLowerCase(), fileName);

            GeneratorDto.GenCodes.Add(new GenCode(21, "uniapp Api", fullPath, result));
        }

        #endregion app页面

        #region 帮助方法

        /// <summary>
        /// 如果有前缀替换将前缀替换成空，替换下划线"_"为空再将首字母大写
        /// 表名转换成C#类名
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string GetClassName(string tableName, bool autoRemovePre, string tablePrefix)
        {
            if (!string.IsNullOrEmpty(tablePrefix) && autoRemovePre)
            {
                string[] prefixList = tablePrefix.Split(",", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < prefixList.Length; i++)
                {
                    if (!string.IsNullOrEmpty(prefixList[i].ToString()))
                    {
                        tableName = tableName.Replace(prefixList[i], "", StringComparison.OrdinalIgnoreCase);
                    }
                }
            }
            //return tableName.UnderScoreToCamelCase();
            return tableName.ConvertToPascal("_");
        }

        /// <summary>
        /// 首字母转小写,模板使用(勿删)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstLowerCase(string str)
        {
            try
            {
                return string.IsNullOrEmpty(str) ? str : str[..1].ToLower() + str[1..];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return str;
            }
        }

        /// <summary>
        /// 获取C# 类型
        /// </summary>
        /// <param name="sDatatype"></param>
        /// <param name="csharpType"></param>
        /// <returns></returns>
        public static CSharpDataType GetCSharpDatatype(string sDatatype, CsharpTypeArr csharpType)
        {
            //定义GUID类型
            string GuidStr;
            if (sDatatype.ToLower().Contains("uniqueidentifier"))
            {
                GuidStr = "00000000-0000-0000-0000-000000000000";
                if (csharpType.uniqueidentifier.CompareTo(Guid.Parse(GuidStr)) == 0)
                {
                    return CSharpDataType.Guid;
                }
            }
            sDatatype = sDatatype.ToLower();
            if (csharpType.Int.Contains(sDatatype))
            {
                return CSharpDataType.@int;
            }
            else if (csharpType.Long.Contains(sDatatype))
            {
                return CSharpDataType.@long;
            }
            else if (csharpType.Float.Contains(sDatatype))
            {
                return CSharpDataType.@float;
            }
            else if (csharpType.Decimal.Contains(sDatatype))
            {
                return CSharpDataType.@decimal;
            }
            else if (csharpType.DateTime.Contains(sDatatype))
            {
                return CSharpDataType.DateTime;
            }
            else if (csharpType.Bool.Contains(sDatatype))
            {
                return CSharpDataType.@bool;
            }
            return CSharpDataType.@string;
        }

        #endregion 帮助方法

        #region 初始化信息

        /// <summary>
        /// 初始化表信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static GenTable InitTable(GeneratorInitTableDto dto)
        {
            //应用程序启动目录
            string StartupPathStr = Directory.GetCurrentDirectory();
            //返回上一层目录
            string PreviousDirStr = StartupPathStr.Substring(0, StartupPathStr.LastIndexOf("\\")); // 第一个\是转义符，所以要写两个
            var className = GetClassName(dto.TableName, dto.CodeGen.AutoPre, dto.CodeGen.TablePrefix);

            GenTable genTable = new()
            {
                //数据库名称
                DbName = dto.DbName,
                //导入默认命名空间前缀
                BaseNameSpace = "Ams.",//导入默认命名空间前缀
                //导入默认模块名
                ModuleName = dto.CodeGen.ModuleName,//导入默认模块名
                //生成实体类名，首字大写
                ClassName = className,
                //生成业务名，首字大写
                BusinessName = className,
                //程序员
                FunctionAuthor = dto.CodeGen.Author,
                //表名
                TableName = dto.TableName,
                //表描述
                TableComment = dto.Desc,
                //生成功能名
                FunctionName = dto.Desc,
                //创建者
                Create_by = dto.UserName,
                //基本信息备注
                Remark = dto.Desc + "(" + dto.TableName + ")",
                //自定义路径
                GenPath = PreviousDirStr,
                //生成代码方式：1为自定义路径，0为zip打包下载
                GenType = "1",
                Options = new CodeOptions()
                {
                    SortType = "asc",
                    CheckedBtn = new int[] { 1, 2, 3, 4, 5, 6 },
                    PermissionPrefix = className.ToLower(),
                    FrontTpl = dto.FrontTpl
                }
            };

            //权限前缀，如表sys_user，前缀为sys:user
            bool isContain = dto.TableName.Contains("_");
            if (isContain)
            {
                //权限前缀，如表sys_user，前缀为sys:user
                genTable.Options.PermissionPrefix = dto.TableName.ToLower().Substring(0, dto.TableName.IndexOf("_")) + ":" + $"{genTable.ClassName.ToLower().Replace(dto.TableName.ToLower().Substring(0, dto.TableName.IndexOf("_")), "")}";//权限
                //genTable.Options.MenuPrefix = tableName.ToLower().Substring(0, tableName.IndexOf("_")) + "." + $"{genTable.ClassName.ToLower().Replace(tableName.ToLower().Substring(0, tableName.IndexOf("_")), "")}";//权限
            }
            else
            {
                //权限前缀，如表sysuser，前缀为la:sysuser
                genTable.Options.PermissionPrefix = $"{genTable.ModuleName.ToLower()}:{genTable.ClassName.ToLower()}";//权限
                //genTable.Options.MenuPrefix = $"{genTable.ModuleName.ToLower()}.{genTable.ClassName.ToLower()}";//权限
            }
            return genTable;
        }

        /// <summary>
        /// 初始化列属性字段数据
        /// </summary>
        /// <param name="genTable"></param>
        /// <param name="dbColumnInfos"></param>
        /// <param name="seqs"></param>
        /// <param name="codeGen"></param>
        public static List<GenTableColumn> InitGenTableColumn(GenTable genTable, List<DbColumnInfo> dbColumnInfos, List<GeneratorOracleSeq> seqs = null, CodeGen codeGen = null)
        {
            OptionsSetting optionsSetting = new();

            var dbConfig = AppSettings.Get<DbConfigs>(nameof(GeneratorConstants.CodeGenDbConfig));

            optionsSetting.CodeGenDbConfig = dbConfig ?? throw new CustomException("代码生成节点数据配置异常"); ;
            optionsSetting.CodeGen = codeGen ?? throw new CustomException("代码生成节点配置异常");

            List<GenTableColumn> genTableColumns = new();
            foreach (var column in dbColumnInfos)
            {
                genTableColumns.Add(InitColumnField(genTable, column, seqs, optionsSetting));
            }
            return genTableColumns;
        }

        /// <summary>
        /// 初始化表字段数据
        /// </summary>
        /// <param name="genTable"></param>
        /// <param name="column"></param>
        /// <param name="optionsSetting"></param>
        /// <param name="seqs">oracle 序列</param>
        /// <returns></returns>
        private static GenTableColumn InitColumnField(GenTable genTable, DbColumnInfo column, List<GeneratorOracleSeq> seqs, OptionsSetting optionsSetting)
        {
            var dataType = column.DataType;
            if (optionsSetting.CodeGenDbConfig.DbType == 3)
            {
                dataType = column.OracleDataType;
                var seqName = $"SEQ_{genTable.TableName}_{column.DbColumnName}";
                var isIdentity = seqs.Any(f => seqName.Equals(f.SEQUENCE_NAME, StringComparison.CurrentCultureIgnoreCase));
                column.IsIdentity = isIdentity;
            }
            GenTableColumn genTableColumn = new()
            {
                ColumnName = column.DbColumnName.FirstLowerCase(),
                ColumnComment = column.ColumnDescription,
                IsPk = column.IsPrimarykey,
                ColumnType = dataType,
                TableId = genTable.TableId,
                TableName = genTable.TableName,
                CsharpType = GetCSharpDatatype(dataType, optionsSetting.CodeGen.CsharpTypeArr).ToString(),
                CsharpField = column.DbColumnName.ConvertToPascal("_"),
                IsRequired = !column.IsNullable,
                IsIncrement = column.IsIdentity,
                Create_by = genTable.Create_by,
                Create_time = DateTime.Now,
                IsInsert = !column.IsIdentity || GeneratorConstants.inputDtoNoField.Any(f => f.Contains(column.DbColumnName, StringComparison.OrdinalIgnoreCase)),//非自增字段都需要插入
                IsEdit = true,
                IsQuery = false,
                IsExport = true,
                HtmlType = GeneratorConstants.HTML_INPUT,
            };
            ///图片类型初始化上传路径
            if (GeneratorConstants.imageFiled.Any(f => column.DbColumnName.ToLower().Contains(f.ToLower())))
            {
                genTableColumn.HtmlType = GeneratorConstants.HTML_IMAGE_UPLOAD;
            }
            ///时间类型初始化时间范围查询
            else if (GeneratorConstants.COLUMNTYPE_TIME.Any(f => genTableColumn.CsharpType.ToLower().Contains(f.ToLower())))
            {
                genTableColumn.HtmlType = GeneratorConstants.HTML_DATETIME;
            }
            //单选
            else if (GeneratorConstants.radioFiled.Any(f => column.DbColumnName.EndsWith(f, StringComparison.OrdinalIgnoreCase)) ||
                GeneratorConstants.radioFiled.Any(f => column.DbColumnName.StartsWith(f, StringComparison.OrdinalIgnoreCase)))
            {
                genTableColumn.HtmlType = GeneratorConstants.HTML_RADIO;
            }
            //选择项
            else if (GeneratorConstants.selectFiled.Any(f => column.DbColumnName == f) ||
                GeneratorConstants.selectFiled.Any(f => column.DbColumnName.EndsWith(f, StringComparison.OrdinalIgnoreCase)))
            {
                genTableColumn.HtmlType = GeneratorConstants.HTML_SELECT;
            }
            //文本大于500则转换
            else if (column.Length > 500)
            {
                genTableColumn.HtmlType = GeneratorConstants.HTML_TEXTAREA;
            }
            //编辑字段
            if (column.IsIdentity || column.IsPrimarykey || GeneratorConstants.COLUMNNAME_NOT_EDIT.Any(f => column.DbColumnName.Contains(f)))
            {
                genTableColumn.IsEdit = false;
            }
            //列表字段
            if (!GeneratorConstants.COLUMNNAME_NOT_LIST.Any(f => column.DbColumnName.Contains(f) && !column.IsPrimarykey))
            {
                genTableColumn.IsList = true;
            }
            //时间类型初始化between范围查询
            if (genTableColumn.CsharpType == GeneratorConstants.TYPE_DATE)
            {
                genTableColumn.QueryType = "BETWEEN";
            }
            //inputNumber字段
            if (genTableColumn.CsharpType == "long" || genTableColumn.CsharpType == "int" || genTableColumn.CsharpType == "decimal" || genTableColumn.CsharpType == "float" || genTableColumn.CsharpType == "bool")
            {
                genTableColumn.HtmlType = GeneratorConstants.HTML_INPUT_NUMBER;
            }
            //时间类型初始化between范围查询
            if (genTableColumn.CsharpType == "string")
            {
                genTableColumn.QueryType = "LIKE";
            }
            //查询字段
            if (GeneratorConstants.COLUMNNAME_NOT_QUERY.Any(f => column.DbColumnName.ToLower().Contains(f.ToLower())))
            {
                genTableColumn.IsQuery = false;
            }
            //填写字段
            if (GeneratorConstants.COLUMNNAME_NOT_REQUIRED.Any(f => column.DbColumnName.ToLower().Contains(f.ToLower())))
            {
                genTableColumn.IsRequired = false;
            }
            //导出字段
            if (GeneratorConstants.COLUMNNAME_NOT_EXPORT.Any(f => column.DbColumnName.ToLower().Contains(f.ToLower())))
            {
                genTableColumn.IsExport = false;
            }

            return genTableColumn;
        }

        #endregion 初始化信息

        /// <summary>
        /// 初始化Jnt模板
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="GeneratorReplaceDto"></param>
        private static void InitJntTemplate(GeneratorDto dto, GeneratorReplaceDto GeneratorReplaceDto)
        {
#if DEBUG
            Engine.Current.Clean();
#endif
            dto.GenTable.Columns = dto.GenTable.Columns.OrderBy(x => x.Sort).ToList();
            bool showCustomInput = dto.GenTable.Columns.Any(f => f.HtmlType.Equals(GeneratorConstants.HTML_CUSTOM_INPUT, StringComparison.OrdinalIgnoreCase));

            #region 查询所有字典

            var dictHtml = new string[] { GeneratorConstants.HTML_CHECKBOX, GeneratorConstants.HTML_RADIO, GeneratorConstants.HTML_SELECT, GeneratorConstants.HTML_SELECT_MULTI };
            var dicts = new List<GenTableColumn>();
            dicts.AddRange(dto.GenTable.Columns.FindAll(f => dictHtml.Contains(f.HtmlType)));
            if (dto.GenTable.SubTable != null && dto.GenTable.SubTableName.IsNotEmpty())
            {
                dicts.AddRange(dto.GenTable?.SubTable?.Columns?.FindAll(f => dictHtml.Contains(f.HtmlType)));
            }

            #endregion 查询所有字典

            //jnt模板引擎全局变量
            Engine.Configure((options) =>
            {
                options.TagPrefix = "${";
                options.TagSuffix = "}";
                options.TagFlag = '$';
                options.OutMode = OutMode.Auto;
                //options.DisableeLogogram = true;//禁用简写
                options.Data.Set("refs", "$");//特殊标签替换
                options.Data.Set("t", "$");//特殊标签替换
                options.Data.Set("modal", "$");//特殊标签替换
                options.Data.Set("alert", "$");//特殊标签替换
                options.Data.Set("index", "$");//特殊标签替换
                options.Data.Set("confirm", "$");//特殊标签替换
                options.Data.Set("nextTick", "$");
                options.Data.Set("tab", "$");
                options.Data.Set("GeneratorReplaceDto", GeneratorReplaceDto);
                options.Data.Set("options", dto.GenOptions);
                options.Data.Set("subTableOptions", dto.SubTableOptions);
                options.Data.Set("genTable", dto.GenTable);
                options.Data.Set("genSubTable", dto.GenTable?.SubTable);
                options.Data.Set("showCustomInput", showCustomInput);
                options.Data.Set("tool", new GeneratorTool());
                options.Data.Set("codeTool", new GeneratorTemplate());
                options.Data.Set("dicts", dicts.DistinctBy(x => x.DictType));
                options.Data.Set("sub", dto.GenTable.SubTable != null && dto.GenTable.SubTableName.IsNotEmpty());
                options.EnableCache = true;
                //...其它数据
            });
        }

        #region 模板用

        /// <summary>
        /// 模板用
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckInputDtoNoField(string str)
        {
            return GeneratorConstants.inputDtoNoField.Any(f => f.Contains(str, StringComparison.OrdinalIgnoreCase));
        }

        public static bool CheckTree(GenTable genTable, string csharpField)
        {
            return (genTable.TplCategory.Equals("tree", StringComparison.OrdinalIgnoreCase) && genTable?.Options?.TreeParentCode != null && csharpField.Equals(genTable?.Options?.TreeParentCode));
        }

        #endregion 模板用
    }
}