using System;
using System.Data.Entity;
using System.Linq;
using LibraryManagement.DTO;

namespace LibraryManagement
{
    public class LibraryManagement : DbContext
    {
        public LibraryManagement()
            : base("name=LibraryManagement")
        {
            Database.SetInitializer(new LibraryDbInitializer());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Borrow> Borrows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Borrow>()
                .HasKey(b => new { b.BookId, b.UserId, b.BorrowDate });

            modelBuilder.Entity<Borrow>()
                .HasRequired(b => b.Student)
                .WithMany(s => s.Borrows)
                .HasForeignKey(b => b.UserId)
                .WillCascadeOnDelete(true); // Xóa Borrow khi xóa Student

            modelBuilder.Entity<Borrow>()
                .HasRequired(b => b.Book)
                .WithMany(bk => bk.Borrows)
                .HasForeignKey(b => b.BookId)
                .WillCascadeOnDelete(true); // Xóa Borrow khi xóa Book
        }
    }
}