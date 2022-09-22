using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> _response)
        {
            if (_response.StatusCode == 204)
                return new ObjectResult(null) { StatusCode = _response.StatusCode };
            else
                return new ObjectResult(_response) { StatusCode = _response.StatusCode};
        }

    }
}
