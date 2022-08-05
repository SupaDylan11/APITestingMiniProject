using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainzMiniAPiApp.DataHandling;

public class DTO<ResponseType> where ResponseType : IResponse
{
    public ResponseType Response { get; set; }

    public void DeserialiseResponse(string dataString)
    {
        Response = JsonConvert.DeserializeObject<ResponseType>(dataString);
    }
}
