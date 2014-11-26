namespace Productions
{
    partial class Form1
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
            this.Ok_but = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Ok_but
            // 
            this.Ok_but.Location = new System.Drawing.Point(149, 84);
            this.Ok_but.Name = "Ok_but";
            this.Ok_but.Size = new System.Drawing.Size(75, 23);
            this.Ok_but.TabIndex = 0;
            this.Ok_but.Text = "OK";
            this.Ok_but.UseVisualStyleBackColor = true;
            this.Ok_but.Click += new System.EventHandler(this.Ok_but_Click);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(23, 132);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(225, 20);
            this.output.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.output);
            this.Controls.Add(this.Ok_but);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Ok_but;
        private System.Windows.Forms.TextBox output;
    }
}

