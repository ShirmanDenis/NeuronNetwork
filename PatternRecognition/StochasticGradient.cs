using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace PatternRecognition
{
    class StochasticGradient
    {
        private const double W_0 = -1;

        public double[] SG(double[][] x, double[] y, double eta, double lambda, double stability)
        {
            var sizeOfVector = x[0].Length;
            var weights = InitWeights(sizeOfVector);
            var q = 0.0;
            for (var i = 0; i < x.Length; i++)
            {
                var neuron_ans = NeuronFunc(x[i], weights);
                q += ErrorFunc(neuron_ans, y[i]);
            }

            var errorsVector = new double[x.Length];
            var k = 0;
            var isStab = false;
            var isChanged = true;
            var weights_prev = new double[sizeOfVector];
            while (!isStab || isChanged)
            {
                var i = new Random().Next(0, x.Length);

                var neuron_ans = NeuronFunc(x[i], weights);

                errorsVector[i] = ErrorFunc(neuron_ans, y[i]);
                weights_prev = weights;
                var koef = eta * 2 * (neuron_ans - y[i]);
                weights = VectorDiff(weights, ForEach(x[i], el => el * koef));
                var q_prev = q;
                q = (1 - lambda) * q + lambda * errorsVector[i];
                var dQ = Math.Abs(q - q_prev);
                isStab = dQ <= stability;
                isChanged = isVectorChange(weights, weights_prev, stability);
                k++;
            }
            return weights;
        }

        private double[] ForEach(double[] vector, Func<double, double> func)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = func(vector[i]);
            }
            return vector;
        }


        private int ActivationFunc(double z)
        {
            return z < 0 ? 0 : (int) Math.Round(z);
        }

        public int NeuronFunc(double[] neuronInputs, double[] weights)
        {
            if (neuronInputs.Length != weights.Length)
                throw new ArgumentException("length must be the same");

            return ActivationFunc(neuronInputs.Select((t, i) => t * weights[i]).Sum() - W_0);
        }

        private double ErrorFunc(double neuron_ans, double correct_ans)
        {
            return (neuron_ans - correct_ans) * (neuron_ans - correct_ans);
        }

        private double[] InitWeights(int vectorSize)
        {
            var result = new double[vectorSize];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = new Random().NextDouble(-1.0 / vectorSize, 1.0 / vectorSize);
            }

            return result;
        }

        private double Norm(double[] vector)
        {
            return Math.Sqrt(vector.Sum(e => e * e));
        }

        private bool isVectorChange(double[] v1, double[] v2, double eps)
        {
            var norm_v1 = Norm(v1);
            var norm_v2 = Norm(v2);
            return Math.Abs(norm_v2 - norm_v1) > eps;
        }

        private double[] VectorDiff(double[] lhs, double[] rhs)
        {
            if (lhs.Length != rhs.Length)
                throw new ArgumentException("vectors size must be the sames");

            var result = new double[lhs.Length];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = lhs[i] - rhs[i];
            }
            return result;
        }
    }
    static class RandomExtension
    {
        public static double NextDouble(this Random r, double min, double max)
        {
            return min + r.NextDouble() * (max - min);
        }

        public static double NextDouble(this Random r, double max)
        {
            return r.NextDouble() * max;
        }
    }
}


