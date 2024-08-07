﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ServitiaTest_Backend_Api.Controllers
{
    [ApiController]
    //[ApiExceptionFilter]
    [Route("api/[controller]/[action]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
