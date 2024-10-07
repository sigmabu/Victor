namespace Victor
{
    partial class vw00Recipe
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
            this.Release();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_Base = new System.Windows.Forms.Panel();
            this.label46 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnl_Base
            // 
            this.pnl_Base.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pnl_Base.Location = new System.Drawing.Point(0, 30);
            this.pnl_Base.Name = "pnl_Base";
            this.pnl_Base.Size = new System.Drawing.Size(1280, 804);
            this.pnl_Base.TabIndex = 1;
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label46.ForeColor = System.Drawing.SystemColors.Control;
            this.label46.Location = new System.Drawing.Point(0, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(1280, 30);
            this.label46.TabIndex = 0;
            this.label46.Text = "Recipe";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vw00Recipe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.label46);
            this.Controls.Add(this.pnl_Base);
            this.DoubleBuffered = true;
            this.Name = "vw00Recipe";
            this.Size = new System.Drawing.Size(1280, 804);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_Base;
        private System.Windows.Forms.Label label46;
    }
}
