namespace PatternRecognition
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ButtonRecognize = new System.Windows.Forms.Button();
            this.ButtonLearn = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.textBoxImageName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.wstabTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stabilityTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.etaTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.iterCountLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dQLabel = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.AbortButt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.weightsDeltaLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(10, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 97);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ButtonRecognize
            // 
            this.ButtonRecognize.Enabled = false;
            this.ButtonRecognize.Location = new System.Drawing.Point(118, 134);
            this.ButtonRecognize.Name = "ButtonRecognize";
            this.ButtonRecognize.Size = new System.Drawing.Size(75, 23);
            this.ButtonRecognize.TabIndex = 1;
            this.ButtonRecognize.Text = "Recognize";
            this.ButtonRecognize.UseVisualStyleBackColor = true;
            this.ButtonRecognize.Click += new System.EventHandler(this.ButtonRecognize_Click);
            // 
            // ButtonLearn
            // 
            this.ButtonLearn.Location = new System.Drawing.Point(7, 52);
            this.ButtonLearn.Name = "ButtonLearn";
            this.ButtonLearn.Size = new System.Drawing.Size(87, 23);
            this.ButtonLearn.TabIndex = 2;
            this.ButtonLearn.Text = "Learn";
            this.ButtonLearn.UseVisualStyleBackColor = true;
            this.ButtonLearn.Click += new System.EventHandler(this.ButtonLearn_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(118, 30);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 3;
            this.ButtonSave.Text = "Save image";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // textBoxImageName
            // 
            this.textBoxImageName.Location = new System.Drawing.Point(9, 33);
            this.textBoxImageName.Name = "textBoxImageName";
            this.textBoxImageName.Size = new System.Drawing.Size(103, 20);
            this.textBoxImageName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Image name:";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(9, 163);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(103, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.wstabTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.stabilityTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.etaTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(214, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 116);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Params";
            // 
            // wstabTextBox
            // 
            this.wstabTextBox.Location = new System.Drawing.Point(118, 83);
            this.wstabTextBox.Name = "wstabTextBox";
            this.wstabTextBox.Size = new System.Drawing.Size(85, 20);
            this.wstabTextBox.TabIndex = 5;
            this.wstabTextBox.Text = "0.00001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(4, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Weights stability:";
            // 
            // stabilityTextBox
            // 
            this.stabilityTextBox.Location = new System.Drawing.Point(103, 50);
            this.stabilityTextBox.Name = "stabilityTextBox";
            this.stabilityTextBox.Size = new System.Drawing.Size(100, 20);
            this.stabilityTextBox.TabIndex = 3;
            this.stabilityTextBox.Text = "0.000001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(4, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Q(W) Stability:";
            // 
            // etaTextBox
            // 
            this.etaTextBox.Location = new System.Drawing.Point(103, 16);
            this.etaTextBox.Name = "etaTextBox";
            this.etaTextBox.Size = new System.Drawing.Size(100, 20);
            this.etaTextBox.TabIndex = 1;
            this.etaTextBox.Text = "0.00001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Eta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Iterations:";
            // 
            // iterCountLabel
            // 
            this.iterCountLabel.AutoSize = true;
            this.iterCountLabel.Location = new System.Drawing.Point(6, 36);
            this.iterCountLabel.Name = "iterCountLabel";
            this.iterCountLabel.Size = new System.Drawing.Size(13, 13);
            this.iterCountLabel.TabIndex = 9;
            this.iterCountLabel.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(153, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "dQ:";
            // 
            // dQLabel
            // 
            this.dQLabel.AutoSize = true;
            this.dQLabel.Location = new System.Drawing.Point(153, 36);
            this.dQLabel.Name = "dQLabel";
            this.dQLabel.Size = new System.Drawing.Size(13, 13);
            this.dQLabel.TabIndex = 11;
            this.dQLabel.Text = "0";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // AbortButt
            // 
            this.AbortButt.Location = new System.Drawing.Point(114, 52);
            this.AbortButt.Name = "AbortButt";
            this.AbortButt.Size = new System.Drawing.Size(87, 23);
            this.AbortButt.TabIndex = 12;
            this.AbortButt.Text = "Abort";
            this.AbortButt.UseVisualStyleBackColor = true;
            this.AbortButt.Click += new System.EventHandler(this.AbortButt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxImageName);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.buttonClear);
            this.groupBox2.Controls.Add(this.ButtonSave);
            this.groupBox2.Controls.Add(this.ButtonRecognize);
            this.groupBox2.Location = new System.Drawing.Point(8, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 203);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.weightsDeltaLabel);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.ButtonLearn);
            this.groupBox3.Controls.Add(this.AbortButt);
            this.groupBox3.Controls.Add(this.dQLabel);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.iterCountLabel);
            this.groupBox3.Location = new System.Drawing.Point(214, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 81);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // weightsDeltaLabel
            // 
            this.weightsDeltaLabel.AutoSize = true;
            this.weightsDeltaLabel.Location = new System.Drawing.Point(81, 36);
            this.weightsDeltaLabel.Name = "weightsDeltaLabel";
            this.weightsDeltaLabel.Size = new System.Drawing.Size(13, 13);
            this.weightsDeltaLabel.TabIndex = 14;
            this.weightsDeltaLabel.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Weights delta:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 227);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(442, 266);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ButtonRecognize;
        private System.Windows.Forms.Button ButtonLearn;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.TextBox textBoxImageName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox stabilityTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox etaTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label iterCountLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label dQLabel;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button AbortButt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox wstabTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label weightsDeltaLabel;
        private System.Windows.Forms.Label label7;
    }
}

