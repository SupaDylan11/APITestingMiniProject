using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainzMiniAPiApp.Tests;

public class BasicTests
{
    MusicBrainzService _singleReleaseService;

    [OneTimeSetUp]
    public async Task OneTimeSetupAsync()
    {
        _singleReleaseService = new MusicBrainzService();
        await _singleReleaseService.MakeMusicRequestAsync("1035c7d3-de41-40f9-9c7a-bac0ca7fc361");
    }

    [Test]
    public void ValidBasicQueryStatus_Is200()
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.status, Is.EqualTo(200));
    }

}
