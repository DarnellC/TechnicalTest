using TradesDataManager.Contracts.Requests;
using TradesDataManager.Contracts.Responses;

namespace TradesDataManager.Services.RequestHandlers
{
    public interface IRequestHandler
    {
        Task<StockResponse> GetStockRequestHandler(string tickerSymbol);

        Task<StocksResponse> GetStocksRequestHandler(IEnumerable<string> tickerSymbolsFilter);

        Task UpsertTradeRequestHandler(TradeNotificationRequest tradeNotificationRequest);
    }
}
