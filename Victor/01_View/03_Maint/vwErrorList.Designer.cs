namespace Victor
{
    partial class vwErrorList
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
            _Release();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Pnl_Item = new System.Windows.Forms.Panel();
            this.grp_Image = new System.Windows.Forms.GroupBox();
            this.pb_Image = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rTB_ErrorCause = new System.Windows.Forms.RichTextBox();
            this.rTB_ErrTitle = new System.Windows.Forms.RichTextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.grp_Error = new System.Windows.Forms.GroupBox();
            this.dGV_ErrorList = new System.Windows.Forms.DataGridView();
            this.Pnl_Item.SuspendLayout();
            this.grp_Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grp_Error.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_ErrorList)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Item
            // 
            this.Pnl_Item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.Pnl_Item.Controls.Add(this.grp_Image);
            this.Pnl_Item.Controls.Add(this.groupBox2);
            this.Pnl_Item.Controls.Add(this.grp_Error);
            this.Pnl_Item.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Item.Name = "Pnl_Item";
            this.Pnl_Item.Size = new System.Drawing.Size(1280, 768);
            this.Pnl_Item.TabIndex = 460;
            // 
            // grp_Image
            // 
            this.grp_Image.Controls.Add(this.pb_Image);
            this.grp_Image.Controls.Add(this.pictureBox1);
            this.grp_Image.ForeColor = System.Drawing.Color.White;
            this.grp_Image.Location = new System.Drawing.Point(643, 385);
            this.grp_Image.Name = "grp_Image";
            this.grp_Image.Size = new System.Drawing.Size(630, 380);
            this.grp_Image.TabIndex = 463;
            this.grp_Image.TabStop = false;
            this.grp_Image.Text = "Image File";
            // 
            // pb_Image
            // 
            this.pb_Image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(100)))));
            this.pb_Image.Location = new System.Drawing.Point(91, 25);
            this.pb_Image.Name = "pb_Image";
            this.pb_Image.Size = new System.Drawing.Size(448, 336);
            this.pb_Image.TabIndex = 1;
            this.pb_Image.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(0, 0);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rTB_ErrorCause);
            this.groupBox2.Controls.Add(this.rTB_ErrTitle);
            this.groupBox2.Controls.Add(this.btn_Save);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(643, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 376);
            this.groupBox2.TabIndex = 463;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output List ";
            // 
            // rTB_ErrorCause
            // 
            this.rTB_ErrorCause.Location = new System.Drawing.Point(12, 67);
            this.rTB_ErrorCause.Name = "rTB_ErrorCause";
            this.rTB_ErrorCause.Size = new System.Drawing.Size(598, 300);
            this.rTB_ErrorCause.TabIndex = 462;
            this.rTB_ErrorCause.Text = "Error Cause";
            // 
            // rTB_ErrTitle
            // 
            this.rTB_ErrTitle.Location = new System.Drawing.Point(12, 29);
            this.rTB_ErrTitle.Name = "rTB_ErrTitle";
            this.rTB_ErrTitle.Size = new System.Drawing.Size(488, 30);
            this.rTB_ErrTitle.TabIndex = 461;
            this.rTB_ErrTitle.Text = "Error Title";
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(506, 29);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(104, 32);
            this.btn_Save.TabIndex = 463;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.Click_Output);
            // 
            // grp_Error
            // 
            this.grp_Error.Controls.Add(this.dGV_ErrorList);
            this.grp_Error.ForeColor = System.Drawing.Color.LawnGreen;
            this.grp_Error.Location = new System.Drawing.Point(3, 3);
            this.grp_Error.Name = "grp_Error";
            this.grp_Error.Size = new System.Drawing.Size(630, 762);
            this.grp_Error.TabIndex = 463;
            this.grp_Error.TabStop = false;
            this.grp_Error.Text = "Error List ";
            // 
            // dGV_ErrorList
            // 
            this.dGV_ErrorList.AllowUserToAddRows = false;
            this.dGV_ErrorList.AllowUserToDeleteRows = false;
            this.dGV_ErrorList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.dGV_ErrorList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dGV_ErrorList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_ErrorList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGV_ErrorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGV_ErrorList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGV_ErrorList.Location = new System.Drawing.Point(8, 25);
            this.dGV_ErrorList.Name = "dGV_ErrorList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_ErrorList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGV_ErrorList.RowHeadersVisible = false;
            this.dGV_ErrorList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dGV_ErrorList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGV_ErrorList.RowTemplate.Height = 23;
            this.dGV_ErrorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV_ErrorList.Size = new System.Drawing.Size(616, 731);
            this.dGV_ErrorList.TabIndex = 457;
            this.dGV_ErrorList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_ErrorList_CellClick);
            // 
            // vwErrorList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Pnl_Item);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "vwErrorList";
            this.Size = new System.Drawing.Size(1280, 768);
            this.Pnl_Item.ResumeLayout(false);
            this.grp_Image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.grp_Error.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_ErrorList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Pnl_Item;
        private System.Windows.Forms.DataGridView dGV_ErrorList;
        private System.Windows.Forms.GroupBox grp_Error;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox grp_Image;
        private System.Windows.Forms.PictureBox pb_Image;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rTB_ErrorCause;
        private System.Windows.Forms.RichTextBox rTB_ErrTitle;
    }
}