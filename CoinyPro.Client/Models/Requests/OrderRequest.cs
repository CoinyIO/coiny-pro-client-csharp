
namespace CoinyPro.Client.Models.Requests
{
    public class OrderRequest
    {
        /// <summary>
        /// Coin Quantity. Quantity needs to be 0 when order is market buy. For market sell and limit orders it needs to be defined rather than 0.
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// Also known as price. Amount needs to be 0 when order is market sell. For market buy and limit orders it needs to be defined rather than 0.
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Pair i.e btc-try
        /// </summary>
        public string Pair { get; set; }
        /// <summary>
        /// Limit order, Market order
        /// </summary>
        public OrderType OrderType { get; set; }
        /// <summary>
        /// If you want to put a limit order which partially matches to an order in the recent order book, you need to set it to yes. 
        /// </summary>
        public bool AllowTaker { get; set; }
        /// <summary>
        /// Side of the order. Buy,Sell
        /// </summary>
        public Side Side { get; set; }
    }

    public enum Side
    {
        Undefined = 0,
        Buy,
        Sell
    }

    public enum OrderType
    {
        Undefined = 0,
        Limit,
        Market
    }

    public enum OrderStatus
    {
        Rejected = -2,
        Cancelled = -1,
        Undefined = 0,
        Pending,
        Open,
        Filled,
        Completed
    }

}
