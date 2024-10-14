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
            this.label_Recipe = new System.Windows.Forms.Label();
            this.pnl_Base = new System.Windows.Forms.Panel();
            this.pnl_Base.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Recipe
            // 
            this.label_Recipe.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label_Recipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label_Recipe.ForeColor = System.Drawing.SystemColors.Control;
            this.label_Recipe.Location = new System.Drawing.Point(0, 0);
            this.label_Recipe.Name = "label_Recipe";
            this.label_Recipe.Size = new System.Drawing.Size(350, 30);
            this.label_Recipe.TabIndex = 0;
            this.label_Recipe.Text = "tRecipe";
            this.label_Recipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Base
            // 
            this.pnl_Base.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pnl_Base.Controls.Add(this.label_Recipe);
            this.pnl_Base.Location = new System.Drawing.Point(0, 0);
            this.pnl_Base.Name = "pnl_Base";
            this.pnl_Base.Size = new System.Drawing.Size(1280, 804);
            this.pnl_Base.TabIndex = 1;
            // 
            // vw00Recipe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.pnl_Base);
            this.DoubleBuffered = true;
            this.Name = "vw00Recipe";
            this.Size = new System.Drawing.Size(1280, 804);
            this.pnl_Base.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_Base;
        private System.Windows.Forms.Label label_Recipe;
    }
}
