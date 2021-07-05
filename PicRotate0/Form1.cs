using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Resources.Extensions;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicRotate0
{
    public partial class Form1 : Form
    {
        //список из файлов 
        private List<string> FileNames;

        //индекс выбраной картинки для лист вью
        private int SelectPic;

        //каринка с кторой ведется работа в питурбоксе
        private Bitmap Pic;

        Bitmap img;
        private Queue<string> QueuePic;
        //Координаты картинки на исходном pictureBox.
        private int begin_x;
        private int begin_y;
        private int xPos;
        private int yPos;
        int tempX;
        int tempY;

        private bool delPic;
        //фигура выдлеления области обрезки
        private Rectangle Rect;

        private Graphics g;

        private bool itemRemove { get; set; }
        public Form1()
        {
            InitializeComponent();

            Preview.BorderStyle = BorderStyle.FixedSingle;

            Preview.Controls.Add(PicSelection);
            PicSelection.Location = new Point(0, 0);
            PicSelection.BackColor = Color.Transparent;//передний фон
            PicSelection.SizeMode = PictureBoxSizeMode.Zoom;
            delPic = true;
            PicSelection.Invalidate();
        }

        #region AddPic

        void LoadData()
        {
            PictureList.Items.Clear();
            PictureList.MultiSelect = false;
            List<string> picNames = new List<string>(); //для вывода имен картинок
            List<bool> selectPic = new List<bool>(); //длдя вывода комобоксов
            ImageList.ImageSize = new Size(120, 60); //размер картинки
            foreach (var file in FileNames)
            {
                ImageList.Images.Add(new Bitmap(file)); // вывести изображения из списка после их добавления туда
                // добавляем в списко изображений путь к изображению
                picNames.Add(Path.GetFileNameWithoutExtension(file));
            }

            PictureList.SmallImageList =
                ImageList; //добавляем полчившийся списко картинок в режим пиктрлиста - маленькие картинки

            for (int i = 0; i < picNames.Count; i++)
            {
                ListViewItem
                    listViewItem =
                        new ListViewItem(new string[]
                        {
                            "", picNames[i]
                        }); //добавляем айтем в вьюьлист первй будет пустой строкой потому что у нас  
                listViewItem.ImageIndex = i; //номер изображения из спикска изображений кторый мы указалив имедждвью в
                //качесвте исходных изоборажений для показа

                PictureList.Items.Add(listViewItem);

            }

            Preview.SizeMode = PictureBoxSizeMode.Zoom; //ставим настройку пиктурбоксу автозум изображенеи подстаивается под
            Pic = new Bitmap(FileNames[0]); //него и не теряет форму
            Preview.Image = Pic; //после добавления картинок в список добавлляем первую из них в превьюшный пикутрбокс

        }

        private void AddPic_Click(object sender, EventArgs e)
        {
            if (FileNames != null)
            {
                itemRemove = true;
                FileNames.Clear();
                PictureList.Items.Clear();
                ImageList.Images.Clear();
            }
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) //создаем экз класса диаологового окна
            {
                openFileDialog.InitialDirectory = @"C:\Users\Maksimmer\Downloads"; //указываем путь по умолчанию
                openFileDialog.Filter =
                    "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*"; //указываем какие расщрения будут возможно выбрать 
                openFileDialog.FilterIndex = 1; //указываем индекс расшиерния корое будет выбрано при откртии окна,
                //отсчет от 1(jpg files (*.jpg)|*.jpg)
                openFileDialog.RestoreDirectory = true; //задает значение, указывающее, восстанавливает
                //ли диалоговое окно ранее выбранный каталог в качестве текущего
                //каталога перед закрытием.
                openFileDialog.Multiselect = true; //задаем возмондсоть полчения несолкьких файлов

                if (openFileDialog.ShowDialog() == DialogResult.OK) //если мы нажимаем окей в диалоге обзора
                {
                    FileNames = new List<string>(openFileDialog.FileNames);
                    LoadData();
                }
            }

           
        }

        #endregion

        #region SelectPic
        bool SelectChange;
        void PictureList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (SelectChange)
            {
                if (PictureList.FocusedItem == null) return;
                SelectPic = PictureList.FocusedItem.Index;

                if (itemRemove)
                {
                    Pic = new Bitmap(FileNames[0]);
                    itemRemove = true;
                }
                else if (!itemRemove)
                {
                    Pic = new Bitmap(FileNames[SelectPic]);
                }
                Preview.Image = Pic;
            }
        }

        private void DelPic_Click(object sender, EventArgs e)
        {

            if (FileNames == null || PictureList.Items.Count <= 0 || PictureList.FocusedItem == null)
            {
                return;
            }

            SelectPic = PictureList.FocusedItem.Index;
                itemRemove = true;
                SelectChange = false;
                //SelectPic = PictureList.FocusedItem.Index;
                FileNames.RemoveAt(SelectPic);
                PictureList.Items.RemoveAt(SelectPic);
                ImageList.Images.RemoveAt(SelectPic);
                Preview.Image = null;
                SelectChange = true;
            
          
        }

        #endregion

        #region RotateImage

        private string RotateAngle;
        void AngleRotate_TextChanged(object sender, EventArgs e)
        {
            RotatePict(Pic ,AngleRotate.Text);
            RotateAngle = AngleRotate.Text;
        }

        Bitmap RotatePict( Bitmap pic, string angle)//тип перменных должны соответстовать типам данных
        {
            // string input = AngleRotate.Text;
            if (string.IsNullOrWhiteSpace(angle))//все проверки не это перенсти или в отдельный мтеод или остаить в текбоксе
            //тк исспользуетя ОДИН РАЗ
            {
                img = RotateImage((Bitmap)pic, 0);
                Preview.Image = img;

            }

            if (!string.IsNullOrWhiteSpace(angle) && Regex.IsMatch(angle, @"^[0-9]+(\.[0-9]{1,3})?$"))
            {
                img = RotateImage(pic, float.Parse(angle));//все преобразования нужнг выносить за метод в
                                                           //отдельный метод тк исользуется ОДИН РАЗ
                Preview.Image = img;
            }
            return img;
        }

        public static Bitmap RotateImage(Bitmap bmpSrc, float theta)
        {
            Matrix mRotate = new Matrix();

            mRotate.Translate(bmpSrc.Width / -2, bmpSrc.Height / -2, MatrixOrder.Append);//матрица последоватлньый набор команд исользуем чтобы переместит картинику
            mRotate.RotateAt(theta, new Point(0, 0), MatrixOrder.Append);//после чего эа картинка поворачиваеися

            using (GraphicsPath gp = new GraphicsPath())
            {
                // transform image points by rotation matrix
                gp.AddPolygon(new System.Drawing.Point[]
                {
                    new Point(0, 0),
                    new Point(bmpSrc.Width, 0),
                    new Point(0, bmpSrc.Height)
                });
                gp.Transform(mRotate);//к пути применяеся набор команд - те матрица
                PointF[] pts = gp.PathPoints;

                // create destination bitmap sized to contain rotated source image
                Rectangle bbox = boundingBox(bmpSrc, mRotate);
                Bitmap bmpDest = new Bitmap(bbox.Width, bbox.Height);

                using (Graphics gDest = Graphics.FromImage(bmpDest))
                {
                    // draw source into dest
                    Matrix mDest = new Matrix();
                    mDest.Translate(bmpDest.Width / 2, bmpDest.Height / 2);
                    gDest.Transform = mDest;
                    gDest.DrawImage(bmpSrc, pts);
                    return bmpDest;
                }
            }
        }

        private static Rectangle boundingBox(Image img, Matrix matrix)
        {
            GraphicsUnit gu = new GraphicsUnit();
            Rectangle rImg = Rectangle.Round(img.GetBounds(ref gu));//rectangleF можно округлять вот так

            // Transform the four points of the image, to get the resized bounding box.
            Point topLeft = new Point(rImg.Left, rImg.Top);
            Point topRight = new Point(rImg.Right, rImg.Top);
            Point bottomRight = new Point(rImg.Right, rImg.Bottom);
            Point bottomLeft = new Point(rImg.Left, rImg.Bottom);
            Point[] points = new Point[]
            {
                topLeft, topRight, bottomRight, bottomLeft
            };

            GraphicsPath gp = new GraphicsPath(points, new byte[]
            {
                (byte) PathPointType.Start,
                (byte) PathPointType.Line, (byte) PathPointType.Line, (byte) PathPointType.Line
            });

            gp.Transform(matrix);

            return Rectangle.Round(gp.GetBounds());
        }

        #endregion

        private void Сrop_Click(object sender, EventArgs e)
        {
            crepEnbl = false;
            CropPict(Pic, Rect);
        }

        Bitmap CropPict(Bitmap pic, Rectangle rect)
        {
            Pic = ImageUtils.CropImage(Preview, rect);
            Preview.Image = Pic;
            delPic = true;
            PicSelection.Invalidate();
            img = Pic;
            crepEnbl = true;
            return img;
        }

        private bool crepEnbl;
        private void PicSelection_MouseUp(object sender, MouseEventArgs e)
        {

            xPos = e.X;
            yPos = e.Y;

            if (xPos > begin_x && yPos > begin_y)
            {

                tempX = xPos - begin_x;
                tempY = yPos - begin_y;
                Rect = new Rectangle(begin_x, begin_y, tempX, tempY);

                //LeftSize.Text = (Rect.Width/ 2).ToString();
                //RightSize.Text = (Rect.Width).ToString();
            }
            else if (xPos < begin_x && yPos < begin_y)
            {
                tempX = begin_x - xPos;
                tempY = begin_y - yPos;
                Rect = new Rectangle(xPos, yPos, tempX, tempY);


            }

            else if (begin_x > xPos && yPos > begin_y)
            {
                tempX = begin_x - xPos;
                tempY = yPos - begin_y;
                Rect = new Rectangle(xPos, begin_y, tempX, tempY);


            }

            else if (xPos > begin_x && yPos < begin_y)
            {
                tempX = xPos - begin_x;
                tempY = begin_y - yPos;
                Rect = new Rectangle(begin_x, yPos, xPos - begin_x, begin_y - yPos);


            }
            if (Rect.Height > 0)
            {
                PicSelection.Image = null;
            }

        }
        private void PicSelection_MouseDown(object sender, MouseEventArgs e)
        {
            begin_x = e.X;
            begin_y = e.Y;
            delPic = false;
        }

        private void PicSelection_Paint(object sender, PaintEventArgs e)
        {
            if (delPic) return;
            using (Pen pen = new Pen(Color.Red, 2))
            {

                g = e.Graphics;
                g.DrawRectangle(pen, Rect);

            }
        }

        private void Preview_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Preview_MousDown(object sender, MouseEventArgs e)
        {

        }


        private void CropPixels_Enter(object sender, EventArgs e)
        {

        }

        private void LeftSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void TopSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void RightSize_TextChanged(object sender, EventArgs e)
        {



        }

        private void BottomSize_TextChanged(object sender, EventArgs e)
        {


        }

        private void PlusSize_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PointX.Text))
            {
                delPic = true;
                Rect.X += Convert.ToInt32(PointX.Text);
                delPic = false;

                PicSelection.Invalidate();
            }

            if (!string.IsNullOrEmpty(PointY.Text))
            {
                delPic = true;
                Rect.Y += Convert.ToInt32(PointY.Text);
                delPic = false;

                PicSelection.Invalidate();
            }

            if (!string.IsNullOrEmpty(LeftSize.Text))
            {
                delPic = true;
                Rect.X -= Convert.ToInt32(LeftSize.Text);

                Rect.Width += Convert.ToInt32(LeftSize.Text);

                delPic = false;

                PicSelection.Invalidate();

            }

            if (!string.IsNullOrEmpty(TopSize.Text))
            {
                delPic = true;
                Rect.Y -= Convert.ToInt32(TopSize.Text);

                Rect.Height += Convert.ToInt32(TopSize.Text);

                delPic = false;

                PicSelection.Invalidate();
            }

            if (!string.IsNullOrEmpty(RightSize.Text))
            {
                delPic = true;
                Rect.Width += Convert.ToInt32(RightSize.Text);

                delPic = false;

                PicSelection.Invalidate();
            }

            if (!string.IsNullOrEmpty(BottomSize.Text))
            {
            

                Rect.Height += Convert.ToInt32(BottomSize.Text);

                delPic = false;
                PicSelection.Invalidate();
            }
        }

        private void MinusSize_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PointX.Text))
            {
                delPic = true;
                Rect.X -= Convert.ToInt32(PointX.Text);
                delPic = false;

                PicSelection.Invalidate();
            }

            if (!string.IsNullOrEmpty(PointY.Text))
            {
                delPic = true;
                Rect.Y -= Convert.ToInt32(PointY.Text);
                delPic = false;

                PicSelection.Invalidate();
            }

            if (!string.IsNullOrEmpty(LeftSize.Text))
            {
                delPic = true;
                Rect.X += Convert.ToInt32(LeftSize.Text);

                Rect.Width -= Convert.ToInt32(LeftSize.Text);
                delPic = false;
                PicSelection.Invalidate();

            }

            if (!string.IsNullOrEmpty(TopSize.Text))
            {
                delPic = true;
                Rect.Y += Convert.ToInt32(TopSize.Text);

                Rect.Height -= Convert.ToInt32(TopSize.Text);
                delPic = false;
                PicSelection.Invalidate();
            }

            if (!string.IsNullOrEmpty(RightSize.Text))
            {
                delPic = true;
                Rect.Width -= Convert.ToInt32(RightSize.Text);


                delPic = false;
                PicSelection.Invalidate();
            }

            if (!string.IsNullOrEmpty(BottomSize.Text))
            {
                delPic = true;

                Rect.Height = Rect.Height - Convert.ToInt32(BottomSize.Text);


                delPic = false;
                PicSelection.Invalidate();
            }
        }


        private void BackbaseBtn_Click(object sender, EventArgs e)
        {

            RightSize.Text = String.Empty;
            LeftSize.Text = String.Empty;
            TopSize.Text = String.Empty;
            BottomSize.Text = String.Empty;

        }

        private void PicSelection_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DelChanges_Click(object sender, EventArgs e)
        {
            delPic = true;
            PicSelection.Invalidate();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            img.Save($"{FileNames[SelectPic]}(измененнная)" + ".jpg");
        }

        private void SaveAll_Click(object sender, EventArgs e)
        {
            QueuePic = new Queue<string>();
           
            foreach (var file in FileNames)
            {
                var pic = new Bitmap(file);
                if (!string.IsNullOrWhiteSpace(AngleRotate.Text) || AngleRotate.Text != "0")
                    pic = RotatePict(pic, AngleRotate.Text);
                if (crepEnbl)
                    pic = CropPict(pic, Rect);
                pic.Save($"{file} (измененнная)" + Path.GetExtension(file));//сохраняем файл в
                                                                            //с тем жеименем и добвавленым текстом, а так же с тем же разрешением
                                                                            //изучить класс Path(Combine Join) File Directory
            }
        }
        
}

    #region CropImage

    public static class ImageUtils
    {
        public static Bitmap CropImage(this PictureBox pb, Rectangle rect)
        {
            var imageRect = pb.GetImageRectangle();
            var image = pb.Image;
            float scaleX = (float)image.Width / imageRect.Width;
            float scaleY = (float)image.Height / imageRect.Height;
            var cropRect = new RectangleF();
            cropRect.X = Scale(rect.X - imageRect.X, scaleX, image.Width);
            cropRect.Y = Scale(rect.Y - imageRect.Y, scaleY, image.Height);
            cropRect.Width = Scale(rect.Width, scaleX, image.Width - cropRect.X);
            cropRect.Height = Scale(rect.Height, scaleY, image.Height - cropRect.Y);
            var result = new Bitmap((int)cropRect.Width, (int)cropRect.Height, image.PixelFormat);
            using (var g = Graphics.FromImage(result))
                g.DrawImage(image, new RectangleF(new Point(0, 0), cropRect.Size), cropRect, GraphicsUnit.Pixel);
            return result;
        }

        static float Scale(float value, float scale, float maxValue)
        {
            float result = (value * scale);
            return result < 0 ? 0 : result > maxValue ? maxValue : result;
        }

        public static Rectangle GetImageRectangle(this PictureBox pb)
        {
            var rect = pb.ClientRectangle;
            var padding = pb.Padding;
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            var image = pb.Image;
            var sizeMode = pb.SizeMode;
            if (sizeMode == PictureBoxSizeMode.Normal || sizeMode == PictureBoxSizeMode.AutoSize)
                rect.Size = image.Size;
            else if (sizeMode == PictureBoxSizeMode.CenterImage)
            {
                rect.X += (rect.Width - image.Width) / 2;
                rect.Y += (rect.Height - image.Height) / 2;
                rect.Size = image.Size;
            }
            else if (sizeMode == PictureBoxSizeMode.Zoom)
            {
                var imageSize = image.Size;
                var zoomSize = pb.ClientSize;
                float ratio = Math.Min((float)zoomSize.Width / imageSize.Width, (float)zoomSize.Height / imageSize.Height);
                rect.Width = (int)(imageSize.Width * ratio);
                rect.Height = (int)(imageSize.Height * ratio);
                rect.X = (pb.ClientRectangle.Width - rect.Width) / 2;
                rect.Y = (pb.ClientRectangle.Height - rect.Height) / 2;
            }
            return rect;
        }
    }
    #endregion

}
