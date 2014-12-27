using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interface;

namespace SeriesPlugin
{
    /// <summary>
    /// The visual aid for the TV Series
    /// </summary>
    public partial class SeriesControl : UserControl, IPluginControl
    {
        /// <summary>
        /// Initializer
        /// </summary>
        public SeriesControl()
        {
            InitializeComponent();
            ID = Guid.NewGuid();
        }

        /// <summary>
        /// The ID of the Control
        /// </summary>
        public Guid ID;

        /// <summary>
        /// The TV Series class that this Control Manages
        /// </summary>
        public PluginItem ControlItem
        {
            get
            {
                return new SeriesItem { ID = ID, Name = txtName.Text, Season = Convert.ToInt32(numSeason.Value), Episode = Convert.ToInt32(numEpisode.Value) };
            }
            set
            {
                if (value is SeriesItem)
                {
                    SeriesItem si = value as SeriesItem;
                    ID = si.ID;
                    txtName.Text = si.Name;
                    numSeason.Value = si.Season;
                    numEpisode.Value = si.Episode;
                }
            }
        }

        /// <summary>
        /// Called when Save is clicked
        /// </summary>
        public event PluginDelegetes.SaveDelegete SaveClicked;

        /// <summary>
        /// Called when Delete is clicked
        /// </summary>
        public event PluginDelegetes.DeleteDelegete DeleteClicked;

        private void pbOK_Click(object sender, EventArgs e)
        {
            SaveClicked();
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            DeleteClicked();
        }
    }
}
