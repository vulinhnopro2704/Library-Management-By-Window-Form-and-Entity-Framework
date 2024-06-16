using LibraryManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace LibraryManagement.BLL
{
    public class QLTV
    {

        private LibraryManagement lb;

        public QLTV()
        {
            lb = new LibraryManagement();
        }

        public static List<Book> GetBooksFromDataGridView(DataGridView dataGridView)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(nameof(dataGridView));

            List<Book> books = new List<Book>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue; 

                Book book = new Book
                {
                    Id = Convert.ToInt64(row.Cells["Id"].Value),
                    Ten = Convert.ToString(row.Cells["Ten"].Value),
                    DanhMuc = Convert.ToString(row.Cells["DanhMuc"].Value),
                    TacGia = Convert.ToString(row.Cells["TacGia"].Value),
                    TonKho = Convert.ToInt32(row.Cells["TonKho"].Value),
                    TongSach = Convert.ToInt32(row.Cells["TongSach"].Value),
                    NamXuatBan = Convert.ToDateTime(row.Cells["NamXuatBan"].Value),
                    CanBorrow = Convert.ToBoolean(row.Cells["CanBorrow"].Value)
                };

                books.Add(book);
            }

            return books;
        }

        public delegate int ComparisonDelegate<T>(T x, T y);
        public static List<T> GenericSort<T>(List<T> list, ComparisonDelegate<T> comparison)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (comparison == null)
                throw new ArgumentNullException(nameof(comparison));

            // Sử dụng thuật toán sắp xếp bất kỳ (ví dụ: Bubble Sort) với delegate so sánh
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (comparison(list[i], list[j]) > 0)
                    {
                        // Hoán đổi vị trí
                        T temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }

            return list;
        }
        //Get All
        public List<Book> GetAllBooks()
        {
            
            return lb.Books.ToList();
        }

        public List<String> GetAllBooksColumnName()
        {
            Book book = new Book();
            return GetPropertyNames(book);
        }

        public List<Student> GetAllStudents()
        {
            
            return lb.Students.ToList();
        }

        //Search
        //Book
        public List<Book> GetAllBookBySearch(string search, int type = 0)
        {
            

            DateTime? searchDate = null;
            int searchInt = 0; // Biến để lưu giá trị integer nếu search là số

            // Kiểm tra xem search có phải là số nguyên không
            bool isNumeric = int.TryParse(search, out searchInt);

            // Nếu search là ngày thì chuyển đổi thành DateTime
            if (!isNumeric && DateTime.TryParse(search, out DateTime parsedDate))
            {
                searchDate = parsedDate.Date;
            }

            var query = lb.Books.Where(p =>
                p.Id.ToString().Equals(search)  
                || p.Ten.Contains(search)                
                || p.DanhMuc.Contains(search)                
                || (searchInt != 0 && p.TonKho == searchInt) 
                || (searchInt != 0 && p.TongSach == searchInt)
                || (searchDate.HasValue && DbFunctions.TruncateTime(p.NamXuatBan) == searchDate.Value));

            switch (type)
            {
                case 1:
                    query = query.Where(p => p.CanBorrow == true);
                    break;
                case 2:
                    query = query.Where(p => p.CanBorrow == false || (p.TongSach - p.TonKho) == 0);
                    break;
                case 3:
                    query = query.Where(p => p.CanBorrow == true && (p.TongSach - p.TonKho) > 0);
                    break;
                default:
                    break;
            }

            return query.ToList();
        }

        private Borrow GetBorrowByAll(int mSSV, long book_id, DateTime date)
        {
            

            // Bỏ đi phần ".Date" ở đây và so sánh trong khoảng thời gian từ 00:00:00 đến 23:59:59 của ngày được cung cấp
            DateTime startDate = date.Date;
            DateTime endDate = date.Date.AddDays(1).AddTicks(-1);

            return lb.Borrows.FirstOrDefault(p => p.Student.MSSV == mSSV
                                                && p.BookId == book_id
                                                && p.BorrowDate >= startDate
                                                && p.BorrowDate <= endDate);
        }

        public Student GetStudentByID(long ID)
        {
            
            return lb.Students.Where(p => p.MSSV == ID).FirstOrDefault();
        }

        //Add, Edit, Delete Book
        public void Add(Book newBook)
        {
            if (newBook != null && !CheckBookExist(newBook.Id))
            {
                
                lb.Books.Add(newBook);
                lb.SaveChanges();
                MessageBox.Show("Adding new Book successful!!!");
                return;
            }
            MessageBox.Show("Can't Add this Book!!!");
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                MessageBox.Show(nameof(student));
            }

            if (string.IsNullOrWhiteSpace(student.TenSV))
            {
                MessageBox.Show("Student name is required.", nameof(student.TenSV));
            }

            if (student.TenSV.Length > 30)
            {
                MessageBox.Show("Student name cannot be longer than 30 characters.", nameof(student.TenSV));
            }

            try
            {
                using (LibraryManagement lb = new LibraryManagement())
                {
                    lb.Students.Add(student);
                    lb.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        MessageBox.Show($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                    }
                }
                throw;
            }
        }

        public void AddBorrowBooks(int MSSV, long Book_id, DateTime date)
        {
                // Ngày được truyền vào là có giá trị
                
                Borrow borrow = GetBorrowByAll(MSSV, Book_id, DateTime.Now);
                if (borrow != null)
                {
                    borrow.SoLuong++;
                }
                else
                {
                    lb.Borrows.Add(new Borrow
                    {
                        UserId = MSSV,
                        BookId = Book_id,
                        BorrowDate = DateTime.Now,
                        SoLuong = 1,
                        ReturnDate = DateTime.Now.AddDays(30)
                    });
                }
                lb.SaveChanges();
        }


        public void Delete(long id)
        {
            if (id != null && CheckBookExist(id))
            {
                
                Book book = GetBookByID(id);
                if (book != null)
                {
                    lb.Books.Remove(book);
                    lb.SaveChanges();
                    MessageBox.Show("Delete Completely!!!");
                }
                else
                {
                    MessageBox.Show("khoong ton tai");
                }
                return;
            }
            MessageBox.Show("Book Doesn't Exist!!!");
        }

        public void Edit(Book book)
        {
            
            Book Book = GetBookByID(book.Id);
            if (Book != null) {
                Book.Ten = book.Ten;
                Book.NamXuatBan = book.NamXuatBan;
                Book.CanBorrow = book.CanBorrow;
                Book.TonKho = book.TonKho;
                Book.TongSach = book.TongSach;
                Book.TacGia = book.TacGia;
                lb.SaveChanges();
                MessageBox.Show("Modify Completely");
                return;
            }
            MessageBox.Show("Modify fail!!!");
        }

        //Sort by search
        public List<Book> SortByColumn(string ColumnName, string search)
        {
            IQueryable<Book> queryable = GetAllBookBySearch(search).AsQueryable();
            return queryable.OrderBy(ColumnName).ToList();
        }

        public List<Book> SortByGeneric(DataGridView dataGridView, string columnName, bool ascending = true)
        {
            if (dataGridView == null)
            {
                MessageBox.Show("Data grid View null");
                return null;
            }

            if (string.IsNullOrEmpty(columnName))
            {
                MessageBox.Show("Column Name is Null");
                return null;
            }

            List<Book> books = GetBooksFromDataGridView(dataGridView);

            ComparisonDelegate<Book> comparison = null;
            switch (columnName)
            {
                case "Id":
                    comparison = (x, y) => x.Id.CompareTo(y.Id);
                    break;
                case "Ten":
                    comparison = (x, y) => string.Compare(x.Ten, y.Ten);
                    break;
                case "DanhMuc":
                    comparison = (x, y) => string.Compare(x.DanhMuc, y.DanhMuc);
                    break;
                case "TacGia":
                    comparison = (x, y) => string.Compare(x.TacGia, y.TacGia);
                    break;
                case "TonKho":
                    comparison = (x, y) => x.TonKho.CompareTo(y.TonKho);
                    break;
                case "TongSach":
                    comparison = (x, y) => x.TongSach.CompareTo(y.TongSach);
                    break;
                case "NamXuatBan":
                    comparison = (x, y) => x.NamXuatBan.CompareTo(y.NamXuatBan);
                    break;
                case "CanBorrow":
                    comparison = (x, y) => x.CanBorrow.CompareTo(y.CanBorrow);
                    break;
                default:
                    MessageBox.Show("Invalid Column Name");
                    return null;
            }

            books = GenericSort(books, comparison);

            if (!ascending)
            {
                books.Reverse();
            }

            return books;
        }

        //Logic
        private bool CheckBookExist(long id)
        {
            
            return lb.Books.Where(p => p.Id == id).Any();
        }

        public Book GetBookByID(long id)
        {

            return lb.Books.Where(p => p.Id == id).FirstOrDefault();
        }

        private List<string> GetPropertyNames<T>(T obj)
        {
            List<string> propertyNames = new List<string>();

            // Lấy kiểu của đối tượng
            Type type = typeof(T);

            // Lấy tất cả các thuộc tính của kiểu đó
            PropertyInfo[] properties = type.GetProperties();

            // Thêm tên của các thuộc tính vào danh sách
            foreach (var property in properties)
            {
                propertyNames.Add(property.Name);
            }

            return propertyNames;
        }

        public void ReturnBook(long Book_id, long MSSV)
        {
            
            Borrow borrow = lb.Borrows.Where(p => p.UserId == MSSV && p.BookId == Book_id).FirstOrDefault();
            borrow.SoLuong--;
            if (borrow.SoLuong == 0)
            {
                lb.Borrows.Remove(borrow);
            }
            lb.SaveChanges();
        }
    } 
}
