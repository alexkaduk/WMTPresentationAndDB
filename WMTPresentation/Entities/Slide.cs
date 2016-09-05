using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMTPresentation.Entities
{
    public class Slide : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string _id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public bool Hidden { get; set; }
        public DateTime CDate { get; set; }
        public string SlideJson { get; set; }

        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }
    }
}
