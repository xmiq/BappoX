using Interface.Interfaces;
using Interface.Interfaces.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.StaticVars;

namespace SeriesPlugin
{
    /// <summary>
    /// Manages Series
    /// </summary>
    public class SeriesPlugin : IPlugin
    {
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
            SeriesControl sc = new SeriesControl();
            sc.SaveControlItem();
            sc.SaveClicked += sc_SaveClicked;
            sc.DeleteClicked += sc_DeleteClicked;
        }

        /// <summary>
        /// Takes all the Data Items in the data and parses them to something useable
        /// </summary>
        /// <param name="data">Text to be converted</param>
        /// <param name="version">Schema Version of the data</param>
        public void ParseSaveData()
        {
            foreach (IDataItem di in DataManager.Data.Select(x => x.Items).SelectMany(x => x).GroupBy(x => x.ID).Select(x => x.First()))
            {
                if (di.VersionNumber == StorageVersion.Version_1)
                {
                    if (di.Data.Value<string>("Type") == "s")
                    {
                        JArray items = di.Data.Properties().Where(x => x.Name == "Type Data").FirstOrDefault().Value as JArray;
                        di.PluginData = new SeriesItem { Name = items[0].ToString(), Season = Convert.ToInt32(items[1].ToString()), Episode = Convert.ToInt32(items[2].ToString()), Parent = di };
                    }
                }
            }
        }

        private void sc_SaveClicked()
        {
            throw new NotImplementedException();
        }

        private void sc_DeleteClicked()
        {
            throw new NotImplementedException();
        }
    }
}