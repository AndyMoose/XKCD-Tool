
namespace XKCDUI
{
    partial class SavedComicsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavedComicsForm));
            this.ComicList = new System.Windows.Forms.ListBox();
            this.SavedComicBox = new System.Windows.Forms.PictureBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SavedComicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ComicList
            // 
            this.ComicList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ComicList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ComicList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComicList.ForeColor = System.Drawing.Color.White;
            this.ComicList.FormattingEnabled = true;
            this.ComicList.HorizontalScrollbar = true;
            this.ComicList.ItemHeight = 15;
            this.ComicList.Location = new System.Drawing.Point(12, 15);
            this.ComicList.Name = "ComicList";
            this.ComicList.Size = new System.Drawing.Size(158, 392);
            this.ComicList.TabIndex = 1;
            this.ComicList.SelectedIndexChanged += new System.EventHandler(this.ComicList_SelectedIndexChanged);
            // 
            // SavedComicBox
            // 
            this.SavedComicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SavedComicBox.Location = new System.Drawing.Point(176, 15);
            this.SavedComicBox.Name = "SavedComicBox";
            this.SavedComicBox.Size = new System.Drawing.Size(596, 434);
            this.SavedComicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SavedComicBox.TabIndex = 2;
            this.SavedComicBox.TabStop = false;
            this.SavedComicBox.MouseHover += new System.EventHandler(this.SavedComicBox_MouseHover);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.Location = new System.Drawing.Point(12, 413);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(158, 36);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete Selected XKCD";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SavedComicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SavedComicBox);
            this.Controls.Add(this.ComicList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "SavedComicsForm";
            this.Text = "Saved Comics";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SavedComicsForm_FormClosed);
            this.Load += new System.EventHandler(this.SavedComicsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SavedComicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ComicList;
        private System.Windows.Forms.PictureBox SavedComicBox;
        private System.Windows.Forms.Button DeleteButton;
    }
}