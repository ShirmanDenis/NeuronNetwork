using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronNetwork.Core
{
   public interface INeuron
    {
        double[,]  Weights { get; set; }
        INeuron[,] Inputs { get; set; }
        double     OutputValue { get; set; }
    }
}
