using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// EVE Server status
/// </summary>
namespace EVEData.ESIData
{
    internal class Status
    {
        /// <summary>
        /// Current online player count
        /// </summary>
        public int players;

        /// <summary>
        /// Running version as string
        /// </summary>
        public string server_version;

        /// <summary>
        /// Server start timestamp
        /// </summary>
        public string start_time;

        /// <summary>
        /// If the server is in VIP mode
        /// </summary>
        public bool vip;
    }
}
