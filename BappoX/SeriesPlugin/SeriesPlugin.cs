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
            SeriesControl sc = new SeriesControl();
            sc.ControlItem.List = "";
            sc.SaveClicked += sc_SaveClicked;
            sc.DeleteClicked += sc_DeleteClicked;
            Data.Add(sc);
        }

        /// <summary>
        /// Takes the text that is saved and converts it to a Series Control
        /// </summary>
        /// <param name="data">Text to be converted</param>
        public void ParseSaveData(Dictionary<string, string[]> data)
        {
            ParseSaveData(data, 1);
        }

        public void ParseSaveData(Dictionary<string, string[]> data, int version)
        {
            switch (version)
            {
                case 1: Data = Data
                    .Concat(data
                        .Select(x => x
                            .Value
                            .Select(y => String.Join("|", new string[] { x.Key, y })))
                        .SelectMany(x => x)
                        .Select(x => x.Split('|'))
                        .Where(x => x[1] == "s")
                        .Select(x => new SeriesItem { ID = Guid.NewGuid(), List = x[0], Name = x[2], Season = Convert.ToInt32(x[3]), Episode = Convert.ToInt32(x[4]) })
                        .Select(x => { SeriesControl sc = new SeriesControl { ControlItem = x }; sc.SaveClicked += sc_SaveClicked; sc.DeleteClicked += sc_DeleteClicked; return sc; }))
                    .ToList();
                    break;
            }
        }

        void sc_SaveClicked()
        {
            throw new NotImplementedException();
        }

        void sc_DeleteClicked()
        {
            throw new NotImplementedException();
        }
    }
}
