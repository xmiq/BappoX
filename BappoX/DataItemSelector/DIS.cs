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
        /// <summary>
        /// Initializer
        /// </summary>
        /// <returns>The Control to show</returns>
        public Control Initialize()
        {
            Panel p = new Panel();
            p.Top = 5;
            p.Left = -20;
            p.Width = 30;
            p.Height = 30;
            p.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictureBox pb = new PictureBox();
            pb.Width = 30;
            pb.Height = 30;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Image = Resources.ArrowR;
            p.Controls.Add(pb);
            return p;
        }
    }
}
