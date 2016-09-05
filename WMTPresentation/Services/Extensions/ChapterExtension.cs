using WMTPresentation.Entities;
using WMTPresentation.Services.Dto;

namespace WMTPresentation.Services.Extensions
{
    public static class ChapterExtension
    {
        public static ChapterDto ToChapterDto(this Chapter chapter, int presentationId)
        {
            var c = new ChapterDto
            {
                _id = chapter._id,
                Title = chapter.Title,
                LastAction = chapter.LastAction,
                Order = chapter.Order,
                ChapterJson = chapter.ChapterJson,
                PresentationId = presentationId.ToString(),
                SlidesCount = chapter.Slides.Count
            };

            return c;
        }
    }
}
