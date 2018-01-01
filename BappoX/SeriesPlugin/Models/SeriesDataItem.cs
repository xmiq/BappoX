using Interface.Interfaces.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesPlugin.Models
{
    public class SeriesDataItem : IDataItem
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
        public IPluginData PluginData
        {
            get
            {
                return SeriesItemData;
            }
            set
            {
                if (value is SeriesItem data)
                    SeriesItemData = data;
                else
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public JObject Data
        {
            get
            {
                return new JObject
                {
                    { "Type", "BappoX Default Series Plugin" },
                    { "Name", SeriesItemData.Name },
                    { "Season", SeriesItemData.Season },
                    { "Episode", SeriesItemData.Episode }
                };
            }
            set
            {
                if (value.Value<string>("Type").Equals("BappoX Default Series Plugin") && VersionNumber == StorageVersion.Version_2)
                    SeriesItemData = new SeriesItem { Name = value.Value<string>("Name"), Season = value.Value<int>("Season"), Episode = value.Value<int>("Episode"), Parent = this };
                else if (value.Value<string>("Type").Equals("s") && VersionNumber == StorageVersion.Version_1)
                {
                    JArray items = value.Properties().Where(x => x.Name == "Type Data").FirstOrDefault().Value as JArray;
                    SeriesItemData = new SeriesItem { Name = items[0].ToString(), Season = Convert.ToInt32(items[1].ToString()), Episode = Convert.ToInt32(items[2].ToString()), Parent = this };
                }
                else
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Gets or sets the series item data.
        /// </summary>
        /// <value>
        /// The series item data.
        /// </value>
        public SeriesItem SeriesItemData { get; set; }

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

        /// <summary>
        /// Gets the series data item from generic data item.
        /// </summary>
        /// <param name="IDataItem">The generic data item.</param>
        /// <returns>The Series Data Item.</returns>
        public static SeriesDataItem GetSeriesDataItemFromGeneric(IDataItem item)
        {
            SeriesDataItem dataItem = new SeriesDataItem
            {
                ID = item.ID,
                VersionNumber = item.VersionNumber,
                Data = item.Data
            };

            foreach (IMediaList ml in item.Parents)
            {
                ml.Items.Remove(item);
                ml.Items.Add(dataItem);
                item.Parents.Remove(ml);
                dataItem.Parents.Add(ml);
            }

            return dataItem;
        }
    }
}