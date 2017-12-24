using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces.Data
{
    /// <summary>
    /// Contains content of a List
    /// </summary>
    public interface IMediaList
    {
        /// <summary>
        /// ID of this Category
        /// </summary>
        Guid ID { get; set; }

        /// <summary>
        /// The Name of this Category
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        List<IDataItem> Items { get; set; }
    }
}