using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    /// <summary>
    /// Provides the framework for the Engine
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Handler of Data
        /// </summary>
        IDataManager DataManager { get; set; }

        /// <summary>
        /// Loads the Engine Components
        /// </summary>
        void Initialize();
    }
}
