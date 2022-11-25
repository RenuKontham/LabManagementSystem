using LabManagementSystem.Data.Models;
using LabManagementSystem.Data.Providers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LabManagementSystem.Api.Controllers
{
    [Route("api/v1/labMgmt/labs")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly ILabMgmtSystemProvider _labMgmtSystemProvider;

        public LabController(ILabMgmtSystemProvider labMgmtSystemProvider)
        {
            _labMgmtSystemProvider = labMgmtSystemProvider;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Lab> GetLabs()
        {
            return _labMgmtSystemProvider.GetLabs();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult SaveLabs([Required] string name, [Required] string description, 
            [Required] int authorId,
            [Required] int categoryId)
        {
            Lab lab = new Lab();
            lab.Name = name;
            lab.Description = description;
            lab.AuthorId = authorId;
            lab.CategoryId = categoryId;
            _labMgmtSystemProvider.SaveLab(lab);
            return Created("saveLabs", null);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLabs(int id)
        {
            bool deleted = _labMgmtSystemProvider.DeleteLab(id);
            if (deleted)
                return Ok();
            else
                return BadRequest("Invalid request");
        }

        [HttpPut]
        public IActionResult UpdateLabs([Required] int id, [Required] string name,
            [Required] string description,
            [Required] int authorId,
            [Required] int categoryId)
        {
            Lab lab = new Lab();
            lab.Id = id;
            lab.Name = name;
            lab.Description = description;
            lab.AuthorId = authorId;
            lab.CategoryId = categoryId;
            bool updated = _labMgmtSystemProvider.UpdateLab(lab);
            if (updated)
                return Ok();
            else
                return BadRequest("Invalid request");
        }
    }
}
