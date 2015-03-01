using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    /// <summary>
    /// Provides the framework needed for plugins to launch
    /// </summary>
    public interface IPluginLoader
    {
        /// <summary>
        /// Loads all the Plugins
        /// </summary>
        void Initialize(string folder);

        List<IPlugin> Plugins { get; set; }
    }
}
