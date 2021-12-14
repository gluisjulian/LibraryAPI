using AspNetCoreWithReact.Data;
using AspNetCoreWithReact.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWithReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public DataContext _context;


        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private ILibraryService _libraryService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILibraryService libraryService)
        {
            _logger = logger;
            _libraryService = libraryService;
        }

        [HttpGet]
        
        public IEnumerable<WeatherForecast> Get()
        {

            //GETALL()
            //List<Library> libraries = _libraryService.GetAll();

            //GETBYNAME()
            //List<Library> libraries = _libraryService.GetByName("Marilia");

            //ADD - CREATE
            //Library library = new Library() { Name= "Biblioteca Santos", Address = "Rua dos Santos, 123", Telephone = "11-123456789"};
            //_libraryService.Save(library);

            //UPDATE
            //Library libraryUpdated = _libraryService.GetByName("Marilia").FirstOrDefault();
            //libraryUpdated.Name = "Biblioteca Santos Updated";
            //_libraryService.Update(libraryUpdated);

            //DELETE
            //Library library = _libraryService.GetByName("Santos").FirstOrDefault();
            //_libraryService.Delete(library);


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}