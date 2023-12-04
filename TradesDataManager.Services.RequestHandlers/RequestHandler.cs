using TradesDataManager.Contracts.Requests;
using TradesDataManager.Contracts.Responses;
using TradesDataManager.Services.Database;

namespace TradesDataManager.Services.RequestHandlers
{
    internal class RequestHandler : IRequestHandler
    {
        private readonly IStocksDatabase _stocksDatabase;

        public RequestHandler(IStocksDatabase stockDatabase)
        {
            _stocksDatabase = stockDatabase;
        }

        public async Task<StockResponse> GetStockRequestHandler(string tickerSymbol)
        {
            var result = await _stocksDatabase.GetStock(tickerSymbol);

            return new StockResponse(result.BrokerId, result.TickerSymbol, result.PriceInPounds, result.NumberOfShares);
        }

        public async Task<StocksResponse> GetStocksRequestHandler(IEnumerable<string> tickerSymbols)
        {
            var results = await _stocksDatabase.GetStocks(tickerSymbols);

            return new StocksResponse(new List<StockResponse>());
        }

        public async Task UpsertTradeRequestHandler(TradeNotificationRequest tradeNotificationRequest)
        {
            await _stocksDatabase.Upsert().ConfigureAwait(false);

            // Could have some response logic bubbled up for success and further control flow 
        }
    }
}