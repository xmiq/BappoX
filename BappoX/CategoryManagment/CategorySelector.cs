using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CategoryManagment
{
    public class CategorySelector : IListManager
    {
        /// <summary>
        /// The program's Engine
        /// </summary>
        public IEngine Engine { get; set; }

        private Panel p;
        private bool expanded;

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

        private void pb_Click(object sender, EventArgs e)
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

        public void Populate()
        {
            throw new NotImplementedException();
        }

        public void Collapse()
        {
            if (expanded) pb_Click(p.Controls[0], null);
        }
    }
}