using HW_CreateCustomerApi_Common.Dtos;
using HW_CreateCustomerApi_Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HW_CreateCustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomersController(ICustomerService service)
        {
            this.service = service;
        }

        [HttpGet("list")]
        public IActionResult GetAllCustomers()
        {
            var data = service.GetAllCustomers();
            return Ok(data);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var result = service.GetCustomerById(id);
            if (result == null)
            {
                return BadRequest("Belirtilen id ile bir veri bulunamadı :(");
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Create([FromBody] AddNewCustomerDto dto)
        {
            var result = service.AddNewCustomer(dto);
            if (!result)
            {
                return BadRequest("Eklenmek İstenen Müşteri Zaten Mevcut ");
            }
            return Ok("Müşteri Eklendi");
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Remove([FromRoute] string id)
        {
            var result = service.DeleteCustomer(id);
            if (!result)
            {
                return BadRequest("Silinmek İstenen Müşteri Mevcut Değil ");
            }
            return Ok("Müşteri Silindi");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateCustomerDto dto, [FromRoute] string id)
        {
            var result = service.UpdateCustomer(dto,id);
            if (!result)
            {
                return BadRequest("Güncellenmek İstenen Müşteri Mevcut Değil ");
            }
            return Ok("Müşteri Güncellendi");
        }


    }
}
