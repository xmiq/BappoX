using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface.Interfaces
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

        /// <summary>
        /// To be called after the list of plugins is filled, this fills the control with the icons
        /// </summary>
        void Populate();

        /// <summary>
        /// Hides all open menus
        /// </summary>
        void Collapse();
    }
}