using Interface.Classes;
using Interface.Interfaces;
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
            Data = new Dictionary<Guid, CategoryItem>();
            DataManager.InitData();
            Plugins.Plugins.ForEach(x => x.Engine = this);
            Plugins.Plugins.ForEach(x => x.ParseSaveData(DataManager.Data));
        }

        /// <summary>
        /// Formatted Data
        /// </summary>
        public Dictionary<Guid, CategoryItem> Data { get; set; }

        /// <summary>
        /// The selected category
        /// </summary>
        public CategoryItem CurrentCategory { get; set; }
    }
}