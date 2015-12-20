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
        private Panel p;
        private bool expanded;

        /// <summary>
        /// Initializer
        /// </summary>
        /// <returns>The Control to show</returns>
        public Control Initialize()
        {
            //Create Root Panel (Holds Icon and Plugin Panel)
            p = new Panel
            {
                Width = 30,
                Height = 30,
                AutoSize = true,
                BackColor = System.Drawing.Color.AntiqueWhite
            };

            //Create PictureBox that displays the icon
            PictureBox pb = new PictureBox()
            {
                Width = 30,
                Height = 30,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Resources.ArrowR
            };
            pb.Click += pb_Click;
            p.Controls.Add(pb);

            //Create Plugin Panel
            Panel p2 = new Panel
            {
                Width = 10,
                Height = 10,
                Left = 35,
                BackColor = System.Drawing.Color.Blue,
                AutoSize = true,
                Visible = false
            };
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