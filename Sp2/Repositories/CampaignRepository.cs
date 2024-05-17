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
    }
}
