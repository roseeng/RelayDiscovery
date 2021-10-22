using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;


namespace RelayDiscovery.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RelaysController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public IEnumerable<Relay> Get()
        {
            return GetRelays().ConfigureAwait(false).GetAwaiter().GetResult();
            /*
            return new RelayDTO[] { 
                new RelayDTO() { 
                    Location = new Location() { City = "Stockholm", Continent = "EU", Country="Sweden" },
                    Url = "https:" + "//relays.syncthing.net//120.29.217.52:443/?id=GJWNUPC-JEQFN6Q-3GTINBB-LC437KR-L3G4IXB-WD6ESGL-W4MXW6I-ISIT5A3"
                } 
            }; */
        }

        private static async Task<IEnumerable<Relay>> GetRelays()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Relay filter");

            var stringData = await client.GetStringAsync("https://relays.syncthing.net/endpoint");
            var result = JsonSerializer.Deserialize<GetRelayResult>(stringData);
            //return result.Relays;

            // Filter & Sort
//            var filteredResult = result.Relays.Where(r => r.Location?.Continent == "EU" && PortFromUrl(r.Url) == 443).OrderByDescending(r => r.Stats?.UptimeSeconds).ToList();
            var filteredResult = result.Relays.Where(r => r.Location?.Continent == "EU" && PortFromUrl(r.Url) == 443).OrderByDescending(r => r.Stats?.Kbps10s1m5m15m30m60m.Last()).ToList();

            return filteredResult;
        }

        private static int PortFromUrl(string url)
        {
            var uri = new Uri(url);
            return uri.Port;
        }
    }
}
