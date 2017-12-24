using Interface.Interfaces;
using Interface.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.StaticVars;

namespace Engine
{
    /// <summary>
    /// The Engine that the program uses for any calculations
    /// </summary>
    public class ProgramEngine : IEngine
    {
        /// <summary>
        /// Handles all the necessary Loading
        /// </summary>
        public ProgramEngine()
        {
            DataManager.InitData();
            foreach (var plugin in Plugins.Plugins)
            {
                plugin.ParseSaveData();
            }
        }

        /// <summary>
        /// The selected category
        /// </summary>
        public IMediaList CurrentCategory { get; set; }
    }
}