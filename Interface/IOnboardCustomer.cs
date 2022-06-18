using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Model;
using Test.Resources;

namespace Test.Interface
{
    public interface IOnboardCustomer
    {
        Task<Response> OnboardCustomer(Customer customer);
        Task<Response> GetAllCustomer();
        Task<Response> GetBanks();

    }
}
