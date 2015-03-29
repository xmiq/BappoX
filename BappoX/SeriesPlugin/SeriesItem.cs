using Interface.Classes;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesPlugin
{
    public class SeriesItem : PluginItem
    {
        public SeriesItem()
            : base()
        {
            List = new List<Guid>();
        }

        public SeriesItem(Guid IDtoAdd)
            : base()
        {
            List = new List<Guid>();
            List.Add(IDtoAdd);
        }

        public SeriesItem(Guid[] IDs)
            : base()
        {
            List = new List<Guid>();
            List.AddRange(IDs);
        }

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