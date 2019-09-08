using System.Data;

namespace HeroBot.Common.Interfaces
{
    public interface IDatabaseService
    {

        public IDbConnection GetDbConnection();
        public IDbConnection GetDbConnection(string v);
    }
}
