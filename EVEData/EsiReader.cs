using Microsoft.Extensions.Options;
using ESI.NET;
using ESI.NET.Models;
using ESI.NET.Enumerations;

namespace EVEData
{
    public sealed class ESIReader
    {
        private static ESIReader? instance = null;
        private static readonly object padlock = new object();

        private EsiClient _client;

        ESIReader()
        {

            IOptions<EsiConfig> config = Options.Create(new EsiConfig()
            {
                EsiUrl = "https://esi.evetech.net/",
                DataSource = DataSource.Tranquility,
                ClientId = EveAppConfig.ClientID,
                SecretKey = EveAppConfig.SecretKey,
                CallbackUrl = EveAppConfig.CallbackURL,
                UserAgent = "SMTx",
            });

            this._client = new ESI.NET.EsiClient(config);
        }

        /// <summary>
        /// This Method tries to get all the server data from ESI
        /// </summary>
        public async Task<ESIData.Status> getStatus()
        {
            ESIData.Status status = new ESIData.Status();
            ESI.NET.EsiResponse<ESI.NET.Models.Status.Status> esr = await this._client.Status.Retrieve();
            if (ESIHelpers.ValidateESICall<ESI.NET.Models.Status.Status>(esr))
            {
                status.players = esr.Data.Players;
                status.server_version = esr.Data.ServerVersion;
                status.start_time = esr.Data.StartTime;
                status.vip = esr.Data.VIP;
            }
            return (status);
        }

        /// <summary>
        /// Singleton Logic
        /// </summary>
        public static ESIReader Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ESIReader();
                    }
                    return instance;
                }
            }
        }
    }
}