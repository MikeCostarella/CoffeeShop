using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

public class ShoppingCartController : Controller
{
    #region Member Variables

    private IProductRepository productRepository;
    private IShoppingCartRepository shoppingCartRepository;

    #endregion Member Variables

    #region Constructors

    public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
    {
        this.shoppingCartRepository = shoppingCartRepository;
        this.productRepository = productRepository;
    }

    #endregion Constructors

    #region Public Actions

    public IActionResult Index()
    {
        var items = shoppingCartRepository.GetShoppingCartItems();
        shoppingCartRepository.ShoppingCartItems = items;
        ViewBag.CartTotal = shoppingCartRepository.GetShoppingCartTotal();
        return View(items);
    }

    public RedirectToActionResult AddToShoppingCart(int pId)
    {
        var product = productRepository.GetAllProducts().FirstOrDefault(p => p.Id == pId);
        if (product != null)
        {
            shoppingCartRepository.AddToCart(product);
            int cartCount = shoppingCartRepository.GetShoppingCartItems().Count;
            HttpContext.Session.SetInt32("CartCount", cartCount);
        }
        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromShoppingCart(int pId)
    {
        var product = productRepository.GetAllProducts().FirstOrDefault(p => p.Id == pId);
        if (product != null)
        {
            shoppingCartRepository.RemoveFromCart(product);
            int cartCount = shoppingCartRepository.GetShoppingCartItems().Count;
            HttpContext.Session.SetInt32("CartCount", cartCount);
        }
        return RedirectToAction("Index");
    }

    #endregion Public Actions
}
