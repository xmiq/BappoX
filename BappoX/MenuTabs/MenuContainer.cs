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
        /// Menu Container Control
        /// </summary>
        public Control MenuControl { get; set; }

        /// <summary>
        /// Initializer for the Menu Container
        /// </summary>
        /// <returns></returns>
        public Control Initialize()
        {
            Panel p = new Panel();
            p.Top = 20;
            p.Left = 0;
            p.Width = 10;
            p.Height = 110;
            p.MouseEnter += p_MouseEnter;
            p.MouseLeave += p_MouseLeave;
            p.GotFocus += p_MouseEnter;
            p.LostFocus += p_MouseLeave;
            Control c = Selector.Initialize();
            p.Controls.Add(c);
            MenuControl = p;
            return p;
        }

        /// <summary>
        /// Contracts the Container
        /// </summary>
        /// <param name="sender">Panel</param>
        /// <param name="e">Default Event</param>
        void p_MouseLeave(object sender, EventArgs e)
        {
            if (MenuControl.Width == 35)
            {
                for (int i = 0; i < 25; i++) MenuControl.Width--;
            }
        }

        /// <summary>
        /// Expands the Container
        /// </summary>
        /// <param name="sender">Panel</param>
        /// <param name="e">Default Event</param>
        void p_MouseEnter(object sender, EventArgs e)
        {
            if (MenuControl.Width == 10)
            {
                for (int i = 0; i < 25; i++) MenuControl.Width++;
            }
        }
    }
}
