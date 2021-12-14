using AspNetCoreWithReact.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWithReact.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Library> library = _libraryService.GetAll();
            return Ok(library);
        }


        [HttpGet]
        public IActionResult Search(string name)
        {
            List<Library> library = _libraryService.GetByName(name);
            return Ok(library);
        }


        [HttpPut]
        public IActionResult Update(Library library)
        {
            return Ok(_libraryService.Update(library));
        }


        [HttpPost]
        public IActionResult Save(Library library)
        {
            return Ok(_libraryService.Save(library));
        }

        [HttpDelete]
        public IActionResult Delete(Library library)
        {
            _libraryService.Delete(library);
            return Ok();
        }
    }
}
