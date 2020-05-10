using Application.Common.Interfaces;
using Cosmonaut;
using Domain.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EbatchSheets.Commands
{
    public class CreateEbatchSheetCommandHandler : IRequestHandler<CreateEbatchSheetCommand, string>
    {
        private readonly ICosmosStore<EbatchSheet> _cosmosStore;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogger<CreateEbatchSheetCommandHandler> _logger;
        private readonly IEbatchSheetEmailSender _ebatchSheetEmailSender;

        public CreateEbatchSheetCommandHandler(ICosmosStore<EbatchSheet> cosmosStore, 
            IHttpContextAccessor httpContext, 
            ILogger<CreateEbatchSheetCommandHandler> logger,
            IEbatchSheetEmailSender ebatchSheetEmailSender)
        {
            _cosmosStore = cosmosStore;
            _httpContext = httpContext;
            _logger = logger;
            _ebatchSheetEmailSender = ebatchSheetEmailSender;
        }

        public async Task<string> Handle(CreateEbatchSheetCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CREATE_NEW_EBATCHSHEET : {@request} ", request);

            var newEbatch = new EbatchSheet();

            newEbatch.Create(request);

            await _cosmosStore.AddAsync(newEbatch);

            await _ebatchSheetEmailSender.SendEmail(newEbatch);

            return newEbatch.Id;
        }
    }
}
