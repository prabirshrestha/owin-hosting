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

        public static System.IO.Stream GetResponseBody(this Env env)
        {
            return env.GetEnvironmentValue<System.IO.Stream>("owin.ResponseBody");
        }

        public static string[] GetHeaderValues(this Headers headers, string name, string[] defaultValue = null)
        {
            string[] values;
            return headers.TryGetValue(name, out values) ? values : defaultValue;
        }

        public static string GetOwinHeaderValue(this Headers headers, string name)
        {
            var values = headers.GetHeaderValues(name);

            if (values == null)
                return null;

            switch (values.Length)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return values[0];
                default:
                    return string.Join(",", values);
            }
        }

        public static Env SetRequestMethod(this Env env, string method)
        {
            return env.SetEnvironmentValue("owin.RequestMethod", method);
        }

        public static Env SetRequestScheme(this Env env, string scheme)
        {
            return env.SetEnvironmentValue("owin.RequestScheme", scheme);
        }

        public static Env SetRequestPathBase(this Env env, string pathBase)
        {
            return env.SetEnvironmentValue("owin.RequestPathBase", pathBase);
        }
    }
}