using TradesDataManager.Models;
using TradesDataManager.Services.CosmosDb.Extensions;
using TradesDataManager.Services.CosmosDb.Models;
using TradesDataManager.Services.Database;

namespace TradesDataManager.Services.CosmosDb
{
    // This is internal for encapsulation. Each project should be fully encapsulated such that no other service can reference their business logic.
    internal class StocksDatabase : IStocksDatabase
    {
        //private readonly CosmosClient client;

        public StocksDatabase()
        {
            //Construct Cosmos Client
        }

        public async Task<Stock> GetStock(string tickerSymbol)
        {
            //Query cosmos db 
            await Task.Delay(500);

            var databaseResult = new CosmosStock(brokerId: 1, tickerSymbol: tickerSymbol, priceInPounds: 50, numberOfShares: 500);

            // Handle null case whereby nulls are assigned to their default values

            // Map to business logic DTO
            var result = databaseResult.Map();

            return result;
        }

        public async Task<Stocks> GetStocks(IEnumerable<string> tickerSymbolsFilter)
        {
            //Query cosmos db 
            //This would involve a parameterised QueryDefinition such that, the call made to cosmos is SELECT [columns] FROM c WHERE CONTAINS(...)
            await Task.Delay(500);

            // Map to business logic DTO
            // Dummy code
            var stockList = new List<Stock>();

            return new Stocks(stockList);
        }

        public async Task Upsert()
        {
            // Could be worth putting a try catch here as the creation of the data is paramount, we cannot afford to not upsert.
            // This could include custom retry logic, or at least, leverage the Cosmos SDK retry which is
            // But this really only accounts for 429 too many requests
            try
            {
                await Task.Delay(1000);

                // This method would call client.UpsertDocumentAsync(). 
                // https://learn.microsoft.com/en-us/dotnet/api/microsoft.azure.documents.client.documentclient.upsertdocumentasync?view=azure-dotnet

                // Would return a means of determining success, 
                return;
            }
            catch (Exception ex)
            //when (ex is DocumentClientException)
            {
                //Some retry logic / handling
            }
        }
    }
}