namespace AddinRibbon.Ctr
{
    partial class UcProperties
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
            this.tbOut = new System.Windows.Forms.TextBox();
            this.tbCategoryName = new System.Windows.Forms.TextBox();
            this.lbCategoryName = new System.Windows.Forms.Label();
            this.lbPropertyName = new System.Windows.Forms.Label();
            this.tbPropertyName = new System.Windows.Forms.TextBox();
            this.lbPropertyValue = new System.Windows.Forms.Label();
            this.tbPropertyValue = new System.Windows.Forms.TextBox();
            this.btFind = new System.Windows.Forms.Button();
            this.btCreateSet = new System.Windows.Forms.Button();
            this.btCreateSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbOut
            // 
            this.tbOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOut.Location = new System.Drawing.Point(3, 3);
            this.tbOut.Multiline = true;
            this.tbOut.Name = "tbOut";
            this.tbOut.ReadOnly = true;
            this.tbOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOut.Size = new System.Drawing.Size(357, 387);
            this.tbOut.TabIndex = 0;
            // 
            // tbCategoryName
            // 
            this.tbCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCategoryName.Location = new System.Drawing.Point(101, 408);
            this.tbCategoryName.Name = "tbCategoryName";
            this.tbCategoryName.Size = new System.Drawing.Size(158, 20);
            this.tbCategoryName.TabIndex = 1;
            this.tbCategoryName.TextChanged += new System.EventHandler(this.tbCategoryName_TextChanged);
            // 
            // lbCategoryName
            // 
            this.lbCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCategoryName.Location = new System.Drawing.Point(3, 408);
            this.lbCategoryName.Name = "lbCategoryName";
            this.lbCategoryName.Size = new System.Drawing.Size(92, 20);
            this.lbCategoryName.TabIndex = 2;
            this.lbCategoryName.Text = "Category Name:";
            this.lbCategoryName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbCategoryName.Click += new System.EventHandler(this.lbCategoryName_Click);
            // 
            // lbPropertyName
            // 
            this.lbPropertyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbPropertyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPropertyName.Location = new System.Drawing.Point(3, 434);
            this.lbPropertyName.Name = "lbPropertyName";
            this.lbPropertyName.Size = new System.Drawing.Size(92, 20);
            this.lbPropertyName.TabIndex = 4;
            this.lbPropertyName.Text = "Property Name:";
            this.lbPropertyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPropertyName
            // 
            this.tbPropertyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPropertyName.Location = new System.Drawing.Point(101, 434);
            this.tbPropertyName.Name = "tbPropertyName";
            this.tbPropertyName.Size = new System.Drawing.Size(158, 20);
            this.tbPropertyName.TabIndex = 3;
            // 
            // lbPropertyValue
            // 
            this.lbPropertyValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbPropertyValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPropertyValue.Location = new System.Drawing.Point(3, 460);
            this.lbPropertyValue.Name = "lbPropertyValue";
            this.lbPropertyValue.Size = new System.Drawing.Size(92, 20);
            this.lbPropertyValue.TabIndex = 6;
            this.lbPropertyValue.Text = "Property Value:";
            this.lbPropertyValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPropertyValue
            // 
            this.tbPropertyValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPropertyValue.Location = new System.Drawing.Point(101, 460);
            this.tbPropertyValue.Name = "tbPropertyValue";
            this.tbPropertyValue.Size = new System.Drawing.Size(158, 20);
            this.tbPropertyValue.TabIndex = 5;
            // 
            // btFind
            // 
            this.btFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btFind.Location = new System.Drawing.Point(265, 408);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(95, 20);
            this.btFind.TabIndex = 7;
            this.btFind.Text = "Find";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            this.btFind.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btFind_MouseUp);
            // 
            // btCreateSet
            // 
            this.btCreateSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateSet.Location = new System.Drawing.Point(265, 434);
            this.btCreateSet.Name = "btCreateSet";
            this.btCreateSet.Size = new System.Drawing.Size(95, 20);
            this.btCreateSet.TabIndex = 8;
            this.btCreateSet.Text = "Create Set";
            this.btCreateSet.UseVisualStyleBackColor = true;
            this.btCreateSet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btCreateSet_MouseUp);
            // 
            // btCreateSearch
            // 
            this.btCreateSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreateSearch.Location = new System.Drawing.Point(265, 460);
            this.btCreateSearch.Name = "btCreateSearch";
            this.btCreateSearch.Size = new System.Drawing.Size(95, 20);
            this.btCreateSearch.TabIndex = 9;
            this.btCreateSearch.Text = "Create Search";
            this.btCreateSearch.UseVisualStyleBackColor = true;
            this.btCreateSearch.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btCreateSearch_MouseUp);
            // 
            // UcProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btCreateSearch);
            this.Controls.Add(this.btCreateSet);
            this.Controls.Add(this.btFind);
            this.Controls.Add(this.lbPropertyValue);
            this.Controls.Add(this.tbPropertyValue);
            this.Controls.Add(this.lbPropertyName);
            this.Controls.Add(this.tbPropertyName);
            this.Controls.Add(this.lbCategoryName);
            this.Controls.Add(this.tbCategoryName);
            this.Controls.Add(this.tbOut);
            this.Name = "UcProperties";
            this.Size = new System.Drawing.Size(363, 519);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOut;
        private System.Windows.Forms.TextBox tbCategoryName;
        private System.Windows.Forms.Label lbCategoryName;
        private System.Windows.Forms.Label lbPropertyName;
        private System.Windows.Forms.TextBox tbPropertyName;
        private System.Windows.Forms.Label lbPropertyValue;
        private System.Windows.Forms.TextBox tbPropertyValue;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.Button btCreateSet;
        private System.Windows.Forms.Button btCreateSearch;
    }
}
