using Azure.Core;
using LoanTable.Application.DTO;
using LoanTable.Application.Interfaces;
using LoanTable.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoanTable.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoanController : ControllerBase
  {
    ILoanRepo repo;

    public LoanController(ILoanRepo repo)
    {
      this.repo = repo;

    }

    [HttpPost]
    [Route("/create")]
    public async Task<IActionResult> createLoans(CreateLoanRequest req)
    {
      var pdata = repo.CreateLoanAsync(req);
      return Ok(new { message = "Loan created Successfully" });
    }

   

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> getLoansById(int id) {
      var data = await repo.GetLoanByIdAsync(id);
      var response = new ApiResponse<object>
      {
        Success = true,
        StatusCode = 200,
        Message = "Loan retrieved successfully",
        Data = data,
        Errors = null,
        Meta = new { Timestamp = DateTime.UtcNow }
      };
      return Ok(response); 
    }

    [HttpGet]
    [Route("/loans/{id}/schedule")]
    public async Task<IActionResult> getEmiSchedule(int id)
    {
      //var data = await repo.GetEmiScheduleAsync(id);

      var response = new ApiResponse<object>
      {
        Success = true,
        StatusCode = 200,
        Message = "Schedule retrieved successfully",
        //Data = data,
        Errors = null,
        Meta = new { Timestamp = DateTime.UtcNow }
      };
      return Ok(response);
    }

    [HttpGet]
    [Route("/customer/{id}")]

    public async Task<IActionResult> getLoanByCustomer(int id) {
      var data = await repo.GetLoansByCustomerAsync(id);

      var response = new ApiResponse<object>
      {
        Success = true,
        StatusCode = 200,
        Message = "Loan retrieved successfully",
        Data = data,
        Errors = null,
        Meta = new { Timestamp = DateTime.UtcNow }
      };

      return Ok(response);
    }

    [HttpGet]
    [Route("/GetBallance/{id}")]
    public async Task<IActionResult> getbalance(int id) {
       var data = await repo.GetBalanceAsync(id);
      var response = new ApiResponse<object>
      {
        Success = true,
        StatusCode = 200,
        Message = "Balance retrieved successfully",
        Data = data,
        Errors = null,
        Meta = new { Timestamp = DateTime.UtcNow }
      };
      return Ok(response);
    }

    [HttpGet]
    [Route("/GetOutstanding/{id}")]
    public async Task<IActionResult> getOutstanding(int id)
    {
      var data = await repo.GetOutstandingAsync(id);
      var response = new ApiResponse<object>
      {
        Success = true,
        StatusCode = 200,
        Message = "Outstanding retrieved successfully",
        Data = data,
        Errors = null,
        Meta = new { Timestamp = DateTime.UtcNow }
      };
      return Ok(response);
    }

    [HttpPatch]
    [Route("/update/{id}")]
    public async Task <IActionResult> updateStatus(int id,string status)
    {
      var data = await repo.UpdateStatusAsync(id,status);
      return Ok(new {message ="Customer status updated Successfully" });
    }

    [HttpGet]
    [Route("/api/Loan/active")]
    public async Task<IActionResult> getActiveLoans()
    {
      var data = await repo.GetActiveLoansAsync();
      var response = new ApiResponse<object>
      {
        Success = true,
        StatusCode = 200,
        Message = "Active loans retrieved successfully",
        Data = data,
        Errors = null,
        Meta = new { Timestamp = DateTime.UtcNow }
      };
      return Ok(response);
    }

  }
}
