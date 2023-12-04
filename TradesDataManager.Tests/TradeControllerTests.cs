using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TradesDataManager.Contracts.Responses;
using TradesDataManager.Controllers;
using TradesDataManager.Services.RequestHandlers;

namespace TradesDataManager.Tests
{
    [TestClass]
    public class TradeControllerTests
    {
        private IRequestHandler fakeRequestHandler;

        private TradeController sut;

        [TestInitialize]
        public void Initialise()
        {
            fakeRequestHandler = A.Fake<IRequestHandler>();
            var fakeLogger = A.Fake<ILogger<TradeController>>();

            sut = new TradeController(fakeRequestHandler, fakeLogger);
        }

        [DataTestMethod]
        [DataRow(1, "GOOG", 50)]
        [DataRow(2, "AMZN", 100)]
        [DataRow(3, "AMD", 150)]
        public async Task GetStockAsyncReturnsOk(int brokerId, string tickerSymbol, int priceInPound)
        {
            // ARRANGE
            var expectedStock = new StockResponse(brokerId, tickerSymbol, priceInPound, 200);

            A.CallTo(() => fakeRequestHandler.GetStockRequestHandler(tickerSymbol)).Returns(expectedStock);

            // ACT
            var result = await sut.GetStock(tickerSymbol).ConfigureAwait(false);

            // ASSERT

            var okResult = result as OkObjectResult;

            var actualStock = okResult.Value as StockResponse;

            actualStock.Should().BeEquivalentTo(expectedStock);
        }

        [TestMethod]
        public async Task GetStockAsyncReturnsBadRequest()
        {
            // ARRANGE
            var tickerSymbol = string.Empty;

            // ACT
            var result = await sut.GetStock(tickerSymbol).ConfigureAwait(false);

            // ASSERT
            result.Should().BeOfType<BadRequestObjectResult>();

            A.CallTo(() => fakeRequestHandler.GetStockRequestHandler(A<string>._)).MustNotHaveHappened();
        }
    }
}