using Interface.Interfaces.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagment.Models
{
    /// <summary>
    /// The storage used by the data management to contain the item
    /// </summary>
    /// <seealso cref="IDataItem" />
    public class DataItem : IDataItem
    {
        /// <summary>
        /// The Version number of the storage data.
        /// </summary>
        public StorageVersion VersionNumber { get; set; }

        /// <summary>
        /// Converts the Version 1 data into something useable
        /// </summary>
        /// <value>
        /// The version 1 data.
        /// </value>
        public string Version1
        {
            set
            {
                string[] items = value.Split('|');
                Data = new JObject();
                Data.Add(new JProperty("Type", items[0]));
                Data.Add(new JProperty("Type Data", items.Skip(1).ToArray()));
            }
        }

        /// <summary>
        /// Gets or sets the plugin data.
        /// </summary>
        /// <value>
        /// The plugin data.
        /// </value>
        public IPluginData PluginData { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public JObject Data { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid ID { get; set; }

        /// <summary>
        /// Gets the Parent Lists.
        /// </summary>
        /// <value>
        /// The Parent Lists.
        /// </value>
        public List<IMediaList> Parents { get; } = new List<IMediaList>();
    }
}