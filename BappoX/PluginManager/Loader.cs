using Interface.Interfaces;
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
            StaticVars.MenuContainer = GetAssembly<IMenuContainer>(settings["MenuContainer"]);
            StaticVars.Engine = GetAssembly<IEngine>(settings["Engine"]);
            StaticVars.DataManager = GetAssembly<IDataManager>(settings["DataManager"]);
            StaticVars.Engine.DataManager = StaticVars.DataManager;
            StaticVars.Plugins = GetAssembly<IPluginLoader>(settings["PluginLoader"]);
            StaticVars.Plugins.Initialize(settings["Plugins"]);
            StaticVars.Engine.Plugins = StaticVars.Plugins.Plugins;
            StaticVars.Engine.Initialize();
            StaticVars.MenuContainer.Selector = GetAssembly<ISelector>(settings["Selector"]);
            StaticVars.MenuContainer.Lists = GetAssembly<IListManager>(settings["ListManager"]);
            StaticVars.MenuContainer.Lists.Engine = StaticVars.Engine;
            StaticVars.MainForm.Controls.Add(StaticVars.MenuContainer.Initialize());
            StaticVars.MenuContainer.Selector.Plugin = StaticVars.Plugins.Plugins;
            StaticVars.MenuContainer.Selector.Populate();
            return StaticVars.MainForm;
        }

        /// <summary>
        /// Loads an assembly
        /// </summary>
        /// <param name="path">Path to Assembly</param>
        /// <returns>The Assembly</returns>
        private T GetAssembly<T>(string path)
        {
            return Assembly
                .Load(AssemblyName.GetAssemblyName(path))
                .GetTypes()
                .Where(x => typeof(T).IsAssignableFrom(x))
                .Select(x => (T)Activator.CreateInstance(x))
                .FirstOrDefault();
        }
    }
}