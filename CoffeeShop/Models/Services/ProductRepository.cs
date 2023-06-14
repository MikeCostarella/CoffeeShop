using CoffeeShop.Data;
using CoffeeShop.Models.Interfaces;

namespace CoffeeShop.Models.Services;

public class ProductRepository : IProductRepository
{
    #region Member Variables

    private CoffeeShopDbContext dbContext;

    #endregion Member Variables

    #region  Constructors

    public ProductRepository(CoffeeShopDbContext dbContext)
    {
        this.dbContext = dbContext; 
    }

    #endregion Constructors

    #region Public Actions

    public IEnumerable<Product> GetAllProducts()
    {
        return dbContext.Products;
    }

    public Product? GetProductDetail(int id)
    {
        return dbContext.Products.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> GetTrendingProducts()
    {
        return dbContext.Products.Where(p => p.IsTrendingProduct);
    }

    #endregion Public Actions
}
