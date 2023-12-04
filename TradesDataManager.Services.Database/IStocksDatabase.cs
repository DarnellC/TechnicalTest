using TradesDataManager.Models;

namespace TradesDataManager.Services.Database
{
    // This interface could be a cosmos specific interface. This would allow separation of the database DTO mapping to the business logic DTO. For more testability.
    // The justification for a generic one, is "if we change down the line" the rest of the code base does not need to amend their implementations as they have subscribed to this generic contract.
    // As long as the Cosmos DTO mapping extension has a unit tested in isolation it's acceptable.
    // A counter proposal is to create a cosmos specific contract and further wrap it such that the rest of the system is still abstracted away from the concrete implementation.
    public interface IStocksDatabase
    {
        Task<Stock> GetStock(string tickerSymbol);

        Task<Stocks> GetStocks(IEnumerable<string> tickerSymbols);

        // Upsert is here as opposed to distinct Create and Update methods. This is to mitigate round trips to the database and preserve cosmos RUs
        // as the throughput for this API should be high during trading times.
        Task Upsert();
    }
}