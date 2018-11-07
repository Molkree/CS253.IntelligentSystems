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
            this.label_heroes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_exec = new System.Windows.Forms.Button();
            this.check_forward = new System.Windows.Forms.RadioButton();
            this.check_backward = new System.Windows.Forms.RadioButton();
            this.list_info = new System.Windows.Forms.ListBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.list_heroes = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Команда злодеев";
            // 
            // list_villains
            // 
            this.list_villains.FormattingEnabled = true;
            this.list_villains.ItemHeight = 16;
            this.list_villains.Location = new System.Drawing.Point(17, 46);
            this.list_villains.Margin = new System.Windows.Forms.Padding(4);
            this.list_villains.Name = "list_villains";
            this.list_villains.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.list_villains.Size = new System.Drawing.Size(159, 116);
            this.list_villains.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Результат";
            // 
            // label_heroes
            // 
            this.label_heroes.AutoSize = true;
            this.label_heroes.BackColor = System.Drawing.Color.White;
            this.label_heroes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_heroes.Location = new System.Drawing.Point(423, 46);
            this.label_heroes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_heroes.Name = "label_heroes";
            this.label_heroes.Size = new System.Drawing.Size(68, 19);
            this.label_heroes.TabIndex = 3;
            this.label_heroes.Text = "Никого...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 292);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Информация о выводе";
            // 
            // button_exec
            // 
            this.button_exec.Location = new System.Drawing.Point(17, 260);
            this.button_exec.Margin = new System.Windows.Forms.Padding(4);
            this.button_exec.Name = "button_exec";
            this.button_exec.Size = new System.Drawing.Size(160, 28);
            this.button_exec.TabIndex = 6;
            this.button_exec.Text = "Собрать команду";
            this.button_exec.UseVisualStyleBackColor = true;
            this.button_exec.Click += new System.EventHandler(this.button_exec_Click);
            // 
            // check_forward
            // 
            this.check_forward.AutoSize = true;
            this.check_forward.Checked = true;
            this.check_forward.Location = new System.Drawing.Point(16, 171);
            this.check_forward.Margin = new System.Windows.Forms.Padding(4);
            this.check_forward.Name = "check_forward";
            this.check_forward.Size = new System.Drawing.Size(124, 21);
            this.check_forward.TabIndex = 7;
            this.check_forward.TabStop = true;
            this.check_forward.Text = "Прямой вывод";
            this.check_forward.UseVisualStyleBackColor = true;
            this.check_forward.CheckedChanged += new System.EventHandler(this.check_forward_CheckedChanged);
            // 
            // check_backward
            // 
            this.check_backward.AutoSize = true;
            this.check_backward.Location = new System.Drawing.Point(781, 171);
            this.check_backward.Margin = new System.Windows.Forms.Padding(4);
            this.check_backward.Name = "check_backward";
            this.check_backward.Size = new System.Drawing.Size(141, 21);
            this.check_backward.TabIndex = 8;
            this.check_backward.Text = "Обратный вывод";
            this.check_backward.UseVisualStyleBackColor = true;
            // 
            // list_info
            // 
            this.list_info.FormattingEnabled = true;
            this.list_info.ItemHeight = 16;
            this.list_info.Location = new System.Drawing.Point(17, 321);
            this.list_info.Margin = new System.Windows.Forms.Padding(4);
            this.list_info.Name = "list_info";
            this.list_info.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.list_info.Size = new System.Drawing.Size(905, 212);
            this.list_info.TabIndex = 10;
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(185, 260);
            this.button_clear.Margin = new System.Windows.Forms.Padding(4);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(100, 28);
            this.button_clear.TabIndex = 11;
            this.button_clear.Text = "Очистить";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // list_heroes
            // 
            this.list_heroes.FormattingEnabled = true;
            this.list_heroes.ItemHeight = 16;
            this.list_heroes.Location = new System.Drawing.Point(763, 46);
            this.list_heroes.Margin = new System.Windows.Forms.Padding(4);
            this.list_heroes.Name = "list_heroes";
            this.list_heroes.Size = new System.Drawing.Size(159, 116);
            this.list_heroes.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(760, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Список героев";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 565);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.list_heroes);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.list_info);
            this.Controls.Add(this.check_backward);
            this.Controls.Add(this.check_forward);
            this.Controls.Add(this.button_exec);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_heroes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.list_villains);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox list_villains;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_heroes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_exec;
        private System.Windows.Forms.RadioButton check_forward;
        private System.Windows.Forms.RadioButton check_backward;
        private System.Windows.Forms.ListBox list_info;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.ListBox list_heroes;
        private System.Windows.Forms.Label label3;
    }
}

