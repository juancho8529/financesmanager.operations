using AutoMapper;
using FinancesManager.Operations.Application.Commands;
using FinancesManager.Operations.Application.Responses;
using FinancesManager.Operations.Core.Entities;

namespace FinancesManager.Operations.Application.tests;
public class MappingTest : Profile
{
    public MappingTest() {
        CreateMap<Operation, OperationResponse>().ReverseMap();
    }

}
