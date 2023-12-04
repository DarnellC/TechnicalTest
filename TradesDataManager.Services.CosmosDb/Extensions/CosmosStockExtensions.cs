using TradesDataManager.Models;
using TradesDataManager.Services.CosmosDb.Models;

namespace TradesDataManager.Services.CosmosDb.Extensions
{
    internal static class CosmosStockExtensions
    {
        // As it stands, this would have to be tested as it's the only non-Azure related 'logic' that is referenced in the Database layer.
        public static Stock Map(this CosmosStock cosmosStock)
        {
            return new Stock(cosmosStock.BrokerId,
                cosmosStock.TickerSymbol,
                cosmosStock.PriceInPounds,
                cosmosStock.NumberOfShares);
        }
    }
}
