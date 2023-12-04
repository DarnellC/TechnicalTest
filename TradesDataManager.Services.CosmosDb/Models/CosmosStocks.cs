using System.Text.Json.Serialization;

namespace TradesDataManager.Services.CosmosDb.Models
{
    internal class CosmosStocks
    {
        [JsonConstructor]
        public CosmosStocks(List<CosmosStock> stocks)
        {
            Stocks = stocks;
        }

        [JsonPropertyName("stocks")]
        public List<CosmosStock> Stocks { get; }
    }
}
