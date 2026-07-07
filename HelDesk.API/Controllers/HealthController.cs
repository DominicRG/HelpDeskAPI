using HelpDesk.Infrastructure.Persistence;
using HelpDesk.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelDesk.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HealthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _context.Database.OpenConnection();
                _context.Database.CloseConnection();

                return Ok(ApiResponseFactory.Success(
                    "API ONLINE",
                    "Conexión exitosa con SQL Server."
                ));
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    ex.Message,
                    InnerException = ex.InnerException?.Message,
                    ExceptionType = ex.GetType().FullName
                });

                //return Ok(ApiResponseFactory.Failure<string>(
                //    ex.Message
                //));
            }

            //bool databaseOnline = _context.Database.CanConnect();

            //var response = ApiResponseFactory.Success(new
            //{
            //    Api = "ONLINE",
            //    Database = databaseOnline ? "ONLINE" : "OFFLINE"
            //}, "Estado de la API."
            //);

            //return Ok(response);
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    List<string> errors = new List<string>();
        //    errors.Add("primer error");
        //    errors.Add("segundo error");

        //    var response1 = ApiResponseFactory.Success<string>("API ONLINE", "HelpDesk API funcionando correctamente.");
        //    var response2 = ApiResponseFactory.Failure<string>("HelpDesk API funcionando correctamente.", errors);
        //    return Ok(response1);
        //}
    }
}
