using System.Text.Json.Serialization;

namespace TradesDataManager.Services.CosmosDb.Models
{
    internal class CosmosTradeNotification
    {
        [JsonConstructor]
        public CosmosTradeNotification(int brokerId, string tickerSymbol, int priceInPounds, decimal numberOfShares)
        {
            BrokerId = brokerId;
            TickerSymbol = tickerSymbol;
            PriceInPounds = priceInPounds;
            NumberOfShares = numberOfShares;
        }

        [JsonPropertyName("brokerId")]
        public int BrokerId { get; }

        [JsonPropertyName("tickerSymbol")]
        public string TickerSymbol { get; }

        [JsonPropertyName("priceInPounds")]
        public int PriceInPounds { get; }

        [JsonPropertyName("numberOfShares")]
        public decimal NumberOfShares { get; }
    }
}
