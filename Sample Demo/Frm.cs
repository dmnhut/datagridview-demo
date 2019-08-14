using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample_Demo
{
    public partial class Frm : Form
    {
        // dataTbl init
        private DataTable dataTbl = new DataTable();

        /// <summary>
        /// Frm
        /// </summary>
        public Frm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Frm_Load
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void Frm_Load(object sender, EventArgs e)
        {
            this.dataTbl.Columns.Add("ID");
            this.dataTbl.Columns.Add("Name");
            this.dataTbl.Columns.Add("Email");
            this.dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.DataSource = dataTbl;
            GetData();
        }

        /// <summary>
        /// btnInsert_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text != "" && this.txtEmail.Text != "")
            {
                this.dataTbl = new DataTable();
                this.dataTbl.Columns.Add("ID");
                this.dataTbl.Columns.Add("Name");
                this.dataTbl.Columns.Add("Email");
                this.dataTbl.Rows.Add(new Object[] { 
                    DateTime.Now.Ticks.ToString(),
                    this.txtName.Text,
                    this.txtEmail.Text
                });
                this.ActiveControl = this.dgvUsers;
                Containers.CONNECTION = DBA.Connect();
                Containers.CONNECTION.Open();
                DBA.ExecuteNonQuery(SQL.Insert(), Containers.CONNECTION, this.dataTbl.Rows[0]);
                Containers.CONNECTION.Close();
                GetData();
            }
        }

        /// <summary>
        /// dgvUsers_CellClick
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">DataGridViewCellEventArgs</param>
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Containers.ROW_INDEX = e.RowIndex;
            if (Containers.ROW_INDEX == -1)
            {
                return;
            }
            this.txtId.Text = this.dgvUsers.Rows[Containers.ROW_INDEX].Cells[0].Value.ToString();
            this.txtName.Text = this.dgvUsers.Rows[Containers.ROW_INDEX].Cells[1].Value.ToString();
            this.txtEmail.Text = this.dgvUsers.Rows[Containers.ROW_INDEX].Cells[2].Value.ToString();
            this.ActiveControl = this.dgvUsers;
        }

        /// <summary>
        /// btnUpdate_Click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtId.Text != "" && this.txtName.Text != "" && this.txtEmail.Text != "")
            {
                this.dataTbl = (DataTable)this.dgvUsers.DataSource;
                this.dataTbl.Rows[Containers.ROW_INDEX][1] = this.txtName.Text;
                this.dataTbl.Rows[Containers.ROW_INDEX][2] = this.txtEmail.Text;
                this.ActiveControl = null;
                this.btnUpdate.Focus();
                Containers.CONNECTION = DBA.Connect();
                Containers.CONNECTION.Open();
                DBA.ExecuteNonQuery(SQL.Update(), Containers.CONNECTION, this.dataTbl.Rows[Containers.ROW_INDEX]);
                Containers.CONNECTION.Close();
                GetData();
            }
        }

        /// <summary>
        /// btnClose_Click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// btnDelete_Click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.txtId.Text != "" && this.txtName.Text != "" && this.txtEmail.Text != "")
            {
                this.dataTbl = (DataTable)this.dgvUsers.DataSource;
                this.ActiveControl = this.dgvUsers;
                Containers.CONNECTION = DBA.Connect();
                Containers.CONNECTION.Open();
                DBA.ExecuteNonQuery(SQL.Delete(), Containers.CONNECTION, this.dataTbl.Rows[Containers.ROW_INDEX]);
                Containers.CONNECTION.Close();
                GetData();
                FormClear();
            }
        }

        /// <summary>
        /// btnReload_Click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            this.ActiveControl = this.dgvUsers;
            GetData();
        }

        /// <summary>
        /// GetData
        /// </summary>
        public void GetData()
        {
            Containers.CONNECTION = DBA.Connect();
            Containers.CONNECTION.Open();
            this.dgvUsers.DataSource = DBA.Fill(SQL.Select(), Containers.CONNECTION);
            Containers.CONNECTION.Close();
        }

        /// <summary>
        /// FormClear
        /// </summary>
        public void FormClear()
        {
            this.txtId.Text = "";
            this.txtName.Text = "";
            this.txtEmail.Text = "";
        }
    }
}
