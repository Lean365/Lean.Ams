using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace Ams.Infrastructure.Helper
{
    /// <summary>
    /// AssemblyUtils
    /// @author Lean365(Davis Ching)
    /// @date 2024-02-01
    /// </summary>
    public static class AssemblyUtils
    {
        /// <summary>
        /// 获取应用中的所有程序集
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Assembly> GetAssemblies()
        {
            var compilationLibrary = DependencyContext.Default
              .CompileLibraries
              .Where(x => !x.Serviceable && x.Type == "project")
              .ToList();
            return compilationLibrary.Select(p => Assembly.Load(new AssemblyName(p.Name)));
        }

        /// <summary>
        /// 获取应用中的所有Type
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> GetAllTypes()
        {
            var assemblies = GetAssemblies();
            return assemblies.SelectMany(p => p.GetTypes());
        }
    }
}