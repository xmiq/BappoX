using Interface.Interfaces.Data;
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
        /// The category that is currently selected
        /// </summary>
        IMediaList CurrentCategory { get; set; }
    }
}