using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainzMiniAPiApp.HttpManager;

public enum ResourceType { LOOKUP, BROWSE, SEARCH };

public class CallManager
{
    private readonly RestClient _client;

    public RestResponse Response { get; set; }

    public CallManager()
    {
        _client = new RestClient(AppConfigReader.BaseUrl);
    }

    public async Task<string> MakeRequestAsync(ResourceType resource, string query)
    {
        var request = new RestRequest();
        request.AddHeader("Content-Type", "application/json");
        switch (resource)
        {
            case (ResourceType.LOOKUP):
                request.Resource = $"release/{query}?fmt=json";
                break;
            case (ResourceType.SEARCH):
                request.Resource = $"{query}&fmt=json";
                break;
            case (ResourceType.BROWSE):
                request.Resource = $"release?artist={query}&fmt=json";
                break;
            default:
                throw new ArgumentException();
        }
        Response = await _client.ExecuteAsync(request);
        return Response.Content;
    }
}
