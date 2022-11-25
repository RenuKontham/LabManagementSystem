using LabManagementSystem.Data.Models;
using LabManagementSystem.Data.Providers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LabManagementSystem.Api.Controllers
{
    [Route("api/v1/labMgmt/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILabMgmtSystemProvider _labMgmtSystemProvider;

        public CategoryController(ILabMgmtSystemProvider labMgmtSystemProvider)
        {
            _labMgmtSystemProvider = labMgmtSystemProvider;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return _labMgmtSystemProvider.GetCategories();
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult SaveCategories([Required] string name)
        {
            Category category = new Category();
            category.Name = name;
            _labMgmtSystemProvider.SaveCategory(category);
            return Created("saveCategories", null);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategories(int id)
        {
            bool deleted = _labMgmtSystemProvider.DeleteCategory(id);
            if (deleted)
                return Ok();
            else
                return BadRequest("Invalid request");
        }

        [HttpPut]
        public IActionResult UpdateCategories([Required] int id, [Required] string name)
        {
            Category category = new Category();
            category.Id = id;
            category.Name = name;
            bool updated = _labMgmtSystemProvider.UpdateCategory(category);
            if (updated)
                return Ok();
            else
                return BadRequest("Invalid request");
        }
    }
}
