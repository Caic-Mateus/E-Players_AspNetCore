using System.Collections.Generic;
using E_Players_AspNetCore.Models;

namespace E_Players_AspNetCore_main.Interfaces
{
    public interface IJogador
    {
         //CRUD
         void Create(Jogador j);
         List<Jogador> ReadAll();
         void Update(Jogador j);
         void Delete(int id);
    }
}