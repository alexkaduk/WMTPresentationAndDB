using WMTPresentation.Entities;
using WMTPresentation.Services.Dto;

namespace WMTPresentation.Services.Extensions
{
    public static class PresentationExtansion
    {
        public static PresentationDto ToPresentationDto(this Presentation presentation)
        {
            var p = new PresentationDto
            {
                _id = presentation._id,
                Title = presentation.Title,
                DefaultFontSize = presentation.DefaultFontSize,
                Thumbnail = presentation.Thumbnail,
                CreatedAt = presentation.CreatedAt,
                PresentationJson = presentation.PresentationJson,
                ChaptersCount = presentation.Chapters.Count
            };

            return p;
        }
    }
}
