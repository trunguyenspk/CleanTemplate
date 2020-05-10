using Cosmonaut;
using Domain.Common;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IEbatchSheetEmailSender
    {
        Task SendEmail(EbatchSheet ebatchSheet);
    }
}
