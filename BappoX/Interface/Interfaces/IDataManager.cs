using Interface.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    /// <summary>
    /// Provides the framework for the Data Managment
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Program's Data.
        /// </summary>
        List<IMediaList> Data { get; set; }

        /// <summary>
        /// Loads the Data
        /// </summary>
        void InitData();

        /// <summary>
        /// Loads the Data from the data source
        /// </summary>
        void GetData();

        /// <summary>
        /// Saves the Data to the data source.
        /// </summary>
        void SaveData();

        /// <summary>
        /// Creates an empty media list.
        /// </summary>
        /// <returns></returns>
        IMediaList CreateMediaList();

        /// <summary>
        /// Creates an empty data item.
        /// </summary>
        /// <returns></returns>
        IDataItem CreateDataItem();
    }
}