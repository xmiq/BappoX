using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface.Interfaces
{
    /// <summary>
    /// Provides the framework needed for the program to launch
    /// </summary>
    public interface ILoader
    {
        /// <summary>
        /// Were all the work is done
        /// </summary>
        /// <returns>The form that is displayed</returns>
        Form Initialize();
    }
}
