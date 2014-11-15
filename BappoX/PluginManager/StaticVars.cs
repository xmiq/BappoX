﻿using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginManager
{
    /// <summary>
    /// Contains Application wide variables
    /// </summary>
    internal class StaticVars
    {
        /// <summary>
        /// Identifies the program that is running
        /// </summary>
        internal static string Program { get; set; }

        /// <summary>
        /// The Form that the program displays
        /// </summary>
        internal static Form MainForm { get; set; }

        /// <summary>
        /// Program Engine
        /// </summary>
        internal static IEngine Engine { get; set; }

        /// <summary>
        /// Manager of Data
        /// </summary>
        internal static IDataManager DataManager { get; set; }
    }
}