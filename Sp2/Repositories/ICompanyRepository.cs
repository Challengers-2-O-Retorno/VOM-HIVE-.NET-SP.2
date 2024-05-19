using Sp2.Models;

namespace Sp2.Repositories
{
    public interface ICompanyRepository
    {
        CompanyModel ListarPorId(int id_company);
        List<CompanyModel> BuscarTodos();
        CompanyModel Adicionar(CompanyModel company);
        CompanyModel Atualizar(CompanyModel company);
        bool Apagar(int id_company);
    }
}
