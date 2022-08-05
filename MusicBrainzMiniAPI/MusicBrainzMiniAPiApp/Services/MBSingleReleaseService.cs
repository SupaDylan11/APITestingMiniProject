using MusicBrainzMiniAPiApp.DataHandling;
using MusicBrainzMiniAPiApp.HttpManager;
using Newtonsoft.Json.Linq;

namespace MusicBrainzMiniAPiApp.Services;

public class MBSingleReleaseService
{
    public CallManager CallManager { get; set; }

    public JObject JSonResponse { get; set; }

    public DTO<SingleReleaseReponse> MusicBrainzDTO { get; set; }

    public string MusicResponse { get; set; }

    public MBSingleReleaseService()
    {
        CallManager = new CallManager();
        MusicBrainzDTO = new DTO<SingleReleaseReponse>();
    }

    public async Task MakeMusicRequestAsync(ResourceType resource, string query)
    {
        MusicResponse = await CallManager.MakeRequestAsync(ResourceType.LOOKUP, query);
        JSonResponse = JObject.Parse(MusicResponse);
        MusicBrainzDTO.DeserialiseResponse(MusicResponse);
    }

    public string GetTitle()
    {
        return (string)JSonResponse["title"];
    }
    public int GetStatus() 
    {
        return (int)CallManager.Response.StatusCode;
    }
}