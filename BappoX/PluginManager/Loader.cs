using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginManager
{
    /// <summary>
    /// The default Loader of the program
    /// </summary>
    public class Loader : ILoader
    {
        /// <summary>
        /// The initializer for the launching class
        /// </summary>
        /// <param name="program">The program the Launcher will Initilaize</param>
        public Loader(string program)
        {
            StaticVars.Program = program;
        }

        /// <summary>
        /// Initialize all the variables
        /// </summary>
        /// <returns>Main Form</returns>
        public Form Initialize()
        {
            Dictionary<string, string> settings = System.IO.File.ReadAllLines("settings.ini")
                .Select(x => x.Split(':'))
                .ToDictionary(x => x[0], x => x[1]);
            StaticVars.MainForm = GetAssembly<Form>(settings["Display"]);
            StaticVars.Engine = GetAssembly<IEngine>(settings["Engine"]);
            StaticVars.DataManager = GetAssembly<IDataManager>(settings["DataManager"]);
            StaticVars.Engine.DataManager = StaticVars.DataManager;
            StaticVars.MenuContainer = GetAssembly<IMenuContainer>(settings["MenuContainer"]);
            StaticVars.MenuContainer.Selector = GetAssembly<ISelector>(settings["Selector"]);
            StaticVars.MainForm.Controls.Add(StaticVars.MenuContainer.Initialize());
            StaticVars.Plugins = GetAssembly<IPluginLoader>(settings["PluginLoader"]);
            StaticVars.Plugins.Initialize(settings["Plugins"]);
            StaticVars.MenuContainer.Selector.Plugin = StaticVars.Plugins.Plugins;
            StaticVars.MenuContainer.Selector.Populate();
            StaticVars.Engine.Plugins = StaticVars.Plugins.Plugins;
            StaticVars.Engine.Initialize();
            return StaticVars.MainForm;
        }
        
        /// <summary>
        /// Loads an assembly
        /// </summary>
        /// <param name="path">Path to Assembly</param>
        /// <returns>The Assembly</returns>
        private T GetAssembly<T>(string path)
        {
            AssemblyName an = AssemblyName.GetAssemblyName(path);
            Assembly assm = Assembly.Load(an);
            var v = assm.GetTypes().Where(x => typeof(T).IsAssignableFrom(x));
            if (v.Any()) return (T)Activator.CreateInstance(v.FirstOrDefault());
            else return default(T);
        }
    }
}
