using Interface.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    /// <summary>
    /// Provides the interface for Controls that the plugins use
    /// </summary>
    public interface IPluginControl
    {
        /// <summary>
        /// The Item that the Control addresses
        /// </summary>
        PluginItem ControlItem { get; set; }

        /// <summary>
        /// Called when it is time to save
        /// </summary>
        event Interface.Interfaces.PluginDelegetes.SaveDelegete SaveClicked;

        /// <summary>
        /// Called when the item is to be deleted
        /// </summary>
        event Interface.Interfaces.PluginDelegetes.DeleteDelegete DeleteClicked;

        /// <summary>
        /// The owning list of the Item
        /// </summary>
        List<Guid> List { get; set; }
    }

    public class PluginDelegetes
    {
        /// <summary>
        /// The delegate that manages save data
        /// </summary>
        public delegate void SaveDelegete();

        /// <summary>
        /// The delegate that manages deletion data
        /// </summary>
        public delegate void DeleteDelegete();
    }
}