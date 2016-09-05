using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMTPresentation.Entities
{
    public class Presentation : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string _id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string DefaultFontSize { get; set; }
        public string Thumbnail { get; set; }
        public string PresentationJson { get; set; }

        public ICollection<Chapter> Chapters { get; set; }
    }
}
