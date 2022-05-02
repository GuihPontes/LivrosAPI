using LivrosAPI.Modl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrosAPI.Repositores
{
    public interface ILivroReository
    {
        Task<IEnumerable<Livro>> Get();

        Task<Livro> Get(int LivroId);

        Task<Livro> Create(Livro livro);
        Task Update(Livro livro);
        Task Delete(int LivroId);

    }
}
