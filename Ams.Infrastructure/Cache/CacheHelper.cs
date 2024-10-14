﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Caching.Memory;

namespace Ams.Infrastructure.Cache
{
    public class CacheHelper
    {
        public static MemoryCache Cache { get; set; }

        static CacheHelper()
        {
            Cache = new MemoryCache(new MemoryCacheOptions
            {
                //SizeLimit = 1024
            });
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetCache<T>(string key) where T : class
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            //return Cache.Get(key) as T; //或者
            return Cache.Get<T>(key);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {
            return Cache.Get<object>(CacheKey);
        }

        public static object Get(string CacheKey)
        {
            return Cache.Get(CacheKey);
        }

        /// <summary>
        /// 设置缓存，永久缓存
        /// </summary>
        /// <param name="CacheKey">key</param>
        /// <param name="objObject">值</param>
        public static object SetCache(string CacheKey, object objObject)
        {
            return Cache.Set(CacheKey, objObject);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="CacheKey">key</param>
        /// <param name="objObject">值</param>
        /// <param name="Timeout">过期时间（分钟）</param>
        public static object SetCache(string CacheKey, object objObject, int Timeout)
        {
            return Cache.Set(CacheKey, objObject, DateTime.Now.AddMinutes(Timeout));
        }

        /// <summary>
        /// 设置缓存(秒)
        /// </summary>
        /// <param name="CacheKey">key</param>
        /// <param name="objObject">值</param>
        /// <param name="Timeout">过期时间（秒）</param>
        public static void SetCaches(string CacheKey, object objObject, int Timeout)
        {
            Cache.Set(CacheKey, objObject, DateTime.Now.AddSeconds(Timeout));
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="CacheKey">key</param>
        /// <param name="objObject">值</param>
        /// <param name="absoluteExpiration">过期时间</param>
        /// <param name="slidingExpiration">过期时间间隔</param>
        public static object SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            return Cache.Set(CacheKey, objObject, absoluteExpiration);
        }

        /// <summary>
        /// 设定绝对的过期时间
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        /// <param name="Seconds">超过多少秒后过期</param>
        public static void SetCacheDateTime(string CacheKey, object objObject, long Seconds)
        {
            Cache.Set(CacheKey, objObject, DateTime.Now.AddSeconds(Seconds));
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">key</param>
        public static void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            return Cache.TryGetValue(key, out _);
        }

        /// <summary>
        /// 获取所有缓存键
        /// </summary>
        /// <returns></returns>
        //public static List<string> GetCacheKeys()
        //{
        //    const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        //    //var entries = Cache.GetType().GetField("_entries", flags).GetValue(Cache);

        //    //.net7需要这样写
        //    var coherentState = Cache.GetType().GetField("_coherentState", flags).GetValue(Cache);
        //    var entries = coherentState.GetType().GetField("_entries", flags).GetValue(coherentState);

        //    var keys = new List<string>();
        //    if (entries is not IDictionary cacheItems) return keys;
        //    foreach (DictionaryEntry cacheItem in cacheItems)
        //    {
        //        keys.Add(cacheItem.Key.ToString());
        //        //Console.WriteLine("缓存key=" +cacheItem.Key);
        //    }
        //    return keys;
        //}
        public static List<string> GetCacheKeys()
        {
            var keys = new List<string>();
            // 获取缓存字段
            var cacheField = typeof(MemoryCache).GetProperty("_entries", BindingFlags.NonPublic | BindingFlags.Instance);
            if (cacheField == null)
            {
                return keys;
                //throw new Exception("无法获取 MemoryCache 中的 'EntriesCollection' 属性。");
            }

            // 获取缓存值
            var cacheEntries = cacheField.GetValue(Cache) as dynamic;
            if (cacheEntries == null)
            {
                return keys;
                //throw new Exception("缓存中没有任何条目。");
            }

            var cacheItems = new Dictionary<string, object>();

            foreach (var cacheEntry in cacheEntries)
            {
                object cacheItem = cacheEntry.GetType().GetProperty("Value").GetValue(cacheEntry, null);
                ICacheEntry entry = (ICacheEntry)cacheItem;
                cacheItems.Add(entry.Key.ToString(), entry.Value);
                keys.Add(entry.Key.ToString());
                Console.WriteLine("缓存key=" + entry.Key.ToString());
            }

            return keys;
        }
    }
}