using Sp2.Models;
using Sp2.Persistence;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sp2.Repositories
{
    public class ProfileuserRepository : IProfileuserRepository
    {
        private readonly OracleDbContext _bancoContext;

        public ProfileuserRepository(OracleDbContext oracleDbContext)
        {
            _bancoContext = oracleDbContext;
        }

        public ProfileuserModel ListarPorId(int id_user)
        {
            return _bancoContext.ProfileUser.FirstOrDefault(x => x.id_user == id_user);
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

        public ProfileuserModel Atualizar(ProfileuserModel profile)
        {
            ProfileuserModel profileDb = ListarPorId(profile.id_user);

            if (profileDb == null) throw new System.Exception("Houve um erro na atualização do Usuário!");

            profileDb.nm_user = profile.nm_user;
            profileDb.pass_user = profile.pass_user;
            profileDb.permission_user = profile.permission_user;
            profileDb.status = profile.status;

            _bancoContext.ProfileUser.Update(profileDb);
            _bancoContext.SaveChanges();
            return profileDb;
        }

        public bool Apagar(int id_user)
        {
            ProfileuserModel profileDb = ListarPorId(id_user);

            if (profileDb == null) throw new System.Exception("Houve um erro na exclusão do usuário!");

            _bancoContext.ProfileUser.Remove(profileDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
