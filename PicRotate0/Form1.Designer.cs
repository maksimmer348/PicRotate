
namespace PicRotate0
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.AddPic = new System.Windows.Forms.Button();
            this.DelPic = new System.Windows.Forms.Button();
            this.PictureList = new System.Windows.Forms.ListView();
            this.Picture = new System.Windows.Forms.ColumnHeader();
            this.PicName = new System.Windows.Forms.ColumnHeader();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.Rotate = new System.Windows.Forms.Button();
            this.AngleRotate = new System.Windows.Forms.TextBox();
            this.Preview = new System.Windows.Forms.PictureBox();
            this.Сrop = new System.Windows.Forms.Button();
            this.RotateAngleText = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.HeightSize = new System.Windows.Forms.TextBox();
            this.WidthSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PicSelection = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // AddPic
            // 
            this.AddPic.Location = new System.Drawing.Point(489, 413);
            this.AddPic.Name = "AddPic";
            this.AddPic.Size = new System.Drawing.Size(75, 23);
            this.AddPic.TabIndex = 0;
            this.AddPic.Text = "Add pic";
            this.AddPic.UseVisualStyleBackColor = true;
            this.AddPic.Click += new System.EventHandler(this.AddPic_Click);
            // 
            // DelPic
            // 
            this.DelPic.Location = new System.Drawing.Point(713, 414);
            this.DelPic.Name = "DelPic";
            this.DelPic.Size = new System.Drawing.Size(75, 23);
            this.DelPic.TabIndex = 2;
            this.DelPic.Text = "Del pic";
            this.DelPic.UseVisualStyleBackColor = true;
            this.DelPic.Click += new System.EventHandler(this.DelPic_Click);
            // 
            // PictureList
            // 
            this.PictureList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Picture,
            this.PicName});
            this.PictureList.HideSelection = false;
            this.PictureList.LargeImageList = this.ImageList;
            this.PictureList.Location = new System.Drawing.Point(489, 14);
            this.PictureList.Name = "PictureList";
            this.PictureList.Size = new System.Drawing.Size(299, 383);
            this.PictureList.SmallImageList = this.ImageList;
            this.PictureList.TabIndex = 3;
            this.PictureList.UseCompatibleStateImageBehavior = false;
            this.PictureList.View = System.Windows.Forms.View.Details;
            this.PictureList.SelectedIndexChanged += new System.EventHandler(this.PictureList_SelectedIndexChanged);
            // 
            // Picture
            // 
            this.Picture.Text = "Pic";
            this.Picture.Width = 120;
            // 
            // PicName
            // 
            this.PicName.Text = "Name";
            this.PicName.Width = 180;
            // 
            // ImageList
            // 
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImageList.ImageSize = new System.Drawing.Size(40, 40);
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Rotate
            // 
            this.Rotate.Location = new System.Drawing.Point(12, 415);
            this.Rotate.Name = "Rotate";
            this.Rotate.Size = new System.Drawing.Size(75, 23);
            this.Rotate.TabIndex = 4;
            this.Rotate.Text = "Rotate";
            this.Rotate.UseVisualStyleBackColor = true;
            // 
            // AngleRotate
            // 
            this.AngleRotate.Location = new System.Drawing.Point(93, 416);
            this.AngleRotate.Name = "AngleRotate";
            this.AngleRotate.Size = new System.Drawing.Size(54, 23);
            this.AngleRotate.TabIndex = 5;
            this.AngleRotate.TextChanged += new System.EventHandler(this.AngleRotate_TextChanged);
            // 
            // Preview
            // 
            this.Preview.Location = new System.Drawing.Point(13, 14);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(424, 383);
            this.Preview.TabIndex = 6;
            this.Preview.TabStop = false;
            this.Preview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Preview_MousDown);
            this.Preview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Preview_MouseUp);
            // 
            // Сrop
            // 
            this.Сrop.Location = new System.Drawing.Point(195, 415);
            this.Сrop.Name = "Сrop";
            this.Сrop.Size = new System.Drawing.Size(64, 23);
            this.Сrop.TabIndex = 7;
            this.Сrop.Text = "Сrop";
            this.Сrop.UseVisualStyleBackColor = true;
            this.Сrop.Click += new System.EventHandler(this.Сrop_Click);
            // 
            // RotateAngleText
            // 
            this.RotateAngleText.AutoSize = true;
            this.RotateAngleText.Location = new System.Drawing.Point(153, 419);
            this.RotateAngleText.Name = "RotateAngleText";
            this.RotateAngleText.Size = new System.Drawing.Size(20, 15);
            this.RotateAngleText.TabIndex = 8;
            this.RotateAngleText.Text = "∠°";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(593, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Add pic";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 11;
            // 
            // HeightSize
            // 
            this.HeightSize.Location = new System.Drawing.Point(293, 415);
            this.HeightSize.Name = "HeightSize";
            this.HeightSize.Size = new System.Drawing.Size(54, 23);
            this.HeightSize.TabIndex = 10;
            // 
            // WidthSize
            // 
            this.WidthSize.Location = new System.Drawing.Point(383, 415);
            this.WidthSize.Name = "WidthSize";
            this.WidthSize.Size = new System.Drawing.Size(54, 23);
            this.WidthSize.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(353, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "↕";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(443, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "⬌";
            // 
            // PicSelection
            // 
            this.PicSelection.Location = new System.Drawing.Point(12, 14);
            this.PicSelection.Name = "PicSelection";
            this.PicSelection.Size = new System.Drawing.Size(425, 383);
            this.PicSelection.TabIndex = 15;
            this.PicSelection.TabStop = false;
            this.PicSelection.Paint += new System.Windows.Forms.PaintEventHandler(this.PicSelection_Paint);
            this.PicSelection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicSelection_MouseDown);
            this.PicSelection.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicSelection_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PicSelection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WidthSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HeightSize);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RotateAngleText);
            this.Controls.Add(this.Сrop);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.AngleRotate);
            this.Controls.Add(this.Rotate);
            this.Controls.Add(this.PictureList);
            this.Controls.Add(this.DelPic);
            this.Controls.Add(this.AddPic);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSelection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddPic;
        private System.Windows.Forms.Button DelPic;
        private System.Windows.Forms.ListView PictureList;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.Button Rotate;
        private System.Windows.Forms.TextBox AngleRotate;
        private System.Windows.Forms.PictureBox Preview;
        private System.Windows.Forms.ColumnHeader Picture;
        private System.Windows.Forms.ColumnHeader PicName;
        private System.Windows.Forms.Button Сrop;
        private System.Windows.Forms.Label RotateAngleText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HeightSize;
        private System.Windows.Forms.TextBox WidthSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox PicSelection;
    }
}

