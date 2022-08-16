using System.Collections.Generic;
using System.Linq;
using BazaarOnline.Application.DTOs.Locations;
using BazaarOnline.Application.Services.Locations;
using BazaarOnline.Domain.Entities.Locations;
using BazaarOnline.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Locations;

[TestFixture]
public class LocationServiceTests
{
    private Mock<IRepository> _repositoryMock;
    private LocationService _locationService;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IRepository>();
        _locationService = new LocationService(_repositoryMock.Object);

        _repositoryMock.Setup(m => m.GetAll<City>())
            .Returns(new List<City> {
                new City {Id=1,Name="abc"},
                new City {Id=2,Name="def"},
            }.AsQueryable());

    }

    [Test]
    public void GetCitiesListDetail_NoFilters_ReturnAll()
    {
        var result = _locationService.GetCitiesListDetail(new CityFilterDTO());

        Assert.That(result.Count(), Is.EqualTo(2));
    }

    [Test]
    public void GetCitiesListDetail_FilterNameFound_ReturnFoundItem()
    {
        var result = _locationService.GetCitiesListDetail(new CityFilterDTO
        {
            Name = "a",
        });

        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().Name, Is.EqualTo("abc"));
    }

    [Test]
    public void GetCitiesListDetail_FilterNameNotFound_ReturnEmptyList()
    {
        var result = _locationService.GetCitiesListDetail(new CityFilterDTO
        {
            Name = "z",
        });

        Assert.That(result.Count(), Is.EqualTo(0));
    }

    [Test]
    public void GetCityDetail_CityFound_ReturnCityDetail()
    {
        var result = _locationService.GetCityDetail(1);

        Assert.That(result.Name, Is.EqualTo("abc"));
    }

    [Test]
    public void GetCityDetail_CityNotFound_ReturnNull()
    {
        var result = _locationService.GetCityDetail(0);

        Assert.That(result, Is.Null);
    }

}
