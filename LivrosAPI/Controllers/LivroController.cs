using LivrosAPI.Modl;
using LivrosAPI.Repositores;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivrosAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroReository _livroReository;
        public LivroController(ILivroReository livroReository)
        {
            _livroReository = livroReository;
        }

        [HttpGet]
        public async Task<IEnumerable<Livro>> GetLivros()
        {
            return await _livroReository.Get();
        }

        [HttpGet("{LivroId}")]
        public async Task<ActionResult<Livro>> GetPorID(int livroId)
        {
            return await _livroReository.Get(livroId);
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro([FromBody] Livro livro)
        {
            var novoLivro = await _livroReository.Create(livro);
            return CreatedAtAction(nameof(GetLivros), new { livroId= novoLivro.LivroId}, novoLivro);
        }


        [HttpDelete]
        public async Task<ActionResult> Deletar(int livroId)
        {
            var deletandoLivro = await _livroReository.Get(livroId);

            if (deletandoLivro == null)
                return NotFound();
          
            await _livroReository.Delete(deletandoLivro.LivroId);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarLivros(int livroId,[FromBody] Livro livro)
        {
            if (livroId != livro.LivroId)
                return NotFound();

            await _livroReository.Update(livro);
            return NoContent();
        }

    }
}
