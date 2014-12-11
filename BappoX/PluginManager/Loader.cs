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
            Dictionary<string, string> dllMapping = new Dictionary<string, string>();
            Array.ForEach(System.IO.File.ReadAllLines("settings.ini"), (s) => { string[] split = s.Split(':'); dllMapping.Add(split[0], split[1]); });
            StaticVars.MainForm = GetAssembly<Form>(dllMapping["Display"]);
            StaticVars.Engine = GetAssembly<IEngine>(dllMapping["Engine"]);
            StaticVars.DataManager = GetAssembly<IDataManager>(dllMapping["DataManager"]);
            StaticVars.Engine.DataManager = StaticVars.DataManager;
            StaticVars.Engine.Initialize();
            StaticVars.MenuContainer = GetAssembly<IMenuContainer>(dllMapping["MenuContainer"]);
            StaticVars.MenuContainer.Selector = GetAssembly<ISelector>(dllMapping["Selector"]);
            StaticVars.MainForm.Controls.Add(StaticVars.MenuContainer.Initialize());
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
            return assm.GetTypes().OfType<T>().FirstOrDefault();
        }
    }
}
