using Sp2.Models;

namespace Sp2.Repositories
{
    public interface IProductRepository
    {
        ProductModel ListarPorId(int id_product);
        List<ProductModel> BuscarTodos();
        ProductModel Adicionar(ProductModel product);
        ProductModel Atualizar(ProductModel product);
        bool Apagar(int id_product);
    }
}
