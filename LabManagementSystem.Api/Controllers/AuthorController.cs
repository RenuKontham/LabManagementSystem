using LabManagementSystem.Data.Models;
using LabManagementSystem.Data.Providers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LabManagementSystem.Controllers;

[ApiController]
[Route("api/v1/labMgmt/authors")]
public class AuthorController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private readonly ILabMgmtSystemProvider _labMgmtSystemProvider;

    public AuthorController(ILogger<AuthorController> logger, ILabMgmtSystemProvider labMgmtSystemProvider)
    {
        _logger = logger;
        _labMgmtSystemProvider = labMgmtSystemProvider;
    }

    [HttpGet]
    public IEnumerable<Author> GetAuthors()
    {
        return _labMgmtSystemProvider.GetAuthors();
    }

    [HttpPost]
    public IActionResult SaveAuthors([Required] string firstName, [Required] string lastName)
    {
        Author author = new Author();
        author.FirstName = firstName;
        author.LastName = lastName;
        _labMgmtSystemProvider.SaveAuthor(author);
        return Created("saveAuthors", null);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        bool deleted = _labMgmtSystemProvider.DeleteAuthor(id);
        if(deleted)
            return Ok(); 
        else
            return BadRequest("Invalid request");
    }

    [HttpPut]
    public IActionResult UpdateAuthors([Required] int id, [Required] string firstName, [Required] string lastName)
    {
        Author author = new Author();
        author.Id = id;
        author.FirstName = firstName;
        author.LastName = lastName;
        bool updated = _labMgmtSystemProvider.UpdateAuthor(author);
        if(updated)
            return Ok();
        else
            return BadRequest("Invalid request");
    }
}
