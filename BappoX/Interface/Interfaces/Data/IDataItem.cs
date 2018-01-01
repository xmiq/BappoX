using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces.Data
{
    /// <summary>
    /// A container for the data that is saved in the storage.
    /// </summary>
    public interface IDataItem
    {
        /// <summary>
        /// The Version number of the storage data.
        /// </summary>
        StorageVersion VersionNumber { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid ID { get; set; }

        /// <summary>
        /// Gets the parents.
        /// </summary>
        /// <value>
        /// The parents.
        /// </value>
        List<IMediaList> Parents { get; }

        /// <summary>
        /// Converts the Version 1 data into something useable
        /// </summary>
        /// <value>
        /// The version 1 data.
        /// </value>
        string Version1 { set; }

        /// <summary>
        /// Gets or sets the plugin data.
        /// </summary>
        /// <value>
        /// The plugin data.
        /// </value>
        IPluginData PluginData { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        JObject Data { get; set; }
    }

    /// <summary>
    /// The versioning system for the data is stored.
    /// </summary>
    public enum StorageVersion
    {
        /// <summary>
        /// The version used by Media Organizer 2.
        /// </summary>
        Version_1 = 0,

        /// <summary>
        /// The version used by BappoX.
        /// </summary>
        Version_2 = 1,

        /// <summary>
        /// Other versioning systems.
        /// </summary>
        CustomVersion = -1
    }
}