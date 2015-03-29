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
        /// Program Engine
        /// </summary>
        IEngine Engine { get; set; }

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
        /// <param name="data">Text to be converted</param>
        void ParseSaveData(Dictionary<string, string[]> data);
    }
}