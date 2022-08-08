using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicBrainzMiniAPiApp.Services;
using NUnit.Framework;

namespace MusicBrainzMiniAPiApp.Tests
{
    [Category("HappyPaths")]
    public class ValidBrowseReleaseGETTests
    {
        MBBrowseReleaseService _browseReleaseRequest;

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _browseReleaseRequest = new MBBrowseReleaseService();
            await _browseReleaseRequest.MakeMusicRequestAsync("678d88b2-87b0-403b-b63d-5da7465aecc3");
        }

        [Test]
        public void ValidBrowseReleaseQueryStatus_Is200()
        {
            Assert.That(_browseReleaseRequest.GetStatus(), Is.EqualTo(200));
        }

        [Test]
        public void GivenArtistGivenOnSETUP_ReturnArrayOf25Releases()
        {
            Assert.That(_browseReleaseRequest.ArtistReleasesDTO.Response.releases.Count, Is.EqualTo(25));
        }


    }
}
