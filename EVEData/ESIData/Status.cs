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
    public class Status
    {
        /// <summary>
        /// Current online player count
        /// </summary>
        public int players { get; set; }

        /// <summary>
        /// Running version as string
        /// </summary>
        public string? server_version { get; set; }

        /// <summary>
        /// Server start timestamp
        /// </summary>
        public DateTime? start_time { get; set; }

        /// <summary>
        /// If the server is in VIP mode
        /// </summary>
        public bool vip { get; set; }
    }
}
