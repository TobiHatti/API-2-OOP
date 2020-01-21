namespace API2OOP
{
    partial class LanguageExample
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
            this.cbxExampleLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseExample = new System.Windows.Forms.Button();
            this.btnCopyExample = new System.Windows.Forms.Button();
            this.webLanguageExample = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // cbxExampleLanguage
            // 
            this.cbxExampleLanguage.FormattingEnabled = true;
            this.cbxExampleLanguage.Items.AddRange(new object[] {
            "C#",
            "C++",
            "C",
            "VB .NET",
            "Java",
            "JavaScript",
            "PHP",
            "Python"});
            this.cbxExampleLanguage.Location = new System.Drawing.Point(96, 13);
            this.cbxExampleLanguage.Margin = new System.Windows.Forms.Padding(4);
            this.cbxExampleLanguage.Name = "cbxExampleLanguage";
            this.cbxExampleLanguage.Size = new System.Drawing.Size(160, 24);
            this.cbxExampleLanguage.TabIndex = 1;
            this.cbxExampleLanguage.SelectedValueChanged += new System.EventHandler(this.cbxExampleLanguage_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Language:";
            // 
            // btnCloseExample
            // 
            this.btnCloseExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseExample.Location = new System.Drawing.Point(802, 403);
            this.btnCloseExample.Name = "btnCloseExample";
            this.btnCloseExample.Size = new System.Drawing.Size(75, 23);
            this.btnCloseExample.TabIndex = 3;
            this.btnCloseExample.Text = "Close";
            this.btnCloseExample.UseVisualStyleBackColor = true;
            this.btnCloseExample.Click += new System.EventHandler(this.btnCloseExample_Click);
            // 
            // btnCopyExample
            // 
            this.btnCopyExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyExample.Location = new System.Drawing.Point(12, 403);
            this.btnCopyExample.Name = "btnCopyExample";
            this.btnCopyExample.Size = new System.Drawing.Size(145, 23);
            this.btnCopyExample.TabIndex = 3;
            this.btnCopyExample.Text = "Copy to Clipboard";
            this.btnCopyExample.UseVisualStyleBackColor = true;
            this.btnCopyExample.Click += new System.EventHandler(this.btnCopyExample_Click);
            // 
            // webLanguageExample
            // 
            this.webLanguageExample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webLanguageExample.Location = new System.Drawing.Point(12, 44);
            this.webLanguageExample.MinimumSize = new System.Drawing.Size(20, 20);
            this.webLanguageExample.Name = "webLanguageExample";
            this.webLanguageExample.Size = new System.Drawing.Size(865, 352);
            this.webLanguageExample.TabIndex = 4;
            // 
            // LanguageExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 438);
            this.Controls.Add(this.webLanguageExample);
            this.Controls.Add(this.btnCopyExample);
            this.Controls.Add(this.btnCloseExample);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxExampleLanguage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LanguageExample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LanguageExample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxExampleLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCloseExample;
        private System.Windows.Forms.Button btnCopyExample;
        private System.Windows.Forms.WebBrowser webLanguageExample;
    }
}