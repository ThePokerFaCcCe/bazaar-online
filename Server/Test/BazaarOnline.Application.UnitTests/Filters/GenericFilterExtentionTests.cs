using System.Collections.Generic;
using System.Linq;
using BazaarOnline.Application.Filters;
using BazaarOnline.Application.Filters.Generic.Attributes;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Filters;

[TestFixture]
public class GenericFilterExtentionTests
{
    private IQueryable<FakeModel> _query;

    [SetUp]
    public void SetUp()
    {
        _query = new List<FakeModel>
        {
            new FakeModel{
                Id=1,
                Title=new TitleC{Value="a"},
                Description="abc",
                OwnerId = 1,
                Price = 100,
            },
            new FakeModel{
                Id=2,
                Title=new TitleC{Value="x"},
                Description="xyz",
                OwnerId = 2,
                Price = 200,
            },
        }.AsQueryable();
        // _query = new List<FakeModel>
        // {
        //     new FakeModel{
        //         Id=1,
        //         Title="a",
        //         Description="abc",
        //         OwnerId = 1,
        //         Price = 100,
        //     },
        //     new FakeModel{
        //         Id=2,
        //         Title="x",
        //         Description="xyz",
        //         OwnerId = 2,
        //         Price = 200,
        //     },
        // }.AsQueryable();
    }

    [Test]
    public void FilterEquals_FilterIsCorrect_ReturnItem()
    {
        var model = _query.First();
        var filter = new FakeModelFilterDTO
        {
            Id = model.Id,
            Title = "a",
        };

        var result = _query.Filter(filter);

        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().Id, Is.EqualTo(model.Id));
    }

    [Test]
    public void FilterEquals_FilterIsNotCorrect_ReturnEmpty()
    {
        var model = _query.First();
        var filter = new FakeModelFilterDTO
        {
            Id = 0,
            Title = "model.Title",
        };

        var result = _query.Filter(filter);

        Assert.That(result.Any(), Is.False);
    }

    [Test]
    public void FilterModelContainsThis_FilterIsCorrect_ReturnItem()
    {
        var model = _query.First();
        var filter = new FakeModelFilterDTO
        {
            Description = "b",
        };

        var result = _query.Filter(filter);

        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().Id, Is.EqualTo(model.Id));
    }

    [Test]
    public void FilterModelContainsThis_FilterIsNotCorrect_ReturnEmpty()
    {
        var model = _query.First();
        var filter = new FakeModelFilterDTO
        {
            Description = "im not exist!",
        };

        var result = _query.Filter(filter);

        Assert.That(result.Any(), Is.False);
    }

    [Test]
    public void FilterThisContainsModel_FilterIsCorrect_ReturnItems()
    {
        var filter = new FakeModelFilterDTO
        {
            OwnerIds = new List<int> { 1, 2 }
        };

        var result = _query.Filter(filter);

        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result.Select(fm => fm.Id),
                    Is.EquivalentTo(_query.Select(fm => fm.Id)));
    }

    [Test]
    public void FilterThisContainsModel_FilterIsNotCorrect_ReturnEmpty()
    {
        var model = _query.First();
        var filter = new FakeModelFilterDTO
        {
            OwnerIds = new List<int> { 0 }
        };

        var result = _query.Filter(filter);

        Assert.That(result.Any(), Is.False);
    }

    [Test]
    public void FilterModelSmallerThanEqualThis_FilterIsCorrect_ReturnItems()
    {
        var filter = new FakeModelFilterDTO
        {
            EndPrice = 100
        };

        var result = _query.Filter(filter);

        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().Id, Is.EqualTo(1));
    }

    [Test]
    public void FilterModelSmallerThanEqualThis_FilterIsNotCorrect_ReturnEmpty()
    {
        var filter = new FakeModelFilterDTO
        {
            EndPrice = 99
        };

        var result = _query.Filter(filter);

        Assert.That(result.Any(), Is.False);
    }

    [Test]
    public void FilterModelGreaterThanEqualThis_FilterIsCorrect_ReturnItems()
    {
        var filter = new FakeModelFilterDTO
        {
            StartPrice = 200
        };

        var result = _query.Filter(filter);

        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().Id, Is.EqualTo(2));
    }

    [Test]
    public void FilterModelGreaterThanEqualThis_FilterIsNotCorrect_ReturnEmpty()
    {
        var filter = new FakeModelFilterDTO
        {
            StartPrice = 201
        };

        var result = _query.Filter(filter);

        Assert.That(result.Any(), Is.False);
    }

}

public class FakeModel
{
    public int Id { get; set; }

    public TitleC Title { get; set; }

    public string Description { get; set; }

    public int OwnerId { get; set; }

    public int Price { get; set; }
}

public class FakeModelFilterDTO
{
    [Filter(FilterTypeEnum.Equals)]
    public int? Id { get; set; }

    [Filter(FilterTypeEnum.Equals, ModelPropertyName = "Title.Value")]
    public string? Title { get; set; }

    [Filter(FilterTypeEnum.ModelContainsThis)]
    public string? Description { get; set; }

    [Filter(FilterTypeEnum.ThisContainsModel, ModelPropertyName = nameof(FakeModel.OwnerId))]
    public List<int>? OwnerIds { get; set; }

    [Filter(FilterTypeEnum.ModelGreaterThanEqualThis, ModelPropertyName = nameof(FakeModel.Price))]
    public int? StartPrice { get; set; }

    [Filter(FilterTypeEnum.ModelSmallerThanEqualThis, ModelPropertyName = nameof(FakeModel.Price))]
    public int? EndPrice { get; set; }
}
public class TitleC
{
    public string Value { get; set; }
}

/*
[Filter(fte.NestedFilter)]
prop AdvPrice price{g;s;}
*/
