using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers;

public class HomeController : Controller
{
    #region Member Variables

    private IProductRepository productRepository;

    #endregion Member Variables

    #region #Constructors

    public HomeController(IProductRepository productRepository)
    {
        this.productRepository = productRepository; 
    }

    #endregion Constructors

    #region Public Actions

    public IActionResult Index()
    {
        return View(productRepository.GetTrendingProducts());
    }

    #endregion Constructors
}
