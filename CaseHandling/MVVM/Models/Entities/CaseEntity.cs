using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseHandling.MVVM.Models.Entities
{
    internal class CaseEntity
    {
        [Key]
        public int Id { get; set; } 
        public string Description { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime CreatedOnDate { get; set; } = DateTime.Now;

       
        [Column(TypeName = "nvarchar(20)")]
        public string Status { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public CustomerEntity Customer { get; set; } = null!;

        public ICollection<CommentEntity> Comments = new HashSet<CommentEntity>();

    }
    
}
