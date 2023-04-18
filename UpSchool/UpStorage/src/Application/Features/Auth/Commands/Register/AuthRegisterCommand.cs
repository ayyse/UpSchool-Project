using MediatR;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Application.Features.Auth.Commands.Register
{
    public class AuthRegisterCommand : IRequest<AuthRegisterDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public AuthRegisterCommand()
        {
            FullName = FirstName + LastName;
        }
    }
}
