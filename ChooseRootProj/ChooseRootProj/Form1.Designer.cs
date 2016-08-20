namespace ChooseRootProj
{
    partial class Form1
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
            this.MatrixGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.sizeMatrixText = new System.Windows.Forms.TextBox();
            this.SizeMatrixConfirm = new System.Windows.Forms.Button();
            this.fillCellsLabel = new System.Windows.Forms.Label();
            this.BuildMatrixButton = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.BuildFromFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MatrixGrid
            // 
            this.MatrixGrid.AllowUserToAddRows = false;
            this.MatrixGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatrixGrid.Location = new System.Drawing.Point(12, 102);
            this.MatrixGrid.Name = "MatrixGrid";
            this.MatrixGrid.Size = new System.Drawing.Size(1138, 433);
            this.MatrixGrid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter the size of matrix:";
            // 
            // sizeMatrixText
            // 
            this.sizeMatrixText.Location = new System.Drawing.Point(286, 12);
            this.sizeMatrixText.Name = "sizeMatrixText";
            this.sizeMatrixText.Size = new System.Drawing.Size(100, 20);
            this.sizeMatrixText.TabIndex = 2;
            // 
            // SizeMatrixConfirm
            // 
            this.SizeMatrixConfirm.Location = new System.Drawing.Point(409, 9);
            this.SizeMatrixConfirm.Name = "SizeMatrixConfirm";
            this.SizeMatrixConfirm.Size = new System.Drawing.Size(100, 23);
            this.SizeMatrixConfirm.TabIndex = 3;
            this.SizeMatrixConfirm.Text = "Ok";
            this.SizeMatrixConfirm.UseVisualStyleBackColor = true;
            this.SizeMatrixConfirm.Click += new System.EventHandler(this.SizeMatrixConfirm_Click);
            // 
            // fillCellsLabel
            // 
            this.fillCellsLabel.AutoSize = true;
            this.fillCellsLabel.Enabled = false;
            this.fillCellsLabel.Location = new System.Drawing.Point(139, 69);
            this.fillCellsLabel.Name = "fillCellsLabel";
            this.fillCellsLabel.Size = new System.Drawing.Size(101, 13);
            this.fillCellsLabel.TabIndex = 4;
            this.fillCellsLabel.Text = "Fill all cells of matrix:";
            // 
            // BuildMatrixButton
            // 
            this.BuildMatrixButton.Location = new System.Drawing.Point(409, 59);
            this.BuildMatrixButton.Name = "BuildMatrixButton";
            this.BuildMatrixButton.Size = new System.Drawing.Size(100, 23);
            this.BuildMatrixButton.TabIndex = 5;
            this.BuildMatrixButton.Text = "Build!";
            this.BuildMatrixButton.UseVisualStyleBackColor = true;
            this.BuildMatrixButton.Click += new System.EventHandler(this.BuildMatrix);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(603, 58);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 6;
            this.ButtonReset.Text = "reset";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // BuildFromFile
            // 
            this.BuildFromFile.Location = new System.Drawing.Point(603, 9);
            this.BuildFromFile.Name = "BuildFromFile";
            this.BuildFromFile.Size = new System.Drawing.Size(107, 23);
            this.BuildFromFile.TabIndex = 7;
            this.BuildFromFile.Text = "from file";
            this.BuildFromFile.UseVisualStyleBackColor = true;
            this.BuildFromFile.Click += new System.EventHandler(this.BuildFromFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 619);
            this.Controls.Add(this.BuildFromFile);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.BuildMatrixButton);
            this.Controls.Add(this.fillCellsLabel);
            this.Controls.Add(this.SizeMatrixConfirm);
            this.Controls.Add(this.sizeMatrixText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MatrixGrid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MatrixGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MatrixGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sizeMatrixText;
        private System.Windows.Forms.Button SizeMatrixConfirm;
        private System.Windows.Forms.Label fillCellsLabel;
        private System.Windows.Forms.Button BuildMatrixButton;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button BuildFromFile;
    }
}

