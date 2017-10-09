using System;using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternRecognition
{
    public partial class Form1 : Form
    {
        private Point _mousePoint;
        private bool isMouseDown = false;
        private string imageName = "";
        private Thread thread;
        private AbortState Abort = new AbortState();
        private double[] _weights;
        private bool isSetted = false;

        private string iterNew = "";
        private string dqNew = "";
        private string vectDelta = "";

        private double[][] _samples;
        private double[] _answers;
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

        private void ButtonLearn_Click(object sender, EventArgs e)
        {
            Abort.Abort = false;
            if (_samples == null)
            {
                var dict = GetLearningSamples();
                _samples = dict.Keys.ToArray();
                foreach (var input in _samples)
                {
                    for (var i = 0; i < input.Length; i++)
                    {
                        input[i] = input[i] > 0 ? 1 : 0;
                    }
                }
                _answers = dict.Values.ToArray();
            }

            var eta = double.Parse(etaTextBox.Text, CultureInfo.InvariantCulture);
            var stab = double.Parse(stabilityTextBox.Text, CultureInfo.InvariantCulture);
            var wstab = double.Parse(wstabTextBox.Text, CultureInfo.InvariantCulture);

            _weights = new double[_samples[0].Length];
            thread = new Thread(() =>
            {
                var SG = new StochasticGradient { Abort = Abort};
                SG.IterationChange += (o, args) => iterNew = SG.Iterations.ToString();
                SG.DQChanged += (o, args) => dqNew = SG.D_Q.ToString("e2");
                SG.VectorChanged += (o, args) => vectDelta = SG.VectDelta.ToString("e2");

                _weights = SG.SG(_samples, _answers, eta, 1.0 / _samples.Length, stab, wstab);
                if (!SG.Abort.Abort)
                    isSetted = true;
            })
            { IsBackground = true, Priority = ThreadPriority.Highest };
            thread.Start();
        }

        private Dictionary<double[], double> GetLearningSamples()
        {
            var str = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
            str[str.Length - 2] = "";
            str[str.Length - 3] = "";
            var path = string.Join("\\", str.TakeWhile(s => !string.IsNullOrEmpty(s))) + "\\Images\\";
            var dict = new Dictionary<double[], double>();
            var filesPath = Directory
                .EnumerateFiles(path);
            foreach (var filePath in filesPath)
            {
                var bitmap = new Bitmap(filePath);
                var value = double.Parse(filePath.Split('\\').Last()[0].ToString(), CultureInfo.InvariantCulture);
                var array = FromImageToArray(bitmap);

                dict.Add(array.ToArray(), value);
            }

            var samples = dict.ToList();
            samples.MakeMixList();
            dict = samples.ToDictionary(el => el.Key, el => el.Value);

            return dict;
        }

        private double[] FromImageToArray(Bitmap bitmap)
        {
            var array = new List<double>();
            for (var i = 0; i < bitmap.Width; i++)
            {
                for (var j = 0; j < bitmap.Height; j++)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    if (pixel.R == 0 && pixel.G == 0 && pixel.B == 0)
                        array.Add(1);
                    else
                        array.Add(0);
                }
            }
            return array.ToArray();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_weights != null && isSetted)
            {
                var str = AppDomain.CurrentDomain.BaseDirectory.Split('\\');
                str[str.Length - 2] = "";
                str[str.Length - 3] = "";
                var path = string.Join("\\", str.TakeWhile(s => !string.IsNullOrEmpty(s)))+ "\\Res.txt";
                
                //foreach (var w in _weights)
                //{
                //   File.WriteAllText(path, w.ToString(CultureInfo.InvariantCulture) +"\n");
                //}

                ButtonRecognize.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null && thread.ThreadState == ThreadState.Running)
                thread.Abort(); 
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            iterCountLabel.Text = iterNew;
            dQLabel.Text = dqNew;
            weightsDeltaLabel.Text = vectDelta;
        }

        private void AbortButt_Click(object sender, EventArgs e)
        {
            Abort.Abort = true;
            thread.Join();
            thread?.Abort();
        }

        private void ButtonRecognize_Click(object sender, EventArgs e)
        {
            var bitmap = (Bitmap) pictureBox1.Image;

            var array = FromImageToArray(bitmap);

            var result = new StochasticGradient().NeuronFunc(array, _weights);

            MessageBox.Show(result.ToString());
        }
    }

    public class AbortState
    {
        public bool Abort;
    }
}
