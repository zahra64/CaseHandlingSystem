using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseHandling.MVVM.Models.Entities
{
    internal class CommentEntity
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime CreatedCommentDate { get; set; } = DateTime.Now;


        [Required]
        public int CaseId { get; set; }
        public CaseEntity Case { get; set; } = null!;

        //[Required]
        //public int TechnicianId { get; set; }
        //public TechnicianEntity Technician { get; set; } = null!;

    }
}
