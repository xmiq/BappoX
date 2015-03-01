﻿using Interface;
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

        bool expanded;
        bool isInChildren;

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
            p.AutoSize = true;
            p.MouseEnter += p_MouseEnter;
            p.MouseLeave += p_MouseLeave;
            p.GotFocus += p_MouseEnter;
            Control c = Selector.Initialize();
            c.Top = 5;
            c.Left = (c.Width - 10) * -1;
            c.MouseEnter += c_MouseEnter;
            c.MouseLeave += c_MouseLeave;
            p.Controls.Add(c);
            MenuControl = p;
            expanded = false;
            isInChildren = false;
            p.BackColor = System.Drawing.Color.Aqua;
            return p;
        }

        void c_MouseLeave(object sender, EventArgs e)
        {
            //isInChildren = false;
        }

        void c_MouseEnter(object sender, EventArgs e)
        {
            isInChildren = true;
        }

        void p_MouseLeave(object sender, EventArgs e)
        {
            if (!isInChildren && expanded) CollapseAllPanels();
        }

        /// <summary>
        /// Expands the Container
        /// </summary>
        /// <param name="sender">Panel</param>
        /// <param name="e">Default Event</param>
        void p_MouseEnter(object sender, EventArgs e)
        {
            if (!expanded)
            {
                expanded = true;
                Control Selector = MenuControl.Controls[0];
                while (Selector.Left < 5)
                {
                    Selector.Left++;
                }
            }
        }

        /// <summary>
        /// Hides all the panels
        /// </summary>
        public void CollapseAllPanels()
        {
            if (expanded)
            {
                expanded = false;
                Control Selector = MenuControl.Controls[0];
                int collapsed = (Selector.Width - 10) * -1;
                while (Selector.Left > collapsed)
                {
                    Selector.Left--;
                }
            }
        }
    }
}
