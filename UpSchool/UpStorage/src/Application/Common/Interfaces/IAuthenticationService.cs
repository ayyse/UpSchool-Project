using Application.Common.Models.Auth;
using Application.Features.Auth.Commands.Login;

namespace Application.Common.Interfaces
{
    public interface IAuthenticationService
    {
        // burada parametre olarak command vermiyoruz çünkü ilerde cqrs kısmını projeden çıkarmak istersek bu kısımlar patlamayacak şekilde dizayn ettik
        Task<string> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken);
        Task<string> GenerateEmailActivationTokenAsync(string userId, CancellationToken cancellationToken);
        Task<bool> CheckIfUserExists(string email, CancellationToken cancellationToken);
        Task<JwtDto> LoginAsync(AuthLoginRequest authLoginRequest, CancellationToken cancellationToken);
    }
}
