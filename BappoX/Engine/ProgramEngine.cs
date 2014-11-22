using Interface;
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
            DataManager.InitData();
        }
    }
}
