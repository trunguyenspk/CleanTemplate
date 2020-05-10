using Application.Common.Constants;
using Application.Common.Exceptions;
using Cosmonaut;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EbatchSheets.Commands
{
    public class DeleteEbatchSheetCommandHandler : IRequestHandler<DeleteEbatchSheetCommand, string>
    {
        private readonly ICosmosStore<EbatchSheet> _cosmosStore;
        private readonly ILogger<DeleteEbatchSheetCommandHandler> _logger;

        public DeleteEbatchSheetCommandHandler(ICosmosStore<EbatchSheet> cosmosStore, ILogger<DeleteEbatchSheetCommandHandler> logger)
        {
            _cosmosStore = cosmosStore;
            _logger = logger;
        }

        public async Task<string> Handle(DeleteEbatchSheetCommand request, CancellationToken cancellationToken)
        {
            var result = await _cosmosStore.RemoveByIdAsync(request.Id,
                new Microsoft.Azure.Documents.Client.RequestOptions
                {
                    PartitionKey = new Microsoft.Azure.Documents.PartitionKey(Constants.EBATCH_SHEET_PARTITON_KEY)
                });
            if (result.ResourceResponse != null)
                return request.Id;

            _logger.LogError("DELETE_EBATCHSHEET: EBATCHSHEET IS NOT FOUND");
            throw new NotFoundException("EbatchSheet", request.Id);
        }
    }
}
