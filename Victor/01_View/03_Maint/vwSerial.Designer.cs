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
            this.Pnl_Item = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radio_Save = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Pnl_Item.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Item
            // 
            this.Pnl_Item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Pnl_Item.Controls.Add(this.button2);
            this.Pnl_Item.Controls.Add(this.button1);
            this.Pnl_Item.Controls.Add(this.dataGridView1);
            this.Pnl_Item.Controls.Add(this.radio_Save);
            this.Pnl_Item.Controls.Add(this.label1);
            this.Pnl_Item.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Item.Name = "Pnl_Item";
            this.Pnl_Item.Size = new System.Drawing.Size(1280, 768);
            this.Pnl_Item.TabIndex = 460;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(117, 298);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(214, 29);
            this.button2.TabIndex = 458;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Click_Save);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(117, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 29);
            this.button1.TabIndex = 458;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Click_Open);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(59, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(445, 154);
            this.dataGridView1.TabIndex = 457;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // radio_Save
            // 
            this.radio_Save.Appearance = System.Windows.Forms.Appearance.Button;
            this.radio_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.radio_Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.radio_Save.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue;
            this.radio_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radio_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.radio_Save.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radio_Save.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radio_Save.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radio_Save.Location = new System.Drawing.Point(1136, 657);
            this.radio_Save.Margin = new System.Windows.Forms.Padding(0);
            this.radio_Save.Name = "radio_Save";
            this.radio_Save.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.radio_Save.Size = new System.Drawing.Size(133, 72);
            this.radio_Save.TabIndex = 456;
            this.radio_Save.Tag = "11";
            this.radio_Save.Text = "Save";
            this.radio_Save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radio_Save.UseVisualStyleBackColor = false;
            this.radio_Save.Click += new System.EventHandler(this.Click_Save);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1132, 609);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial";
            // 
            // vwSerial
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Pnl_Item);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "vwSerial";
            this.Size = new System.Drawing.Size(1280, 768);
            this.Pnl_Item.ResumeLayout(false);
            this.Pnl_Item.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Pnl_Item;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radio_Save;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}