using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    /// <summary>
    /// Provides the framework for the plugins to use
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// The plugin data
        /// </summary>
        List<IPluginControl> Data { get; set; }

        /// <summary>
        /// The icon to be shown
        /// </summary>
        Image Icon { get; }

        /// <summary>
        /// Add a new Plugin Control to Data
        /// </summary>
        void AddNew();
    }
}
