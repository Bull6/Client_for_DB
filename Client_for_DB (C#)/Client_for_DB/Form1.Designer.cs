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
            this.IP_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Login_label = new System.Windows.Forms.Label();
            this.Password_label = new System.Windows.Forms.Label();
            this.Password_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
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
            // IP_maskedTextBox
            // 
            this.IP_maskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.IP_maskedTextBox.Location = new System.Drawing.Point(155, 80);
            this.IP_maskedTextBox.Mask = "990/990/990/990";
            this.IP_maskedTextBox.Name = "IP_maskedTextBox";
            this.IP_maskedTextBox.Size = new System.Drawing.Size(166, 29);
            this.IP_maskedTextBox.TabIndex = 1;
            this.IP_maskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // Password_maskedTextBox
            // 
            this.Password_maskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Password_maskedTextBox.Location = new System.Drawing.Point(155, 221);
            this.Password_maskedTextBox.Name = "Password_maskedTextBox";
            this.Password_maskedTextBox.PasswordChar = '*';
            this.Password_maskedTextBox.ShortcutsEnabled = false;
            this.Password_maskedTextBox.Size = new System.Drawing.Size(166, 29);
            this.Password_maskedTextBox.TabIndex = 4;
            this.Password_maskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBox1.Location = new System.Drawing.Point(155, 151);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 29);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(342, 486);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Password_maskedTextBox);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Login_label);
            this.Controls.Add(this.IP_maskedTextBox);
            this.Controls.Add(this.IP_addres_label);
            this.HelpButton = true;
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connecting DataBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IP_addres_label;
        private System.Windows.Forms.MaskedTextBox IP_maskedTextBox;
        private System.Windows.Forms.Label Login_label;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.MaskedTextBox Password_maskedTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_connect;
    }
}

