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
        private string[] FileNames;
        private Queue<string> PicturesQueue;
        private Bitmap Pic;
        private PictureBox PicBox;
        private int SelectPic;
        private Rectangle CropArea;
        private Point LocationXY;
        private Point LocationX1Y1;
        private bool MouseDown;

        public Form1()
        {
            InitializeComponent();
            Preview.BorderStyle = BorderStyle.FixedSingle;
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

            Preview.SizeMode =
                PictureBoxSizeMode.Zoom; //ставим настройку пиктурбоксу автозум изображенеи подстаивается под
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
                    PicturesQueue = new Queue<string>();
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

        }

        #endregion

        #region RotateImage

        public static Bitmap RotateImage(Bitmap bmpSrc, float theta)
        {
            Matrix mRotate = new Matrix();

            mRotate.Translate(bmpSrc.Width / -2, bmpSrc.Height / -2, MatrixOrder.Append);
            mRotate.RotateAt(theta, new Point(0, 0), MatrixOrder.Append);

            using (GraphicsPath gp = new GraphicsPath())
            {
                // transform image points by rotation matrix
                gp.AddPolygon(new System.Drawing.Point[]
                {
                    new Point(0, 0),
                    new Point(bmpSrc.Width, 0),
                    new Point(0, bmpSrc.Height)
                });
                gp.Transform(mRotate);
                PointF[] pts = gp.PathPoints;

                // create destination bitmap sized to contain rotated source image
                Rectangle bbox = boundingBox(bmpSrc, mRotate);
                Bitmap bmpDest = new Bitmap(bbox.Width, bbox.Height);

                using (Graphics gDest = Graphics.FromImage(bmpDest))
                {
                    // draw source into dest
                    Matrix mDest = new Matrix();
                    mDest.Translate(bmpDest.Width / 2, bmpDest.Height / 2, MatrixOrder.Append);
                    gDest.Transform = mDest;
                    gDest.DrawImage(bmpSrc, pts);
                    return bmpDest;
                }
            }
        }

        private static Rectangle boundingBox(Image img, Matrix matrix)
        {
            GraphicsUnit gu = new GraphicsUnit();
            Rectangle rImg = Rectangle.Round(img.GetBounds(ref gu));

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

        void AngleRotate_TextChanged(object sender, EventArgs e)
        {

            string input = AngleRotate.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                Preview.Image = RotateImage(Pic, 0);
            }

            if (!string.IsNullOrWhiteSpace(AngleRotate.Text) && Regex.IsMatch(input, @"^[0-9]+(\.[0-9]{1,3})?$"))
            {
                var img = RotateImage(Pic, float.Parse(input));
                Preview.Image = img;
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

        public static Image Crop(Image image, RectangleF selection)
        {
            Bitmap bmp = image as Bitmap;

            // Check if it is a bitmap:
            if (bmp == null)
                throw new ArgumentException("No valid bitmap");

            // Crop the image:
            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);

            // Release the resources:
            image.Dispose();

            return cropBmp;
        }

        private void DelPic_Click(object sender, EventArgs e)
        {
            // Preview.Image = Crop(Preview.Image, CropArea);
            Preview.Image = null;
        }

        private void RotateBtn_Click(object sender, EventArgs e)
        {

        }

        void label1_Click(object sender, EventArgs e)
        {

        }
        private void Preview_Click(object sender, EventArgs e)
        {

        }
        private Timer MyTimer = new Timer();

        private void Preview_MousDown(object sender, MouseEventArgs e)
        {
            begin_x = e.X;
            begin_y = e.Y;
            //begin_x = e.X;
            //begin_y = e.Y;
            //SetTimer();
            //PictureBox pb = new PictureBox();
            //pb.Image = new Bitmap(Preview.Height, Preview.Width);
            //Pen p = new Pen(Color.Red);
            //Graphics g = Graphics.FromImage(pb.Image);
            //g.DrawRectangle(p,10,10,100,100);
        }





        void SetTimer()
        {
            MyTimer.Interval = 10;
            MyTimer.Tick += new EventHandler(MousePos);
            MyTimer.Enabled = true;

        }

        private void MousePos(object? sender, EventArgs e)
        {

        }

        private Pen pen;
        private Graphics g;

        private float begin_x;
        private float begin_y; //Координаты картинки на исходном pictureBox.
        private float xPos;
        private float yPos;

        float tempX;
        float tempY;

        private RectangleF Rect;
        private void Preview_MouseUp(object sender, MouseEventArgs e)
        {
            g = Preview.CreateGraphics();
            //g.RotateTransform(90);
            // g.Clear(Color.Transparent);//очисить, перерисовать картинку 
            pen = new Pen(Color.Red);
            //g.DrawImPic,0,0);
            xPos = e.X;
            yPos = e.Y;
            tempX = 0;
            tempY = 0;
            if (xPos > begin_x && yPos > begin_y)
            {
                tempX = xPos - begin_x;
                tempY = yPos - begin_y;
                g.DrawRectangle(pen, begin_x, begin_y, tempX, tempY);
                Rect = new RectangleF(begin_x, begin_y, tempX, tempY);
            }
            if (xPos < begin_x && yPos < begin_y)
            {

                tempX = begin_x - xPos;
                tempY = begin_y - yPos;
                g.DrawRectangle(pen, xPos, yPos, tempX, tempY);
                Rect = new RectangleF(xPos, yPos, tempX, tempY);
            }

            if (xPos > begin_x && yPos > begin_y)
            {
                tempX = xPos - begin_x;
                tempY = yPos - begin_y;
                g.DrawRectangle(pen, begin_x, begin_y, tempX,tempY);
                Rect = new RectangleF(begin_x, begin_y, tempX, tempY);
            }
            if (begin_x > xPos && yPos > begin_y)
            {
                g.DrawRectangle(pen, xPos, begin_y, begin_x - xPos, yPos - begin_y);
                Rect = new RectangleF(xPos, begin_y, begin_x - xPos, yPos - begin_y);
            }

            if (xPos > begin_x && yPos < begin_y)
            {
                g.DrawRectangle(pen, begin_x, yPos, xPos - begin_x, begin_y - yPos);
                Rect = new RectangleF(begin_x, yPos, xPos - begin_x, begin_y - yPos);
            }


        }

        private void Preview_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Preview_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Сrop_Click(object sender, EventArgs e)
        {
            g = Preview.CreateGraphics();
            g.DrawRectangle(new Pen(Color.Green), begin_x, begin_y, tempX, tempY);
        }
    }
}
