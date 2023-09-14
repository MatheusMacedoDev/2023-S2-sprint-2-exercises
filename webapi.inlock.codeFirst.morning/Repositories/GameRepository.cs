using webapi.inlock.codeFirst.morning.Contexts;
using webapi.inlock.codeFirst.morning.Domain;
using webapi.inlock.codeFirst.morning.Interfaces;

namespace webapi.inlock.codeFirst.morning.Repositories
{
    public class GameRepository : IGameRepository
    {
        private InlockContext _context;

        public GameRepository()
        {
            _context = new InlockContext();
        }

        public void Create(Game game)
        {
            _context.Add(game);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Game findedGame = GetById(id);

            if (findedGame != null)
            {
                _context.Remove(findedGame);
                _context.SaveChanges();
            }
        }

        public Game GetById(Guid id)
        {
            return _context.Games.FirstOrDefault(game => game.Id == id)!;
        }

        public List<Game> ListAll()
        {
            return _context.Games.ToList();
        }

        public void Update(Game gameData)
        {
            Game findedGame = GetById(gameData.Id);

            if (findedGame != null)
            {
                findedGame.Name = gameData.Name;
                findedGame.IdStudio = gameData.IdStudio;
                findedGame.Name = gameData.Name;
                findedGame.Description = gameData.Description;
                findedGame.ReleaseDate = gameData.ReleaseDate;

                _context.Games.Update(findedGame);
                _context.SaveChanges();
            }
        }
    }
}
