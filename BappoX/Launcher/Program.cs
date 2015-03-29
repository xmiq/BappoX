using Interface.Interfaces;
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
            string Loader = System.IO.File.ReadAllLines("settings.ini")
                .Select(x => x.Split(':'))
                .Where(x => x[0] == "Loader")
                .FirstOrDefault()[1];
            Application.Run(GetAssembly<ILoader>(Loader, "Media Organizer").Initialize());
        }

        /// <summary>
        /// Loads an assembly
        /// </summary>
        /// <param name="path">Path to Assembly</param>
        /// <param name="parameter">Parameter for assembly instance</param>
        /// <returns>The Assembly</returns>
        private static T GetAssembly<T>(string path, string parameter)
        {
            return Assembly
                .Load(AssemblyName.GetAssemblyName(path))
                .GetTypes()
                .Where(x => typeof(T).IsAssignableFrom(x))
                .Select(x => (T)Activator.CreateInstance(x, parameter))
                .FirstOrDefault();
        }
    }
}
