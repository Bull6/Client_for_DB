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
    public partial class ConnectForm : Form
    {
        string ip, login, pas, DB;
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void Login_label_Click(object sender, EventArgs e)
        {

        }
        public string take_conn()
        {
            
            string strConn = "Data Source=" + ip + ";" +
                //"Network Library=DBMSSOCN;" +
                "Initial Catalog= " + DB + ";User ID=" + login + ";" +
                "Password=" + pas + ";";
            return strConn;
        }
        public static string strConn { get; set; }

        private void button_connect_Click(object sender, EventArgs e)
        {

            ip = this.IP_textBox.Text;
            login = this.Login_textBox.Text;
            pas = this.Pass_textBox.Text;
            DB = this.DB_Name_textBox.Text;
            string strConn = this.take_conn();
            ConnectForm.strConn = strConn;
 
            this.Hide();
            Form main_win = new Workspace();
            
            main_win.Show();
            Form rep_form = new Reports_Win();
            
            
        }
    }
}
