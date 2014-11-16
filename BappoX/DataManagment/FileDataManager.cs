using Interface;
using System;
using System.Collections.Generic;
using System.IO;
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
        public Dictionary<string, string[]> Data { get; set; }

        /// <summary>
        /// Loads the Data
        /// </summary>
        public void InitData()
        {
            Data = new Dictionary<string, string[]>();
            GetData();
        }

        /// <summary>
        /// Data Load Method
        /// </summary>
        public void GetData()
        {
            GetData("items");
        }

        /// <summary>
        /// Data Load Method
        /// </summary>
        /// <param name="path">Path of data</param>
        public void GetData(string path)
        {
            if (Directory.Exists(path))
            {
                if (File.Exists(path + Path.DirectorySeparatorChar + "media.txt"))
                {
                    string media = File.ReadAllText(path + Path.DirectorySeparatorChar + "media.txt");
                    if (!string.IsNullOrEmpty(media)) Array.ForEach(media.Split(','), (s) => Data.Add(s, null));
                }
                foreach (string s in Data.Keys)
                {
                    if (File.Exists(path + Path.DirectorySeparatorChar + s + ".txt"))
                    {
                        string media = File.ReadAllText(path + Path.DirectorySeparatorChar + s + ".txt");
                        if (!string.IsNullOrEmpty(media)) Data[s] = media.Split(',');
                    }
                }
            }
        }

    }
}
