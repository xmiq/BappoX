using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Dictionary<string, string> settings = System.IO.File.ReadAllLines("settings.ini")
                .Select(x => x.Split(':'))
                .ToDictionary(x => x[0], x => x[1]);
            Application.Run(GetAssembly<ILoader>(settings["Loader"], "Media Organizer").Initialize());
            //Application.Run(new PluginManager.Loader("Media Organizer").Initialize());
        }

        /// <summary>
        /// Loads an assembly
        /// </summary>
        /// <param name="path">Path to Assembly</param>
        /// <param name="parameter">Parameter for assembly instance</param>
        /// <returns>The Assembly</returns>
        private static T GetAssembly<T>(string path, string parameter)
        {
            AssemblyName an = AssemblyName.GetAssemblyName(path);
            Assembly assm = Assembly.Load(an);
            var v = assm.GetTypes().Where(x => typeof(T).IsAssignableFrom(x));
            if (v.Any()) return (T)Activator.CreateInstance(v.FirstOrDefault(), parameter);
            else return default(T);
        }
    }
}
