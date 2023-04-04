using Application.Common.Interfaces;
using Application.Common.Models.Excel;
using Domain.Common;
using MediatR;

namespace Application.Features.Excel.Commands.ReadCities
{
    public class ExcelReadCitiesCommandHandler : IRequestHandler<ExcelReadCitiesCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IExcelService _excelService;

        public ExcelReadCitiesCommandHandler(IApplicationDbContext applicationDbContext, IExcelService excelService)
        {
            _applicationDbContext = applicationDbContext;
            _excelService = excelService;
        }

        public async Task<Response<int>> Handle(ExcelReadCitiesCommand request, CancellationToken cancellationToken)
        {
            var cityDtos = _excelService.ReadCities(MapCommandToExcelBase64Dto(request));

            var cities = cityDtos.Select(x => x.MapToCity()).ToList(); // ToList() olmayınca IEnumerable olur

            await _applicationDbContext.Cities.AddRangeAsync(cities, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>($"{cities.Count} cities were added to the db successfully", cities.Count);
            // ToList => Count
            // IEnumerable => Count()

            // cities.ToList() kullandığımız için cities.Count tek sefer çalışır ve her çağrıldığında aynı sonucu döner
            // IEnumerable olduğunda cities.Count() her defasında çalışır ve performans kaybı yaşanmasına sebep olur
        }

        private ExcelBase64Dto MapCommandToExcelBase64Dto(ExcelReadCitiesCommand command)
        {
            return new ExcelBase64Dto()
            {
                File = command.ExcelBase64File
            };
        }
    }
}
