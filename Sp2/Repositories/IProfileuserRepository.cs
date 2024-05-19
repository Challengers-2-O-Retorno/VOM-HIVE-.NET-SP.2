using Sp2.Models;

namespace Sp2.Repositories
{
    public interface IProfileuserRepository
    {
        ProfileuserModel ListarPorId(int id_user);
        List<ProfileuserModel> BuscarTodos();
        ProfileuserModel Adicionar(ProfileuserModel profileuser);
        ProfileuserModel Atualizar (ProfileuserModel profileuser);
        bool Apagar(int id_user);
    }
}
