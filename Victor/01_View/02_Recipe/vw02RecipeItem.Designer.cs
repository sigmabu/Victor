namespace Victor
{
    partial class vw02RecipeItem
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
            this.label_RecipeItem = new System.Windows.Forms.Label();
            this.radio_Save = new System.Windows.Forms.RadioButton();
            this.Pnl_Item = new System.Windows.Forms.Panel();
            this.Pnl_Button = new System.Windows.Forms.Panel();
            this.Pnl_Button.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_RecipeItem
            // 
            this.label_RecipeItem.BackColor = System.Drawing.Color.Indigo;
            this.label_RecipeItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_RecipeItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label_RecipeItem.ForeColor = System.Drawing.SystemColors.Control;
            this.label_RecipeItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_RecipeItem.Location = new System.Drawing.Point(0, 0);
            this.label_RecipeItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_RecipeItem.Name = "label_RecipeItem";
            this.label_RecipeItem.Size = new System.Drawing.Size(1280, 30);
            this.label_RecipeItem.TabIndex = 453;
            this.label_RecipeItem.Text = "RECIPE Item";
            this.label_RecipeItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.radio_Save.Location = new System.Drawing.Point(5, 657);
            this.radio_Save.Margin = new System.Windows.Forms.Padding(0);
            this.radio_Save.Name = "radio_Save";
            this.radio_Save.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.radio_Save.Size = new System.Drawing.Size(133, 72);
            this.radio_Save.TabIndex = 455;
            this.radio_Save.Tag = "11";
            this.radio_Save.Text = "Save";
            this.radio_Save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radio_Save.UseVisualStyleBackColor = false;
            this.radio_Save.Click += new System.EventHandler(this.Click_Save);
            // 
            // Pnl_Item
            // 
            this.Pnl_Item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.Pnl_Item.Location = new System.Drawing.Point(0, 33);
            this.Pnl_Item.Name = "Pnl_Item";
            this.Pnl_Item.Size = new System.Drawing.Size(1136, 768);
            this.Pnl_Item.TabIndex = 460;
            // 
            // Pnl_Button
            // 
            this.Pnl_Button.BackColor = System.Drawing.Color.Black;
            this.Pnl_Button.Controls.Add(this.radio_Save);
            this.Pnl_Button.Location = new System.Drawing.Point(1136, 33);
            this.Pnl_Button.Name = "Pnl_Button";
            this.Pnl_Button.Size = new System.Drawing.Size(141, 768);
            this.Pnl_Button.TabIndex = 461;
            // 
            // vw02RecipeItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label_RecipeItem);
            this.Controls.Add(this.Pnl_Button);
            this.Controls.Add(this.Pnl_Item);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "vw02RecipeItem";
            this.Size = new System.Drawing.Size(1280, 804);
            this.Pnl_Button.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_RecipeItem;
        private System.Windows.Forms.RadioButton radio_Save;
        private System.Windows.Forms.Panel Pnl_Item;
        private System.Windows.Forms.Panel Pnl_Button;
    }
}