using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainzMiniAPiApp.HttpManager;

public class CallManager
{
    private readonly RestClient _client;

    public RestResponse Response { get; set; }

    public CallManager()
    {
        _client = new RestClient(AppConfigReader.BaseUrl);
    }

    public async Task<string> MakeRequestAsync(string query)
    {
        var request = new RestRequest();
        request.AddHeader("Content-Type", "application/json");
        request.Resource = $"release/{query}?fmt=json";
        Response = await _client.ExecuteAsync(request);
        return Response.Content;
    }
}
