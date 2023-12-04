using System.Text.Json.Serialization;

namespace TradesDataManager.Contracts.Responses
{
    public class StocksResponse
    {
        [JsonConstructor]
        public StocksResponse(List<StockResponse> stocks)
        {
            Stocks = stocks;
        }

        [JsonPropertyName("stocks")]
        public List<StockResponse> Stocks { get; }
    }
}
