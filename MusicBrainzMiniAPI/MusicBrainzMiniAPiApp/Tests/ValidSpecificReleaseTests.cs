using MusicBrainzMiniAPiApp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainzMiniAPiApp.Tests;
public class ValidSpecificReleaseTests
{
    MusicBrainzService _singleReleaseService;
    [OneTimeSetUp]
    public async Task OneTimeSetupAsync()
    {
        _singleReleaseService = new MusicBrainzService();
        await _singleReleaseService.MakeMusicRequestAsync("1035c7d3-de41-40f9-9c7a-bac0ca7fc361");
    }

    [Test]
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsExpectedTitle() 
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.title, Is.EqualTo("Good Times Bad Times / Communication Breakdown"));
    }
    [Test]
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsExpectedDate()
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.date, Is.EqualTo("1969"));
    }
    [Test]
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsExpectedCountry()
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.country, Is.EqualTo("AU"));
    }
    [Test]
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsCoverArt()
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.coverartarchive, Is.Not.Null);
    }
}

