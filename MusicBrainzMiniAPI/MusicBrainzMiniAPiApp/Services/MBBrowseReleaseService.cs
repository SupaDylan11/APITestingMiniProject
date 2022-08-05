using MusicBrainzMiniAPiApp.DataHandling;
using MusicBrainzMiniAPiApp.HttpManager;
using Newtonsoft.Json.Linq;

namespace MusicBrainzMiniAPiApp.Services
{
    public class MBBrowseReleaseService
    {
        public CallManager CallManager { get; set; }
        public JObject JSonResponse { get; set; }
        public DTO<Rootobject> ArtistReleasesDTO { get; set; }
        public string BrowseResponse { get; set; }

        public MBBrowseReleaseService()
        {
            CallManager = new CallManager();
            ArtistReleasesDTO = new DTO<Rootobject>();
        }

        public async Task MakeMusicRequestAsync(string query)
        {
            BrowseResponse = await CallManager.MakeRequestAsync(ResourceType.BROWSE, query);
            JSonResponse = JObject.Parse(BrowseResponse);
            ArtistReleasesDTO.DeserialiseResponse(BrowseResponse);
        }

        public string GetSpecifiedSong(int index)
        {
            return (string)JSonResponse["title"][index];
        }
    }
}
