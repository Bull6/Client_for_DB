using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;


namespace Client_for_DB
{
    public partial class Report2_win : Form
    {
        SqlCommandBuilder commandBuilder;
        SqlDataAdapter adapter;
        DataTable dt;
        
        
        string strConn = Workspace.strConn;
        public Report2_win()
        {
            InitializeComponent();
            this.fill_DGV();
        }

        public void fill_DGV()
        {
            //string strConn = form.take_conn();
            dataGridView1.Enabled = true;
            dataGridView1.Visible = true;

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string cmd = "SELECT product.p_name as 'Продукт', e_manufacturer.m_name as 'Завод', material.mat_name as 'Материал' " +
                "FROM product LEFT outer Join material ON product.ID_material = material.ID_material " +
                "LEFT OUTER JOIN e_manufacturer ON material.ID_manuf = e_manufacturer.ID_manuf"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, conn);
            createCommand.ExecuteNonQuery();

            adapter = new SqlDataAdapter(createCommand);
            dt = new DataTable("table_name"); // В скобках указываем название таблицы
            adapter.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView; // Сам вывод

            this.datagrid_resize();
        }
        public void datagrid_resize()
        {
            int height = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                height += row.Height;
            }
            height += dataGridView1.ColumnHeadersHeight;

            int width = 0;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                width += col.Width;
            }
            width += dataGridView1.RowHeadersWidth;

            dataGridView1.ClientSize = new Size(width + 2, height + 2);

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.datagrid_resize();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.datagrid_resize();
        }

        private void dataGridView1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            this.datagrid_resize();
        }

        private void dataGridView1_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            this.datagrid_resize();
        }

        private void Report2_win_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
