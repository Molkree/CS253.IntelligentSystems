namespace NeuralNetworks1
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
            this.button_draw = new System.Windows.Forms.Button();
            this.button_gen = new System.Windows.Forms.Button();
            this.button_open = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_predict = new System.Windows.Forms.Button();
            this.button_train = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_label = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_draw
            // 
            this.button_draw.Location = new System.Drawing.Point(13, 13);
            this.button_draw.Name = "button_draw";
            this.button_draw.Size = new System.Drawing.Size(92, 29);
            this.button_draw.TabIndex = 0;
            this.button_draw.Text = "Нарисовать";
            this.button_draw.UseVisualStyleBackColor = true;
            this.button_draw.Click += new System.EventHandler(this.button_draw_Click);
            // 
            // button_gen
            // 
            this.button_gen.Location = new System.Drawing.Point(13, 48);
            this.button_gen.Name = "button_gen";
            this.button_gen.Size = new System.Drawing.Size(92, 29);
            this.button_gen.TabIndex = 1;
            this.button_gen.Text = "Сгенерировать";
            this.button_gen.UseVisualStyleBackColor = true;
            this.button_gen.Click += new System.EventHandler(this.button_gen_Click);
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(15, 149);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(92, 29);
            this.button_open.TabIndex = 2;
            this.button_open.Text = "Открыть";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(14, 184);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(92, 29);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_predict
            // 
            this.button_predict.Location = new System.Drawing.Point(318, 47);
            this.button_predict.Name = "button_predict";
            this.button_predict.Size = new System.Drawing.Size(92, 29);
            this.button_predict.TabIndex = 6;
            this.button_predict.Text = "Предсказать";
            this.button_predict.UseVisualStyleBackColor = true;
            this.button_predict.Click += new System.EventHandler(this.button_predict_Click);
            // 
            // button_train
            // 
            this.button_train.Location = new System.Drawing.Point(318, 12);
            this.button_train.Name = "button_train";
            this.button_train.Size = new System.Drawing.Size(92, 29);
            this.button_train.TabIndex = 5;
            this.button_train.Text = "Тренировать";
            this.button_train.UseVisualStyleBackColor = true;
            this.button_train.Click += new System.EventHandler(this.button_train_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Это";
            // 
            // comboBox_label
            // 
            this.comboBox_label.FormattingEnabled = true;
            this.comboBox_label.Items.AddRange(new object[] {
            "Синусоида",
            "Прямоугольник",
            "Треугольник",
            "Окружность",
            "..."});
            this.comboBox_label.Location = new System.Drawing.Point(350, 104);
            this.comboBox_label.Name = "comboBox_label";
            this.comboBox_label.Size = new System.Drawing.Size(121, 21);
            this.comboBox_label.TabIndex = 8;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(112, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 233);
            this.Controls.Add(this.comboBox_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_predict);
            this.Controls.Add(this.button_train);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.button_gen);
            this.Controls.Add(this.button_draw);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_draw;
        private System.Windows.Forms.Button button_gen;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_predict;
        private System.Windows.Forms.Button button_train;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_label;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

