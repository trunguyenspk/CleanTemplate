using Cosmonaut;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface ICosmosContext
    {
        ICosmosStore<EbatchSheet> EbatchSheet { get; set; }
    }
}
