using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    /// <summary>
    /// Provides the framework the for the clickable Items
    /// </summary>
    public interface ISelector
    {
        /// <summary>
        /// Loads the Plugin Selector
        /// </summary>
        /// <returns>Plugin Selector</returns>
        Control Initialize();
    }
}
