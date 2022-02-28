namespace CourseWork
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.btnPgn = new System.Windows.Forms.Button();
            this.btnCross = new System.Windows.Forms.Button();
            this.btnBezier = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSpс = new System.Windows.Forms.Button();
            this.btnMv = new System.Windows.Forms.Button();
            this.btnSpf = new System.Windows.Forms.Button();
            this.btnRc = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnIntersection = new System.Windows.Forms.Button();
            this.btnSymDifference = new System.Windows.Forms.Button();
            this.tName = new System.Windows.Forms.ToolTip(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.nDeleteFig = new System.Windows.Forms.Button();
            this.cbColorFig = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(859, 458);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.domainUpDown1);
            this.groupBox1.Controls.Add(this.btnPgn);
            this.groupBox1.Controls.Add(this.btnCross);
            this.groupBox1.Controls.Add(this.btnBezier);
            this.groupBox1.Controls.Add(this.btnLine);
            this.groupBox1.Location = new System.Drawing.Point(0, 485);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 66);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Примитивы";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Items.Add("20");
            this.domainUpDown1.Items.Add("19");
            this.domainUpDown1.Items.Add("18");
            this.domainUpDown1.Items.Add("17");
            this.domainUpDown1.Items.Add("16");
            this.domainUpDown1.Items.Add("15");
            this.domainUpDown1.Items.Add("14");
            this.domainUpDown1.Items.Add("13");
            this.domainUpDown1.Items.Add("12");
            this.domainUpDown1.Items.Add("11");
            this.domainUpDown1.Items.Add("10");
            this.domainUpDown1.Items.Add("9");
            this.domainUpDown1.Items.Add("8");
            this.domainUpDown1.Items.Add("7");
            this.domainUpDown1.Items.Add("6");
            this.domainUpDown1.Items.Add("5");
            this.domainUpDown1.Items.Add("4");
            this.domainUpDown1.Items.Add("3");
            this.domainUpDown1.Location = new System.Drawing.Point(110, 39);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(100, 20);
            this.domainUpDown1.TabIndex = 13;
            this.domainUpDown1.Text = "20";
            this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // btnPgn
            // 
            this.btnPgn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPgn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPgn.Location = new System.Drawing.Point(110, 12);
            this.btnPgn.Name = "btnPgn";
            this.btnPgn.Size = new System.Drawing.Size(100, 21);
            this.btnPgn.TabIndex = 3;
            this.btnPgn.Text = "Многоугольник";
            this.btnPgn.UseVisualStyleBackColor = false;
            this.btnPgn.Click += new System.EventHandler(this.btnPgn_Click);
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCross.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCross.Location = new System.Drawing.Point(216, 12);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(100, 21);
            this.btnCross.TabIndex = 2;
            this.btnCross.Text = "Крест";
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // btnBezier
            // 
            this.btnBezier.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBezier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBezier.Location = new System.Drawing.Point(4, 39);
            this.btnBezier.Name = "btnBezier";
            this.btnBezier.Size = new System.Drawing.Size(100, 21);
            this.btnBezier.TabIndex = 1;
            this.btnBezier.Text = "Безье";
            this.btnBezier.UseVisualStyleBackColor = false;
            this.btnBezier.Click += new System.EventHandler(this.btnBezier_Click);
            // 
            // btnLine
            // 
            this.btnLine.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLine.Location = new System.Drawing.Point(4, 12);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(100, 21);
            this.btnLine.TabIndex = 0;
            this.btnLine.Text = "Отрезок";
            this.btnLine.UseVisualStyleBackColor = false;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSpс);
            this.groupBox2.Controls.Add(this.btnMv);
            this.groupBox2.Controls.Add(this.btnSpf);
            this.groupBox2.Controls.Add(this.btnRc);
            this.groupBox2.Location = new System.Drawing.Point(322, 485);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 63);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Геометрические преобразования";
            // 
            // btnSpс
            // 
            this.btnSpс.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSpс.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSpс.Location = new System.Drawing.Point(111, 39);
            this.btnSpс.Name = "btnSpс";
            this.btnSpс.Size = new System.Drawing.Size(100, 21);
            this.btnSpс.TabIndex = 7;
            this.btnSpс.Text = "Зеркаливание т";
            this.btnSpс.UseVisualStyleBackColor = false;
            this.btnSpс.Click += new System.EventHandler(this.btnSpс_Click);
            // 
            // btnMv
            // 
            this.btnMv.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMv.Location = new System.Drawing.Point(5, 12);
            this.btnMv.Name = "btnMv";
            this.btnMv.Size = new System.Drawing.Size(100, 21);
            this.btnMv.TabIndex = 4;
            this.btnMv.Text = "Перемещение";
            this.btnMv.UseVisualStyleBackColor = false;
            this.btnMv.Click += new System.EventHandler(this.btnMv_Click);
            // 
            // btnSpf
            // 
            this.btnSpf.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSpf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSpf.Location = new System.Drawing.Point(111, 12);
            this.btnSpf.Name = "btnSpf";
            this.btnSpf.Size = new System.Drawing.Size(100, 21);
            this.btnSpf.TabIndex = 6;
            this.btnSpf.Text = "Зеркаливание ц";
            this.btnSpf.UseVisualStyleBackColor = false;
            this.btnSpf.Click += new System.EventHandler(this.btnSpf_Click);
            // 
            // btnRc
            // 
            this.btnRc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRc.Location = new System.Drawing.Point(5, 39);
            this.btnRc.Name = "btnRc";
            this.btnRc.Size = new System.Drawing.Size(100, 21);
            this.btnRc.TabIndex = 5;
            this.btnRc.Text = "Вращение";
            this.btnRc.UseVisualStyleBackColor = false;
            this.btnRc.Click += new System.EventHandler(this.btnRc_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnIntersection);
            this.groupBox3.Controls.Add(this.btnSymDifference);
            this.groupBox3.Location = new System.Drawing.Point(549, 485);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(122, 66);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ТМО";
            // 
            // btnIntersection
            // 
            this.btnIntersection.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIntersection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIntersection.Location = new System.Drawing.Point(4, 12);
            this.btnIntersection.Name = "btnIntersection";
            this.btnIntersection.Size = new System.Drawing.Size(100, 21);
            this.btnIntersection.TabIndex = 8;
            this.btnIntersection.Text = "Объеденение";
            this.btnIntersection.UseVisualStyleBackColor = false;
            this.btnIntersection.Click += new System.EventHandler(this.btnIntersection_Click);
            // 
            // btnSymDifference
            // 
            this.btnSymDifference.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSymDifference.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSymDifference.Location = new System.Drawing.Point(6, 39);
            this.btnSymDifference.Name = "btnSymDifference";
            this.btnSymDifference.Size = new System.Drawing.Size(100, 21);
            this.btnSymDifference.TabIndex = 9;
            this.btnSymDifference.Text = "A - B";
            this.btnSymDifference.UseVisualStyleBackColor = false;
            this.btnSymDifference.Click += new System.EventHandler(this.btnSymDifference_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(76, 40);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 21);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Очистить экран";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // nDeleteFig
            // 
            this.nDeleteFig.Location = new System.Drawing.Point(6, 39);
            this.nDeleteFig.Name = "nDeleteFig";
            this.nDeleteFig.Size = new System.Drawing.Size(70, 21);
            this.nDeleteFig.TabIndex = 10;
            this.nDeleteFig.Text = "Удалить";
            this.nDeleteFig.UseVisualStyleBackColor = true;
            this.nDeleteFig.Click += new System.EventHandler(this.nDeleteFig_Click);
            // 
            // cbColorFig
            // 
            this.cbColorFig.FormattingEnabled = true;
            this.cbColorFig.Items.AddRange(new object[] {
            "Черный",
            "Красный",
            "Желтый",
            "Зеленый",
            "Синий",
            "Фиолетовый"});
            this.cbColorFig.Location = new System.Drawing.Point(6, 13);
            this.cbColorFig.Name = "cbColorFig";
            this.cbColorFig.Size = new System.Drawing.Size(170, 21);
            this.cbColorFig.TabIndex = 12;
            this.cbColorFig.Text = "Черный";
            this.cbColorFig.SelectedIndexChanged += new System.EventHandler(this.cbColorFig_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbColorFig);
            this.groupBox4.Controls.Add(this.nDeleteFig);
            this.groupBox4.Controls.Add(this.btnClear);
            this.groupBox4.Location = new System.Drawing.Point(677, 485);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(182, 66);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 563);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPgn;
        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.Button btnBezier;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSpс;
        private System.Windows.Forms.Button btnMv;
        private System.Windows.Forms.Button btnSpf;
        private System.Windows.Forms.Button btnRc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnIntersection;
        private System.Windows.Forms.Button btnSymDifference;
        private System.Windows.Forms.ToolTip tName;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button nDeleteFig;
        private System.Windows.Forms.ComboBox cbColorFig;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

