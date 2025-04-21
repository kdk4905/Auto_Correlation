namespace Auto_Correlation
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn_open_r = new System.Windows.Forms.Button();
            this.txtBox_std = new System.Windows.Forms.TextBox();
            this.lbl_std = new System.Windows.Forms.Label();
            this.lbl_bat = new System.Windows.Forms.Label();
            this.txtBox_bat = new System.Windows.Forms.TextBox();
            this.btn_cor_alpha = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_open_cor = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_cor_all = new System.Windows.Forms.Button();
            this.btn_cor_eta = new System.Windows.Forms.Button();
            this.btn_cor_beta = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_open_r
            // 
            this.btn_open_r.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_open_r.Location = new System.Drawing.Point(6, 24);
            this.btn_open_r.Name = "btn_open_r";
            this.btn_open_r.Size = new System.Drawing.Size(160, 30);
            this.btn_open_r.TabIndex = 0;
            this.btn_open_r.Text = "%R";
            this.btn_open_r.UseVisualStyleBackColor = true;
            this.btn_open_r.Click += new System.EventHandler(this.Open_Click);
            // 
            // txtBox_std
            // 
            this.txtBox_std.Font = new System.Drawing.Font("돋움", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBox_std.Location = new System.Drawing.Point(15, 43);
            this.txtBox_std.Multiline = true;
            this.txtBox_std.Name = "txtBox_std";
            this.txtBox_std.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBox_std.Size = new System.Drawing.Size(190, 390);
            this.txtBox_std.TabIndex = 1;
            this.txtBox_std.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_std
            // 
            this.lbl_std.Location = new System.Drawing.Point(12, 9);
            this.lbl_std.Name = "lbl_std";
            this.lbl_std.Size = new System.Drawing.Size(193, 30);
            this.lbl_std.TabIndex = 2;
            this.lbl_std.Text = "STD";
            this.lbl_std.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_bat
            // 
            this.lbl_bat.Location = new System.Drawing.Point(211, 8);
            this.lbl_bat.Name = "lbl_bat";
            this.lbl_bat.Size = new System.Drawing.Size(190, 30);
            this.lbl_bat.TabIndex = 3;
            this.lbl_bat.Text = "BAT";
            this.lbl_bat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox_bat
            // 
            this.txtBox_bat.Font = new System.Drawing.Font("돋움", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBox_bat.Location = new System.Drawing.Point(211, 43);
            this.txtBox_bat.Multiline = true;
            this.txtBox_bat.Name = "txtBox_bat";
            this.txtBox_bat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBox_bat.Size = new System.Drawing.Size(190, 390);
            this.txtBox_bat.TabIndex = 4;
            this.txtBox_bat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_cor_alpha
            // 
            this.btn_cor_alpha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_cor_alpha.Location = new System.Drawing.Point(6, 60);
            this.btn_cor_alpha.Name = "btn_cor_alpha";
            this.btn_cor_alpha.Size = new System.Drawing.Size(160, 30);
            this.btn_cor_alpha.TabIndex = 5;
            this.btn_cor_alpha.Tag = "alpha";
            this.btn_cor_alpha.Text = "ALPHA (α)";
            this.btn_cor_alpha.UseVisualStyleBackColor = true;
            this.btn_cor_alpha.Click += new System.EventHandler(this.btn_cor_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_open_cor);
            this.groupBox1.Controls.Add(this.btn_open_r);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(407, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Open";
            // 
            // btn_open_cor
            // 
            this.btn_open_cor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_open_cor.Location = new System.Drawing.Point(6, 60);
            this.btn_open_cor.Name = "btn_open_cor";
            this.btn_open_cor.Size = new System.Drawing.Size(160, 30);
            this.btn_open_cor.TabIndex = 1;
            this.btn_open_cor.Text = "Correlation File";
            this.btn_open_cor.UseVisualStyleBackColor = true;
            this.btn_open_cor.Click += new System.EventHandler(this.btn_open_cor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_cor_all);
            this.groupBox2.Controls.Add(this.btn_cor_eta);
            this.groupBox2.Controls.Add(this.btn_cor_beta);
            this.groupBox2.Controls.Add(this.btn_cor_alpha);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(407, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 172);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Correlation";
            // 
            // btn_cor_all
            // 
            this.btn_cor_all.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_cor_all.Location = new System.Drawing.Point(6, 24);
            this.btn_cor_all.Name = "btn_cor_all";
            this.btn_cor_all.Size = new System.Drawing.Size(160, 30);
            this.btn_cor_all.TabIndex = 8;
            this.btn_cor_all.Tag = "all";
            this.btn_cor_all.Text = "α+β+η";
            this.btn_cor_all.UseVisualStyleBackColor = true;
            this.btn_cor_all.Click += new System.EventHandler(this.btn_cor_btn_Click);
            // 
            // btn_cor_eta
            // 
            this.btn_cor_eta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_cor_eta.Location = new System.Drawing.Point(6, 133);
            this.btn_cor_eta.Name = "btn_cor_eta";
            this.btn_cor_eta.Size = new System.Drawing.Size(160, 30);
            this.btn_cor_eta.TabIndex = 7;
            this.btn_cor_eta.Tag = "eta";
            this.btn_cor_eta.Text = "ETA (η)";
            this.btn_cor_eta.UseVisualStyleBackColor = true;
            this.btn_cor_eta.Click += new System.EventHandler(this.btn_cor_btn_Click);
            // 
            // btn_cor_beta
            // 
            this.btn_cor_beta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_cor_beta.Location = new System.Drawing.Point(6, 97);
            this.btn_cor_beta.Name = "btn_cor_beta";
            this.btn_cor_beta.Size = new System.Drawing.Size(160, 30);
            this.btn_cor_beta.TabIndex = 6;
            this.btn_cor_beta.Tag = "beta";
            this.btn_cor_beta.Text = "BETA (β)";
            this.btn_cor_beta.UseVisualStyleBackColor = true;
            this.btn_cor_beta.Click += new System.EventHandler(this.btn_cor_btn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_exit);
            this.groupBox3.Controls.Add(this.btn_reset);
            this.groupBox3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(407, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 98);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Function";
            // 
            // btn_exit
            // 
            this.btn_exit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_exit.Location = new System.Drawing.Point(6, 60);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(160, 30);
            this.btn_exit.TabIndex = 7;
            this.btn_exit.Text = "EXIT";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_reset.Location = new System.Drawing.Point(6, 24);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(160, 30);
            this.btn_reset.TabIndex = 5;
            this.btn_reset.Text = "RESET";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 444);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtBox_bat);
            this.Controls.Add(this.lbl_bat);
            this.Controls.Add(this.lbl_std);
            this.Controls.Add(this.txtBox_std);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Auto_Correation Program";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_open_r;
        private System.Windows.Forms.TextBox txtBox_std;
        private System.Windows.Forms.Label lbl_std;
        private System.Windows.Forms.Label lbl_bat;
        private System.Windows.Forms.TextBox txtBox_bat;
        private System.Windows.Forms.Button btn_cor_alpha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_open_cor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_cor_eta;
        private System.Windows.Forms.Button btn_cor_beta;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_cor_all;
    }
}

