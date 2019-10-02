using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Bookstore.Business;
using Bookstore.DAL;
using Bookstore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bookstore.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private static CategoryBusiness _categoryBusiness;
        public CategoriesController(BookStoreContext context)
        {
            _categoryBusiness = new CategoryBusiness(context);
        }

        // GET: api/<controller>
        [HttpGet]
        public ObjectResult Get()
        {
            var data = _categoryBusiness.Get();

            var result = new ObjectResult(data)
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            return result;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            var data = _categoryBusiness.Get(id);

            if (data == null) return NotFound("Category Not Found");

            var result = new ObjectResult(data)
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            return result;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Category viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var id = _categoryBusiness.Add(viewModel);

            return CreatedAtAction(nameof(Get), new { Id = id }, viewModel);
        }

        // PUT api/<controller>
        [HttpPut]
        public IActionResult Put([FromBody]Category viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var model = _categoryBusiness.Update(viewModel);

            if (model == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(Get), new { Id = model.Id }, model);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var model = _categoryBusiness.Delete(id);

            if (!model) return NotFound();

            return Ok();
        }
    }
}
