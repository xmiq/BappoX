using Interface.Interfaces;
using Interface.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesPlugin
{
    public class SeriesItem : IPluginData
    {
        /// <summary>
        /// Gets or sets the name of the series.
        /// </summary>
        /// <value>
        /// The name of the series.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// The currently watching season
        /// </summary>
        public int Season { get; set; }

        /// <summary>
        /// The current episode
        /// </summary>
        public int Episode { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public IDataItem Parent { get; set; }
    }
}