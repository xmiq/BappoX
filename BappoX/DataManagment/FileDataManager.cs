using Interface.Interfaces;
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
            if (Directory.Exists(path) && File.Exists(path + Path.DirectorySeparatorChar + "media.txt"))
                Data = (File
                    .ReadAllText(path + Path.DirectorySeparatorChar + "media.txt") ?? "")
                    .Split(',')
                    .Select(x => new { Name = x, Path = path + Path.DirectorySeparatorChar + x + ".txt" })
                    .Where(x => File.Exists(x.Path))
                    .Select(x => new { Name = x.Name, Media = File.ReadAllText(x.Path) })
                    .Where(x => !String.IsNullOrEmpty(x.Media))
                    .Select(x => new KeyValuePair<string, string[]>(x.Name, x.Media.Split(',')))
                    .Concat(Data)
                    .ToDictionary(x => x.Key, y => y.Value);
        }
    }
}