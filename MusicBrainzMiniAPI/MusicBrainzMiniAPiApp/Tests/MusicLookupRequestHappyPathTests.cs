using MusicBrainzMiniAPiApp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainzMiniAPiApp.Tests;

public class MusicLookupRequestHappyPathTests
{
    MBSingleReleaseService _singleReleaseService;

    [OneTimeSetUp]
    public async Task OneTimeSetupAsync()
    {
        _singleReleaseService = new MBSingleReleaseService();
        await _singleReleaseService.MakeMusicRequestAsync("1035c7d3-de41-40f9-9c7a-bac0ca7fc361");
    }

    [Test]
    public void ValidBasicQueryStatus_Is200()
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.status, Is.Not.Null);
    }

    [Test]
    public void ValidBasicQuery_GetTitle_ReturnsExpectedTitle()
    {
        Assert.That(_singleReleaseService.GetTitle(), Is.EqualTo("Good Times Bad Times / Communication Breakdown"));
    }

    [Test]
    public void ValidBasicQuery_GetTitleViaJSON_ReturnExpectedTtile()
    {
        Assert.That((string)_singleReleaseService.JSonResponse["title"], Is.EqualTo("Good Times Bad Times / Communication Breakdown"));
    }

    //return (string) JSonResponse["result"]["title"];
}
