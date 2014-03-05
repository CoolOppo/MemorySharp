﻿using System;
using Binarysharp.MemoryManagement.Helpers;

namespace Binarysharp.MemoryManagement.Assembly.CallingConvention
{
    /// <summary>
    ///     Static class providing calling convention instances.
    /// </summary>
    public static class CallingConventionSelector
    {
        /// <summary>
        ///     Gets a calling convention object according the given type.
        /// </summary>
        /// <param name="callingConvention">The type of calling convention to get.</param>
        /// <returns>The return value is a singleton of a <see cref="ICallingConvention" /> child.</returns>
        public static ICallingConvention Get(CallingConventions callingConvention)
        {
            switch (callingConvention)
            {
                case CallingConventions.Cdecl:
                    return Singleton<CdeclCallingConvention>.Instance;
                case CallingConventions.Stdcall:
                    return Singleton<StdcallCallingConvention>.Instance;
                case CallingConventions.Fastcall:
                    return Singleton<FastcallCallingConvention>.Instance;
                case CallingConventions.Thiscall:
                    return Singleton<ThiscallCallingConvention>.Instance;
                default:
                    throw new ApplicationException("Unsupported calling convention.");
            }
        }
    }
}