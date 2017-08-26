namespace ZonClubHackTool
{
    partial class TaiXiu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbData
            // 
            this.tbData.BackColor = System.Drawing.Color.White;
            this.tbData.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbData.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbData.Location = new System.Drawing.Point(2, 1);
            this.tbData.Multiline = true;
            this.tbData.Name = "tbData";
            this.tbData.ReadOnly = true;
            this.tbData.Size = new System.Drawing.Size(96, 87);
            this.tbData.TabIndex = 0;
            this.tbData.Text = "#75395: Xỉu - 9 (1 4 4)";
            // 
            // TaiXiu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tbData);
            this.Name = "TaiXiu";
            this.Size = new System.Drawing.Size(100, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbData;
    }
}
