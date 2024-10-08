namespace Victor
{
    partial class vw01RecipeList
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vw01RecipeList));
            this.label_RecipeList = new System.Windows.Forms.Label();
            this.pnlM_Grp = new System.Windows.Forms.Panel();
            this.lbxM_Grp = new System.Windows.Forms.ListBox();
            this.btnM_GDel = new System.Windows.Forms.Button();
            this.btnM_GCopy = new System.Windows.Forms.Button();
            this.btnM_GNew = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.pnlM_List = new System.Windows.Forms.Panel();
            this.lbxM_Dev = new System.Windows.Forms.ListBox();
            this.btnM_DDel = new System.Windows.Forms.Button();
            this.btnM_DCopy = new System.Windows.Forms.Button();
            this.btnM_DNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_Btn = new System.Windows.Forms.Panel();
            this.btnM_DApp = new System.Windows.Forms.Button();
            this.btnM_DBcr = new System.Windows.Forms.Button();
            this.btnM_DCur = new System.Windows.Forms.Button();
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlM_Grp.SuspendLayout();
            this.pnlM_List.SuspendLayout();
            this.pnl_Btn.SuspendLayout();
            this.pnl_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_RecipeList
            // 
            this.label_RecipeList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.label_RecipeList, "label_RecipeList");
            this.label_RecipeList.ForeColor = System.Drawing.SystemColors.Control;
            this.label_RecipeList.Name = "label_RecipeList";
            // 
            // pnlM_Grp
            // 
            this.pnlM_Grp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlM_Grp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlM_Grp.Controls.Add(this.label39);
            this.pnlM_Grp.Controls.Add(this.lbxM_Grp);
            this.pnlM_Grp.Controls.Add(this.label1);
            this.pnlM_Grp.Controls.Add(this.btnM_GDel);
            this.pnlM_Grp.Controls.Add(this.btnM_GCopy);
            this.pnlM_Grp.Controls.Add(this.btnM_GNew);
            resources.ApplyResources(this.pnlM_Grp, "pnlM_Grp");
            this.pnlM_Grp.Name = "pnlM_Grp";
            // 
            // lbxM_Grp
            // 
            this.lbxM_Grp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lbxM_Grp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxM_Grp.ForeColor = System.Drawing.Color.White;
            this.lbxM_Grp.FormattingEnabled = true;
            resources.ApplyResources(this.lbxM_Grp, "lbxM_Grp");
            this.lbxM_Grp.Items.AddRange(new object[] {
            resources.GetString("lbxM_Grp.Items"),
            resources.GetString("lbxM_Grp.Items1"),
            resources.GetString("lbxM_Grp.Items2")});
            this.lbxM_Grp.Name = "lbxM_Grp";
            this.lbxM_Grp.SelectedIndexChanged += new System.EventHandler(this.lbxM_Grp_SelectedIndexChanged);
            // 
            // btnM_GDel
            // 
            this.btnM_GDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnM_GDel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.btnM_GDel, "btnM_GDel");
            this.btnM_GDel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnM_GDel.Name = "btnM_GDel";
            this.btnM_GDel.TabStop = false;
            this.btnM_GDel.UseVisualStyleBackColor = false;
            this.btnM_GDel.Click += new System.EventHandler(this.btnClick_Delete);
            // 
            // btnM_GCopy
            // 
            this.btnM_GCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnM_GCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.btnM_GCopy, "btnM_GCopy");
            this.btnM_GCopy.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnM_GCopy.Name = "btnM_GCopy";
            this.btnM_GCopy.TabStop = false;
            this.btnM_GCopy.UseVisualStyleBackColor = false;
            this.btnM_GCopy.Click += new System.EventHandler(this.btnClick_SaveAs);
            // 
            // btnM_GNew
            // 
            this.btnM_GNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnM_GNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.btnM_GNew, "btnM_GNew");
            this.btnM_GNew.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnM_GNew.Name = "btnM_GNew";
            this.btnM_GNew.TabStop = false;
            this.btnM_GNew.UseVisualStyleBackColor = false;
            this.btnM_GNew.Click += new System.EventHandler(this.btnClick_New);
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.label39, "label39");
            this.label39.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label39.Name = "label39";
            // 
            // pnlM_List
            // 
            this.pnlM_List.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlM_List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlM_List.Controls.Add(this.label2);
            this.pnlM_List.Controls.Add(this.lbxM_Dev);
            this.pnlM_List.Controls.Add(this.label3);
            this.pnlM_List.Controls.Add(this.btnM_DDel);
            this.pnlM_List.Controls.Add(this.btnM_DCopy);
            this.pnlM_List.Controls.Add(this.btnM_DNew);
            resources.ApplyResources(this.pnlM_List, "pnlM_List");
            this.pnlM_List.Name = "pnlM_List";
            // 
            // lbxM_Dev
            // 
            this.lbxM_Dev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lbxM_Dev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxM_Dev.ForeColor = System.Drawing.Color.White;
            this.lbxM_Dev.FormattingEnabled = true;
            resources.ApplyResources(this.lbxM_Dev, "lbxM_Dev");
            this.lbxM_Dev.Name = "lbxM_Dev";
            this.lbxM_Dev.SelectedIndexChanged += new System.EventHandler(this.lbxM_Dev_SelectedIndexChanged);
            // 
            // btnM_DDel
            // 
            this.btnM_DDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnM_DDel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.btnM_DDel, "btnM_DDel");
            this.btnM_DDel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnM_DDel.Name = "btnM_DDel";
            this.btnM_DDel.TabStop = false;
            this.btnM_DDel.UseVisualStyleBackColor = false;
            this.btnM_DDel.Click += new System.EventHandler(this.btnClick_DeleteFile);
            // 
            // btnM_DCopy
            // 
            this.btnM_DCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnM_DCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.btnM_DCopy, "btnM_DCopy");
            this.btnM_DCopy.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnM_DCopy.Name = "btnM_DCopy";
            this.btnM_DCopy.TabStop = false;
            this.btnM_DCopy.UseVisualStyleBackColor = false;
            this.btnM_DCopy.Click += new System.EventHandler(this.btnClick_SaveAsFile);
            // 
            // btnM_DNew
            // 
            this.btnM_DNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnM_DNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.btnM_DNew, "btnM_DNew");
            this.btnM_DNew.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnM_DNew.Name = "btnM_DNew";
            this.btnM_DNew.TabStop = false;
            this.btnM_DNew.UseVisualStyleBackColor = false;
            this.btnM_DNew.Click += new System.EventHandler(this.btnClick_NewFile);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Name = "label2";
            // 
            // pnl_Btn
            // 
            this.pnl_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnl_Btn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Btn.Controls.Add(this.btnM_DApp);
            this.pnl_Btn.Controls.Add(this.btnM_DBcr);
            this.pnl_Btn.Controls.Add(this.btnM_DCur);
            resources.ApplyResources(this.pnl_Btn, "pnl_Btn");
            this.pnl_Btn.Name = "pnl_Btn";
            // 
            // btnM_DApp
            // 
            this.btnM_DApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnM_DApp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.btnM_DApp, "btnM_DApp");
            this.btnM_DApp.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnM_DApp.Name = "btnM_DApp";
            this.btnM_DApp.TabStop = false;
            this.btnM_DApp.Tag = "2";
            this.btnM_DApp.UseVisualStyleBackColor = false;
            this.btnM_DApp.Click += new System.EventHandler(this.btnM_DApp_Click);
            // 
            // btnM_DBcr
            // 
            this.btnM_DBcr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnM_DBcr.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.btnM_DBcr, "btnM_DBcr");
            this.btnM_DBcr.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnM_DBcr.Name = "btnM_DBcr";
            this.btnM_DBcr.TabStop = false;
            this.btnM_DBcr.Tag = "1";
            this.btnM_DBcr.UseVisualStyleBackColor = false;
            // 
            // btnM_DCur
            // 
            this.btnM_DCur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnM_DCur.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.btnM_DCur, "btnM_DCur");
            this.btnM_DCur.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnM_DCur.Name = "btnM_DCur";
            this.btnM_DCur.TabStop = false;
            this.btnM_DCur.Tag = "3";
            this.btnM_DCur.UseVisualStyleBackColor = false;
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pnl_Menu.Controls.Add(this.pnl_Btn);
            this.pnl_Menu.Controls.Add(this.pnlM_List);
            this.pnl_Menu.Controls.Add(this.pnlM_Grp);
            resources.ApplyResources(this.pnl_Menu, "pnl_Menu");
            this.pnl_Menu.Name = "pnl_Menu";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Name = "label3";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Name = "label1";
            // 
            // vw01RecipeList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.label_RecipeList);
            this.Controls.Add(this.pnl_Menu);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "vw01RecipeList";
            this.pnlM_Grp.ResumeLayout(false);
            this.pnlM_List.ResumeLayout(false);
            this.pnl_Btn.ResumeLayout(false);
            this.pnl_Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_RecipeList;
        private System.Windows.Forms.Panel pnlM_Grp;
        private System.Windows.Forms.ListBox lbxM_Grp;
        private System.Windows.Forms.Button btnM_GDel;
        private System.Windows.Forms.Button btnM_GCopy;
        private System.Windows.Forms.Button btnM_GNew;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Panel pnlM_List;
        private System.Windows.Forms.ListBox lbxM_Dev;
        private System.Windows.Forms.Button btnM_DDel;
        private System.Windows.Forms.Button btnM_DCopy;
        private System.Windows.Forms.Button btnM_DNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_Btn;
        private System.Windows.Forms.Button btnM_DApp;
        private System.Windows.Forms.Button btnM_DBcr;
        private System.Windows.Forms.Button btnM_DCur;
        private System.Windows.Forms.Panel pnl_Menu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}
