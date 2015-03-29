using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataPlugins
{
    public class Loader : IPluginLoader
    {
        public void Initialize(string folder)
        {
             Plugins = Directory
                .GetFiles(folder)
                .Select<string, AssemblyName>(x => AssemblyName.GetAssemblyName(x))
                .Select<AssemblyName, Assembly>(x => Assembly.Load(x))
                .Select(x => x.GetTypes().ToList())
                .SelectMany(x => x)
                .Where(x => typeof(IPlugin).IsAssignableFrom(x))
                .Select(x => (IPlugin)Activator.CreateInstance(x))
                .ToList();
        }

        public List<IPlugin> Plugins { get; set; }
    }
}
