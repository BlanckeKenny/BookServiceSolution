using System.Threading.Tasks;
using BookService.WebApi.Models;
using BookService.WebApi.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebApi.Controllers
{
    public class ControllerCrudBase<T, TR> : ControllerBase
        where T : EntityBase
        where TR : Repository<T>
    {
        protected TR Repository;

        public ControllerCrudBase(TR r)
        {
            Repository = r;
        }

        // GET: api/T
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(await Repository.ListAll());
        }

        // GET: api/T/2
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            return Ok(await Repository.GetById(id));
        }

        // PUT: api/T/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != entity.Id) return BadRequest("Id bestaat niet");
            var e = await Repository.Update(entity);
            if (e == null) return NotFound();
            return Ok(e);
        }

        // POST: api/T
        [HttpPost]
        public async Task<IActionResult> PostPublisher([FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var e = await Repository.Add(entity);
            if (e == null) return NotFound();
            return CreatedAtAction("Get", new {id = entity.Id}, entity);
        }

        // DELETE: api/T/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var entity = await Repository.Delete(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }
        
        
    }
}
