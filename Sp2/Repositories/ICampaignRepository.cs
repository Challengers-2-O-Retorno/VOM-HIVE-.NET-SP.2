using Sp2.Models;

namespace Sp2.Repositories
{
    public interface ICampaignRepository
    {
        List<CampaignModel> BuscarTodos();
        CampaignModel Adicionar(CampaignModel campaign);
    }
}
