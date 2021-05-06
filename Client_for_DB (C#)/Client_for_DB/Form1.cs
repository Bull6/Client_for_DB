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
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void Login_label_Click(object sender, EventArgs e)
        {

        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            string strConn = "Data Source="+"192.168.1.202"+",1433;Network Library=DBMSSOCN;Initial Catalog=ElectroTransport;User ID="+"sa"+";Password="+"290798Denis"+";";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            string cmd = "SELECT * FROM Depo"; // Из какой таблицы нужен вывод 
            SqlCommand createCommand = new SqlCommand(cmd, conn);
            createCommand.ExecuteNonQuery();

             

            
            this.Hide();
            Form main_win = new Workspace();
            main_win.Show();
            //main_win.ShowDialog(this);
            
        }
    }
}
