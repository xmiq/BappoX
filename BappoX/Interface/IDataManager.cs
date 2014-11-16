using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    /// <summary>
    /// Provides the framework for the Data Managment
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Program's Data.
        /// </summary>
        Dictionary<string, string[]> Data { get; set; }

        /// <summary>
        /// Loads the Data
        /// </summary>
        void InitData();

        /// <summary>
        /// Loads the Data from the data source
        /// </summary>
        void GetData();
    }
}
