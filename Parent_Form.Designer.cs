﻿namespace MultiUIThread
{
    partial class Parent_Form
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
            this.buttonSpawn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSpawn
            // 
            this.buttonSpawn.Location = new System.Drawing.Point(39, 167);
            this.buttonSpawn.Name = "buttonSpawn";
            this.buttonSpawn.Size = new System.Drawing.Size(203, 68);
            this.buttonSpawn.TabIndex = 0;
            this.buttonSpawn.Text = "Spawn";
            this.buttonSpawn.UseVisualStyleBackColor = true;
            this.buttonSpawn.Click += new System.EventHandler(this.buttonSpawn_Click);
            // 
            // Parent_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonSpawn);
            this.Name = "Parent_Form";
            this.Text = "Parent";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSpawn;
    }
}
