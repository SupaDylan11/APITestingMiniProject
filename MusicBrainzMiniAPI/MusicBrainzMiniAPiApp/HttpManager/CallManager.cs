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

    public async Task<string> MakeRequestAsync()
    {

    }

}
