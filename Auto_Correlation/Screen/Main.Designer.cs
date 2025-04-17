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
            this.btn_open = new System.Windows.Forms.Button();
            this.txtBox_std = new System.Windows.Forms.TextBox();
            this.lbl_std = new System.Windows.Forms.Label();
            this.lbl_bat = new System.Windows.Forms.Label();
            this.txtBox_bat = new System.Windows.Forms.TextBox();
            this.btn_correlation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_open
            // 
            this.btn_open.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_open.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_open.Location = new System.Drawing.Point(12, 13);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(160, 30);
            this.btn_open.TabIndex = 0;
            this.btn_open.Text = "OPEN";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.Open_Click);
            // 
            // txtBox_std
            // 
            this.txtBox_std.Font = new System.Drawing.Font("돋움", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBox_std.Location = new System.Drawing.Point(179, 103);
            this.txtBox_std.Multiline = true;
            this.txtBox_std.Name = "txtBox_std";
            this.txtBox_std.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBox_std.Size = new System.Drawing.Size(190, 390);
            this.txtBox_std.TabIndex = 1;
            this.txtBox_std.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_std
            // 
            this.lbl_std.Location = new System.Drawing.Point(176, 70);
            this.lbl_std.Name = "lbl_std";
            this.lbl_std.Size = new System.Drawing.Size(193, 30);
            this.lbl_std.TabIndex = 2;
            this.lbl_std.Text = "STD";
            this.lbl_std.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_bat
            // 
            this.lbl_bat.Location = new System.Drawing.Point(375, 70);
            this.lbl_bat.Name = "lbl_bat";
            this.lbl_bat.Size = new System.Drawing.Size(190, 30);
            this.lbl_bat.TabIndex = 3;
            this.lbl_bat.Text = "BAT";
            this.lbl_bat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox_bat
            // 
            this.txtBox_bat.Font = new System.Drawing.Font("돋움", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBox_bat.Location = new System.Drawing.Point(375, 103);
            this.txtBox_bat.Multiline = true;
            this.txtBox_bat.Name = "txtBox_bat";
            this.txtBox_bat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBox_bat.Size = new System.Drawing.Size(190, 390);
            this.txtBox_bat.TabIndex = 4;
            this.txtBox_bat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_correlation
            // 
            this.btn_correlation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_correlation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_correlation.Location = new System.Drawing.Point(12, 49);
            this.btn_correlation.Name = "btn_correlation";
            this.btn_correlation.Size = new System.Drawing.Size(160, 30);
            this.btn_correlation.TabIndex = 5;
            this.btn_correlation.Text = "Correlation";
            this.btn_correlation.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 716);
            this.Controls.Add(this.btn_correlation);
            this.Controls.Add(this.txtBox_bat);
            this.Controls.Add(this.lbl_bat);
            this.Controls.Add(this.lbl_std);
            this.Controls.Add(this.txtBox_std);
            this.Controls.Add(this.btn_open);
            this.Name = "Main";
            this.Text = "Auto_Correation Program";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.TextBox txtBox_std;
        private System.Windows.Forms.Label lbl_std;
        private System.Windows.Forms.Label lbl_bat;
        private System.Windows.Forms.TextBox txtBox_bat;
        private System.Windows.Forms.Button btn_correlation;
    }
}

