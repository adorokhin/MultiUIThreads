namespace MultiUIThread
{
    partial class Child_Form
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
            this.labelBatch = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTask = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCycle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelBatch
            // 
            this.labelBatch.AutoSize = true;
            this.labelBatch.BackColor = System.Drawing.Color.Black;
            this.labelBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBatch.ForeColor = System.Drawing.Color.Yellow;
            this.labelBatch.Location = new System.Drawing.Point(104, 9);
            this.labelBatch.Name = "labelBatch";
            this.labelBatch.Size = new System.Drawing.Size(86, 31);
            this.labelBatch.TabIndex = 0;
            this.labelBatch.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Batch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Task";
            // 
            // labelTask
            // 
            this.labelTask.AutoSize = true;
            this.labelTask.BackColor = System.Drawing.Color.Black;
            this.labelTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTask.ForeColor = System.Drawing.Color.Yellow;
            this.labelTask.Location = new System.Drawing.Point(104, 42);
            this.labelTask.Name = "labelTask";
            this.labelTask.Size = new System.Drawing.Size(86, 31);
            this.labelTask.TabIndex = 2;
            this.labelTask.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(12, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "Cycle";
            // 
            // labelCycle
            // 
            this.labelCycle.AutoSize = true;
            this.labelCycle.BackColor = System.Drawing.Color.Black;
            this.labelCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCycle.ForeColor = System.Drawing.Color.Yellow;
            this.labelCycle.Location = new System.Drawing.Point(104, 75);
            this.labelCycle.Name = "labelCycle";
            this.labelCycle.Size = new System.Drawing.Size(86, 31);
            this.labelCycle.TabIndex = 4;
            this.labelCycle.Text = "label1";
            // 
            // Child_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 122);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelCycle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelBatch);
            this.Name = "Child_Form";
            this.Text = "Child";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelBatch;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelTask;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label labelCycle;
    }
}