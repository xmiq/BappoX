using DataItemSelector;
using DataManagment;
using Engine;
using Interface;
using MenuTabs;
using System;
using System.Collections.Generic;
using System.Linq;
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
            StaticVars.MainForm = new MainForm.MainForm();
            StaticVars.Engine = new ProgramEngine(StaticVars.Program);
            StaticVars.DataManager = new FileDataManager();
            StaticVars.Engine.DataManager = StaticVars.DataManager;
            StaticVars.Engine.Initialize();
            StaticVars.MenuContainer = new MenuContainer();
            StaticVars.MenuContainer.Selector = new DIS();
            StaticVars.MenuContainer.Initialize();
            return StaticVars.MainForm;
        }
    }
}
