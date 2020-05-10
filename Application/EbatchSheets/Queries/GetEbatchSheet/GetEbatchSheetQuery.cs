using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Cosmonaut;
using Application.Common.Models;
using Application.Common.Mappings;
using Application.Common.Constants;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Application.Identity;

namespace Application.EbatchSheets.Queries
{
    public class GetEbatchSheetQuery : IRequest<EbatchSheetVm>
    {
        public string Id { get; set; }
    }

    public class GetEbatchSheetQueryHandler : IRequestHandler<GetEbatchSheetQuery, EbatchSheetVm>
    {
        private readonly ICosmosStore<EbatchSheet> _cosmosStore;
        private readonly IHttpContextAccessor _httpContext;

        public GetEbatchSheetQueryHandler(ICosmosStore<EbatchSheet> context, IHttpContextAccessor httpContext)
        {
            _cosmosStore = context;
            _httpContext = httpContext;
        }

        public async Task<EbatchSheetVm> Handle(GetEbatchSheetQuery request, CancellationToken cancellationToken)
        {
            var ebatchSheet = await _cosmosStore.FindAsync(request.Id, Constants.EBATCH_SHEET_PARTITON_KEY);
            if (ebatchSheet != null)
            {
                var userRoles = _httpContext.HttpContext?.User?.FindAll("roles").Select(r => r.Value);
                if (userRoles.Contains(UserRole.AdminTeam))
                {
                    return ebatchSheet.ToViewEntity();
                }
                else
                {
                    var states = userRoles.Select(x => MappingExtention.GetReviewStateByRole(x).Value);
                    if (states.Contains(ebatchSheet.CurrentState.Value))
                    {
                        return ebatchSheet.ToViewEntity();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }

            //return ebatchSheet.ToViewEntity();
        }
    }
}
