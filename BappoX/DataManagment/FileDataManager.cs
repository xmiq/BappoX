using DataManagment.Models;
using Interface.Interfaces;
using Interface.Interfaces.Data;
using Newtonsoft.Json;
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
        /// <param name="path">The path of data.</param>
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
        /// Saves the Data to the data source.
        /// </summary>
        public void SaveData()
        {
            SaveData("items");
        }

        /// <summary>
        /// Saves the Data to the data source.
        /// </summary>
        /// <param name="path">The path of the data.</param>
        public void SaveData(string path)
        {
            var mediaList = JsonConvert.SerializeObject(Data.Select(x => new { x.ID, x.Name, Items = x.Items.Select(y => y.ID) }));
            var itemList = JsonConvert.SerializeObject(Data.Select(x => x.Items).SelectMany(x => x).GroupBy(x => x.ID).Select(x => x.FirstOrDefault()).Select(x => new { x.ID, x.VersionNumber, x.Data }));
            foreach (var fi in Directory.EnumerateFiles(path).Select(x => new FileInfo(x)).Where(x => x.Extension == ".txt"))
                fi.Delete();
            if (File.Exists(path + Path.DirectorySeparatorChar + "media.json.bak"))
                File.Delete(path + Path.DirectorySeparatorChar + "media.json.bak");
            if (File.Exists(path + Path.DirectorySeparatorChar + "media.json"))
                File.Move(path + Path.DirectorySeparatorChar + "media.json", path + Path.DirectorySeparatorChar + "media.json.bak");
            if (File.Exists(path + Path.DirectorySeparatorChar + "items.json.bak"))
                File.Delete(path + Path.DirectorySeparatorChar + "items.json.bak");
            if (File.Exists(path + Path.DirectorySeparatorChar + "items.json"))
                File.Move(path + Path.DirectorySeparatorChar + "items.json", path + Path.DirectorySeparatorChar + "items.json.bak");
            File.WriteAllText(path + Path.DirectorySeparatorChar + "media.json", mediaList);
            File.WriteAllText(path + Path.DirectorySeparatorChar + "items.json", itemList);
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