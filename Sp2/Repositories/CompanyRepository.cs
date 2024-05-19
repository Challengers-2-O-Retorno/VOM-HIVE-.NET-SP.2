using Sp2.Models;
using Sp2.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Sp2.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly OracleDbContext _bancoContext;

        public CompanyRepository(OracleDbContext oracleDbContext)
        {
             _bancoContext = oracleDbContext;
        }

        public CompanyModel ListarPorId(int id_company)
        {
            return _bancoContext.Company.FirstOrDefault(x => x.id_company == id_company);
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

        public CompanyModel Atualizar(CompanyModel company)
        {
            CompanyModel companyDb = ListarPorId(company.id_company);

            if (companyDb == null) throw new System.Exception("Houve um erro na atualização da empresa!");

            companyDb.nm_company = company.nm_company;
            companyDb.cnpj = company.cnpj;
            companyDb.email = company.email;

            _bancoContext.Company.Update(companyDb);
            _bancoContext.SaveChanges();
            return companyDb;
        }

        public bool Apagar(int id_company)
        {
            CompanyModel companyDb = ListarPorId(id_company);

            if (companyDb == null) throw new System.Exception("Houve um erro na exclusão da empresa!");

            _bancoContext.Company.Remove(companyDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
