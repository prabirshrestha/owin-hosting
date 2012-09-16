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
    }
}