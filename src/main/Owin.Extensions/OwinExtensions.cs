using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Owin.Extensions
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    using StartupEnv = IDictionary<string, object>;
    using Env = IDictionary<string, object>;
    using WsEnv = IDictionary<string, object>;

    using Headers = IDictionary<string, string[]>;

    public static class OwinExtensions
    {
        public static T GetStartupValue<T>(this StartupEnv startup, string name, T defaultValue = default(T))
        {
            object value;
            return startup.TryGetValue(name, out value) && value is T ? (T)value : defaultValue;
        }

        public static StartupEnv SetStartupValue(this StartupEnv startup, string name, object value)
        {
            startup[name] = value;
            return startup;
        }

        public static T GetEnvironmentValue<T>(this Env env, string name, T defaultValue = default(T))
        {
            object value;
            return env.TryGetValue(name, out value) && value is T ? (T)value : defaultValue;
        }

        public static Env SetEnvironmentValue(this Env env, string name, object value)
        {
            env[name] = value;
            return env;
        }

        public static string GetRequestMethod(this Env env)
        {
            return env.GetEnvironmentValue<string>("owin.RequestMethod");
        }

        public static string GetRequestScheme(this Env env)
        {
            return env.GetEnvironmentValue<string>("owin.RequestScheme");
        }

        public static string GetRequestPathBase(this Env env)
        {
            return env.GetEnvironmentValue<string>("owin.RequestPathBase");
        }

        public static string GetRequestPath(this Env env)
        {
            return env.GetEnvironmentValue<string>("owin.RequestPath");
        }

        public static string GetRequestQueryString(this Env env)
        {
            return env.GetEnvironmentValue<string>("owin.RequestQueryString");
        }

        public static System.IO.Stream GetRequestBody(this Env env)
        {
            return env.GetEnvironmentValue<System.IO.Stream>("owin.RequestBody");
        }

        public static string GetCallCancelled(this Env env)
        {
            return env.GetEnvironmentValue<string>("owin.CallCancelled");
        }

        public static Headers GetRequestHeaders(this Env env)
        {
            return env.GetEnvironmentValue<Headers>("owin.RequestHeaders");
        }

        public static Headers GetResponseHeaders(this Env env)
        {
            return env.GetEnvironmentValue<Headers>("owin.ResponseHeaders");
        }
    }
}