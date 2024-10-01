namespace Victor._02_Dialogue
{
    partial class Form_DevSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_Can = new System.Windows.Forms.Button();
            this.txt_Value = new System.Windows.Forms.TextBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.tipName = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_gVal = new System.Windows.Forms.Label();
            this.lb_dVal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title
            // 
            this.lbl_Title.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_Title.ForeColor = System.Drawing.Color.Black;
            this.lbl_Title.Location = new System.Drawing.Point(12, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(206, 23);
            this.lbl_Title.TabIndex = 8;
            // 
            // btn_Can
            // 
            this.btn_Can.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Can.FlatAppearance.BorderSize = 0;
            this.btn_Can.ForeColor = System.Drawing.Color.Black;
            this.btn_Can.Location = new System.Drawing.Point(301, 431);
            this.btn_Can.Name = "btn_Can";
            this.btn_Can.Size = new System.Drawing.Size(75, 23);
            this.btn_Can.TabIndex = 6;
            this.btn_Can.Tag = "";
            this.btn_Can.Text = "Cancel";
            this.btn_Can.UseVisualStyleBackColor = false;
            this.btn_Can.Click += new System.EventHandler(this.btn_Can_Click);
            // 
            // txt_Value
            // 
            this.txt_Value.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txt_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Value.ForeColor = System.Drawing.Color.Black;
            this.txt_Value.Location = new System.Drawing.Point(23, 350);
            this.txt_Value.Name = "txt_Value";
            this.txt_Value.Size = new System.Drawing.Size(100, 21);
            this.txt_Value.TabIndex = 7;
            this.txt_Value.Tag = "0";
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Ok.FlatAppearance.BorderSize = 0;
            this.btn_Ok.ForeColor = System.Drawing.Color.Black;
            this.btn_Ok.Location = new System.Drawing.Point(220, 431);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 5;
            this.btn_Ok.Tag = "";
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // tipName
            // 
            this.tipName.ForeColor = System.Drawing.Color.Red;
            this.tipName.ShowAlways = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(23, 73);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(333, 271);
            this.dataGridView1.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 3;
            // 
            // lb_gVal
            // 
            this.lb_gVal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lb_gVal.ForeColor = System.Drawing.Color.Black;
            this.lb_gVal.Location = new System.Drawing.Point(186, 374);
            this.lb_gVal.Name = "lb_gVal";
            this.lb_gVal.Size = new System.Drawing.Size(100, 23);
            this.lb_gVal.TabIndex = 2;
            // 
            // lb_dVal
            // 
            this.lb_dVal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lb_dVal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lb_dVal.Location = new System.Drawing.Point(224, 24);
            this.lb_dVal.Name = "lb_dVal";
            this.lb_dVal.Size = new System.Drawing.Size(100, 23);
            this.lb_dVal.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 1;
            // 
            // Form_DevSelect
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(405, 466);
            this.Controls.Add(this.lb_dVal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_gVal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_Can);
            this.Controls.Add(this.txt_Value);
            this.Controls.Add(this.lbl_Title);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_DevSelect";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button btn_Can;
        private System.Windows.Forms.TextBox txt_Value;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.ToolTip tipName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_gVal;
        private System.Windows.Forms.Label lb_dVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}