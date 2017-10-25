using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Neuro;
using AForge.Neuro.Learning;

namespace BackPropNet
{
    public partial class Form1 : Form
    {
        private bool needToStop = false;
        private ActivationNetwork neuronNet;
        private Thread workThread;
        private BackPropagationLearning teacher;
        private SampleStorage sampleStorage;
        private string errorVal = "";
        public Form1()
        {
            InitializeComponent();

            sampleStorage = new SampleStorage();
            sampleStorage.ReadFromFile("dataSet.txt");

            //  Network Params

            var alpha = 2;

            neuronNet = new ActivationNetwork(new SigmoidFunction(alpha), 8, 8, 1);
            neuronNet.Randomize();
            teacher = new BackPropagationLearning(neuronNet) { LearningRate = 1, Momentum = 0.1 };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            needToStop = false;
            workThread = new Thread(() =>
            {
                // Learning
                while (!needToStop)
                {
                    var error = teacher.RunEpoch(sampleStorage.InputLearn, sampleStorage.OutPutLearn);
                    errorVal = error.ToString(CultureInfo.InvariantCulture);
                    if (error < 0.1)
                        needToStop = true;
                }
            });
            workThread.Priority =ThreadPriority.Highest;
            workThread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            neuronNet.Save("Weights_.txt");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = errorVal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            needToStop = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (workThread.ThreadState != ThreadState.Running) return;
            needToStop = true;
            workThread.Join();
            workThread.Abort();
        }
    }
}
