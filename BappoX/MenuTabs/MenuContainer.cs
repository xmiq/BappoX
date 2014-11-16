using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuTabs
{
    /// <summary>
    /// The Container for the Menus
    /// </summary>
    public class MenuContainer : IMenuContainer
    {
        /// <summary>
        /// Clickable Selector
        /// </summary>
        public ISelector Selector { get; set; }

        /// <summary>
        /// Initializer for the Menu Container
        /// </summary>
        /// <returns></returns>
        public Control Initialize()
        {
            Panel p = new Panel();
            Control c = Selector.Initialize();
            return p;
        }
    }
}
