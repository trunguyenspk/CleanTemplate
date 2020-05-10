using MediatR;

namespace Application.EbatchSheets.Commands
{
    public class DeleteEbatchSheetCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
}
