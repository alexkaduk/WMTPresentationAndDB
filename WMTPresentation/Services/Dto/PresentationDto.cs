using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMTPresentation.Services.Dto
{
    public class PresentationDto
    {
        public string _id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string DefaultFontSize { get; set; }
        public string Thumbnail { get; set; }
        public string PresentationJson { get; set; }
        public int ChaptersCount { get; set; }
    }
}
