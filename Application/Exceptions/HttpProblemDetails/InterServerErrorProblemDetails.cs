using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Exceptions.HttpProblemDetails
{
    public class InterServerErrorProblemDetails : ProblemDetails
    {
        public InterServerErrorProblemDetails(string detail)
        {
            Title = "Internal Server Error";
            Detail = "Internal Server Error";
            Status = StatusCodes.Status500InternalServerError;
            Type = "https://example.com/prob/internal";
        }
    }
}
