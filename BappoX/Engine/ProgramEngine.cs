using Interface.Classes;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// The Engine that the program uses for any calculations
    /// </summary>
    public class ProgramEngine : IEngine
    {
        /// <summary>
        /// Handler of Data
        /// </summary>
        public IDataManager DataManager { get; set; }

        /// <summary>
        /// Handles all the necessary Loading
        /// </summary>
        public void Initialize()
        {
            Data = new Dictionary<Guid, CategoryItem>();
            DataManager.InitData();
            Plugins.ForEach(x => x.Engine = this);
            Plugins.ForEach(x => x.ParseSaveData(DataManager.Data));
        }

        /// <summary>
        /// Plugins of the program
        /// </summary>
        public List<IPlugin> Plugins { get; set; }

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