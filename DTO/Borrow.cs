using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DTO
{
    public class Borrow
    {
        [ForeignKey("Student")]
        public long UserId { get; set; }

        [ForeignKey("Book")]
        public long BookId { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.Now;

        public int SoLuong { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual Student Student { get; set; }
        public virtual Book Book { get; set; }
    }
}
