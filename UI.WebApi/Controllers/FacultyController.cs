﻿using Core.Application.DTOs.Faculty;
using Core.Application.Exceptions;
using Core.Application.Features.Base.Requests.Commands;
using Core.Application.Features.Faculties.Requests.Commands;
using Core.Application.Features.Faculties.Requests.Queries;
using Core.Application.Transform;
using Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace UI.WebApi.Controllers
{
    [Route("api/faculty")]
    [ApiController]
    [Authorize]
    public class FacultyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacultyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lấy danh sách khoa
        /// </summary>
        /// <remarks>
        /// Ràng buộc: 
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<List<FacultyDto>>> Get([FromQuery] ListFacultyRequest<FacultyDto> request)
        {
            var response = await _mediator.Send(request);


            return StatusCode(response.Code, response);
        }

        /// <summary>
        /// Lấy thông tin khoa theo mã
        /// </summary>
        /// <remarks>
        /// Ràng buộc: 
        /// - Id: int, required
        /// </remarks>
        [HttpGet("detail")]
        public async Task<ActionResult<FacultyDto>> Get([FromQuery] DetailFacultyRequest request)
        {
            var response = await _mediator.Send(request);

            return StatusCode(response.Code, response);
        }

        /// <summary>
        /// Thêm khoa
        /// </summary>
        /// <remarks>
        /// Ràng buộc: 
        /// - Name: string, required, max(190)
        /// - PhoneNumber: string, length(10)
        /// - Email: string, email_format
        /// </remarks>
        [HttpPost]
        public async Task<ActionResult<FacultyDto>> Post([FromBody] CreateFacultyDto FacultyRequest)
        {
            var command = new CreateFacultyRequest { createFacultyDto = FacultyRequest };
            var response = await _mediator.Send(command);

            return StatusCode(response.Code, response);
        }

        /// <summary>
        /// Sửa khoa
        /// </summary>
        /// <remarks>
        /// Ràng buộc: 
        /// - Id: int, required
        /// - Name: string, required, max(190)
        /// - PhoneNumber: string, length(10)
        /// - Email: string, email_format
        /// </remarks>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateFacultyDto FacultyRequest)
        {
            var command = new UpdateFacultyRequest { updateFacultyDto = FacultyRequest };
            var response = await _mediator.Send(command);

            return StatusCode(response.Code, response);
        }

        /// <summary>
        /// Xóa khoa
        /// </summary>
        /// <remarks>
        /// Ràng buộc: 
        /// - Id: int, required
        /// </remarks>
        [HttpDelete]
        public async Task<ActionResult> Delete([FromForm] DeleteBaseRequest<Faculty> request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            catch (NotFoundException ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new { Error = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Error = ResponseTranform.ServerError });
            }
        }
    }
}