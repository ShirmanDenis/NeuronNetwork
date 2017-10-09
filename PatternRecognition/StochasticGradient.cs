using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
namespace PatternRecognition
{
    class StochasticGradient
    {
        public event EventHandler IterationChange;
        public event EventHandler DQChanged;
        public event EventHandler VectorChanged;

        private double _vector_delta;
        private int _iterations;
        private double _dQ;
        private const double W_0 = -1;

        public int Iterations
        {
            get => _iterations;
            private set
            {
                _iterations = value;
                IterationChange?.Invoke(this, EventArgs.Empty);
            }
        }

        public double D_Q
        {
            get => _dQ;
            private set
            {
                _dQ = value;
                DQChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public double VectDelta
        {
            get => _vector_delta;
            set
            {
                _vector_delta = value;
                VectorChanged?.Invoke(this, null);
            }
        }

        public AbortState Abort { get; set; } = new AbortState(){Abort = false};

        public double[] SG(double[][] x, double[] y, double eta, double lambda, double q_stability, double v_stability)
        {
            Iterations = 0;
            _dQ = double.MaxValue;
            var weights = InitWeights(x);
            var q = 0.0;
            for (var i = 0; i < x.Length; i++)
            {
                var neuron_ans = NeuronFunc(x[i], weights);
                q += ErrorFunc(neuron_ans, y[i]);
            }
            var errorsVector = new double[x.Length];
            var isStab = false;
            var isChanged = true;
            var weightsPrev = new double[x[0].Length];
            var s = x[2].Count(el => (int) el == 0);
            var rand = new Random(DateTime.Now.Millisecond);

            while ((!isStab || isChanged) && !Abort.Abort)
            {
                var i = rand.Next(0, x.Length); 

                var neuron_ans = NeuronFunc(x[i], weights);
                errorsVector[i] = ErrorFunc(neuron_ans, y[i]);
                weights.CopyTo(weightsPrev,0);

                var koef = eta * 2 * (neuron_ans - y[i]);
                weights = VectorDiff(weights, ForEach(x[i], el => el * koef));

                var q_previous = q;
                q = (1 - lambda) * q + lambda * errorsVector[i];

                D_Q = Math.Abs(q - q_previous);
                isStab = D_Q <= q_stability;
                isChanged = isVectorChange(weights, weightsPrev, v_stability);

                Iterations++;
            }
            return weights;
        }

        private double[] ForEach(double[] vector, Func<double, double> func)
        {
            var res = new double[vector.Length];
            for (var i = 0; i < vector.Length; i++)
            {
                res[i] = func(vector[i]);
            }
            return res;
        }

        private int ActivationFunc(double z)
        {
            return z < 0 ? 0 : (int) Math.Round(z);
        }

        public int NeuronFunc(double[] neuronInputs, double[] weights)
        {
            if (neuronInputs.Length != weights.Length)
                throw new ArgumentException("length must be the same");

            var s = neuronInputs.Select((t, i) => t * weights[i]).Sum();
            return ActivationFunc( s - W_0);
        }

        private double ErrorFunc(double neuron_ans, double correct_ans)
        {
            return (neuron_ans - correct_ans) * (neuron_ans - correct_ans);
        }

        private double[] InitWeights(double[][] x)
        {
            var result = new double[x[0].Length];
            var rand = new Random();
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = rand.NextDouble(-1.0 / x.Length, 1.0 / x.Length);
            }

            return result;
        }

        private double Norm(double[] vector)
        {
            var sum = vector.Sum(e => e * e);
            return Math.Sqrt(sum);
        }

        private bool isVectorChange(double[] v1, double[] v2, double eps)
        {
            var norm_v1 = Norm(v1);
            var norm_v2 = Norm(v2);
            VectDelta = Math.Abs(norm_v2 * norm_v2 - norm_v1 * norm_v1);
            return VectDelta > eps;
        }

        private double[] VectorDiff(double[] lhs, double[] rhs)
        {
            if (lhs.Length != rhs.Length)
                throw new ArgumentException("vectors size must be the sames");

            for (var i = 0; i < lhs.Length; i++)
            {
                lhs[i] -= rhs[i];
            }
            return lhs;
        }
    }
    static class RandomExtension
    {
        public static double NextDouble(this Random r, double min, double max)
        {
            return min + r.NextDouble() * (max - min);
        }
    }

    static class ListExtensions
    {
        public static void MakeMixList<T>(this IList<T> list)
        {
            var r = new Random();

            var mixedList = new SortedList<int, T>();
            foreach (var item in list)
                mixedList.Add(r.Next(), item);

            list.Clear();
            for (var i = 0; i < mixedList.Count; i++)
            {
                list.Add(mixedList.Values[i]);
            }
            mixedList.Clear();  
        }
    }
}


