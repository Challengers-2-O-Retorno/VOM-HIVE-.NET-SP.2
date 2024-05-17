using Sp2.Models;

namespace Sp2.Repositories
{
    public interface IProductRepository
    {
        List<ProductModel> BuscarTodos();
        ProductModel Adicionar(ProductModel product);
    }
}
