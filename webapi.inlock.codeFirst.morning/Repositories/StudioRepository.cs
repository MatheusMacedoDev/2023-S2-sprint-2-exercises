using webapi.inlock.codeFirst.morning.Contexts;
using webapi.inlock.codeFirst.morning.Domain;
using webapi.inlock.codeFirst.morning.Interfaces;

namespace webapi.inlock.codeFirst.morning.Repositories
{
    public class StudioRepository : IStudioRepository
    {
        private InlockContext _context;

        public StudioRepository()
        {
            _context = new InlockContext();
        }

        public void Create(Studio studio)
        {
            _context.Add(studio);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Studio findedStudio = GetById(id);

            if (findedStudio != null)
            {
                _context.Remove(findedStudio);
                _context.SaveChanges();
            }
        }

        public Studio GetById(Guid id)
        {
            return _context.Studios.FirstOrDefault(studio => studio.Id == id)!;
        }

        public List<Studio> ListAll()
        {
            return _context.Studios.ToList();
        }

        public void Update(Studio studioData)
        {
            Studio findedStudio = GetById(studioData.Id);

            if (findedStudio != null)
            {
                findedStudio.Name = studioData.Name;

                _context.Studios.Update(findedStudio);
                _context.SaveChanges();
            }
        }
    }
}
