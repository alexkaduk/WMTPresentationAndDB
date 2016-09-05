using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMTPresentation.Entities;
using WMTPresentation.Services.Dto;

namespace WMTPresentation.Services.Extensions
{
    public static class SlideExtension
    {
        public static SlideDto ToSlideDto(this Slide slide)
        {
            var s = new SlideDto
            {
                _id = slide._id,
                Title = slide.Title,
                Hidden = (slide.Hidden == false) ? "Hidden" : "Visible",
                ChapterId = slide.ChapterId.ToString(),
                CDate = slide.CDate.ToString("MM/dd/yyyy HH:mm:ss.fff",
                                CultureInfo.InvariantCulture)
            };

            return s;
        }
    }
}
