using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Entities;
using Cosmonaut;
using Cosmonaut.Extensions;
using Application.Common.Models;
using Application.Common.Mappings;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;
using Application.Common.Exceptions;
using Application.Common.Constants;
using System;
using Microsoft.Extensions.Logging;
using Application.Identity;

namespace Application.EbatchSheets.Queries
{
    public class GetEbatchSheetsQuery : IRequest<IEnumerable<EbatchSheetVm>>
    {
    }

    public class GetEbatchSheetsQueryHandler : IRequestHandler<GetEbatchSheetsQuery, IEnumerable<EbatchSheetVm>>
    {
        private readonly ICosmosStore<EbatchSheet> _cosmosStore;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogger<GetEbatchSheetsQueryHandler> _logger;

        public GetEbatchSheetsQueryHandler(ICosmosStore<EbatchSheet> cosmosStore, IHttpContextAccessor httpContext, ILogger<GetEbatchSheetsQueryHandler> logger)
        {
            _cosmosStore = cosmosStore;
            _httpContext = httpContext;
            _logger = logger;
        }

        public async Task<IEnumerable<EbatchSheetVm>> Handle(GetEbatchSheetsQuery request, CancellationToken cancellationToken)
        {
            var userRoles = _httpContext.HttpContext?.User?.FindAll("roles").Select(r => r.Value);
            if (userRoles.Contains(UserRole.AdminTeam))
            {
                var allEbatchs = await _cosmosStore.Query(new FeedOptions()
                {
                    PartitionKey = new PartitionKey(Constants.EBATCH_SHEET_PARTITON_KEY)
                })
                .ToListAsync();

                if (allEbatchs.Count > 0)
                {
                    _logger.LogInformation("GET_EBATCHSHEET_BY_ADMIN: {@result}", allEbatchs);
                    return allEbatchs.Select(x => x.ToViewEntity());
                }
            }
            else
            {
                var states = userRoles.Select(x => MappingExtention.GetReviewStateByRole(x).Value);

                var ebatchSheets = await _cosmosStore.Query(new FeedOptions()
                {
                    PartitionKey = new PartitionKey(Constants.EBATCH_SHEET_PARTITON_KEY)
                })
                .Where(x => states.Contains(x.CurrentState.Value))
                .ToListAsync();

                if (ebatchSheets.Count > 0)
                {
                    _logger.LogInformation("GET_EBATCHSHEET_BY {@role} {@result}", userRoles, ebatchSheets);
                    return ebatchSheets.Select(x => x.ToViewEntity());
                }
            }
            return new List<EbatchSheetVm>();
        }
    }
}
