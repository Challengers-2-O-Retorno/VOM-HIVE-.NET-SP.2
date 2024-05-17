using Sp2.Models;

namespace Sp2.Repositories
{
    public interface IProfileuserRepository
    {
        List<ProfileuserModel> BuscarTodos();
        ProfileuserModel Adicionar(ProfileuserModel profileuser);
    }
}
