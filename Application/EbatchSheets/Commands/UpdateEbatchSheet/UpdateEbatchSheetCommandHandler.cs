using Application.Common.Constants;
using Application.Common.Exceptions;
using Cosmonaut;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using Domain.Commands;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Application.Common.Interfaces;
using Application.Identity;

namespace Application.EbatchSheets.Commands
{
    public class UpdateEbatchSheetCommandHandler : IRequestHandler<UpdateEbatchSheetCommand, string>
    {
        private readonly ICosmosStore<EbatchSheet> _cosmosStore;
        private readonly ILogger<UpdateEbatchSheetCommandHandler> _logger;
        private readonly IEbatchSheetEmailSender _ebatchSheetEmailSender;
        private readonly IHttpContextAccessor _httpContext;

        public UpdateEbatchSheetCommandHandler(ICosmosStore<EbatchSheet> cosmosStore,
            IHttpContextAccessor httpContext,
            ILogger<UpdateEbatchSheetCommandHandler> logger,
            IEbatchSheetEmailSender ebatchSheetEmailSender)
        {
            _cosmosStore = cosmosStore;
            _httpContext = httpContext;
            _logger = logger;
            _ebatchSheetEmailSender = ebatchSheetEmailSender;
        }

        public async Task<string> Handle(UpdateEbatchSheetCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(nameof(UpdateEbatchSheetCommandHandler) + "UPDATE_EBATCHSHEET: {requestId} - {@BODY} ", request.Id, request);

            var ebatchSheet = await _cosmosStore.FindAsync(request.Id, Constants.EBATCH_SHEET_PARTITON_KEY);

            var user = _httpContext.HttpContext?.User;

            if (ebatchSheet != null)
            {
                var currentState = ebatchSheet.CurrentState;
                var requestedState = request.CurrentState;

                ebatchSheet.UpdateDataWithoutChangingState(request);

                if (!requestedState.Equals(currentState))
                {
                    if (user.IsInRole(UserRole.AdminTeam))
                    {
                        ebatchSheet.ChangeState(requestedState);
                    }
                    else
                    {
                        ebatchSheet.ProceedNextState(requestedState);
                    }
                }

                var result = await _cosmosStore.UpdateAsync(ebatchSheet);

                if (!currentState.Equals(result.Entity.CurrentState))
                {
                    await _ebatchSheetEmailSender.SendEmail(ebatchSheet);
                }
                return request.Id;
            }
            else
            {
                var exception = new NotFoundException($"EBATCHSHEET", request.Id);
                _logger.LogError(exception, $"[UpdateEbatchSheetCommandHandler] Ebatchsheet {request.Id} not found");
                throw exception;
            }
        }
    }
}
