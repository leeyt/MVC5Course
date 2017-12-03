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

        public IQueryable<Product> Get���o�Ҧ��|���R�����ӫ~���()
        {
            return this.All();
        }

        public IQueryable<Product> Get���o�Ҧ��|���R�����ӫ~���Top10()
        {
            return this.Get���o�Ҧ��|���R�����ӫ~���().Take(10);
        }
    }

    public interface IProductRepository : IRepository<Product>
    {
        Product Find(int id);

        IQueryable<Product> Get���o�Ҧ��|���R�����ӫ~���();

        IQueryable<Product> Get���o�Ҧ��|���R�����ӫ~���Top10();
    }
}