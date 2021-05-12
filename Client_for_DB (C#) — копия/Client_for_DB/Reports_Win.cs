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
            this.button2_Click();
        }


        private void button2_Click()
        {
            //string strConn = form.take_conn();
            dataGridView1.Enabled = true;
            dataGridView1.Visible = true;

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string cmd = "SELECT product.p_name as 'Продукт', product.p_price as 'Цена', department.d_name as 'Отдел',  CONCAT (employee.Surname,' ', employee.First_name) as 'Изготовил', position.ID_position as 'Должность' " +
                 "FROM product LEFT outer Join department ON product.ID_department = department.ID_department " +
                 "LEFT OUTER JOIN employee ON department.ID_department = employee.ID_department " +
                 "LEFT OUTER JOIN position ON position.ID_position = employee.ID_position"; // Из какой таблицы нужен вывод 
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
            
        }

    }
}
