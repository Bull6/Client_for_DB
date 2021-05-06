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
using Client_for_DB;

namespace Client_for_DB
{
    public partial class Workspace : Form
    {
        SqlCommandBuilder commandBuilder;
        SqlDataAdapter adapter;
        DataTable dt;
        string strConn = ConnectForm.strConn;
        
        public Workspace()
        {
            InitializeComponent();
            
            //string strConn = form.take_conn();
            this.take_table_names();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        public void take_table_names()
        {
            //string strConn = form.take_conn();

            using (SqlConnection conn = new SqlConnection(this.strConn))
            {
                
                SqlCommand cmd1 = new SqlCommand("select TABLE_NAME from INFORMATION_SCHEMA.TABLES", conn);
                dt = new DataTable();
                adapter = new SqlDataAdapter(cmd1);
                adapter.Fill(dt);

                this.comboBox1.DataSource = dt;
                this.comboBox1.DisplayMember = "TABLE_NAME";// столбец для отображения
                this.comboBox1.SelectedIndex = -1;
            }
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
            {
                //string strConn = form.take_conn();
                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    string table_name = this.comboBox1.Text;

                    connection.Open();

                    adapter = new SqlDataAdapter("SELECT * FROM " + table_name, strConn);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    /*
                    adapter.InsertCommand = new SqlCommand("sp_CreateUser", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50, "Name"));
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@age", SqlDbType.Int, 0, "Age"));

                    SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                    parameter.Direction = ParameterDirection.Output;
                    */
                    adapter.Update(dt);
                }
            }
        

            this.TopMost = true;
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string strConn = form.take_conn();
            string table_name = this.comboBox1.Text;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string cmd = "SELECT * FROM " + table_name; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, conn);
            createCommand.ExecuteNonQuery();

            adapter = new SqlDataAdapter(createCommand);
            dt = new DataTable(table_name); // В скобках указываем название таблицы
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

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form rep_win = new Reports_Win();
            rep_win.Show();
            this.Hide();

        }
    }
}
