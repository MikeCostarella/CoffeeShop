namespace CoffeeShop.Models.Interfaces;

public interface IShoppingCartRepository
{
    void AddToCart(Product product);
    void ClearCart();
    List<ShoppingCartItem> GetShoppingCartItems();
    decimal GetShoppingCartTotal();
    int RemoveFromCart(Product product);
    public List<ShoppingCartItem>? ShoppingCartItems { get; set; }
}
