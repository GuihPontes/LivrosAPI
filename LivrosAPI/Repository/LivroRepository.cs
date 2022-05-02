using LivrosAPI.Modl;
using LivrosAPI.Repositores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrosAPI.Repository
{

    public class LivroRepository : ILivroReository
    {
        public readonly LivroContext _livro;
        public LivroRepository(LivroContext livro)
        {
            _livro = livro;
        }
        public async Task<Livro> Create(Livro livro)
        {
            _livro.Livros.Add(livro);
          await  _livro.SaveChangesAsync();
            return livro;
        }

        public async Task Delete(int LivroId)
        {
            var LivroDelete = await _livro.Livros.FindAsync(LivroId);
            _livro.Livros.Remove(LivroDelete);
            await _livro.SaveChangesAsync();
        }

        public async Task<IEnumerable<Livro>> Get()
        {
            return await _livro.Livros.ToListAsync();
        }

        public async Task<Livro> Get(int LivroId)
        {
           return await _livro.Livros.FindAsync(LivroId);
        }

        public async Task Update(Livro livro)
        {
            _livro.Entry(livro).State = EntityState.Modified;
            await _livro.SaveChangesAsync();
        }
    }
}
