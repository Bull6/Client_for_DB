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
    public partial class Workspace : Form
    {
        public Workspace()
        {
            InitializeComponent();
            this.take_table_names();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        public void take_table_names()
        {
            string strConn = "Data Source=" + "192.168.1.202" + ",1433;Network Library=DBMSSOCN;Initial Catalog=ElectroTransport;User ID=" + "sa" + ";Password=" + "290798Denis" + ";";
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd1 = new SqlCommand("select TABLE_NAME from INFORMATION_SCHEMA.TABLES", conn);
            DataTable tbl1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(tbl1);

            this.comboBox1.DataSource = tbl1;
            this.comboBox1.DisplayMember = "TABLE_NAME";// столбец для отображения
            ///this.comboBox1.ValueMember = "...";//столбец с id
            this.comboBox1.SelectedIndex = -1;
        }

        private void actionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Creating by Bull6 26.04.2021",
            "About",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);

            this.TopMost = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "Save changes to DB?",
           "Save data to DB?",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Information,
           MessageBoxDefaultButton.Button1,
           MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
                this.Text = "";

            this.TopMost = true;
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table_name = this.comboBox1.Text;
            string strConn = "Data Source=" + "192.168.1.202" + ",1433;Network Library=DBMSSOCN;Initial Catalog=ElectroTransport;User ID=" + "sa" + ";Password=" + "290798Denis" + ";";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string cmd = "SELECT * FROM " + table_name; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, conn);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable(table_name); // В скобках указываем название таблицы
            dataAdp.Fill(dt);
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
        

        private void Workspace_Load(object sender, EventArgs e)
        {
            ///Application.Exit();
        }
       
        private void Workspace_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            this.datagrid_resize();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.datagrid_resize();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.datagrid_resize();
        }

        private void dataGridView1_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            this.datagrid_resize();
        }
    }
}
