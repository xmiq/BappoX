using Interface.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagment.Models
{
    /// <summary>
    /// Contains the Media Items
    /// </summary>
    /// <seealso cref="Interface.Interfaces.Data.IMediaList" />
    public class MediaList : IMediaList
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
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<IDataItem> Items { get; set; }
    }
}