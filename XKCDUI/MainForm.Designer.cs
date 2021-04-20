
namespace XKCDUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ButtonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.GetButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SkipButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ComicBox = new System.Windows.Forms.PictureBox();
            this.ComicTitle = new System.Windows.Forms.Label();
            this.LabelPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComicBox)).BeginInit();
            this.LabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonPanel.ColumnCount = 3;
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ButtonPanel.Controls.Add(this.GetButton, 1, 1);
            this.ButtonPanel.Controls.Add(this.SaveButton, 1, 3);
            this.ButtonPanel.Controls.Add(this.SkipButton, 1, 5);
            this.ButtonPanel.Controls.Add(this.SearchButton, 1, 7);
            this.ButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.RowCount = 9;
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ButtonPanel.Size = new System.Drawing.Size(217, 361);
            this.ButtonPanel.TabIndex = 6;
            // 
            // GetButton
            // 
            this.GetButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GetButton.BackColor = System.Drawing.SystemColors.Control;
            this.GetButton.Location = new System.Drawing.Point(23, 33);
            this.GetButton.Name = "GetButton";
            this.GetButton.Size = new System.Drawing.Size(151, 46);
            this.GetButton.TabIndex = 0;
            this.GetButton.Text = "Most Recent XKCD";
            this.GetButton.UseVisualStyleBackColor = false;
            this.GetButton.Click += new System.EventHandler(this.GetButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SaveButton.BackColor = System.Drawing.SystemColors.Control;
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(23, 115);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(151, 46);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save Comic";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SkipButton
            // 
            this.SkipButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SkipButton.BackColor = System.Drawing.SystemColors.Control;
            this.SkipButton.Location = new System.Drawing.Point(23, 197);
            this.SkipButton.Name = "SkipButton";
            this.SkipButton.Size = new System.Drawing.Size(151, 46);
            this.SkipButton.TabIndex = 2;
            this.SkipButton.Text = "Random Comic";
            this.SkipButton.UseVisualStyleBackColor = false;
            this.SkipButton.Click += new System.EventHandler(this.SkipButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchButton.BackColor = System.Drawing.SystemColors.Control;
            this.SearchButton.Location = new System.Drawing.Point(23, 279);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(151, 46);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "View Saved Comics";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ComicBox
            // 
            this.ComicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComicBox.Location = new System.Drawing.Point(223, 51);
            this.ComicBox.Name = "ComicBox";
            this.ComicBox.Size = new System.Drawing.Size(449, 298);
            this.ComicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ComicBox.TabIndex = 7;
            this.ComicBox.TabStop = false;
            this.ComicBox.MouseHover += new System.EventHandler(this.ComicBox_MouseHover);
            // 
            // ComicTitle
            // 
            this.ComicTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComicTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ComicTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.ComicTitle.Location = new System.Drawing.Point(0, 4);
            this.ComicTitle.Name = "ComicTitle";
            this.ComicTitle.Size = new System.Drawing.Size(448, 25);
            this.ComicTitle.TabIndex = 10;
            this.ComicTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelPanel
            // 
            this.LabelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPanel.Controls.Add(this.ComicTitle);
            this.LabelPanel.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelPanel.Location = new System.Drawing.Point(223, 10);
            this.LabelPanel.Name = "LabelPanel";
            this.LabelPanel.Size = new System.Drawing.Size(448, 35);
            this.LabelPanel.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.LabelPanel);
            this.Controls.Add(this.ComicBox);
            this.Controls.Add(this.ButtonPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "XKCD Tool";
            this.ButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ComicBox)).EndInit();
            this.LabelPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel ButtonPanel;
        private System.Windows.Forms.Button GetButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button SkipButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.PictureBox ComicBox;
        private System.Windows.Forms.Label ComicTitle;
        private System.Windows.Forms.Panel LabelPanel;
    }
}

