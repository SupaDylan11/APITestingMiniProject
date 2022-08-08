using MusicBrainzMiniAPiApp.DataHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MusicBrainzMiniAPiApp.Services
{

    public class Rootobject : IResponse
    {
        public Release[] releases { get; set; }
        public int releasecount { get; set; }
        public int releaseoffset { get; set; }
    }

    public class Release
    {
        public string packagingid { get; set; }
        public string date { get; set; }
        public string barcode { get; set; }
        public ReleaseEvents[] releaseevents { get; set; }
        public string id { get; set; }
        public string statusid { get; set; }
        public string quality { get; set; }
        public string status { get; set; }
        public CoverArtArchive coverartarchive { get; set; }
        public TextRepresentation textrepresentation { get; set; }
        public string disambiguation { get; set; }
        public string country { get; set; }
        public string title { get; set; }
        public string packaging { get; set; }
        public object asin { get; set; }
    }

    /*public class CoverArtArchive
    {
        public bool darkened { get; set; }
        public bool front { get; set; }
        public int count { get; set; }
        public bool artwork { get; set; }
        public bool back { get; set; }
    }

    public class TextRepresentation
    {
        public string script { get; set; }
        public string language { get; set; }
    }*/

    /*public class ReleaseEvents
    {
        public Area area { get; set; }
        public string date { get; set; }
    }*/

    /*public class Area
    {
        public string id { get; set; }
        public string name { get; set; }
        public object type { get; set; }
        public string disambiguation { get; set; }
        public string[] iso31661codes { get; set; }
        public object typeid { get; set; }
        public string sortname { get; set; }
    }*/
}

