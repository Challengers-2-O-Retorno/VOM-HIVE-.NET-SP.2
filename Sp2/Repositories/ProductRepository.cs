using Microsoft.EntityFrameworkCore;
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

        public ProductModel ListarPorId(int id_product)
        {
            return _bancoContext.Product.FirstOrDefault(p => p.id_product == id_product);
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

        public ProductModel Atualizar(ProductModel product)
        {
            ProductModel productDb = ListarPorId(product.id_product);

            if (productDb == null) throw new System.Exception("Houve um erro ao atualizar o produto");
            
            productDb.nm_product = product.nm_product;
            productDb.category_product = product.category_product;

            _bancoContext.Product.Update(productDb);
            _bancoContext.SaveChanges();
            return productDb;
        }

        public bool Apagar(int id_product)
        {
            ProductModel productDb = ListarPorId(id_product);

            if (productDb == null) throw new System.Exception("Produto não encontrado!");

            _bancoContext.Product.Remove(productDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
