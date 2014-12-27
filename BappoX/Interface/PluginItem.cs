using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    /// <summary>
    /// The main point for each plugin to pass its data
    /// </summary>
    public abstract class PluginItem
    {
        /// <summary>
        /// The ID of the plugin
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// A text based identifier for the user to see in the text files
        /// </summary>
        public string Name { get; set; }
    }
}
