using Interface.Interfaces;
using Interface.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.StaticVars;

namespace SeriesPlugin
{
    /// <summary>
    /// The visual aid for the TV Series
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    /// <seealso cref="Interface.Interfaces.IPluginControl" />
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
        /// The control item
        /// </summary>
        private IDataItem controlItem;

        /// <summary>
        /// The TV Series class that this Control Manages
        /// </summary>
        public IDataItem ControlItem
        {
            get
            {
                return controlItem;
            }
            set
            {
                if (value.PluginData is SeriesItem)
                {
                    SeriesItem si = value.PluginData as SeriesItem;
                    ID = value.ID;
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbOK_Click(object sender, EventArgs e)
        {
            SaveClicked();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbCancel_Click(object sender, EventArgs e)
        {
            DeleteClicked();
        }

        /// <summary>
        /// Saves the control item.
        /// </summary>
        public void SaveControlItem()
        {
            if (controlItem == null)
            {
                controlItem = DataManager.CreateDataItem();
                controlItem.Parents.Add(Engine.CurrentCategory);
                Engine.CurrentCategory.Items.Add(controlItem);
            }
            if (controlItem.PluginData == null)
                controlItem.PluginData = new SeriesItem { Parent = controlItem };
            var item = controlItem.PluginData as SeriesItem;
            item.Name = txtName.Text;
            item.Season = Convert.ToInt32(numSeason.Value);
            item.Episode = Convert.ToInt32(numEpisode.Value);
        }
    }
}