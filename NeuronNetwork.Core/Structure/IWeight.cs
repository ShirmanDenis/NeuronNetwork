using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronNetwork.Core.Structure
{
    interface IWeight<T>
    {
        T Value { get; set; }
    }
}
