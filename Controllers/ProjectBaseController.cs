using Microsoft.AspNetCore.Mvc;
using pLocals.Models.DTOs;
using System.Text.Json;

namespace pLocals.Controllers
{
    public class ProjectBaseController : Controller
    /// <summary>
    ///  Parent controller derived from Controller for all another within this project
    /// </summary>
    {
        public override BadRequestObjectResult BadRequest(object? errorMessage)
        {
            if (errorMessage == null)
            {
                errorMessage = "Bad request. You're doing something wrong.";
            }
            
            Response.ContentType = "application/json";

            var output = new RequestErrorMessageDTO()
            {
                ErrorMessage = errorMessage.ToString(),
                StatusCode = StatusCodes.Status400BadRequest
            };

            return new BadRequestObjectResult(output);
        }

        public override NotFoundObjectResult NotFound(object? errorMessage)
        {
            if (errorMessage == null)
            {
                errorMessage = "Not Found";
            }

            Response.ContentType = "application/json";

            var output = new RequestErrorMessageDTO()
            {
                ErrorMessage = errorMessage.ToString(),
                StatusCode = StatusCodes.Status404NotFound
            };

            return new NotFoundObjectResult(output);
        }
    }
}
