using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Common.Tools;

namespace DataPlugins
{
    public class Loader : IPluginLoader
    {
        public Loader()
        {
            string folder = Settings("Plugins");
            if (Directory.Exists(folder))
                Plugins = Directory
                   .EnumerateFiles(folder)
                   .Select<string, AssemblyName>(x => AssemblyName.GetAssemblyName(x))
                   .Select<AssemblyName, Assembly>(x => Assembly.Load(x))
                   .Select(x => x.GetTypes().ToList())
                   .SelectMany(x => x)
                   .Where(x => typeof(IPlugin).IsAssignableFrom(x))
                   .Select(x => (IPlugin)Activator.CreateInstance(x))
                   .ToList();
            else
                Directory.CreateDirectory(folder);
        }

        public List<IPlugin> Plugins { get; set; }
    }
}