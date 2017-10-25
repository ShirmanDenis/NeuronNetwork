using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Neuro;
using AForge.Neuro.Learning;

namespace BackPropNet
{
    class SampleStorage
    {
        public double[][] InputLearn { get; private set; }
        public double[][] OutPutLearn { get; private set; }

        public double[][] InputWork { get; private set; }
        public double[][] OutputWork { get; private set; }
        public void ReadFromFile(string fileName)
        {
            var inputList = new List<double[]>();
            var outPutList = new List<double[]>();
            foreach (var samples in File.ReadLines(fileName))
            {
                var parsedValues = samples.Split(',').Select(elem => elem.Length == 1 ? 
                                                                elem.ToCharArray().First() :
                                                                double.Parse(elem, CultureInfo.InvariantCulture)).ToList();
                var input = parsedValues.GetRange(0, 8).ToArray();
                inputList.Add(input);
                var output = new[] { parsedValues.Last()};
                outPutList.Add(output);
            }

            var learnCount = (int)Math.Floor(inputList.Count * 0.2);
            var workCount = inputList.Count - learnCount;

            // Normalize values
            inputList.ForEach(elem =>
            {
                for (var i = 0; i < elem.Length; i++)
                    elem[i] = elem[i] / 100.0;
            });
            outPutList.ForEach(elem =>
            {
                for (var i = 0; i < elem.Length; i++)
                    elem[i] = elem[i] / 100.0;
            });
            // Devide samples to Learning and Working sequences
            InputLearn = inputList.GetRange(0, learnCount).ToArray();
            OutPutLearn = outPutList.GetRange(0, learnCount).ToArray();
            InputWork = inputList.GetRange(learnCount - 1, workCount).ToArray();
            OutputWork = outPutList.GetRange(learnCount - 1, workCount).ToArray();
        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
