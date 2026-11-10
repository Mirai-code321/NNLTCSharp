using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace VeNha01_QuanLyCuaHang
{
    public class FormCoBan : Form
    {
        public FormCoBan(string tieuDe, int rong, int cao)
        {
            Text = tieuDe;
            ClientSize = new Size(rong, cao);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        protected void Nhan(string text, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.SetBounds(x, y, 180, 30);
            Controls.Add(lbl);
        }

        protected TextBox OText(int x, int y, int rong)
        {
            TextBox txt = new TextBox();
            txt.SetBounds(x, y, rong, 30);
            Controls.Add(txt);
            return txt;
        }

        protected Button Nut(
            string text,
            int x,
            int y,
            int rong,
            Action xuLy)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.SetBounds(x, y, rong, 40);
            btn.Click += (_, _) => AnToan(xuLy);
            Controls.Add(btn);
            return btn;
        }

        protected DataGridView Bang(
            int x, int y, int rong, int cao)
        {
            DataGridView grid = new DataGridView();
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            grid.SetBounds(x, y, rong, cao);
            Controls.Add(grid);
            return grid;
        }

        protected void AnToan(Action xuLy)
        {
            try
            {
                xuLy();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    this,
                    ex.Message,
                    "Thông báo SQL Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (InvalidOperationException ex)
            {
                BaoLoi(ex.Message);
            }
            catch (ArgumentException ex)
            {
                BaoLoi(ex.Message);
            }
        }

        protected void BaoLoi(string text)
        {
            MessageBox.Show(
                this, text, "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        protected void BaoTin(string text)
        {
            MessageBox.Show(
                this, text, "Kết quả",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}