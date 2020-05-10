using Application.Common.Interfaces;
using Application.EbatchSheets.Commands;
using Application.EbatchSheets.Queries;
using Cosmonaut;
using Cosmonaut.Response;
using Domain.Commands;
using Domain.Entities;
using Domain.Enumerations;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using EbatchSheetEntity = Domain.Entities;
using MockQueryable;
using MockQueryable.Moq;

namespace UnitTests.Application
{
    public class ApplicationTests
    {
        public Mock<ICosmosStore<EbatchSheetEntity.EbatchSheet>> _cosmosStore;
        public Mock<IHttpContextAccessor> _httpContext;
        public Mock<ILogger<UpdateEbatchSheetCommandHandler>> _updateLogger;
        public Mock<ILogger<CreateEbatchSheetCommandHandler>> _createLogger;
        public Mock<ILogger<GetEbatchSheetsQueryHandler>> _queryLogger;
        public Mock<IEbatchSheetEmailSender> _mailSender;

        public ApplicationTests()
        {
            _cosmosStore = new Mock<ICosmosStore<EbatchSheetEntity.EbatchSheet>>();

            _httpContext = new Mock<IHttpContextAccessor>();

            _updateLogger = new Mock<ILogger<UpdateEbatchSheetCommandHandler>>();

            _createLogger = new Mock<ILogger<CreateEbatchSheetCommandHandler>>();

            _queryLogger = new Mock<ILogger<GetEbatchSheetsQueryHandler>>();

            _mailSender = new Mock<IEbatchSheetEmailSender>();

            _mailSender.Setup(f => f.SendEmail(It.IsAny<EbatchSheetEntity.EbatchSheet>())).Returns(Task.CompletedTask);
        }

        [Fact]
        public void Create_EbatchSheet_Successfully()
        {
            var createRequest = new CreateEbatchSheetCommand()
            {
                WorkOrderNumber = "WON_2020"
            };

            var addResponse = new CosmosResponse<EbatchSheetEntity.EbatchSheet>(new EbatchSheetEntity.EbatchSheet(), new ResourceResponse<Document>());

            _cosmosStore.Setup(f => f.AddAsync(It.IsAny<EbatchSheetEntity.EbatchSheet>(), null)).ReturnsAsync(addResponse);

            var createHandler = new CreateEbatchSheetCommandHandler(_cosmosStore.Object, _httpContext.Object, _createLogger.Object, _mailSender.Object);

            var result = createHandler.Handle(createRequest, CancellationToken.None);

            _cosmosStore.Verify(v => v.AddAsync(It.IsAny<EbatchSheetEntity.EbatchSheet>(), null));
        }

        [Fact]
        public void Update_State_By_Admin_Correctly()
        {
            var currentEbatchSheet = new EbatchSheetEntity.EbatchSheet()
            {
                CurrentState = EbatchState.ProductionReview
            };

            var updateRequest = new UpdateEbatchSheetCommand()
            {
                CurrentState = EbatchState.WarehouseReview
            };
            var updateResponse = new CosmosResponse<EbatchSheetEntity.EbatchSheet>(currentEbatchSheet, new ResourceResponse<Document>());

            _cosmosStore.Setup(f => f.FindAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(currentEbatchSheet);

            _cosmosStore.Setup(f => f.UpdateAsync(It.IsAny<EbatchSheetEntity.EbatchSheet>(), null)).ReturnsAsync(updateResponse);

            _httpContext.Setup(x => x.HttpContext.User.IsInRole(It.IsAny<string>())).Returns(true);

            var updateHandler = new UpdateEbatchSheetCommandHandler(_cosmosStore.Object, _httpContext.Object, _updateLogger.Object, _mailSender.Object);

            var result = updateHandler.Handle(updateRequest, CancellationToken.None);

            Assert.Equal(updateRequest.CurrentState.Value, updateResponse.Entity.CurrentState.Value);
        }

        [Fact]
        public void Update_Next_State_By_User_Correctly()
        {
            var currentEbatchSheet = new EbatchSheetEntity.EbatchSheet()
            {
                CurrentState = EbatchState.ProductionReview
            };

            var updateRequest = new UpdateEbatchSheetCommand()
            {
                CurrentState = EbatchState.ChillerReview
            };
            var updateResponse = new CosmosResponse<EbatchSheetEntity.EbatchSheet>(currentEbatchSheet, new ResourceResponse<Document>());

            _cosmosStore.Setup(f => f.FindAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(currentEbatchSheet);

            _cosmosStore.Setup(f => f.UpdateAsync(It.IsAny<EbatchSheetEntity.EbatchSheet>(), null)).ReturnsAsync(updateResponse);

            _httpContext.Setup(x => x.HttpContext.User.IsInRole(It.IsAny<string>())).Returns(false);

            var updateHandler = new UpdateEbatchSheetCommandHandler(_cosmosStore.Object, _httpContext.Object, _updateLogger.Object, _mailSender.Object);

            var result = updateHandler.Handle(updateRequest, CancellationToken.None);

            Assert.Equal(updateRequest.CurrentState.Value, updateResponse.Entity.CurrentState.Value);
        }

        [Fact]
        public void Update_Any_State_By_User_Failed()
        {
            var currentEbatchSheet = new EbatchSheetEntity.EbatchSheet()
            {
                CurrentState = EbatchState.ProductionReview
            };

            var updateRequest = new UpdateEbatchSheetCommand()
            {
                CurrentState = EbatchState.WarehouseReview
            };
            var updateResponse = new CosmosResponse<EbatchSheetEntity.EbatchSheet>(currentEbatchSheet, new ResourceResponse<Document>());

            _cosmosStore.Setup(f => f.FindAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(currentEbatchSheet);

            _cosmosStore.Setup(f => f.UpdateAsync(It.IsAny<EbatchSheetEntity.EbatchSheet>(), null)).ReturnsAsync(updateResponse);

            _httpContext.Setup(x => x.HttpContext.User.IsInRole(It.IsAny<string>())).Returns(false);

            var updateHandler = new UpdateEbatchSheetCommandHandler(_cosmosStore.Object, _httpContext.Object, _updateLogger.Object, _mailSender.Object);

            Assert.ThrowsAsync<InvalidStateChange>(() => updateHandler.Handle(updateRequest, CancellationToken.None));
        }
    }
}
