using System.Reflection;
using System.Runtime.Loader;

namespace HeroBot.Common.ExtendedModules
{
    public sealed class ModuleLoadContext : AssemblyLoadContext
    {
        public ModuleLoadContext() : base(true)
        {
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return base.Load(assemblyName);
        }
    }
}
