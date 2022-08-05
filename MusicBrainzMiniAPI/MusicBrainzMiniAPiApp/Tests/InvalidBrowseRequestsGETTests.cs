using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicBrainzMiniAPiApp.Services;
using NUnit.Framework;

namespace MusicBrainzMiniAPiApp.Tests
{
    [Category("Sad Paths")]
    public class InvalidBrowseRequestsGETTests
    {
        MBBrowseReleaseService _browseReleaseRequest;

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _browseReleaseRequest = new MBBrowseReleaseService();
            await _browseReleaseRequest.MakeMusicRequestAsync("WindowsXPBestSystem");
        }

        [Test]
        public void GivenInvalidArtistGivenOnSETUP_ReturnEmptyArray()
        {
            Assert.That(_browseReleaseRequest.ArtistReleasesDTO.Response.releases, Is.Null);
        }
    }
}
