using System;using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternRecognition
{
    public partial class Form1 : Form
    {
        private Point _mousePoint;
        private bool isMouseDown = false;
        private string imageName = "";
        public Form1()
        {
            InitializeComponent();
            ClearPictureBox();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            _mousePoint = e.Location;

            if (isMouseDown)
            {
                DrawPoint(_mousePoint.X, _mousePoint.Y, Color.Black);
            }
        }

        public void DrawPoint(int x, int y, Color color)
        {
            var bitmap = new Bitmap(pictureBox1.Image);
            using (var g = Graphics.FromImage(bitmap))
            {
                var pen = new Pen(color);
                var rect = new Rectangle(x, y, 5, 5);
                g.FillRectangle(Brushes.Black, rect);
                g.DrawRectangle(pen, rect);
            }
            pictureBox1.Image = bitmap;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxImageName.Text))
            {
                MessageBox.Show("Set picture name!");
                return;
            }
            imageName = textBoxImageName.Text;
            var str = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
            str[str.Length - 2] = "";
            str[str.Length - 3] = "";
            var path = string.Join("\\", str.TakeWhile(s => !string.IsNullOrEmpty(s))) + "\\Images\\";
            var nextIndex = GetNextIndex(path) + 1;
            path = path + imageName + "_" + nextIndex + ".bmp";
            try
            {
                pictureBox1.Image.Save(path, ImageFormat.Bmp);
            }
            finally
            {
                imageName = "";
                textBoxImageName.Text = "";
                ClearPictureBox();
                pictureBox1.Invalidate();
            }
        }

        private void ClearPictureBox()
        {
            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var gr = Graphics.FromImage(bitmap))
            {
                gr.FillRectangle(Brushes.White, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
            pictureBox1.Image = bitmap;
        }

        private int GetNextIndex(string path)
        {
            var indexes = Directory
                .EnumerateFiles(path)
                .Select(s => s.Split('\\').Last())
                .Select(s => new Regex(imageName + "_(?<index>\\d+).+").Match(s).Groups["index"]?.ToString())
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(int.Parse);

            var enumerable = indexes as int[] ?? indexes.ToArray();
            return !enumerable.Any() ? -1 : enumerable.Max();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearPictureBox();
        }
    }
}
