using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom_lab1
{
    public interface INode
    {
        int Coef { get; set; }
        Node PointerNext { get; set; }


    }
}
