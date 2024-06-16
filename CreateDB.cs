using LibraryManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class LibraryDbInitializer : DropCreateDatabaseIfModelChanges<LibraryManagement>
    {
        protected override void Seed(LibraryManagement context)
        {
            // Thêm sách mẫu
            context.Books.Add(new Book
            {
                Id = 1,
                Ten = "Book 1",
                DanhMuc = "Category 1",
                TacGia = "Author 1",
                TonKho = 10,
                TongSach = 10,
                NamXuatBan = DateTime.Now.AddYears(-1),
                CanBorrow = false
            });

            context.Books.Add(new Book
            {
                Id = 2,
                Ten = "Book 2",
                DanhMuc = "Category 2",
                TacGia = "Author 2",
                TonKho = 7,
                TongSach = 10,
                NamXuatBan = DateTime.Now.AddYears(-2),
                CanBorrow = true
            });

            context.Books.Add(new Book
            {
                Id = 3,
                Ten = "Book 3",
                DanhMuc = "Category 3",
                TacGia = "Author 3",
                TonKho = 10,
                TongSach = 15,
                NamXuatBan = DateTime.Now.AddYears(-2),
                CanBorrow = true
            });

            // Thêm sinh viên mẫu
            context.Students.Add(new Student { MSSV = 10000000, TenSV = "Student 1" });
            context.Students.Add(new Student { MSSV = 10000001, TenSV = "Student 2" });
            context.Students.Add(new Student { MSSV = 10000002, TenSV = "Student 3" });
            context.Students.Add(new Student { MSSV = 10000003, TenSV = "Student 4" });
            base.Seed(context);
        }
    }
}
