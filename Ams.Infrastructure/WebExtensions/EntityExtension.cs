using System;
using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace Ams.Infrastructure.WebExtensions
{
    /// <summary>
    /// 实体扩展类
    /// @Author Lean365(Davis.Ching)
    /// @Date 2004-02-01
    /// </summary>
    public static class EntityExtension
    {
        /// <summary>
        /// 将实体类转化为创建人员实体类
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static TSource ToCreate<TSource>(this TSource source, HttpContext? context = null)
        {
            var types = source?.GetType();
            if (types == null || context == null) return source;
            BindingFlags flag = BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance;

            types.GetProperty("CreateTime", flag)?.SetValue(source, DateTime.Now, null);
            types.GetProperty("CreateBy", flag)?.SetValue(source, context.GetName(), null);
            types.GetProperty("Create_by", flag)?.SetValue(source, context.GetName(), null);
            //types.GetProperty("UserId", flag)?.SetValue(source, context.GetUId(), null);
            types.GetProperty("DeptId", flag)?.SetValue(source, context.GetDeptId(), null);

            return source;
        }

        /// <summary>
        /// 将实体类转化为更新人员实体类
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static TSource ToUpdate<TSource>(this TSource source, HttpContext? context = null)
        {
            var types = source?.GetType();
            if (types == null || context == null) return source;
            BindingFlags flag = BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance;

            types.GetProperty("UpdateTime", flag)?.SetValue(source, DateTime.Now, null);
            types.GetProperty("Update_time", flag)?.SetValue(source, DateTime.Now, null);
            types.GetProperty("UpdateBy", flag)?.SetValue(source, context.GetName(), null);
            types.GetProperty("Update_by", flag)?.SetValue(source, context.GetName(), null);

            return source;
        }
    }
}