using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DTO
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MSSV { get; set; }

        [Required]
        [MaxLength(30)]
        public string TenSV { get; set; }

        public virtual ICollection<Borrow> Borrows { get; set; }
    }
}
