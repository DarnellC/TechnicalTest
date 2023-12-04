using System.Text.Json.Serialization;

namespace TradesDataManager.Contracts.Requests
{
    public class TradeNotificationRequest
    {
        [JsonConstructor]
        public TradeNotificationRequest(int brokerId, string tickerSymbol, int priceInPounds, decimal numberOfShares)
        {
            BrokerId = brokerId;
            TickerSymbol = tickerSymbol;
            PriceInPounds = priceInPounds;
            NumberOfShares = numberOfShares;
        }

        [JsonPropertyName("brokerId")]
        public int BrokerId { get; set; }

        [JsonPropertyName("tickerSymbol")]
        public string TickerSymbol { get; set; }

        [JsonPropertyName("priceInPounds")]
        public int PriceInPounds { get; set; }

        [JsonPropertyName("numberOfShares")]
        public decimal NumberOfShares { get; set; }
    }
}