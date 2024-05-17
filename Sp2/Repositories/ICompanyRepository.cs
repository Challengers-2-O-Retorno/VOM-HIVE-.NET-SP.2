using Sp2.Models;

namespace Sp2.Repositories
{
    public interface ICompanyRepository
    {
        List<CompanyModel> BuscarTodos();
        CompanyModel Adicionar(CompanyModel company);
    }
}
