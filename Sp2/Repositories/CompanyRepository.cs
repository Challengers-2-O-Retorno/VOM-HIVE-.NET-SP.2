using Sp2.Models;
using Sp2.Persistence;

namespace Sp2.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly OracleDbContext _bancoContext;

        public CompanyRepository(OracleDbContext oracleDbContext)
        {
             _bancoContext = oracleDbContext;
        }

        public List<CompanyModel> BuscarTodos()
        {
            return _bancoContext.Company.ToList(); 
        }

        public CompanyModel Adicionar(CompanyModel company)
        {
            //Gravar no banco de dados
            _bancoContext.Company.Add(company);
            _bancoContext.SaveChanges();
            return company;
        }
    }
}
