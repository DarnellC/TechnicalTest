namespace TradesDataManager.Models
{
    public class Stocks
    {
        public Stocks(List<Stock> stocks)
        {
            this.stocks = stocks;
        }

        public List<Stock> stocks;
    }
}
