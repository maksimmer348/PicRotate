
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
            this.AngleRotate = new System.Windows.Forms.TextBox();
            this.Preview = new System.Windows.Forms.PictureBox();
            this.Сrop = new System.Windows.Forms.Button();
            this.RotateAngleText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LeftSize = new System.Windows.Forms.TextBox();
            this.PicSelection = new System.Windows.Forms.PictureBox();
            this.CropPixels = new System.Windows.Forms.GroupBox();
            this.DelChanges = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PointY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PointX = new System.Windows.Forms.TextBox();
            this.BackbaseBtn = new System.Windows.Forms.Button();
            this.PlusSize = new System.Windows.Forms.Button();
            this.MinusSize = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BottomSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TopSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RightSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SaveAll = new System.Windows.Forms.Button();
            this.RotateGroup = new System.Windows.Forms.GroupBox();
            this.Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSelection)).BeginInit();
            this.CropPixels.SuspendLayout();
            this.RotateGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddPic
            // 
            this.AddPic.Location = new System.Drawing.Point(512, 413);
            this.AddPic.Name = "AddPic";
            this.AddPic.Size = new System.Drawing.Size(66, 25);
            this.AddPic.TabIndex = 0;
            this.AddPic.Text = "Add pic";
            this.AddPic.UseVisualStyleBackColor = true;
            this.AddPic.Click += new System.EventHandler(this.AddPic_Click);
            // 
            // DelPic
            // 
            this.DelPic.Location = new System.Drawing.Point(584, 413);
            this.DelPic.Name = "DelPic";
            this.DelPic.Size = new System.Drawing.Size(55, 25);
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
            // AngleRotate
            // 
            this.AngleRotate.Location = new System.Drawing.Point(6, 17);
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
            this.Сrop.Location = new System.Drawing.Point(6, 16);
            this.Сrop.Name = "Сrop";
            this.Сrop.Size = new System.Drawing.Size(42, 23);
            this.Сrop.TabIndex = 7;
            this.Сrop.Text = "Сrop";
            this.Сrop.UseVisualStyleBackColor = true;
            this.Сrop.Click += new System.EventHandler(this.Сrop_Click);
            // 
            // RotateAngleText
            // 
            this.RotateAngleText.AutoSize = true;
            this.RotateAngleText.Location = new System.Drawing.Point(62, 21);
            this.RotateAngleText.Name = "RotateAngleText";
            this.RotateAngleText.Size = new System.Drawing.Size(20, 15);
            this.RotateAngleText.TabIndex = 8;
            this.RotateAngleText.Text = "∠°";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(469, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 11;
            // 
            // LeftSize
            // 
            this.LeftSize.Location = new System.Drawing.Point(72, 16);
            this.LeftSize.Name = "LeftSize";
            this.LeftSize.Size = new System.Drawing.Size(35, 23);
            this.LeftSize.TabIndex = 10;
            this.LeftSize.TextChanged += new System.EventHandler(this.LeftSize_TextChanged);
            // 
            // PicSelection
            // 
            this.PicSelection.Location = new System.Drawing.Point(12, 14);
            this.PicSelection.Name = "PicSelection";
            this.PicSelection.Size = new System.Drawing.Size(425, 383);
            this.PicSelection.TabIndex = 15;
            this.PicSelection.TabStop = false;
            this.PicSelection.Click += new System.EventHandler(this.PicSelection_Click);
            this.PicSelection.Paint += new System.Windows.Forms.PaintEventHandler(this.PicSelection_Paint);
            this.PicSelection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicSelection_MouseDown);
            this.PicSelection.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicSelection_MouseUp);
            // 
            // CropPixels
            // 
            this.CropPixels.Controls.Add(this.DelChanges);
            this.CropPixels.Controls.Add(this.label3);
            this.CropPixels.Controls.Add(this.PointY);
            this.CropPixels.Controls.Add(this.label2);
            this.CropPixels.Controls.Add(this.PointX);
            this.CropPixels.Controls.Add(this.BackbaseBtn);
            this.CropPixels.Controls.Add(this.PlusSize);
            this.CropPixels.Controls.Add(this.MinusSize);
            this.CropPixels.Controls.Add(this.label5);
            this.CropPixels.Controls.Add(this.BottomSize);
            this.CropPixels.Controls.Add(this.label6);
            this.CropPixels.Controls.Add(this.TopSize);
            this.CropPixels.Controls.Add(this.label7);
            this.CropPixels.Controls.Add(this.RightSize);
            this.CropPixels.Controls.Add(this.label4);
            this.CropPixels.Controls.Add(this.LeftSize);
            this.CropPixels.Controls.Add(this.Сrop);
            this.CropPixels.Location = new System.Drawing.Point(161, 404);
            this.CropPixels.Name = "CropPixels";
            this.CropPixels.Size = new System.Drawing.Size(345, 74);
            this.CropPixels.TabIndex = 17;
            this.CropPixels.TabStop = false;
            this.CropPixels.Text = "Crop pixels";
            this.CropPixels.Enter += new System.EventHandler(this.CropPixels_Enter);
            // 
            // DelChanges
            // 
            this.DelChanges.Location = new System.Drawing.Point(312, 41);
            this.DelChanges.Name = "DelChanges";
            this.DelChanges.Size = new System.Drawing.Size(20, 20);
            this.DelChanges.TabIndex = 26;
            this.DelChanges.Text = "⊠";
            this.DelChanges.UseVisualStyleBackColor = true;
            this.DelChanges.Click += new System.EventHandler(this.DelChanges_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Y Pos";
            // 
            // PointY
            // 
            this.PointY.Location = new System.Drawing.Point(245, 45);
            this.PointY.Name = "PointY";
            this.PointY.Size = new System.Drawing.Size(35, 23);
            this.PointY.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "X Pos";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // PointX
            // 
            this.PointX.Location = new System.Drawing.Point(131, 45);
            this.PointX.Name = "PointX";
            this.PointX.Size = new System.Drawing.Size(35, 23);
            this.PointX.TabIndex = 22;
            // 
            // BackbaseBtn
            // 
            this.BackbaseBtn.Location = new System.Drawing.Point(312, 16);
            this.BackbaseBtn.Name = "BackbaseBtn";
            this.BackbaseBtn.Size = new System.Drawing.Size(20, 20);
            this.BackbaseBtn.TabIndex = 20;
            this.BackbaseBtn.Text = "←";
            this.BackbaseBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BackbaseBtn.UseVisualStyleBackColor = true;
            this.BackbaseBtn.Click += new System.EventHandler(this.BackbaseBtn_Click);
            // 
            // PlusSize
            // 
            this.PlusSize.Location = new System.Drawing.Point(286, 15);
            this.PlusSize.Name = "PlusSize";
            this.PlusSize.Size = new System.Drawing.Size(20, 20);
            this.PlusSize.TabIndex = 18;
            this.PlusSize.Text = "+";
            this.PlusSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PlusSize.UseVisualStyleBackColor = true;
            this.PlusSize.Click += new System.EventHandler(this.PlusSize_Click);
            // 
            // MinusSize
            // 
            this.MinusSize.Location = new System.Drawing.Point(286, 41);
            this.MinusSize.Name = "MinusSize";
            this.MinusSize.Size = new System.Drawing.Size(20, 20);
            this.MinusSize.TabIndex = 19;
            this.MinusSize.Text = "-";
            this.MinusSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MinusSize.UseVisualStyleBackColor = true;
            this.MinusSize.Click += new System.EventHandler(this.MinusSize_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(231, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "B";
            // 
            // BottomSize
            // 
            this.BottomSize.Location = new System.Drawing.Point(245, 16);
            this.BottomSize.Name = "BottomSize";
            this.BottomSize.Size = new System.Drawing.Size(35, 23);
            this.BottomSize.TabIndex = 18;
            this.BottomSize.TextChanged += new System.EventHandler(this.BottomSize_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "T";
            // 
            // TopSize
            // 
            this.TopSize.Location = new System.Drawing.Point(189, 16);
            this.TopSize.Name = "TopSize";
            this.TopSize.Size = new System.Drawing.Size(35, 23);
            this.TopSize.TabIndex = 16;
            this.TopSize.TextChanged += new System.EventHandler(this.TopSize_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "R";
            // 
            // RightSize
            // 
            this.RightSize.Location = new System.Drawing.Point(131, 16);
            this.RightSize.Name = "RightSize";
            this.RightSize.Size = new System.Drawing.Size(35, 23);
            this.RightSize.TabIndex = 14;
            this.RightSize.TextChanged += new System.EventHandler(this.RightSize_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "L";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 23);
            this.textBox1.TabIndex = 14;
            // 
            // SaveAll
            // 
            this.SaveAll.Location = new System.Drawing.Point(13, 436);
            this.SaveAll.Name = "SaveAll";
            this.SaveAll.Size = new System.Drawing.Size(41, 40);
            this.SaveAll.TabIndex = 18;
            this.SaveAll.Text = "Save All";
            this.SaveAll.UseVisualStyleBackColor = true;
            this.SaveAll.Click += new System.EventHandler(this.SaveAll_Click);
            // 
            // RotateGroup
            // 
            this.RotateGroup.Controls.Add(this.AngleRotate);
            this.RotateGroup.Controls.Add(this.RotateAngleText);
            this.RotateGroup.Location = new System.Drawing.Point(69, 404);
            this.RotateGroup.Name = "RotateGroup";
            this.RotateGroup.Size = new System.Drawing.Size(86, 47);
            this.RotateGroup.TabIndex = 19;
            this.RotateGroup.TabStop = false;
            this.RotateGroup.Text = "Rotate";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(13, 408);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(41, 26);
            this.Save.TabIndex = 20;
            this.Save.Text = "Save ";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 482);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.RotateGroup);
            this.Controls.Add(this.SaveAll);
            this.Controls.Add(this.CropPixels);
            this.Controls.Add(this.PicSelection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.PictureList);
            this.Controls.Add(this.DelPic);
            this.Controls.Add(this.AddPic);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSelection)).EndInit();
            this.CropPixels.ResumeLayout(false);
            this.CropPixels.PerformLayout();
            this.RotateGroup.ResumeLayout(false);
            this.RotateGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddPic;
        private System.Windows.Forms.Button DelPic;
        private System.Windows.Forms.ListView PictureList;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.TextBox AngleRotate;
        private System.Windows.Forms.PictureBox Preview;
        private System.Windows.Forms.ColumnHeader Picture;
        private System.Windows.Forms.ColumnHeader PicName;
        private System.Windows.Forms.Button Сrop;
        private System.Windows.Forms.Label RotateAngleText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LeftSize;
        private System.Windows.Forms.PictureBox PicSelection;
        private System.Windows.Forms.GroupBox CropPixels;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox BottomSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TopSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox RightSize;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button PlusSize;
        private System.Windows.Forms.Button MinusSize;
        private System.Windows.Forms.Button BackbaseBtn;
        private System.Windows.Forms.Button SaveAll;
        private System.Windows.Forms.TextBox PointX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PointY;
        private System.Windows.Forms.Button DelChanges;
        private System.Windows.Forms.GroupBox RotateGroup;
        private System.Windows.Forms.Button Save;
    }
}

