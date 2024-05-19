using Sp2.Models;
using Sp2.Persistence;

namespace Sp2.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly OracleDbContext _bancoContext;

        public CampaignRepository(OracleDbContext oracleDbContext)
        {
            _bancoContext = oracleDbContext;
        }

        public CampaignModel ListarPorId(int id_campaign)
        {
            return _bancoContext.Campaign.FirstOrDefault(x => x.id_campaing == id_campaign);
        }

        public List<CampaignModel> BuscarTodos()
        {
            return _bancoContext.Campaign.ToList();
        }

        public CampaignModel Adicionar(CampaignModel campaign)
        {
            _bancoContext.Campaign.Add(campaign);
            _bancoContext.SaveChanges();
            return campaign;
        }
        public CampaignModel Atualizar(CampaignModel campaign)
        {
            CampaignModel campaignDb = ListarPorId(campaign.id_campaing);

            if (campaignDb == null) throw new System.Exception("Houve um erro na atualização da Campanha!");

            campaignDb.nm_campaign = campaign.nm_campaign;
            campaignDb.target = campaign.target;
            campaignDb.details = campaign.details;
            campaignDb.status = campaign.status;

            _bancoContext.Campaign.Update(campaignDb);
            _bancoContext.SaveChanges();
            return campaignDb;
        }

        public bool Apagar(int id_campaign)
        {
            CampaignModel campaignDb = ListarPorId(id_campaign);

            if (campaignDb == null) throw new System.Exception("Houve um erro na exclusão da Campanha!");

            _bancoContext.Campaign.Remove(campaignDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
