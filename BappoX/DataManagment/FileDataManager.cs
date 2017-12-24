using DataManagment.Models;
using Interface.Interfaces;
using Interface.Interfaces.Data;
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
        public List<IMediaList> Data { get; set; }

        /// <summary>
        /// Loads the Data
        /// </summary>
        public void InitData()
        {
            Data = new List<IMediaList>();
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
            /* Check for Version 1 of the Data */
            if (Directory.Exists(path) && File.Exists(path + Path.DirectorySeparatorChar + "media.txt"))
                Data = (File
                    .ReadAllText(path + Path.DirectorySeparatorChar + "media.txt") ?? "")
                    .Split(',')
                    .Select(x => new { MediaList = new MediaList { ID = Guid.NewGuid(), Name = x, Items = new List<IDataItem>() }, Path = path + Path.DirectorySeparatorChar + x + ".txt" })
                    .Where(x => File.Exists(x.Path))
                    .Select(x => new { MediaList = x.MediaList, Media = File.ReadAllText(x.Path) })
                    .Where(x => !String.IsNullOrEmpty(x.Media))
                    .Select(x =>
                    {
                        x.MediaList.Items = x.Media.Split(',').Select(y => new DataItem { ID = Guid.NewGuid(), VersionNumber = StorageVersion.Version_1, Version1 = y } as IDataItem).ToList(); x.MediaList.Items.ForEach(y => y.Parents.Add(x.MediaList)); return x.MediaList;
                    })
                    .Concat(Data)
                    .ToList();
        }

        /// <summary>
        /// Creates an empty media list.
        /// </summary>
        /// <returns></returns>
        public IMediaList CreateMediaList()
        {
            return new MediaList { ID = Guid.NewGuid() };
        }

        /// <summary>
        /// Creates an empty data item.
        /// </summary>
        /// <returns></returns>
        public IDataItem CreateDataItem()
        {
            return new DataItem { ID = Guid.NewGuid(), VersionNumber = StorageVersion.Version_2 };
        }
    }
}