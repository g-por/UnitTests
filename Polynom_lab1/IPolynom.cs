using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom_lab1
{
    public interface IPolynom
    {
        Polynom SumNum(Polynom p1, int number);
        Polynom SumPol(Polynom p);
        Polynom SubNum(Polynom p1, int number);
        Polynom SubPol(Polynom p);
        Polynom MultNum(int number);
        int CalcPol(int value);
        bool IsEqualPol(Polynom p); 
        string ToString();
    }
}
