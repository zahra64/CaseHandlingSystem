using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseHandling.MVVM.Models.Entities
{
    internal class TechnicianEntity
    {
        [Key]
        public int Id { get; set; }

        public ICollection<CommentEntity> Comments = new HashSet<CommentEntity>();
    }
}
