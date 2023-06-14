using CoffeeShop.Data;
using CoffeeShop.Models.Interfaces;

namespace CoffeeShop.Models.Services;

public class OrderRepository : IOrderRepository
{
    #region Member Variables

    private CoffeeShopDbContext dbContext;
    private IShoppingCartRepository shoppingCartRepository;

    #endregion Member Variables

    #region Constructors

    public OrderRepository(CoffeeShopDbContext dbContext, IShoppingCartRepository shoppingCartRepository)
    {
        this.dbContext = dbContext;
        this.shoppingCartRepository = shoppingCartRepository;
    }

    #endregion Constructors

    #region Public Actions

    public void PlaceOrder(Order order)
    {
        var shoppingCartItems = shoppingCartRepository.GetShoppingCartItems();
        order.OrderDetails = new List<OrderDetail>();
        foreach (var item in shoppingCartItems)
        {
            var orderDetail = new OrderDetail
            {
                Quantity = item.Qty,
                ProductId = item.Product.Id,
                Price = item.Product.Price
            };
            order.OrderDetails.Add(orderDetail);
        }
        order.OrderPlaced = DateTime.Now;
        order.OrderTotal = shoppingCartRepository.GetShoppingCartTotal();
        dbContext.Orders.Add(order);
        dbContext.SaveChanges();
    }

    #endregion Public Actions
}
