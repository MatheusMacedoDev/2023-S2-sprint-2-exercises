﻿using webapi.Inlock.Domains;

namespace webapi.Inlock.Interfaces
{
    public interface IStudioRepository
    {
        List<Studio> ListAll();
        Studio FindById(Guid id);
        void Create(Studio newStudio);
        void Update(Guid id, Studio newStudioData);
        void UpdateWithBody(Studio newStudio);
        void Delete(Guid id);
        List<Studio> ListAllWithGames();
    }
}
