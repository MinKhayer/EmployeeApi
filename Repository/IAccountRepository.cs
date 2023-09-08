using EmployeeApi.Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeApi.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(SignUpModel signUpModel);

        Task<string> Login(SignInModel sigInModel);
    }
}
