using LibraryManagement.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.DTO;

namespace LibraryManagement.View
{
    public partial class DetailForm : Form
    {
        public delegate void MyDel(long Book_id);
        public MyDel d;
        Boolean Type = false;
        private void setUI(long Book_id)
        {
            QLTV qLTV = new QLTV();
            Book book = qLTV.GetBookByID(Book_id);
            txtID.Text = book.Id.ToString();
            txtID.ReadOnly = true;
            txtAuthor.Text = book.TacGia.ToString();
            txtCategory.Text = book.DanhMuc.ToString();
            txtName.Text = book.Ten;
            dtpPublish.Value = book.NamXuatBan;
            txtQty.Text = book.TonKho.ToString();
            txtTotal.Text = book.TongSach.ToString();
            if (book.CanBorrow)
            {
                rbCanBorrow.Checked = true;
            }
            else
            {
                rbReadonly.Checked = true;
            }
            Type = true;
        }
        public DetailForm()
        {
            InitializeComponent();
            d = setUI;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            QLTV qLTV = new QLTV();
            Book book = new Book
            {
                Id = Convert.ToUInt32(txtID.Text),
                Ten = txtName.Text,
                NamXuatBan = dtpPublish.Value,
                DanhMuc = txtCategory.Text,
                TacGia = txtName.Text,
                TongSach = Convert.ToInt32(txtTotal.Text),
                TonKho = Convert.ToInt32(txtQty.Text),
                CanBorrow = rbCanBorrow.Checked
            };
            if (Type == false)
            {
                qLTV.Add(book);
            }
            else
            {
                qLTV.Edit(book);
            }
            Dispose();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
