using System;
using System.Reflection;
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
        SqlCommandBuilder commandBuilder;
        SqlDataAdapter adapter;
        DataTable dt;
        public string take_conn()
        {

            string strConn = "Data Source=acer\sqlexpress;" +
                "Initial Catalog=Melkoe_proizvodstvo;" +
                "User ID=sa;" +
                "Password=mmcc2012;";
            return strConn;
        }
        public static string strConn { get; set; }
        
        
        public Workspace()
        {
            InitializeComponent();

            //string strConn = form.take_conn();
            string strConn = this.take_conn();
            Workspace.strConn = strConn;
            this.take_table_names();
            
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;

        }

        public void take_table_names()
        {
            //string strConn = form.take_conn();

            using (SqlConnection conn = new SqlConnection(strConn))
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
            "Creating by Tonya Medvedeva 10.05.2021",
            "About",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);

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

        private void reportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form rep_win = new Reports_Win();
            rep_win.Show();
        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string table_name = this.comboBox1.Text;
            string columns = take_col(table_name);

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string cmd = "SELECT * FROM " + table_name + "WHERE CONCAT(" + columns + ") LIKE lower('%" + this.textBox1.Text + "%')"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, conn);
            createCommand.ExecuteNonQuery();

            adapter = new SqlDataAdapter(createCommand);
            dt = new DataTable(table_name); // В скобках указываем название таблицы
            adapter.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView; // Сам вывод

            this.datagrid_resize();
        }
        public string take_col(string tab_name)
        {
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand cmd2 = new SqlCommand("select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS " +
                "WHERE TABLE_NAME" +
                " = '" + tab_name + "'", conn);
            dt = new DataTable();
            adapter = new SqlDataAdapter(cmd2);
            adapter.Fill(dt);

            List<string> col_names = new List<string>() { };
            col_names = ConvertDataTable<string>(dt);
            var result = String.Join(", ", col_names.ToArray());
            return result;
        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sort;
            if (this.comboBox2.Text == "Descending")
                sort = " DESC";
            else
                sort = "";

            //string strConn = form.take_conn();
            string table_name = this.comboBox1.Text;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string cmd = "SELECT * FROM " + table_name + " ORDER BY" + sort; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, conn);
            createCommand.ExecuteNonQuery();

            adapter = new SqlDataAdapter(createCommand);
            dt = new DataTable(table_name); // В скобках указываем название таблицы
            adapter.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView; // Сам вывод

            this.datagrid_resize();
        }

        private void reportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form rep2_win = new Report2_win();
            rep2_win.Show();
        }
    }
}
