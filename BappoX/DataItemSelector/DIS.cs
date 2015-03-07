using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataItemSelector
{
    /// <summary>
    /// Where plugins are displayed
    /// </summary>
    public class DIS : ISelector
    {
        Panel p;
        bool expanded;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <returns>The Control to show</returns>
        public Control Initialize()
        {
            p = new Panel();
            p.Width = 30;
            p.Height = 30;
            p.AutoSize = true;
            p.BackColor = System.Drawing.Color.AntiqueWhite;
            PictureBox pb = new PictureBox();
            pb.Width = 30;
            pb.Height = 30;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Image = Resources.ArrowR;
            pb.Click += pb_Click;
            p.Controls.Add(pb);
            Panel p2 = new Panel();
            p2.Width = 10;
            p2.Height = 10;
            p2.Left = 35;
            p2.BackColor = System.Drawing.Color.Blue;
            p2.AutoSize = true;
            p2.Visible = false;
            p.Controls.Add(p2);
            expanded = false;
            return p;
        }

        void pb_Click(object sender, EventArgs e)
        {
            if (expanded)
            {
                expanded = false;
                (sender as PictureBox).Image = Resources.ArrowR;
                p.Controls[1].Visible = false;
            }
            else
            {
                expanded = true;
                (sender as PictureBox).Image = Resources.ArrowL;
                p.Controls[1].Visible = true;
            }
        }

        /// <summary>
        /// Adding plugins to control
        /// </summary>
        public void Populate()
        {
            Panel secondPanel = p.Controls[1] as Panel;
            int leftShift = 0;
            foreach (IPlugin ip in Plugin)
            {
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Top = 0;
                pb.Left = leftShift + 5;
                leftShift += 55;
                pb.Width = 50;
                pb.Height = 50;
                pb.Image = ip.Icon;
                secondPanel.Controls.Add(pb);
            }
        }

        /// <summary>
        /// Hides all open menus
        /// </summary>
        public void Collapse()
        {
            if (expanded) pb_Click(p.Controls[0], null);
        }

        /// <summary>
        /// The list of plugins
        /// </summary>
        public List<IPlugin> Plugin { get; set; }
    }
}
