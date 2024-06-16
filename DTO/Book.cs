using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DTO
{
    public class Book
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ten { get; set; }

        [MaxLength(50)]
        public string DanhMuc { get; set; }

        [MaxLength(25)]
        public string TacGia { get; set; }

        public int TonKho { get; set; }
        public int TongSach { get; set; }
        public DateTime NamXuatBan { get; set; }
        public Boolean CanBorrow { get; set; }
        public virtual ICollection<Borrow> Borrows { get; set; }
    }
}
