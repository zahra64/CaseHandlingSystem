using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseHandling.MVVM.Models
{
    public class Case
    {
        public int Id { get; set; }
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedOnDate { get; set; } = DateTime.Now;
        public string Status { get; set; }

    }
}
