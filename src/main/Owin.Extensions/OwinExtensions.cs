﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Owin.Extensions
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    using StartupEnv = System.Collections.Generic.IDictionary<string, object>;
    using Env = System.Collections.Generic.IDictionary<string, object>;
    using WsEnv = System.Collections.Generic.IDictionary<string, object>;

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
    }
}