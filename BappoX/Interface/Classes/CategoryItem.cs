using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Classes
{
    /// <summary>
    /// Holder for the Categories
    /// </summary>
    public class CategoryItem
    {
        /// <summary>
        /// ID of this Category
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// The Name of this Category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The PluginItem Associated with this Category
        /// </summary>
        public List<PluginItem> PluginData { get; set; }

        /// <summary>
        /// The Plugin Controls Associated with this Category
        /// </summary>
        public List<IPluginControl> PluginControls { get; set; }
    }
}