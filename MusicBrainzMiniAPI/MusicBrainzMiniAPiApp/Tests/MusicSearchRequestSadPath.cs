using MusicBrainzMiniAPiApp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainzMiniAPiApp.Tests;

public class MusicSearchRequestSadPathTests
{
    MBQueryService _singleReleaseSearchService;

    [OneTimeSetUp]
    public async Task OneTimeSetupAsync()
    {
        _singleReleaseSearchService = new MBQueryService();
        await _singleReleaseSearchService.MakeMusicRequestAsync("artist?query=fghfgh54a0ghj");
    }

    //[Test]
    //public void GivenThatInvalidInputForTheQuery_CountReturnsZero()
    //{
    //    Assert.That(_singleReleaseSearchService.GetStatus(), Is.EqualTo(400));
    //}

    [Test]
    public void GivenThatInvalidInputForTheQuery_CountReturnsZero()
    {
        Assert.That(_singleReleaseSearchService.MusicBrainzDTO.Response.count, Is.EqualTo(0));
    }
}

