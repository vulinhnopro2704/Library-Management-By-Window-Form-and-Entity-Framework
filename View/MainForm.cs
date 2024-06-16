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
using Microsoft.VisualBasic;
using LibraryManagement.View;

namespace LibraryManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            QLTV qLTV = new QLTV();
            RefreshDGV();
            cbbSort.Items.AddRange(qLTV.GetAllBooksColumnName().ToArray());
            cbbShow.Items.AddRange(new CbbItem[] {
                    new CbbItem
                    {
                        Text = "All",
                        Value = 0,
                    },
                    new CbbItem
                    {
                        Text = "Can Borrow",
                        Value = 1,
                    },
                    new CbbItem
                    {
                        Text = "Read Only/Run out",
                        Value = 2,
                    },
                    new CbbItem
                    {
                        Text = "Borrowing",
                        Value = 3,
                    }
            });
            cbbShow.SelectedIndex = 0;
            cbbSort.SelectedIndex = 0;
        }

        private void txtMSSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void RefreshDGV()
        {
            QLTV qLTV = new QLTV();
            dataGridView1.DataSource = qLTV.GetAllBooks();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text.Length == 8) {
                QLTV qLTV = new QLTV();
                Student student = qLTV.GetStudentByID(Convert.ToInt32(txtMSSV.Text));
                if (student != null)
                {
                    txtName.Text = student.TenSV;
                }
                else
                {
                    MessageBox.Show("txtMSSV.Text, không tồn tại");
                    DialogResult result = MessageBox.Show("Do you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string userName = Interaction.InputBox("Please enter your name:", "Name Input", "");
                        if (!string.IsNullOrWhiteSpace(userName))
                        {
                            MessageBox.Show("You entered: " + userName);
                            qLTV.AddStudent(new Student { MSSV = Convert.ToInt32(txtMSSV.Text), TenSV = userName });
                            txtName.Text = userName;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("No name entered.");
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        MessageBox.Show("Bạn chọn không thêm sinh viên đó " + txtMSSV.Text);
                        return;
                    }
                }
                return;
            }
            MessageBox.Show("MSSV là 8 kí tự số!!!");
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                QLTV qLTV = new QLTV();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (Convert.ToBoolean(row.Cells["CanBorrow"].Value) == true)
                        qLTV.AddBorrowBooks(Convert.ToInt32(txtMSSV.Text), Convert.ToInt64(row.Cells[0].Value.ToString()), DateTime.Now.Date);
                    else MessageBox.Show("Book with id " + row.Cells[0].Value.ToString() + " is Readonly!!!");
                }
                int type = ((CbbItem)(cbbShow.SelectedItem)).Value;
                dataGridView1.DataSource = qLTV.GetAllBookBySearch(txtSearch.Text, type);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DetailForm detailForm = new DetailForm();
            detailForm.ShowDialog();
            QLTV qLTV = new QLTV();
            int type = ((CbbItem)(cbbShow.SelectedItem)).Value;
            dataGridView1.DataSource = qLTV.GetAllBookBySearch(txtSearch.Text, type);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DetailForm detailForm1 = new DetailForm();
                detailForm1.d(Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                detailForm1.ShowDialog();
                QLTV qLTV = new QLTV();
                int type = ((CbbItem)(cbbShow.SelectedItem)).Value;
                dataGridView1.DataSource = qLTV.GetAllBookBySearch(txtSearch.Text, type);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
                QLTV qLTV = new QLTV();
                int type = ((CbbItem)(cbbShow.SelectedItem)).Value;
                dataGridView1.DataSource = qLTV.GetAllBookBySearch(txtSearch.Text, type);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                QLTV qLTV = new QLTV();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    qLTV.Delete(Convert.ToInt64(row.Cells[0].Value));
                }
                int type = ((CbbItem)(cbbShow.SelectedItem)).Value;
                dataGridView1.DataSource = qLTV.GetAllBookBySearch(txtSearch.Text, type);
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string col = cbbSort.Text;
            QLTV qLTV = new QLTV();
            dataGridView1.DataSource = qLTV.SortByGeneric(dataGridView1, col);
        }

        private void cbbShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            QLTV qLTV = new QLTV();
            int type = ((CbbItem)(cbbShow.SelectedItem)).Value;
            dataGridView1.DataSource = qLTV.GetAllBookBySearch(txtSearch.Text, type);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (cbbShow.SelectedIndex == 3)
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Hãy nhập mã số sinh viên và bấm Check");
                }
                if (dataGridView1.SelectedRows.Count > 0) {
                    QLTV qLTV = new QLTV();
                    foreach(DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        qLTV.ReturnBook(Convert.ToInt64(row.Cells[0].Value), Convert.ToInt32(txtMSSV.Text.ToString()));
                    }
                }
                else
                {
                    MessageBox.Show("Chọn ít nhất 1 sách muốn trả!!");
                }
                return;
            }
            MessageBox.Show("Chuyển danh sách sang Borrowing để chọn sách trả");
        }
    }
}
