using Domain.Common;
using MediatR;

namespace Application.Features.Cities.Commands.Add
{
    public class CityAddCommand : IRequest<Response<int>> // response içinde city id tipini vermemiz gerekiyor
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
