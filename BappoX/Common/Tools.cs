using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Tools
    {
        private static Dictionary<string, string> _Settings;

        /// <summary>
        /// Loads an assembly
        /// </summary>
        /// <param name="path">Path to Assembly</param>
        /// <returns>The Assembly</returns>
        public static T GetAssembly<T>(string path)
        {
            return Assembly
                .Load(AssemblyName.GetAssemblyName(path))
                .GetTypes()
                .Where(x => typeof(T).IsAssignableFrom(x))
                .Select(x => (T)Activator.CreateInstance(x))
                .FirstOrDefault();
        }

        /// <summary>
        /// Loads an assembly
        /// </summary>
        /// <param name="path">Path to Assembly</param>
        /// <param name="parameter">Parameter for assembly instance</param>
        /// <returns>The Assembly</returns>
        public static T GetAssembly<T>(string path, string parameter)
        {
            return Assembly
                .Load(AssemblyName.GetAssemblyName(path))
                .GetTypes()
                .Where(x => typeof(T).IsAssignableFrom(x))
                .Select(x => (T)Activator.CreateInstance(x, parameter))
                .FirstOrDefault();
        }

        /// <summary>
        /// Loads the assembly.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Path to Assembly.</param>
        /// <param name="parameters">The parameters for assembly instance.</param>
        /// <returns>The Assembly</returns>
        public static T GetAssembly<T>(string path, params object[] parameters)
        {
            return Assembly
                .Load(AssemblyName.GetAssemblyName(path))
                .GetTypes()
                .Where(x => typeof(T).IsAssignableFrom(x))
                .Select(x => (T)Activator.CreateInstance(x, parameters))
                .FirstOrDefault();
        }

        /// <summary>
        /// Retrieves the value from the Settings according the specified key.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <returns>The DLL to be loaded from the settings</returns>
        public static string Settings(string Key)
        {
            if (_Settings == null)
                _Settings = File
                    .ReadLines("settings.ini")
                    .Select(x => x.Split(':'))
                    .ToDictionary(x => x[0], x => x[1]);
            if (_Settings.ContainsKey(Key))
                return _Settings[Key];
            else
                //TODO: returns default value if there isn't anything
                return null;
        }
    }
}