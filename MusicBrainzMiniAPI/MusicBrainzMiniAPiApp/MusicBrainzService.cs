using MusicBrainzMiniAPiApp.DataHandling;
using MusicBrainzMiniAPiApp.HttpManager;
using Newtonsoft.Json.Linq;

namespace MusicBrainzMiniAPiApp;

public class MusicBrainzService
{
    public CallManager CallManager { get; set; }

    public JObject JSonResponse { get; set; }

    public DTO<SingleReleaseReponse> MusicBrainzDTO { get; set;}

    public string MusicResponse { get; set; }

    public MusicBrainzService()
    {
        CallManager = new CallManager();
        MusicBrainzDTO = new DTO<SingleReleaseReponse>();
    }

    public async Task MakeMusicRequestAsync(string query)
    {
        MusicResponse = await CallManager.MakeRequestAsync(query);
        JSonResponse = JObject.Parse(MusicResponse);
        MusicBrainzDTO.DeserialiseResponse(MusicResponse);
    }
}