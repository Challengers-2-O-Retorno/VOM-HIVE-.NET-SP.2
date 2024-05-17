using Sp2.Models;
using Sp2.Persistence;

namespace Sp2.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OracleDbContext _bancoContext;

        public ProductRepository(OracleDbContext oracleDbContext)
        {
            _bancoContext = oracleDbContext;
        }

        public List<ProductModel> BuscarTodos()
        {
            return _bancoContext.Product.ToList();
        }

        public ProductModel Adicionar(ProductModel product)
        {
            _bancoContext.Product.Add(product);
            _bancoContext.SaveChanges();
            return product;
        }
    }
}
