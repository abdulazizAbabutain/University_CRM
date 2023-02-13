using MediatR;

namespace University_CRM.Application.Features.Collages.Commands
{
    public class AddCollageCommand : IRequest
    {
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string? DescriptionArabic { get; set; }
        public string? DescriptionEnglish { get; set; }
    }
}
