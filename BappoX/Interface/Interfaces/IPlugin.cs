using Interface.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    /// <summary>
    /// Provides the framework for the plugins to use
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// The icon to be shown
        /// </summary>
        Image Icon { get; }

        /// <summary>
        /// Add a new Plugin Control to Data
        /// </summary>
        void AddNew();

        /// <summary>
        /// Takes the text that is saved and converts it to an IPluginControl
        /// </summary>
        void ParseSaveData();
    }
}