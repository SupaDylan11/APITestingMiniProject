using MusicBrainzMiniAPiApp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainzMiniAPiApp.Tests;

public class InvalidLookupSpecificReleaseTests
{
    MBSingleReleaseService _singleReleaseService;


    [OneTimeSetUp]
    public async Task OneTimeSetupAsync()
    {
        _singleReleaseService = new MBSingleReleaseService();
        await _singleReleaseService.MakeMusicRequestAsync("ayyy");
    }

    [Test]
    public void GivenAnInvalidSpecificRelease_LookupRequest_Returns400()
    {
        Assert.That(_singleReleaseService.GetStatus(), Is.EqualTo(400));
    }
}
