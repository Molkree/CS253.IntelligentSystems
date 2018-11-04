namespace lab4
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.list_villains = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_heros = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_info = new System.Windows.Forms.Label();
            this.button_exec = new System.Windows.Forms.Button();
            this.check_forward = new System.Windows.Forms.RadioButton();
            this.check_backward = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Команда злодеев";
            // 
            // list_villains
            // 
            this.list_villains.FormattingEnabled = true;
            this.list_villains.Location = new System.Drawing.Point(13, 37);
            this.list_villains.Name = "list_villains";
            this.list_villains.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.list_villains.Size = new System.Drawing.Size(120, 95);
            this.list_villains.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Команда героев";
            // 
            // label_heros
            // 
            this.label_heros.AutoSize = true;
            this.label_heros.BackColor = System.Drawing.Color.White;
            this.label_heros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_heros.Location = new System.Drawing.Point(337, 37);
            this.label_heros.Name = "label_heros";
            this.label_heros.Size = new System.Drawing.Size(55, 15);
            this.label_heros.TabIndex = 3;
            this.label_heros.Text = "Никого...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Информация о выводе";
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.BackColor = System.Drawing.Color.White;
            this.label_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_info.Location = new System.Drawing.Point(13, 271);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(18, 15);
            this.label_info.TabIndex = 5;
            this.label_info.Text = "...";
            // 
            // button_exec
            // 
            this.button_exec.Location = new System.Drawing.Point(13, 195);
            this.button_exec.Name = "button_exec";
            this.button_exec.Size = new System.Drawing.Size(120, 23);
            this.button_exec.TabIndex = 6;
            this.button_exec.Text = "Собрать команду";
            this.button_exec.UseVisualStyleBackColor = true;
            this.button_exec.Click += new System.EventHandler(this.button_exec_Click);
            // 
            // check_forward
            // 
            this.check_forward.AutoSize = true;
            this.check_forward.Checked = true;
            this.check_forward.Location = new System.Drawing.Point(12, 139);
            this.check_forward.Name = "check_forward";
            this.check_forward.Size = new System.Drawing.Size(100, 17);
            this.check_forward.TabIndex = 7;
            this.check_forward.TabStop = true;
            this.check_forward.Text = "Прямой вывод";
            this.check_forward.UseVisualStyleBackColor = true;
            // 
            // check_backward
            // 
            this.check_backward.AutoSize = true;
            this.check_backward.Location = new System.Drawing.Point(12, 162);
            this.check_backward.Name = "check_backward";
            this.check_backward.Size = new System.Drawing.Size(111, 17);
            this.check_backward.TabIndex = 8;
            this.check_backward.Text = "Обратный вывод";
            this.check_backward.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 459);
            this.Controls.Add(this.check_backward);
            this.Controls.Add(this.check_forward);
            this.Controls.Add(this.button_exec);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_heros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.list_villains);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox list_villains;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_heros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Button button_exec;
        private System.Windows.Forms.RadioButton check_forward;
        private System.Windows.Forms.RadioButton check_backward;
    }
}

