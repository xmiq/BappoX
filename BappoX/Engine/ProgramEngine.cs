using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// The Engine that the program uses for any calculations
    /// </summary>
    public class ProgramEngine : IEngine
    {
        /// <summary>
        /// Initialize the Engine
        /// </summary>
        /// <param name="Program">Selected Program</param>
        public ProgramEngine(string Program)
        {
            this.Program = Program;
        }

        /// <summary>
        /// The program that the Engine manages
        /// </summary>
        private string Program { get; set; }

        /// <summary>
        /// Handler of Data
        /// </summary>
        public IDataManager DataManager { get; set; }

        /// <summary>
        /// Handles all the necessary Loading
        /// </summary>
        public void Initialize()
        {
            DataManager.InitData();
        }
    }
}
