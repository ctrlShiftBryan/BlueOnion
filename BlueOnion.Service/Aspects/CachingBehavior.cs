using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;

namespace BlueOnion.Service.Aspects
{
    /// <summary>
    /// A cache behavior that can be used to prevent extraneous repository or service queries 
    /// </summary>
    public class CachingBehavior : IInterceptionBehavior
    {

        public bool Enabled { get; set; }
        private static string CacheKey { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            SetCacheKey(input);

            if (!ShouldWeCacheThisMethod(CacheKey))
                return CallRealMethod(input, getNext);

            if (MemoryCache.Default.Contains(CacheKey))
            {
                Trace.WriteLine("From Cached-" + CacheKey);
                return input.CreateMethodReturn(MemoryCache.Default[CacheKey]);
            }

            var realMethod = CallRealMethod(input, getNext);
            AddDataToCache(CacheKey, realMethod.ReturnValue);
            return realMethod;
        }

        private static void SetCacheKey(IMethodInvocation input)
        {
            if (input.MethodBase.ReflectedType == null) return;

            var parentName = input.MethodBase.ReflectedType.FullName;
            var methodName = input.MethodBase.Name;

            var listOfArguments = (from object x in input.Arguments select x.ToString()).ToList();

            var arguments = String.Join("~", listOfArguments);
            var fullName = String.Format("{0}-{1}-{2}", parentName, methodName, arguments);

            CacheKey = fullName;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return new Type[0];
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private static readonly string[] CachedMethods = { "GetByUsername" };
        public static bool ShouldWeCacheThisMethod(string methodName)
        {
            return CachedMethods.Any(methodName.Contains);
        }

        private static IMethodReturn CallRealMethod(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Trace.WriteLine("Non Cached-" + CacheKey);
            return getNext()(input, getNext);
        }

        private static void AddDataToCache(string key, Object data)
        {
            if (data != null)
                MemoryCache.Default.Add(key, data, new CacheItemPolicy());
        }

    }
}