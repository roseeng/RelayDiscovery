using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RelayDiscovery
{
    public class RelaysResult
    {
        [JsonPropertyName("relays")]
        public IEnumerable<Relay> Relays { get; set; }
    }

    public class Relay
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }

        [JsonPropertyName("statsRetrieved")]
        public string StatsRetrieved { get; set; }
    }

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Location
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("continent")]
        public string Continent { get; set; }
    }

    public class Options
    {
        [JsonPropertyName("network-timeout")]
        public int NetworkTimeout { get; set; }

        [JsonPropertyName("ping-interval")]
        public int PingInterval { get; set; }

        [JsonPropertyName("message-timeout")]
        public int MessageTimeout { get; set; }

        [JsonPropertyName("per-session-rate")]
        public int PerSessionRate { get; set; }

        [JsonPropertyName("global-rate")]
        public int GlobalRate { get; set; }

        [JsonPropertyName("pools")]
        public List<string> Pools { get; set; }

        [JsonPropertyName("provided-by")]
        public string ProvidedBy { get; set; }
    }

    public class Stats
    {
        [JsonPropertyName("startTime")]
        public string StartTime { get; set; }

        [JsonPropertyName("uptimeSeconds")]
        public int UptimeSeconds { get; set; }

        [JsonPropertyName("numPendingSessionKeys")]
        public int NumPendingSessionKeys { get; set; }

        [JsonPropertyName("numActiveSessions")]
        public int NumActiveSessions { get; set; }

        [JsonPropertyName("numConnections")]
        public int NumConnections { get; set; }

        [JsonPropertyName("numProxies")]
        public int NumProxies { get; set; }

        [JsonPropertyName("bytesProxied")]
        public long BytesProxied { get; set; }

        [JsonPropertyName("goVersion")]
        public string GoVersion { get; set; }

        [JsonPropertyName("goOS")]
        public string GoOS { get; set; }

        [JsonPropertyName("goArch")]
        public string GoArch { get; set; }

        [JsonPropertyName("goMaxProcs")]
        public int GoMaxProcs { get; set; }

        [JsonPropertyName("goNumRoutine")]
        public int GoNumRoutine { get; set; }

        [JsonPropertyName("kbps10s1m5m15m30m60m")]
        public List<int> Kbps10s1m5m15m30m60m { get; set; }

        [JsonPropertyName("options")]
        public Options Options { get; set; }
    }
}
