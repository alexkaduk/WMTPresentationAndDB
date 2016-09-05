using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMTPresentation.Entities
{
    public class Chapter : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string _id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public int? LastAction { get; set; }
        public string ChapterJson { get; set; }

        public Presentation Presentation { get; set; }
        public int PresentationId { get; set; }

        public ICollection<Slide> Slides { get; set; }
    }
}
