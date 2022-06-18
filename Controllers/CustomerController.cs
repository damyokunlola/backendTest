using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Interface;
using Test.Model;
using Test.Resources;

namespace Test.Controllers
{
    [Route("Test/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IOnboardCustomer _onboardCustomer;
        public CustomerController(IOnboardCustomer onboardCustomer)
        {
            _onboardCustomer = onboardCustomer;
        }
        [HttpPost, Route("NewCustomer")]
        public async Task<IActionResult> NewCustomer(Customer customer)
        {
            try
            {
                var result = _onboardCustomer.OnboardCustomer(customer);
                if (result==null)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet, Route("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                var result =await _onboardCustomer.GetAllCustomer();
                if (result == null)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet, Route("GetBanks")]
        public async Task<IActionResult> GetBanks()
        {
            try
            {
                var result =await _onboardCustomer.GetBanks();
                if (result == null)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
