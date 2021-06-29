
namespace PicRotate0
{
    partial class ExistFile
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
            this.Change = new System.Windows.Forms.Button();
            this.Skip = new System.Windows.Forms.Button();
            this.CopyAndRename = new System.Windows.Forms.Button();
            this.FileNameText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(17, 62);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(90, 43);
            this.Change.TabIndex = 0;
            this.Change.Text = "Заменить";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // Skip
            // 
            this.Skip.Location = new System.Drawing.Point(148, 62);
            this.Skip.Name = "Skip";
            this.Skip.Size = new System.Drawing.Size(98, 43);
            this.Skip.TabIndex = 1;
            this.Skip.Text = "Пропустить";
            this.Skip.UseVisualStyleBackColor = true;
            this.Skip.Click += new System.EventHandler(this.Skip_Click);
            // 
            // CopyAndRename
            // 
            this.CopyAndRename.Location = new System.Drawing.Point(286, 62);
            this.CopyAndRename.Name = "CopyAndRename";
            this.CopyAndRename.Size = new System.Drawing.Size(175, 43);
            this.CopyAndRename.TabIndex = 2;
            this.CopyAndRename.Text = "Копироват с переимнованием";
            this.CopyAndRename.UseVisualStyleBackColor = true;
            this.CopyAndRename.Click += new System.EventHandler(this.CopyAndRename_Click);
            // 
            // FileNameText
            // 
            this.FileNameText.AutoSize = true;
            this.FileNameText.Location = new System.Drawing.Point(17, 21);
            this.FileNameText.Name = "FileNameText";
            this.FileNameText.Size = new System.Drawing.Size(163, 15);
            this.FileNameText.TabIndex = 3;
            this.FileNameText.Text = "Файл АОАО уже существует";
            // 
            // ExistFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 147);
            this.Controls.Add(this.FileNameText);
            this.Controls.Add(this.CopyAndRename);
            this.Controls.Add(this.Skip);
            this.Controls.Add(this.Change);
            this.Name = "ExistFile";
            this.Text = "ExistFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button Change;
        public System.Windows.Forms.Button Skip;
        public System.Windows.Forms.Button CopyAndRename;
        public System.Windows.Forms.Label FileNameText;
    }
}