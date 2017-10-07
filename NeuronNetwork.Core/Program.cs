using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Neuro;
using AForge.Neuro.Learning;
namespace NeuronNetwork.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = new[]
            {
                new double[]{ 4, 4},
                new double[]{ 5, 2},
                new double[]{ 8, 2},
                new double[]{ 7, 8},
                new double[]{ 2, 8},
                new double[]{ 16, 1},
                new double[]{ 1, 16},
                new double[]{ 1, 1},
                new double[]{ 1, 0},
                new double[]{99, 8}
            };
            var outputs = new[]
            {
                new double[]{1},
                new double[]{-1},
                new double[]{1},
                new double[]{-1},
                new double[]{1},
                new double[]{1},
                new double[]{1},
                new double[]{-1},
                new double[]{-1},
                new double[]{-1}
            };

            var firstNeuron = new ActivationNeuron(2, new SigmoidFunction());
            firstNeuron.Randomize();
            var firstLayer = new ActivationLayer(1, 2, new SigmoidFunction());
            firstLayer.Neurons[0] = firstNeuron;

            var network = new ActivationNetwork(new ThresholdFunction(), 1, 2);
            network.Layers[0] = firstLayer;

            var deltaRule = new DeltaRuleLearning(network)
            {
                LearningRate = 0.00005
            };
            deltaRule.RunEpoch(inputs, outputs);
            foreach (var input in inputs)
            {
                var res = network.Compute(input);
                Console.WriteLine(res[0]);
            }
            Console.ReadLine();
        }
    }

    class MyNeuron : Neuron
    {
        public MyNeuron(int inputs) : base(inputs)
        {
            
        }

        public override double Compute(double[] input)
        {
            throw new NotImplementedException();
        }
    }
}
