using Interface.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    /// <summary>
    /// Provides the framework for the Engine
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// The List of Data in usable format by the program
        /// </summary>
        Dictionary<Guid, CategoryItem> Data { get; set; }

        /// <summary>
        /// The category that is currently selected
        /// </summary>
        CategoryItem CurrentCategory { get; set; }
    }
}