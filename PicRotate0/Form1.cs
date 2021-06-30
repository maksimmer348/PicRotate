using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Resources.Extensions;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicRotate0
{
    public partial class Form1 : Form
    {
        //список из файлов 
        private string[] FileNames;

        //индекс выбраной картинки для лист вью
        private int SelectPic;

        //каринка с кторой ведется работа в питурбоксе
        private Bitmap Pic;

        //цвет ктором будет рисоватся выделелние
        private Pen pen;

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
        public Form1()
        {
            InitializeComponent();

            Preview.BorderStyle = BorderStyle.FixedSingle;

            Preview.Controls.Add(PicSelection);
            PicSelection.Location = new Point(0, 0);
            PicSelection.BackColor = Color.Transparent;//передний фон
            PicSelection.SizeMode = PictureBoxSizeMode.Zoom;
            g = PicSelection.CreateGraphics();
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

            //не используется

            #region добавить пустое изборажение

            //ImageList.Images.Add(new Bitmap(@"pic/photo.jpg"));


            //Bitmap emptyPIc = new Bitmap(60, 60);

            //using (Graphics gr = Graphics.FromImage(emptyPIc))//можно редактировать изобрадение
            //{
            //    gr.Clear(Color.AliceBlue);//заливаем былым чтобы небыло видно изображение на лист вюь
            //}
            //ImageList.Images.Add(emptyPIc);//добавить пустое изображение в список

            #endregion

        }

        private void AddPic_Click(object sender, EventArgs e)
        {
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
                    FileNames = openFileDialog.FileNames;
                    LoadData();
                }
            }
        }

        #endregion

        #region SelectPic


        void PictureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PictureList.FocusedItem == null) return;
            SelectPic = PictureList.FocusedItem.Index;
            Pic = new Bitmap(FileNames[SelectPic]);
            Preview.Image = Pic;
            Angle = 0;
        }

        #endregion

        #region RotateImage

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

        private float Angle;
        void AngleRotate_TextChanged(object sender, EventArgs e)
        {

            string input = AngleRotate.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                Preview.Image = RotateImage((Bitmap) Preview.Image, 0-Angle);
                Angle = 0;
            }

            if (!string.IsNullOrWhiteSpace(AngleRotate.Text) && Regex.IsMatch(input, @"^[0-9]+(\.[0-9]{1,3})?$"))
            {
                var img = RotateImage((Bitmap) Preview.Image, float.Parse(input) - Angle);
                Preview.Image = img;
                Angle = float.Parse(input);
            }

            
        }

        //public static Image RotateImage(Image img, float rotationAngle)
        //{
        //    if (img != null)
        //    {
        //        //создаем пустую юитмап картинку с размерам входной кратинки
        //        Bitmap bmp = new Bitmap(img.Width, img.Height);

        //        //превращаем Bitmap в объект Graphics
        //        Graphics gfx = Graphics.FromImage(bmp);

        //        //устанавливаем центр нашего обьекта графики
        //        gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

        //        //поворачиваем наш обьект графики
        //        gfx.RotateTransform(rotationAngle,MatrixOrder.Append);
        //        //возвращаем картинку обратно на центр после транфсормации
        //        gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

        //        //Задает высококачественную бикубическую интерполяцию. Выполняется предварительная
        //        //фильтрация, чтобы гарантировать высококачественное сжатие. Этот режим создает
        //        //преобразованные изображения самого высокого качества.
        //        gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

        //        //Рисует указанный объект Image в заданном месте, используя указанную форму и точку создания.
        //        gfx.DrawImage(img, new Point(0,  0));

        //        //Освобождает все ресурсы, используемые этим объектом графики
        //        gfx.Dispose();
        //        //return the image
        //        return bmp;
        //    }

        //    return img;
        //}

        #endregion

        private void Сrop_Click(object sender, EventArgs e)
        {
            Preview.Image = ImageUtils.CropImage(Preview, Rect);
            delPic = true;
            PicSelection.Invalidate();
        }

        private void DelPic_Click(object sender, EventArgs e)
        {
            delPic = true;
            PicSelection.Invalidate();

        }

        private void PicSelection_MouseUp(object sender, MouseEventArgs e)
        {

            xPos = e.X;
            yPos = e.Y;

            if (xPos > begin_x && yPos > begin_y)
            {

                tempX = xPos - begin_x;
                tempY = yPos - begin_y;
                Rect = new Rectangle(begin_x, begin_y, tempX, tempY);

                HeightSize.Text = Rect.Height.ToString();
                WidthSize.Text = Rect.Width.ToString();
            }
            else if (xPos < begin_x && yPos < begin_y)
            {
                tempX = begin_x - xPos;
                tempY = begin_y - yPos;
                Rect = new Rectangle(xPos, yPos, tempX, tempY);
             
                HeightSize.Text = Rect.Height.ToString();
                WidthSize.Text = Rect.Width.ToString();
            }

            else if (begin_x > xPos && yPos > begin_y)
            {
                tempX = begin_x - xPos;
                tempY = yPos - begin_y;
                Rect = new Rectangle(xPos, begin_y, tempX, tempY);
              
                HeightSize.Text = Rect.Height.ToString();
                WidthSize.Text = Rect.Width.ToString();
            }

            else if (xPos > begin_x && yPos < begin_y)
            {
                tempX = xPos - begin_x;
                tempY = begin_y - yPos;
                Rect = new Rectangle(begin_x, yPos, xPos - begin_x, begin_y - yPos);
               
                HeightSize.Text = Rect.Height.ToString();
                WidthSize.Text = Rect.Width.ToString();
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
        private void Preview_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Preview_MousDown(object sender, MouseEventArgs e)
        {

        }

        private void PicSelection_Paint(object sender, PaintEventArgs e)
        {
            if(delPic) return;
            using (Pen pen = new Pen(Color.Red, 2))
            {

                g = e.Graphics;
                g.DrawRectangle(pen, Rect);
                   
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
