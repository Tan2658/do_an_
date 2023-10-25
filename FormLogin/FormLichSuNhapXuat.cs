using DAL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormLogin
{
    public partial class FormLichSuNhapXuat : Form
    {
        FormTrangChu frm;
        public FormLichSuNhapXuat()
        {
            InitializeComponent();
        }

        public FormLichSuNhapXuat(FormTrangChu frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        private void BindGrid(List<LichSuNhapXuat> Medics)
        {
            dgvVatTuInput.Rows.Clear();
            foreach (var Medic in Medics)
            {
                int index = dgvVatTuInput.Rows.Add();
                if (Medic.NoiDung == false)
                {
                    dgvVatTuInput.Rows[index].Cells[0].Value = "Xuất";
                }
                else
                {
                    dgvVatTuInput.Rows[index].Cells[0].Value = "Nhập";
                }
                dgvVatTuInput.Rows[index].Cells[1].Value = Medic.IDDungCu;
                dgvVatTuInput.Rows[index].Cells[2].Value = Medic.TenDungCu.ToString();
                dgvVatTuInput.Rows[index].Cells[3].Value = Medic.Loai.ToString();
                dgvVatTuInput.Rows[index].Cells[4].Value = Medic.DonViTinh.ToString();
                dgvVatTuInput.Rows[index].Cells[5].Value = Medic.SoLuongNhapXuat.ToString();
                dgvVatTuInput.Rows[index].Cells[6].Value = Medic.Don.ToString();
                dgvVatTuInput.Rows[index].Cells[7].Value = Medic.ThanhTien.ToString();
                dgvVatTuInput.Rows[index].Cells[8].Value = Medic.NgayNhap.ToString();

            }
        }

        private void FormLichSuNhapXuat_Load(object sender, EventArgs e)
        {
            DentalContextDB context = new DentalContextDB();
            List<LichSuNhapXuat> listHis = context.LichSuNhapXuats.ToList();
            BindGrid(listHis);
        }

        private void btnDongKho_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvVatTuInput.Rows.Count; i++)
            {
                if (cboFind.SelectedItem.ToString() == dgvVatTuInput.Rows[i].Cells[0].Value.ToString())
                {
                    dgvVatTuInput.Rows[i].Visible = true;
                }
                else
                {
                    dgvVatTuInput.Rows[i].Visible = false;
                }
            }
        }
    }
}
