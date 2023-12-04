using System.ComponentModel.DataAnnotations;

namespace TradesDataManager.Models
{
    public class TradeNotification
    {
        public TradeNotification(int brokerId, string tickerSymbol, int priceInPounds, decimal numberOfShares)
        {
            BrokerId = brokerId;
            TickerSymbol = tickerSymbol;
            PriceInPounds = priceInPounds;
            NumberOfShares = numberOfShares;
        }

        [Required]
        public int BrokerId { get; }

        [Required]
        public string TickerSymbol { get; }

        [Required]
        public int PriceInPounds { get; }

        [Required]
        public decimal NumberOfShares { get; }
    }
}