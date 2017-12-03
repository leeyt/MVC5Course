namespace MVC5Course.Models
{
    using System.Linq;

    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }
    }

    public  interface IProductRepository : IRepository<Product>
	{
        Product Find(int id);
	}
}