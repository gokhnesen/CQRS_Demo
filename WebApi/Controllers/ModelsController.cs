using Application.Features.Brands.Queries.GetList;
using Application.Features.Dynamic;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListDynamic;
using Application.Features.Requests;
using Application.Features.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListModelListItemDto> response = await Mediator.Send(getListModelQuery);
            return Ok(response);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery=null)
        {
            try
            {
                GetListDynamicModelQuery getListDynamicModelQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
                GetListResponse<GetListDynamicModelListItemDto> response = await Mediator.Send(getListDynamicModelQuery);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, stackTrace = ex.StackTrace });
            }
        }
    }
}
