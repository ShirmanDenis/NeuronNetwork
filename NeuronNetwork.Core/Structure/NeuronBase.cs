using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronNetwork.Core
{
    public abstract class NeuronBase : INeuron
    {
        public double[,] Weights { get; set; }
        public List<double> Inputs { get; set; }
        public double OutputValue => ActivationFunc(Sum());

        protected Func<double, double> ActivationFunc
        {
            get { return x => 1 / (1 + Math.Exp(-x)); }
        }

        protected NeuronBase(List<double> inputs, double[,] weights)
        {
            Inputs = inputs;
            Weights = weights;
        }

        private double Sum()
        {
            var result = 0.0;

            return result;
        }
    }
}
