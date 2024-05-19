using Sp2.Models;

namespace Sp2.Repositories
{
    public interface ICampaignRepository
    {
        CampaignModel ListarPorId(int id_campaign);
        List<CampaignModel> BuscarTodos();
        CampaignModel Adicionar(CampaignModel campaign);
        CampaignModel Atualizar(CampaignModel campaign);
        bool Apagar(int id_campaign);
    }
}
