using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    /// <summary>
    /// Contains Application wide variables
    /// </summary>
    public static class StaticVars
    {
        /// <summary>
        /// Identifies the program that is running
        /// </summary>
        public static string Program { get; set; }

        /// <summary>
        /// The Form that the program displays
        /// </summary>
        public static Form MainForm { get; set; }

        /// <summary>
        /// Program Engine
        /// </summary>
        public static IEngine Engine { get; set; }

        /// <summary>
        /// Manager of Data
        /// </summary>
        public static IDataManager DataManager { get; set; }

        /// <summary>
        /// Menu Container
        /// </summary>
        public static IMenuContainer MenuContainer { get; set; }

        /// <summary>
        /// Where all the content plugins are kept
        /// </summary>
        public static IPluginLoader Plugins { get; set; }
    }
}