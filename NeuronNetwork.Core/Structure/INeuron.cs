using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuronNetwork.Core.Structure;

namespace NeuronNetwork.Core
{
    interface INeuron
    {
        IWeight<object>[,] Weights { get; set; }
    }
}
