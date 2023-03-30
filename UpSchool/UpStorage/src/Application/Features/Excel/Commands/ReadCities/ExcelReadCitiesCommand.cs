﻿using MediatR;

namespace Application.Features.Excel.Commands.ReadCities
{
    public class ExcelReadCitiesCommand : IRequest<object>
    {
        public string ExcelBase64File { get; set; }
    }
}
