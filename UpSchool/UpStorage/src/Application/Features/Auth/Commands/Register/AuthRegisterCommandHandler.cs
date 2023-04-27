using Application.Common.Interfaces;
using Application.Common.Models.Auth;
using MediatR;

namespace Application.Features.Auth.Commands.Register
{
    public class AuthRegisterCommandHandler : IRequestHandler<AuthRegisterCommand, AuthRegisterDto>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IJwtService _jwtservice;
        public AuthRegisterCommandHandler(IAuthenticationService authenticationService, IJwtService jwtservice)
        {
            _authenticationService = authenticationService;
            _jwtservice = jwtservice;
        }

        public async Task<AuthRegisterDto> Handle(AuthRegisterCommand request, CancellationToken cancellationToken)
        {
            var createUserDto = new CreateUserDto(request.FirstName, request.LastName, request.Email, request.Password);

            var userId = await _authenticationService.CreateUserAsync(createUserDto, cancellationToken);

            var emailToken = _authenticationService.GenerateEmailActivationTokenAsync(userId, cancellationToken);

            var fullName = $"{request.FirstName} {request.LastName}";

            var jwtDto = _jwtservice.Generate(userId, request.Email, request.FirstName, request.LastName);

            return new AuthRegisterDto(request.Email, fullName, jwtDto.AccessToken);
        }
    }
}
