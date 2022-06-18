using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Test.Interface;
using Test.Model;
using Test.Resources;

namespace Test.Sevices
{
    public class OnboardCustomerService :IOnboardCustomer
    {
        private readonly IHttpClientFactory _clienttFactory;
        private readonly TestDbContext _dbContext;
        IOptions<ConnectionConfig> _config;
        public Banks banks { get; set; }

        public OnboardCustomerService(TestDbContext dbContext, IHttpClientFactory clienttFactory, IOptions<ConnectionConfig> option)
        {
            _dbContext = dbContext;
            _clienttFactory = clienttFactory;
            _config = option;
        }

      
        public async  Task<Response>OnboardCustomer(Customer customer)
        {
            try
            {

                var pwd = PasswordResource.Encrypt(customer.Password);

                _dbContext.Customer.Add(new Customer
               {
                   Email=customer.Email,
                   PhoneNumber=customer.PhoneNumber,
                   StateOfResident = customer.StateOfResident,
                   LGA=customer.LGA,
                   Password=pwd
               });

                var checkEmail = _dbContext.Customer.Find(customer.Email);
                if (checkEmail == null)
                {
                    return new Response { Status = true, ResponseCode = "-1", ResponseMessage = "Email already exist" };

                    
                }
                else
                {
                    _dbContext.SaveChanges();
                    return new Response { Status = true, ResponseCode = "00", ResponseMessage = "Customer Added" };
                }
            }
            catch (Exception ex)
            {

                return new Response { Status = true, ResponseCode = "-1", ResponseMessage=ex.Message };
            }
        }


        public async Task<Response> GetAllCustomer()
        {
            var result= _dbContext.Customer;
            return new Response { Status = true, ResponseCode = "00", ResponseMessage = "Success", ResponseData=result };

        }

        public async Task<Response> GetBanks()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks?");
                request.Headers.Add("Ocp-Apim-Subscription-Key", "2b7bdebb3bca4fb584f6e58f424385c5");

                var client = _clienttFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStreamAsync();

                    banks = await JsonSerializer.DeserializeAsync<Banks>(result);
                    return new Response { Status = true, ResponseCode = "00", ResponseMessage = "Success", ResponseData = banks };
                }
                else
                {
                    return new Response { ResponseData = response.ReasonPhrase, ResponseCode = "05", ResponseMessage = "Failed" };

                }
            }
            catch (Exception ex)
            {

                return new Response { ResponseCode = "-1", ResponseMessage = "Failed" };
            }
        }
    }
}
