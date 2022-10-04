using AutoMapper;
using FinancesManager.Operations.Application.Commands;
using FinancesManager.Operations.Application.Handlers;
using FinancesManager.Operations.Application.Queries;
using FinancesManager.Operations.Core.Entities;
using FinancesManager.Operations.Infrastructure.Data;
using FinancesManager.Operations.Infrastructure.Repositories;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace FinancesManager.Operations.Application.tests;

public class OperationTest
{
    private IEnumerable<Operation> GetDummyOperations()
    {

        A.Configure<Operation>()
            .Fill(x => x.Id, () => (new Random()).Next(10000))
            .Fill(x => x.UserId, () => Guid.NewGuid())
            .Fill(x => x.Earning, () => Convert.ToBoolean((new Random()).Next() % 2))
            .Fill(x => x.EffectedDate).AsPastDate()
            .Fill(x => x.Ammount, () => (new Random()).NextSingle() * 10000)
            .Fill(x => x.Currency, () => "CAD")
            .Fill(x => x.Description).AsLoremIpsumWords()
            .Fill(x => x.Categories, () => "mercado,sevicios");

        var list = A.ListOf<Operation>(30);
        list[0].UserId = Guid.Empty;
        list[0].EffectedDate = DateTime.Now;

        return list;
    }

    private Mock<OperationContext> CreateContext()
    {

        var dataPrueba = GetDummyOperations().AsQueryable();

        var dbSet = new Mock<DbSet<Operation>>();
        dbSet.As<IQueryable<Operation>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);
        dbSet.As<IQueryable<Operation>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);
        dbSet.As<IQueryable<Operation>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);
        dbSet.As<IQueryable<Operation>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator());

        dbSet.As<IAsyncEnumerable<Operation>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
        .Returns(new AsyncEnumerator<Operation>(dataPrueba.GetEnumerator()));


        dbSet.As<IQueryable<Operation>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Operation>(dataPrueba.Provider));


        var contexto = new Mock<OperationContext>();
        contexto.Setup(x => x.Operations).Returns(dbSet.Object);
        return contexto;
    }

    [Fact]
    public async void CreateOperationTest()
    {
        var request = new CreateOperationCommand() {
            userId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            Earning = false,
            EffectedDate= DateTime.Now,
            Ammount = 102.31F,
            Currency = "CAD",
            Description = "mercado test",
            Categories = "mercado"
        };

        var options = new DbContextOptionsBuilder<OperationContext>()
            .UseInMemoryDatabase(databaseName: "OperationsDB")
            .Options;


        var operationContext = new OperationContext(options);
        var operationRepository = new OperationRepository(operationContext);
        var createOperationHandler = new CreateOperationHandler(operationRepository);

        var response = await createOperationHandler.Handle(request, new System.Threading.CancellationToken());

        Assert.True(request.userId == response.UserId);
    }

    [Fact]
    public async void GetAllOperationsQuery()
    {
        var mockOperationContext = CreateContext();
        var mapConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingTest());
        });

        var operationRepository = new OperationRepository(mockOperationContext.Object);
        var mapper = mapConfig.CreateMapper();



        var request = new GetAllOperationsQuery(
            userId: Guid.Empty, 
            startDate: DateTime.Now.AddDays(-1), 
            endDate: DateTime.Now);

        var handler = new GetAllOperationsHandler(operationRepository);
        var list = await handler.Handle(request, new CancellationToken());
        Assert.True(list.Any());
    }
}
