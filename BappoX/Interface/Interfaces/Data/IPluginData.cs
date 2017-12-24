using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces.Data
{
    /// <summary>
    /// To be implemented by the plugins to contain their data.
    /// </summary>
    public interface IPluginData
    {
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        IDataItem Parent { get; set; }
    }
}
