using Interface.Classes;
using Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Program Engine
        /// </summary>
        public IEngine Engine { get; set; }

        /// <summary>
        /// Add a new TV Series to the list
        /// </summary>
        public void AddNew()
        {
            SeriesControl sc = new SeriesControl();
            List<Guid> CategoryList = new List<Guid>();
            CategoryList.Add(Engine.CurrentCategory.ID);
            sc.ControlItem.List = CategoryList;
            sc.SaveClicked += sc_SaveClicked;
            sc.DeleteClicked += sc_DeleteClicked;
            Engine.CurrentCategory.PluginControls.Add(sc);
            Engine.CurrentCategory.PluginData.Add(sc.ControlItem);
        }

        /// <summary>
        /// Takes the text that is saved and converts it to a Series Control
        /// </summary>
        /// <param name="data">Text to be converted</param>
        public void ParseSaveData(Dictionary<string, string[]> data)
        {
            ParseSaveData(data, 1);
        }

        /// <summary>
        /// Takes the text that is saved and converts it to a Series Control
        /// </summary>
        /// <param name="data">Text to be converted</param>
        /// <param name="version">Schema Version of the data</param>
        public void ParseSaveData(Dictionary<string, string[]> data, int version)
        {
            switch (version)
            {
                case 1: Engine.Data = Engine
                        .Data
                        .Concat(data
                            .Select(x => x.Key)
                            .Except(Engine.Data.Select(x => x.Value.Name))
                            .Select(x => new CategoryItem { Name = x, ID = Guid.NewGuid(), PluginControls = new List<IPluginControl>(), PluginData = new List<PluginItem>() })
                            .ToDictionary(x => x.ID, x => x))
                        .ToDictionary(x => x.Key, x => x.Value);
                    foreach (SeriesControl sc in data
                        .Select(x => new
                            {
                                Key = Engine
                                    .Data
                                    .Values
                                    .FirstOrDefault(y => y.Name == x.Key)
                                    .ID,
                                Value = x.Value
                            })
                        .Select(x => x
                            .Value
                            .Select(y => new { Key = x.Key, Value = y }))
                        .SelectMany(x => x)
                        .Select(x => new { Key = x.Key, Value = x.Value.Split('|') })
                        .Where(x => x.Value[0] == "s")
                        .Select(x => new SeriesItem(x.Key) { ID = Guid.NewGuid(), Name = x.Value[1], Season = Convert.ToInt32(x.Value[2]), Episode = Convert.ToInt32(x.Value[3]) })
                        .Select(x => { SeriesControl sc = new SeriesControl { ControlItem = x }; sc.SaveClicked += sc_SaveClicked; sc.DeleteClicked += sc_DeleteClicked; return sc; }))
                    {
                        foreach (Guid g in sc.ControlItem.List)
                        {
                            CategoryItem ci = Engine.Data[g];
                            ci.PluginControls.Add(sc);
                            ci.PluginData.Add(sc.ControlItem);
                        }
                    }
                    break;
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