namespace Victor
{
    partial class vwSerial
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
            this.label_MaintBase = new System.Windows.Forms.Label();
            this.Pnl_Item = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label_MaintBase
            // 
            this.label_MaintBase.BackColor = System.Drawing.Color.Indigo;
            this.label_MaintBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_MaintBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label_MaintBase.ForeColor = System.Drawing.SystemColors.Control;
            this.label_MaintBase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_MaintBase.Location = new System.Drawing.Point(0, 0);
            this.label_MaintBase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_MaintBase.Name = "label_MaintBase";
            this.label_MaintBase.Size = new System.Drawing.Size(1280, 30);
            this.label_MaintBase.TabIndex = 453;
            this.label_MaintBase.Text = "Maint Base";
            this.label_MaintBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pnl_Item
            // 
            this.Pnl_Item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Pnl_Item.Location = new System.Drawing.Point(0, 33);
            this.Pnl_Item.Name = "Pnl_Item";
            this.Pnl_Item.Size = new System.Drawing.Size(1280, 768);
            this.Pnl_Item.TabIndex = 460;
            // 
            // vwSerial
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label_MaintBase);
            this.Controls.Add(this.Pnl_Item);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "vwSerial";
            this.Size = new System.Drawing.Size(1280, 804);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_MaintBase;
        private System.Windows.Forms.Panel Pnl_Item;
    }
}