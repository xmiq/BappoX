﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interfaces
{
    /// <summary>
    /// Provides the framework needed for plugins to launch
    /// </summary>
    public interface IPluginLoader
    {
        List<IPlugin> Plugins { get; set; }
    }
}