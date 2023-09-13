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
            newStudio.Id = Guid.NewGuid();

            context.Studios.Add(newStudio);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Studio findedStudio = FindById(id);

            if (findedStudio != null)
            {
                context.Studios.Remove(findedStudio);
                context.SaveChanges();
            }
        }

        public Studio FindById(Guid id)
        {
            return context.Studios.FirstOrDefault(studio => studio.Id == id)!;
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
            Studio findedStudio = FindById(id);

            if (findedStudio != null)
            {
                findedStudio.Name = newStudioData.Name;

                context.Studios.Update(findedStudio);
                context.SaveChanges();
            }
        }

        public void UpdateWithBody(Studio newStudio)
        {
            Studio findedStudio = FindById(newStudio.Id);

            if (findedStudio != null)
            {
                findedStudio.Name = newStudio.Name;

                context.Studios.Update(findedStudio);
                context.SaveChanges();
            }
        }
    }
}
