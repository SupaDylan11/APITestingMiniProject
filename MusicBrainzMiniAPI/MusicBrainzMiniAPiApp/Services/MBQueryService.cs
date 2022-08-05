using MusicBrainzMiniAPiApp.DataHandling;
using MusicBrainzMiniAPiApp.HttpManager;
using Newtonsoft.Json.Linq;

namespace MusicBrainzMiniAPiApp.Services;

public class MBQueryService
{
    public CallManager CallManager { get; set; }

    public JObject JSonResponse { get; set; }

    public DTO<QueryResponse> MusicBrainzDTO { get; set; }

    public string MusicResponse { get; set; }

    public MBQueryService()
    {
        CallManager = new CallManager();
        MusicBrainzDTO = new DTO<QueryResponse>();
    }

    public async Task MakeMusicRequestAsync(string query)
    {
        MusicResponse = await CallManager.MakeRequestAsync(ResourceType.SEARCH, query);
        JSonResponse = JObject.Parse(MusicResponse);
        MusicBrainzDTO.DeserialiseResponse(MusicResponse);
    }

    public int GetStatus()
    {
        return (int)CallManager.Response.StatusCode;
    }
}