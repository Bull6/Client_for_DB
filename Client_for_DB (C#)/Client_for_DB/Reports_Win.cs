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
    public partial class Reports_Win : Form
    {

        SqlCommandBuilder commandBuilder;
        SqlDataAdapter adapter;
        DataTable dt;

        //string strConn = "Data Source=" + "192.168.1.202" + ",1433;Network Library=DBMSSOCN;Initial Catalog=ElectroTransport;User ID=" + "sa" + ";Password=" + "290798Denis" + ";";
        //ConnectForm form = new ConnectForm();
        string strConn = ConnectForm.strConn;
        public Reports_Win()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            this.take_table_names();
            

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

        public void take_columns_names()
        {
           
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string strConn = form.take_conn();
            using (SqlConnection conn = new SqlConnection(strConn))
            {

                SqlCommand cmd2 = new SqlCommand("select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME" +
                    " = '" + this.comboBox1.Text + "'", conn);
                dt = new DataTable();
                adapter = new SqlDataAdapter(cmd2);
                adapter.Fill(dt);

                this.comboBox2.DataSource = dt;
                this.comboBox2.DisplayMember = "COLUMN_NAME";// столбец для отображения
                this.comboBox2.SelectedIndex = -1;
            }
        }
        List<string> tables = new List<string> { };
        List<string> tables_fromsec = new List<string> { };
        List<string> columns = new List<string> { };

        private void button1_Click(object sender, EventArgs e)
        {
            
            

            if (columns.Contains( this.comboBox2.Text)==false || tables.Contains(this.comboBox1.Text )==false)
            {
                if (columns.Contains(this.comboBox2.Text) == false)
                    columns.Add(this.comboBox2.Text);
                if (tables.Contains(this.comboBox1.Text) == false)
                    tables.Add(this.comboBox1.Text);
                this.fill_textbox_select();
                this.fill_textbox_join();
            }
            
            this.comboBox4.DataSource = tables;
            this.comboBox5.DataSource = columns;
            
            
        }
        private void fill_textbox_join()
        {
            foreach (string j in tables)
                tables_fromsec.Add(j);
            tables_fromsec.RemoveAt(0);
            
            this.textBox3.Text = "";
            foreach(string i in tables_fromsec)
            {
                if (this.textBox3.Text != "")
                    this.textBox3.Text += ", ";
                this.textBox3.Text += i;
                
            }
            tables_fromsec.Clear();
        }
        private void fill_textbox_select()
        {
            this.textBox2.Text = tables[0];
            
            if (this.textBox1.Text != "")
                this.textBox1.Text += ", ";

            this.textBox1.Text += this.comboBox1.Text + "." + this.comboBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string strConn = form.take_conn();
            dataGridView1.Enabled = true;
            dataGridView1.Visible = true;
            string table_name = this.comboBox1.Text;
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string cmd = "SELECT " +this.textBox1.Text +" FROM " + this.textBox2.Text + " "+ this.comboBox3.Text+ " "
                +this.textBox3.Text+" ON "+"ETransport.ID_Depo"+" = "+"Depo.ID_Depo"; // Из какой таблицы нужен вывод 
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

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.datagrid_resize();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.datagrid_resize();
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            this.datagrid_resize();
        }

        private void dataGridView1_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            this.datagrid_resize();
        }

        private void Reports_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
