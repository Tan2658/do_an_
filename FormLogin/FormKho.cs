using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Data;
using BUS;

namespace FormLogin
{
    public partial class FormKho : Form
    {
        private readonly KhoService kho = new KhoService();

        public FormKho()
        {
            InitializeComponent();
        }

        private void BindGrid(List<Kho> Medics)
        {
            dgvStore.Rows.Clear();
            foreach (var Medic in Medics)
            {
                int index = dgvStore.Rows.Add();
                dgvStore.Rows[index].Cells[0].Value = Medic.IDSanPham.ToString();
                dgvStore.Rows[index].Cells[1].Value = Medic.IDDungCu.ToString();
                dgvStore.Rows[index].Cells[2].Value = Medic.TenDungCu.ToString();
                dgvStore.Rows[index].Cells[3].Value = Medic.Loai.ToString();
                dgvStore.Rows[index].Cells[4].Value = Medic.DonViTinh.ToString();
                dgvStore.Rows[index].Cells[5].Value = Medic.SoLuong.ToString();

            }
        }

        private void FormKho_Load(object sender, EventArgs e)
        {
            BindGrid(kho.GetAll());
        }

        private void cboFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvStore.Rows.Count; i++)
            {
                if (cboFind.SelectedItem.ToString() == dgvStore.Rows[i].Cells[3].Value.ToString())
                {
                    dgvStore.Rows[i].Visible = true;
                }
                else
                {
                    dgvStore.Rows[i].Visible = false;
                }
            }
        }

        private void btnDongKho_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
