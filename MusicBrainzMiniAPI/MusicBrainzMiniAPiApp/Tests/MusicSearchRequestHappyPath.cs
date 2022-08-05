using MusicBrainzMiniAPiApp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainzMiniAPiApp.Tests;

public class MusicSearchRequestHappyPathTests
{
    MBQueryService _singleReleaseService;

    [OneTimeSetUp]
    public async Task OneTimeSetupAsync()
    {
        _singleReleaseService = new MBQueryService();
        await _singleReleaseService.MakeMusicRequestAsync("artist?query=Nirvana");
    }

    [Test]
    public void GivenValidBasicSearchQueryStatus_Is200()
    {
        Assert.That(_singleReleaseService.GetStatus, Is.EqualTo(200));
    }

    [Test]
    public void GivenValidSearchQuery_Name_ReturnsExpectedArtistName()
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.artists[0].name, Is.EqualTo("Nirvana"));
    }

    [Test]
    public void GivenValidSearchQuery_Country_ReturnsExpectedArtistCountryOfOrigin()
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.artists[0].country, Is.EqualTo("US"));
    }

    [Test]
    public void GivenValidSearchQuery_Group_ReturnsExpectedArtistGroupType()
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.artists[0].disambiguation, Is.EqualTo("90s US grunge band"));
    }
}
