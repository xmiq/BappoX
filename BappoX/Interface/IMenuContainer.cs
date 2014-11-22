using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    /// <summary>
    /// Provides the framework for the Menu Containers
    /// </summary>
    public interface IMenuContainer
    {
        /// <summary>
        /// Selector for the plugins
        /// </summary>
        ISelector Selector { get; set; }

        /// <summary>
        /// Menu Container Control
        /// </summary>
        Control MenuControl { get; set; }

        /// <summary>
        /// Loads the Menu Container
        /// </summary>
        /// <returns>Menu Container Control</returns>
        Control Initialize();
    }
}
