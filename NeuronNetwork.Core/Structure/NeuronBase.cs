using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronNetwork.Core.Structure
{
    class NeuronBase : INeuron
    {
        public IWeight<object>[,] Weights { get; set; }

        public NeuronBase(IWeight<object>[,] weights)
        {
            Weights = weights;
        }
    }
}
