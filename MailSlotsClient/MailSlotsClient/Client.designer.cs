namespace MailSlots
{
    partial class frmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMailSlot = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbMailSlot = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMailSlot
            // 
            this.lblMailSlot.AutoSize = true;
            this.lblMailSlot.Location = new System.Drawing.Point(16, 16);
            this.lblMailSlot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMailSlot.Name = "lblMailSlot";
            this.lblMailSlot.Size = new System.Drawing.Size(93, 32);
            this.lblMailSlot.TabIndex = 2;
            this.lblMailSlot.Text = "Введите имя \r\nмейлслота";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(116, 116);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(121, 32);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Подключиться";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbMailSlot
            // 
            this.tbMailSlot.Location = new System.Drawing.Point(115, 12);
            this.tbMailSlot.Margin = new System.Windows.Forms.Padding(4);
            this.tbMailSlot.Name = "tbMailSlot";
            this.tbMailSlot.Size = new System.Drawing.Size(240, 22);
            this.tbMailSlot.TabIndex = 0;
            this.tbMailSlot.Text = "ServerMailslot";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(116, 64);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(239, 22);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(27, 70);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(46, 16);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Логин";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 173);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.tbMailSlot);
            this.Controls.Add(this.lblMailSlot);
            this.Controls.Add(this.btnConnect);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMailSlot;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbMailSlot;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
    }
}

