namespace CodeGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTableInfo = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCopyDataAcc = new System.Windows.Forms.Button();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.WebTxtDataAccsess = new System.Windows.Forms.WebBrowser();
            this.clbTables = new System.Windows.Forms.CheckedListBox();
            this.WebTxtBusinessLayers = new System.Windows.Forms.WebBrowser();
            this.btnCopyBusunessLayer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(0, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Base";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(0, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Table";
            // 
            // dgvTableInfo
            // 
            this.dgvTableInfo.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTableInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableInfo.Location = new System.Drawing.Point(5, 331);
            this.dgvTableInfo.Name = "dgvTableInfo";
            this.dgvTableInfo.Size = new System.Drawing.Size(340, 324);
            this.dgvTableInfo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(12, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Table Info";
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateCode.ForeColor = System.Drawing.Color.Blue;
            this.btnGenerateCode.Location = new System.Drawing.Point(167, 278);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(129, 38);
            this.btnGenerateCode.TabIndex = 7;
            this.btnGenerateCode.Text = "Generate";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // txtTableName
            // 
            this.txtTableName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTableName.Location = new System.Drawing.Point(121, 210);
            this.txtTableName.Multiline = true;
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(175, 28);
            this.txtTableName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(0, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Table Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(687, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data Accsess Code";
            // 
            // btnCopyDataAcc
            // 
            this.btnCopyDataAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyDataAcc.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnCopyDataAcc.Location = new System.Drawing.Point(912, 7);
            this.btnCopyDataAcc.Name = "btnCopyDataAcc";
            this.btnCopyDataAcc.Size = new System.Drawing.Size(96, 28);
            this.btnCopyDataAcc.TabIndex = 12;
            this.btnCopyDataAcc.Text = "Copy";
            this.btnCopyDataAcc.UseVisualStyleBackColor = true;
            this.btnCopyDataAcc.Click += new System.EventHandler(this.btnCopyDataAcc_Click);
            // 
            // cmbTable
            // 
            this.cmbTable.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(109, 137);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(187, 24);
            this.cmbTable.TabIndex = 43;
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged_1);
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.BackColor = System.Drawing.Color.White;
            this.cmbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(109, 61);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(187, 28);
            this.cmbDatabase.TabIndex = 44;
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged_1);
            // 
            // WebTxtDataAccsess
            // 
            this.WebTxtDataAccsess.Location = new System.Drawing.Point(601, 45);
            this.WebTxtDataAccsess.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebTxtDataAccsess.Name = "WebTxtDataAccsess";
            this.WebTxtDataAccsess.Size = new System.Drawing.Size(491, 276);
            this.WebTxtDataAccsess.TabIndex = 46;
            // 
            // clbTables
            // 
            this.clbTables.CheckOnClick = true;
            this.clbTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbTables.FormattingEnabled = true;
            this.clbTables.Location = new System.Drawing.Point(315, 61);
            this.clbTables.Name = "clbTables";
            this.clbTables.Size = new System.Drawing.Size(239, 251);
            this.clbTables.TabIndex = 47;
            // 
            // WebTxtBusinessLayers
            // 
            this.WebTxtBusinessLayers.Location = new System.Drawing.Point(601, 376);
            this.WebTxtBusinessLayers.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebTxtBusinessLayers.Name = "WebTxtBusinessLayers";
            this.WebTxtBusinessLayers.Size = new System.Drawing.Size(491, 276);
            this.WebTxtBusinessLayers.TabIndex = 48;
            // 
            // btnCopyBusunessLayer
            // 
            this.btnCopyBusunessLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyBusunessLayer.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnCopyBusunessLayer.Location = new System.Drawing.Point(912, 332);
            this.btnCopyBusunessLayer.Name = "btnCopyBusunessLayer";
            this.btnCopyBusunessLayer.Size = new System.Drawing.Size(96, 28);
            this.btnCopyBusunessLayer.TabIndex = 50;
            this.btnCopyBusunessLayer.Text = "Copy";
            this.btnCopyBusunessLayer.UseVisualStyleBackColor = true;
            this.btnCopyBusunessLayer.Click += new System.EventHandler(this.btnCopyBusinessLayer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(687, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 24);
            this.label6.TabIndex = 49;
            this.label6.Text = "Business Layer Code";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1120, 667);
            this.Controls.Add(this.btnCopyBusunessLayer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.WebTxtBusinessLayers);
            this.Controls.Add(this.clbTables);
            this.Controls.Add(this.WebTxtDataAccsess);
            this.Controls.Add(this.cmbDatabase);
            this.Controls.Add(this.cmbTable);
            this.Controls.Add(this.btnCopyDataAcc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.btnGenerateCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvTableInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTableInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCopyDataAcc;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.WebBrowser WebTxtDataAccsess;
        private System.Windows.Forms.CheckedListBox clbTables;
        private System.Windows.Forms.WebBrowser WebTxtBusinessLayers;
        private System.Windows.Forms.Button btnCopyBusunessLayer;
        private System.Windows.Forms.Label label6;
    }
}

