using System.Collections.Generic;
using BazaarOnline.API.Controllers.Locations;
using BazaarOnline.Application.DTOs.Locations;
using BazaarOnline.Application.Interfaces.Locations;
using BazaarOnline.Application.ViewModels.Locations;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace BazaarOnline.API.UnitTests.Controllers.Locations;

[TestFixture]
public class LocationsControllerTests
{
    private Mock<ILocationService> _locationServiceMock;
    private LocationsController _controller;

    [SetUp]
    public void SetUp()
    {
        _locationServiceMock = new Mock<ILocationService>();
        _controller = new LocationsController(_locationServiceMock.Object);
    }

    [Test]
    public void GetCitiesList_WhenCalled_CallGetCitiesListDetail()
    {
        _controller.GetCitiesList(new CityFilterDTO());

        _locationServiceMock.Verify(m =>
            m.GetCitiesListDetail(It.IsAny<CityFilterDTO>()));
    }


    [Test]
    public void GetCitiesList_WhenCalled_ReturnListCityListDetailViewModel()
    {
        var result = _controller.GetCitiesList(new CityFilterDTO());

        Assert.That(result, Is.TypeOf<ActionResult<List<CityListDetailViewModel>>>());
    }

    [Test]
    public void GetCityDetail_CityFound_ReturnListCityDetailViewModel()
    {
        _locationServiceMock.Setup(m => m.GetCityDetail(1))
            .Returns(new CityDetailViewModel());

        var result = _controller.GetCityDetail(1);

        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.TypeOf<ActionResult<CityDetailViewModel>>());
    }


    [Test]
    public void GetCityDetail_CityNotFound_ReturnNotFound()
    {
        _locationServiceMock.Setup(m => m.GetCityDetail(1))
            .Returns(value: null);

        var result = _controller.GetCityDetail(1);

        Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
    }




}
