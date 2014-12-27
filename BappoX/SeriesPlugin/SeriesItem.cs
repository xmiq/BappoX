using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;

namespace SeriesPlugin
{
    public class SeriesItem : PluginItem
    {
        /// <summary>
        /// The currently watching season
        /// </summary>
        public int Season { get; set; }

        /// <summary>
        /// The current episode
        /// </summary>
        public int Episode { get; set; }
    }
}
