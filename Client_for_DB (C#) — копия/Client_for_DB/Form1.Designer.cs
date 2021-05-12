namespace Client_for_DB
{
    partial class ConnectForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.IP_addres_label = new System.Windows.Forms.Label();
            this.Login_label = new System.Windows.Forms.Label();
            this.Password_label = new System.Windows.Forms.Label();
            this.IP_textBox = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Login_textBox = new System.Windows.Forms.TextBox();
            this.Pass_textBox = new System.Windows.Forms.TextBox();
            this.DB_Name_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IP_addres_label
            // 
            this.IP_addres_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IP_addres_label.AutoSize = true;
            this.IP_addres_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.IP_addres_label.Location = new System.Drawing.Point(18, 80);
            this.IP_addres_label.Name = "IP_addres_label";
            this.IP_addres_label.Size = new System.Drawing.Size(98, 24);
            this.IP_addres_label.TabIndex = 0;
            this.IP_addres_label.Text = "IP address";
            // 
            // Login_label
            // 
            this.Login_label.AutoSize = true;
            this.Login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Login_label.Location = new System.Drawing.Point(18, 156);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(57, 24);
            this.Login_label.TabIndex = 2;
            this.Login_label.Text = "Login";
            this.Login_label.Click += new System.EventHandler(this.Login_label_Click);
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Password_label.Location = new System.Drawing.Point(18, 221);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(92, 24);
            this.Password_label.TabIndex = 3;
            this.Password_label.Text = "Password";
            // 
            // IP_textBox
            // 
            this.IP_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.IP_textBox.Location = new System.Drawing.Point(157, 75);
            this.IP_textBox.Name = "IP_textBox";
            this.IP_textBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IP_textBox.Size = new System.Drawing.Size(166, 29);
            this.IP_textBox.TabIndex = 5;
            this.IP_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_connect
            // 
            this.button_connect.AutoEllipsis = true;
            this.button_connect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button_connect.Location = new System.Drawing.Point(22, 353);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(287, 56);
            this.button_connect.TabIndex = 6;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(18, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "DB Name";
            // 
            // Login_textBox
            // 
            this.Login_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Login_textBox.Location = new System.Drawing.Point(157, 151);
            this.Login_textBox.Name = "Login_textBox";
            this.Login_textBox.Size = new System.Drawing.Size(166, 29);
            this.Login_textBox.TabIndex = 8;
            this.Login_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Pass_textBox
            // 
            this.Pass_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Pass_textBox.Location = new System.Drawing.Point(157, 216);
            this.Pass_textBox.Name = "Pass_textBox";
            this.Pass_textBox.PasswordChar = '*';
            this.Pass_textBox.Size = new System.Drawing.Size(166, 29);
            this.Pass_textBox.TabIndex = 9;
            this.Pass_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DB_Name_textBox
            // 
            this.DB_Name_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.DB_Name_textBox.Location = new System.Drawing.Point(157, 272);
            this.DB_Name_textBox.Name = "DB_Name_textBox";
            this.DB_Name_textBox.Size = new System.Drawing.Size(166, 29);
            this.DB_Name_textBox.TabIndex = 10;
            this.DB_Name_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(335, 365);
            this.Controls.Add(this.DB_Name_textBox);
            this.Controls.Add(this.Pass_textBox);
            this.Controls.Add(this.Login_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.IP_textBox);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Login_label);
            this.Controls.Add(this.IP_addres_label);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connecting DataBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IP_addres_label;
        private System.Windows.Forms.Label Login_label;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.Button button_connect;
        public System.Windows.Forms.TextBox IP_textBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Login_textBox;
        public System.Windows.Forms.TextBox Pass_textBox;
        public System.Windows.Forms.TextBox DB_Name_textBox;
    }
}

