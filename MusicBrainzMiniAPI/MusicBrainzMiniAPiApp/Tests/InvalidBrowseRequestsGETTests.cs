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
        public void InValidBrowseReleaseQueryStatus_Is400Error()
        {
            Assert.That(_browseReleaseRequest.GetStatus(), Is.EqualTo(400));
        }
    }
}
