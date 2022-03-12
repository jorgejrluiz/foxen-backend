using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TCC.Backend.CrossCutting.Assemblies
{
    [ExcludeFromCodeCoverage]
    public class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {            
            return new Assembly[]
            {
                Assembly.Load("TCC.Backend.Api"),
                Assembly.Load("TCC.Backend.Application"),
                Assembly.Load("TCC.Backend.Domain"),
                Assembly.Load("TCC.Backend.Domain.Core"),
                Assembly.Load("TCC.Backend.Infrastructure"),
                Assembly.Load("TCC.Backend.CrossCutting")
            };
        }
    }
}
