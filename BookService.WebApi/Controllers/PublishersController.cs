﻿using System.Threading.Tasks;
using BookService.WebApi.Models;
using BookService.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherRepository _repository;

        public PublishersController(PublisherRepository repository)
        {
            _repository = repository;
        }


        // api/publishers
        public async Task<IActionResult> GetPublishers()
        {
            var publishers = await _repository.ListAll();
            return Ok(publishers);
        }

        // api/publishers/2
        [Route("{id}")]
        public async Task<IActionResult> GetPublisher(int id)
        {
            return Ok(await _repository.GetById(id));
        }


        // put: api/Publishers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublisher([FromRoute] int id, [FromBody] Publisher publisher)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != publisher.Id) return BadRequest();
            Publisher p = await _repository.Update(publisher);
            if (p == null) return NotFound();
            return Ok(p);

        }

        // post: api/Publishers
        [HttpPost]
        public async Task<IActionResult> PostPublisher([FromBody] Publisher publisher)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _repository.Add(publisher);
            return CreatedAtAction("GetPublisher", new { id = publisher.Id } , publisher);

        }

        // DELETE: api/Publishers/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher([FromRoute] int id)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var publisher = await _repository.Delete(id);
            if (publisher == null) return NotFound();
            return Ok(publisher);

        }


    }
}