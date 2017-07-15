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
        public INeuron[,] Inputs { get; set; }
        public double OutputValue { get; set; }

        protected NeuronBase(INeuron[,] inputNeurons,double[,] weights)
        {
            Inputs = inputNeurons;
            Weights = weights;
        }
    }
}
