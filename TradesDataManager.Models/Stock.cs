namespace TradesDataManager.Models
{
    public class Stock
    {
        public Stock(int brokerId, string tickerSymbol, int priceInPounds, decimal numberOfShares)
        {
            BrokerId = brokerId;
            TickerSymbol = tickerSymbol;
            PriceInPounds = priceInPounds;
            NumberOfShares = numberOfShares;
        }

        public int BrokerId { get; }

        public string TickerSymbol { get; }

        public int PriceInPounds { get; }

        public decimal NumberOfShares { get; }
    }
}
