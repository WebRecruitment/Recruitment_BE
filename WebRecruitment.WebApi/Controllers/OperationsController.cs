using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebRecruitment.Application.Model.Request.OperationRequest;
using WebRecruitment.Application.Model.Response.OperationResponse;

using WebRecruitment.Domain.Entity;
using WebRecruitment.Application.IRepository.ApplyRepository;
using WebRecruitment.Application.IService;
using System.Net;

namespace WebRecruitment.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {

        private readonly IOperationService _operationService;

        public OperationsController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        // GET: api/Operations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseOperation>>> GetOperations()
        {
            var operation = await _operationService.GetAllOperation();
            return Ok(new
            {
                Success = true,
                Data = operation,
            });

        }

        // GET: api/Operations/5
        [HttpGet]
        public async Task<ActionResult<Operation>> GetOperationById(Guid id)
        {
            try
            {
                var operation = await _operationService.GetByOperationId(id);
                return Ok(new
                {
                    Success = true,
                    Data = operation,
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    Success = HttpStatusCode.InternalServerError,
                    Message = "Failed",
                    Error = ex.Message
                });
            }
        }


        // POST: api/Operations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseOperation>> PostOperation(RequestCreateOperation requestCreateOperation)
        {

            var response = await _operationService.CreateOperationCompany(requestCreateOperation);
            return response == null ? BadRequest() : Ok(new
            {
                Success = true,
                Data = response
            });
        }
    }
}
