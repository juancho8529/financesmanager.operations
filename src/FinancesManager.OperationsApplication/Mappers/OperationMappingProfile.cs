using AutoMapper;
using FinancesManager.Operations.Application.Commands;
using FinancesManager.Operations.Application.Responses;
using FinancesManager.Operations.Core.Entities;

namespace FinancesManager.Operations.Application.Mappers;

public class OperationMappingProfile : Profile
{
    public OperationMappingProfile()
    {
        CreateMap<Operation, CreateOperationCommand>().ReverseMap();
        CreateMap<Operation, OperationResponse>().ReverseMap();
    }
}
