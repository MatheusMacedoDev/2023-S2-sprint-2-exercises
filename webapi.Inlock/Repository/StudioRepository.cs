using Microsoft.EntityFrameworkCore;
using webapi.Inlock.Contexts;
using webapi.Inlock.Domains;
using webapi.Inlock.Interfaces;

namespace webapi.Inlock.Repository
{
    public class StudioRepository : IStudioRepository
    {
        private InLockContext context;

        public StudioRepository()
        {
            context = new InLockContext();
        }

        public void Create(Studio newStudio)
        {
            throw new NotImplementedException();
        }

        public Studio FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Studio> ListAll()
        {
            return context.Studios.ToList(); ;
        }

        public List<Studio> ListAllWithGames()
        {
            return context.Studios.Include(studio => studio.Games).ToList();
        }

        public void Update(Guid id, Studio newStudioData)
        {
            throw new NotImplementedException();
        }
    }
}
