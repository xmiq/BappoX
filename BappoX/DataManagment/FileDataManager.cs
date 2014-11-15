using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagment
{
    /// <summary>
    /// Handles saving and loading data from files
    /// </summary>
    public class FileDataManager : IDataManager
    {
        /// <summary>
        /// Program's Data
        /// </summary>
        public List<string> Data { get; set; }

        /// <summary>
        /// Loads the Data
        /// </summary>
        public void InitData()
        {

        }
    }
}
