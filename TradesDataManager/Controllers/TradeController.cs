using Microsoft.AspNetCore.Mvc;
using TradesDataManager.Contracts.Requests;
using TradesDataManager.Contracts.Responses;
using TradesDataManager.Services.RequestHandlers;

namespace TradesDataManager.Controllers
{
    [ApiController]
    // If we used the API.Versioning.Http nuget package 
    //[ApiVersion("1.0")]
    //[Route("/api/v{version:apiVersion}/[controller]")]
    [Route("api/v1")]
    [Produces("application/json")]
    public class TradeController : ControllerBase
    {
        private readonly IRequestHandler _requestHandler;

        private readonly ILogger<TradeController> _logger;

        public TradeController(IRequestHandler requestHandler, ILogger<TradeController> logger)
        {
            _requestHandler = requestHandler;
            _logger = logger;
        }

        // Would expand response types
        [HttpGet("stock")]
        [ProducesResponseType(typeof(StockResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //This is the complete controller, other controllers are dummied / incomplete as this controllers structure would be replicated, others are incomplete due to time constraints.
        public async Task<IActionResult> GetStock([FromQuery] string tickerSymbol)
        {
            try
            {
                // Would require more extensive validation for class objects
                if (string.IsNullOrEmpty(tickerSymbol))
                {
                    var message = "Null request";
                    _logger.LogError(message);
                    return BadRequest(message);
                }

                _logger.LogDebug($"{nameof(GetStock)} called with ticker symbol: {tickerSymbol}");
                var stock = await _requestHandler.GetStockRequestHandler(tickerSymbol);

                return Ok(stock);

            }
            // This would be broken down into specifics catch exceptions, enabling a custom response based on the error type.
            // Alternatively error response objects can be constructed with status codes and error messages
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("stocks")]
        [ProducesResponseType(typeof(StocksResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStocks([FromQuery] IEnumerable<string> tickerSymbolsFilter)
        {
            try
            {
                if (!tickerSymbols.Any())
                {
                    //This means it's a request to get all stocks, without a filter.
                    //Log here
                }

                _logger.LogDebug($"{nameof(GetStock)} called with ticker symbols: {string.Join(", ", tickerSymbols)}");
                var results = await _requestHandler.GetStocksRequestHandler(tickerSymbols).ConfigureAwait(false);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("trade")]
        // Could use authorize decorator [Authorize] depending on how auth is handled
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // Add other response types
        public async Task<IActionResult> PutTrade([FromBody] TradeNotificationRequest tradeNotificationRequest)
        {
            try
            {
                if (tradeNotificationRequest == null)
                {
                    var message = "Null request";
                    _logger.LogError(message);
                    return BadRequest(message);
                }

                await _requestHandler.UpsertTradeRequestHandler(tradeNotificationRequest).ConfigureAwait(false);

                return Ok();
            }
            // This would have to be more specific to propagate the correct issue, as the request itself might not be the issue here!
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}