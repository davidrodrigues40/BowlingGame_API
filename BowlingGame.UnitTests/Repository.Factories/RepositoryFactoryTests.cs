﻿using BowlingGame.Core.Abstractions.Repositories;
using BowlingGame.Core.Enums;
using BowlingGame.Factories;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BowlingGame.UnitTests.Repository.Factories;
[TestFixture]
[ExcludeFromCodeCoverage]
internal class RepositoryFactoryTests
{
    private readonly RepositoryFactory _factory;
    private readonly Mock<MenuRepository> _menuProvider;
    private readonly Mock<RatingRepository> _ratingProvider;

    public RepositoryFactoryTests()
    {
        _menuProvider = new Mock<MenuRepository>();
        _ratingProvider = new Mock<RatingRepository>();
        _factory = new RepositoryFactory(_menuProvider.Object, _ratingProvider.Object);
    }

    [Test]
    public void CreateMenuRepository_WhenCalled_ReturnsMenuRepository()
    {
        // Arrange
        DataSource datasource = DataSource.InMemory;
        IMenuRepository expected = Mock.Of<IMenuRepository>();
        _ = _menuProvider.Setup(x => x.Invoke(datasource)).Returns(expected);

        // Act
        IMenuRepository? actual = _factory.CreateMenuRepository(datasource);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CreateRatingRepository_WhenCalled_ReturnsRatingRepository()
    {
        // Arrange
        DataSource datasource = DataSource.InMemory;
        IRatingRepository expected = Mock.Of<IRatingRepository>();
        _ = _ratingProvider.Setup(x => x.Invoke(datasource)).Returns(expected);

        // Act
        IRatingRepository? actual = _factory.CreateRatingRepository(datasource);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
