using MusicBrainzMiniAPiApp.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainzMiniAPiApp.Tests;
public class ValidLookupSpecificReleaseTests
{
    MBSingleReleaseService _singleReleaseService;


    [OneTimeSetUp]
    public async Task OneTimeSetupAsync()
    {
        _singleReleaseService = new MBSingleReleaseService();
        await _singleReleaseService.MakeMusicRequestAsync("1035c7d3-de41-40f9-9c7a-bac0ca7fc361");
    }

    [Test]
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsOK()
    {
        Assert.That(_singleReleaseService.GetStatus(), Is.EqualTo("OK"));
    }
    [Test]
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsExpectedTitle() 
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.title, Is.EqualTo("Good Times Bad Times / Communication Breakdown"));
    }

    [Test]
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsValidTitle()
    {
        Assert.IsInstanceOf(typeof(string), _singleReleaseService.MusicBrainzDTO.Response.title);
    }
    [Test]
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsExpectedDate()
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.date, Is.EqualTo("1969"));
    }
    [Test]
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsValidDate()
    {
        Assert.IsInstanceOf(typeof(string), _singleReleaseService.MusicBrainzDTO.Response.date);
    }
    [Test]
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsExpectedCountry()
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.country, Is.EqualTo("AU"));
    }
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsValidCountry()
    {
        Assert.IsInstanceOf(typeof(string), _singleReleaseService.MusicBrainzDTO.Response.country);
    }
    [Test]
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsExpectedCoverArt()
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.coverartarchive.front, Is.EqualTo(true));
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.coverartarchive.count, Is.EqualTo(1));
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.coverartarchive.artwork, Is.EqualTo(true));
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.coverartarchive.back, Is.EqualTo(false));
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.coverartarchive.darkened, Is.EqualTo(false));
    }
    [Test]
    public void GivenAValidSpecificRelease_LookupRequest_ReturnsValidCoverArt()
    {
        Assert.That(_singleReleaseService.MusicBrainzDTO.Response.coverartarchive, Is.Not.Null);
    }
}

