using webapi.inlock.codeFirst.morning.Domain;

namespace webapi.inlock.codeFirst.morning.Interfaces
{
    public interface IGameRepository
    {
        void Create(Game studio);
        List<Game> ListAll();
        Game GetById(Guid id);
        void Update(Game studio);
        void Delete(Guid Id);
    }
}
