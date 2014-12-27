using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;

namespace SeriesPlugin
{
    /// <summary>
    /// Manages Series
    /// </summary>
    public class SeriesPlugin : IPlugin
    {
        /// <summary>
        /// Initializer
        /// </summary>
        public SeriesPlugin()
        {
            Data = new List<IPluginControl>();
        }

        /// <summary>
        /// List of Controls that this plugin manages
        /// </summary>
        public List<IPluginControl> Data { get; set; }

        /// <summary>
        /// The Series Icon
        /// </summary>
        public System.Drawing.Image Icon
        {
            get
            {
                return Resources.series;
            }
        }


        /// <summary>
        /// Add a new TV Series to the list
        /// </summary>
        public void AddNew()
        {
            Data.Add(new SeriesControl());
        }
    }
}
