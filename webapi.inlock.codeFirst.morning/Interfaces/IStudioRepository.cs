using webapi.inlock.codeFirst.morning.Domain;

namespace webapi.inlock.codeFirst.morning.Interfaces
{
    public interface IStudioRepository
    {
        void Create(Studio studio);
        List<Studio> ListAll();
        Studio GetById(Guid id);
        void Update(Studio studio);
        void Delete(Guid Id);
    }
}
