using Sp2.Models;
using Sp2.Persistence;

namespace Sp2.Repositories
{
    public class ProfileuserRepository : IProfileuserRepository
    {
        private readonly OracleDbContext _bancoContext;

        public ProfileuserRepository(OracleDbContext oracleDbContext)
        {
            _bancoContext = oracleDbContext;
        }

        public List<ProfileuserModel> BuscarTodos()
        {
            return _bancoContext.ProfileUser.ToList();
        }

        public ProfileuserModel Adicionar(ProfileuserModel profileuser)
        {
            _bancoContext.ProfileUser.Add(profileuser);
            _bancoContext.SaveChanges();
            return profileuser;
        }
    }
}
