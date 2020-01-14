namespace API2OOP
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbApiUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCopyResult2Clipboard = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbxLanguage = new System.Windows.Forms.ComboBox();
            this.lbxApiResult = new System.Windows.Forms.ListBox();
            this.txbCSObject = new System.Windows.Forms.TextBox();
            this.btnLoadApi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbPost1Key = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbPost1Value = new System.Windows.Forms.TextBox();
            this.txbPost2Key = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbPost2Value = new System.Windows.Forms.TextBox();
            this.txbPost3Key = new System.Windows.Forms.TextBox();
            this.txbPost3Value = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbApiUrl
            // 
            this.txbApiUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbApiUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbApiUrl.Location = new System.Drawing.Point(13, 29);
            this.txbApiUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txbApiUrl.Name = "txbApiUrl";
            this.txbApiUrl.Size = new System.Drawing.Size(566, 22);
            this.txbApiUrl.TabIndex = 0;
            this.txbApiUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbApiUrl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Api Url :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCopyResult2Clipboard);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbxLanguage);
            this.groupBox1.Controls.Add(this.lbxApiResult);
            this.groupBox1.Controls.Add(this.txbCSObject);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 101);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(635, 597);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result View";
            // 
            // btnCopyResult2Clipboard
            // 
            this.btnCopyResult2Clipboard.Location = new System.Drawing.Point(558, 535);
            this.btnCopyResult2Clipboard.Name = "btnCopyResult2Clipboard";
            this.btnCopyResult2Clipboard.Size = new System.Drawing.Size(69, 25);
            this.btnCopyResult2Clipboard.TabIndex = 5;
            this.btnCopyResult2Clipboard.Text = "Copy";
            this.btnCopyResult2Clipboard.UseVisualStyleBackColor = true;
            this.btnCopyResult2Clipboard.Click += new System.EventHandler(this.btnCopyResult2Clipboard_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(467, 566);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Get Sample-Code";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cbxLanguage
            // 
            this.cbxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxLanguage.FormattingEnabled = true;
            this.cbxLanguage.Items.AddRange(new object[] {
            "C#, Java, Python, etc.",
            "VBA",
            "PHP"});
            this.cbxLanguage.Location = new System.Drawing.Point(11, 566);
            this.cbxLanguage.Name = "cbxLanguage";
            this.cbxLanguage.Size = new System.Drawing.Size(133, 24);
            this.cbxLanguage.TabIndex = 3;
            this.cbxLanguage.SelectedValueChanged += new System.EventHandler(this.cbxLanguage_SelectedValueChanged);
            // 
            // lbxApiResult
            // 
            this.lbxApiResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxApiResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxApiResult.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxApiResult.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lbxApiResult.FormattingEnabled = true;
            this.lbxApiResult.ItemHeight = 18;
            this.lbxApiResult.Location = new System.Drawing.Point(11, 22);
            this.lbxApiResult.Name = "lbxApiResult";
            this.lbxApiResult.Size = new System.Drawing.Size(616, 506);
            this.lbxApiResult.TabIndex = 2;
            this.lbxApiResult.SelectedValueChanged += new System.EventHandler(this.lbxApiResult_SelectedValueChanged);
            // 
            // txbCSObject
            // 
            this.txbCSObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCSObject.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCSObject.Location = new System.Drawing.Point(11, 535);
            this.txbCSObject.Margin = new System.Windows.Forms.Padding(4);
            this.txbCSObject.Name = "txbCSObject";
            this.txbCSObject.ReadOnly = true;
            this.txbCSObject.Size = new System.Drawing.Size(540, 25);
            this.txbCSObject.TabIndex = 0;
            // 
            // btnLoadApi
            // 
            this.btnLoadApi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadApi.Location = new System.Drawing.Point(586, 29);
            this.btnLoadApi.Name = "btnLoadApi";
            this.btnLoadApi.Size = new System.Drawing.Size(63, 23);
            this.btnLoadApi.TabIndex = 2;
            this.btnLoadApi.Text = "Go";
            this.btnLoadApi.UseVisualStyleBackColor = true;
            this.btnLoadApi.Click += new System.EventHandler(this.btnLoadApi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "POST-Value 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "POST-Value 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "POST-Value 3";
            // 
            // txbPost1Key
            // 
            this.txbPost1Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPost1Key.Location = new System.Drawing.Point(12, 74);
            this.txbPost1Key.Name = "txbPost1Key";
            this.txbPost1Key.Size = new System.Drawing.Size(78, 20);
            this.txbPost1Key.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "=";
            // 
            // txbPost1Value
            // 
            this.txbPost1Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPost1Value.Location = new System.Drawing.Point(117, 74);
            this.txbPost1Value.Name = "txbPost1Value";
            this.txbPost1Value.Size = new System.Drawing.Size(78, 20);
            this.txbPost1Value.TabIndex = 4;
            // 
            // txbPost2Key
            // 
            this.txbPost2Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPost2Key.Location = new System.Drawing.Point(239, 74);
            this.txbPost2Key.Name = "txbPost2Key";
            this.txbPost2Key.Size = new System.Drawing.Size(78, 20);
            this.txbPost2Key.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "=";
            // 
            // txbPost2Value
            // 
            this.txbPost2Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPost2Value.Location = new System.Drawing.Point(344, 74);
            this.txbPost2Value.Name = "txbPost2Value";
            this.txbPost2Value.Size = new System.Drawing.Size(78, 20);
            this.txbPost2Value.TabIndex = 4;
            // 
            // txbPost3Key
            // 
            this.txbPost3Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPost3Key.Location = new System.Drawing.Point(466, 74);
            this.txbPost3Key.Name = "txbPost3Key";
            this.txbPost3Key.Size = new System.Drawing.Size(78, 20);
            this.txbPost3Key.TabIndex = 4;
            // 
            // txbPost3Value
            // 
            this.txbPost3Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPost3Value.Location = new System.Drawing.Point(571, 74);
            this.txbPost3Value.Name = "txbPost3Value";
            this.txbPost3Value.Size = new System.Drawing.Size(78, 20);
            this.txbPost3Value.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(550, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "=";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(201, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "        ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(428, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "        ";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(661, 711);
            this.Controls.Add(this.txbPost3Value);
            this.Controls.Add(this.txbPost3Key);
            this.Controls.Add(this.txbPost2Value);
            this.Controls.Add(this.txbPost2Key);
            this.Controls.Add(this.txbPost1Value);
            this.Controls.Add(this.txbPost1Key);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoadApi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbApiUrl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainWindow";
            this.Text = "API-2-OOP Parser";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbApiUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbCSObject;
        private System.Windows.Forms.Button btnLoadApi;
        private System.Windows.Forms.ListBox lbxApiResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbPost1Key;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbPost1Value;
        private System.Windows.Forms.TextBox txbPost2Key;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbPost2Value;
        private System.Windows.Forms.TextBox txbPost3Key;
        private System.Windows.Forms.TextBox txbPost3Value;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxLanguage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCopyResult2Clipboard;
    }
}

