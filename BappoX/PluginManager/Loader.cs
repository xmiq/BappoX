using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.StaticVars;
using static Common.Tools;

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
        /// <param name="program">The program the Launcher will Initialize</param>
        public Loader(string program)
        {
            Program = program;
        }

        /// <summary>
        /// Initialize all the variables
        /// </summary>
        /// <returns>Main Form</returns>
        public Form Initialize()
        {
            MainForm = GetAssembly<Form>(Settings("Display"));
            MenuContainer = GetAssembly<IMenuContainer>(Settings("MenuContainer"));
            Plugins = GetAssembly<IPluginLoader>(Settings("PluginLoader"));
            DataManager = GetAssembly<IDataManager>(Settings("DataManager"));
            Engine = GetAssembly<IEngine>(Settings("Engine"));
            MenuContainer.Selector = GetAssembly<ISelector>(Settings("Selector"));
            MenuContainer.Lists = GetAssembly<IListManager>(Settings("ListManager"));
            MainForm.Controls.Add(MenuContainer.Initialize());
            MenuContainer.Selector.Populate();
            return MainForm;
        }
    }
}