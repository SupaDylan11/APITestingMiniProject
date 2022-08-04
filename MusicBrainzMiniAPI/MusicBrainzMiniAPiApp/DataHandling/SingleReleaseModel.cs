using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainzMiniAPiApp.DataHandling;


public class SingleReleaseReponse : IResponse
{
    public string id { get; set; }
    public string date { get; set; }
    public object packagingid { get; set; }
    public ReleaseEvents[] releaseevents { get; set; }
    public string barcode { get; set; }
    public object asin { get; set; }
    public object packaging { get; set; }
    public string title { get; set; }
    public TextRepresentation textrepresentation { get; set; }
    public string disambiguation { get; set; }
    public string country { get; set; }
    public string statusid { get; set; }
    public CoverArtArchive coverartarchive { get; set; }
    public string status { get; set; }
    public string quality { get; set; }
}

public class TextRepresentation
{
    public string script { get; set; }
    public string language { get; set; }
}

public class CoverArtArchive
{
    public bool back { get; set; }
    public bool artwork { get; set; }
    public int count { get; set; }
    public bool front { get; set; }
    public bool darkened { get; set; }
}

public class ReleaseEvents
{
    public string date { get; set; }
    public Area area { get; set; }
}

public class Area
{
    public string id { get; set; }
    public string name { get; set; }
    public string disambiguation { get; set; }
    public string[] iso31661codes { get; set; }
    public object type { get; set; }
    public object typeid { get; set; }
    public string sortname { get; set; }
}
