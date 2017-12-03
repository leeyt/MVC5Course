namespace MVC5Course.Models
{
    using System.Linq;

    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => !p.IsDeleted);
        }

        public override void Delete(Product product)
        {
            product.IsDeleted = true;
        }

        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

        public IQueryable<Product> Get取得所有尚未刪除的商品資料()
        {
            return this.All();
        }

        public IQueryable<Product> Get取得所有尚未刪除的商品資料Top10()
        {
            return this.Get取得所有尚未刪除的商品資料().Take(10);
        }
    }

    public interface IProductRepository : IRepository<Product>
    {
        Product Find(int id);

        IQueryable<Product> Get取得所有尚未刪除的商品資料();

        IQueryable<Product> Get取得所有尚未刪除的商品資料Top10();
    }
}