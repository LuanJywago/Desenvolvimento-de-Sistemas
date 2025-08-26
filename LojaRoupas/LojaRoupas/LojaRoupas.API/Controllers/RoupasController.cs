using Microsoft.AspNetCore.Mvc;
using LojaRoupas.API.Models;

namespace LojaRoupas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoupasController : ControllerBase
    {
        private static List<Roupa> _roupas = new List<Roupa>();
        private static int _nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<Roupa>> GetAll()
        {
            return Ok(_roupas);
        }

        [HttpGet("{id}")]
        public ActionResult<Roupa> GetById(int id)
        {
            var roupa = _roupas.FirstOrDefault(r => r.Id == id);
            if (roupa == null) return NotFound();
            return Ok(roupa);
        }

        [HttpPost]
        public ActionResult<Roupa> Create(Roupa novaRoupa)
        {
            novaRoupa.Id = _nextId++;
            _roupas.Add(novaRoupa);
            return CreatedAtAction(nameof(GetById), new { id = novaRoupa.Id }, novaRoupa);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Roupa roupaAtualizada)
        {
            var roupa = _roupas.FirstOrDefault(r => r.Id == id);
            if (roupa == null) return NotFound();

            roupa.Nome = roupaAtualizada.Nome;
            roupa.Tamanho = roupaAtualizada.Tamanho;
            roupa.Preco = roupaAtualizada.Preco;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var roupa = _roupas.FirstOrDefault(r => r.Id == id);
            if (roupa == null) return NotFound();

            _roupas.Remove(roupa);
            return NoContent();
        }
    }
}
