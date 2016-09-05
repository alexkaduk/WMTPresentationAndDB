using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMTPresentation.Services.Dto
{
    public class ChapterDto
    {
        public string _id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public int? LastAction { get; set; }
        public string ChapterJson { get; set; }
        public string PresentationId { get; set; }
        public int SlidesCount { get; set; }
    }
}
