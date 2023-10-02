using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Polynom_lab1
{
    public class Polynom : IPolynom
    {
        public Node head;
        public int[] coefficients;

        public Polynom() {
            head = null;
        }

        public Polynom(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (head == null)
                {
                    AddTerm(values[i]);
                    this.coefficients = values;

                }
                else
                {
                    Node current = head;
                    while (current.PointerNext != null)
                    {
                        current = current.PointerNext;
                    }
                    AddTerm(values[i]);
                }
            }
        }
        public Polynom(Polynom p)
        {
            Node current = p.head;
            while (current != null)
            {
                AddTerm(current.Coef);
                current = current.PointerNext;
            }
        }
        public Polynom(int size, int[] coef)
        {
            for (int i = 0; i < coef.Length; i++)
            {
                if (head == null)
                {
                    AddTerm(coef[i]);
                }
                else
                {
                    Node current = head;
                    while (current.PointerNext != null)
                    {
                        current = current.PointerNext;
                    }
                    AddTerm(coef[i]);
                }
            }
        }
        public void AddTerm(int coefficient)
        {
            Node newNode = new Node(coefficient);

            if (head == null)
            {
                head = newNode;
                head.Size = 1; 
            }
            else
            {
                Node current = head;
                while (current.PointerNext != null)
                {
                    current = current.PointerNext;
                }
                current.PointerNext = newNode;
                head.Size++;
            }
        }

        public int CalcPol(int value)
        {
            int res = 0;
            Node current = head;
            int degree = 0;

            while (current != null)
            {
                res += current.Coef * (int)Math.Pow(value, degree);
                current = current.PointerNext;
                degree++;
            }

            return res;
        }

        public bool IsEqualPol(Polynom p)
        {
            Node current1 = head;
            Node current2 = p.head;

            while (current1 != null && current2 != null)
            {
                if (current1.Coef != current2.Coef)
                {
                    return false;
                }

                current1 = current1.PointerNext;
                current2 = current2.PointerNext;
            }
            return current1 == null && current2 == null;
        }

        public Polynom MultNum(int number)
        {
            Node current = head;
            while (current != null)
            {
                current.Coef *= number;
                current = current.PointerNext;
            }

            return this;
        }
        public Polynom SubNum(Polynom p, int number)
        {
            var result = new Polynom(p);
            result.head.Coef = p.head.Coef - number;
            return result;
        }
        public Polynom SumNum(Polynom p, int number)
        {
            var result = new Polynom(p);
            result.head.Coef = p.head.Coef + number;
            return result;
        }

        public Polynom SumPol(Polynom p)
        {
            Node current1 = head;
            Node current2 = p.head;
            Polynom result = new Polynom();

            while (current1 != null || current2 != null)
            {
                int coef1 = (current1 != null) ? current1.Coef : 0;
                int coef2 = (current2 != null) ? current2.Coef : 0;

                int sum = coef1 + coef2;
                result.AddTerm(sum);

                if (current1 != null)
                    current1 = current1.PointerNext;
                if (current2 != null)
                    current2 = current2.PointerNext;
            }

            return result;
        }
        public Polynom SubPol(Polynom p)
        {
            Polynom result = new Polynom();

            Node current1 = head;
            Node current2 = p.head;

            while (current1 != null || current2 != null)
            {
                int coef1 = (current1 != null) ? current1.Coef : 0;
                int coef2 = (current2 != null) ? current2.Coef : 0;

                int difference = coef1 - coef2;
                result.AddTerm(difference);

                if (current1 != null)
                    current1 = current1.PointerNext;
                if (current2 != null)
                    current2 = current2.PointerNext;
            }
            return result;
        }
        public static Polynom operator *(Polynom polynom1, Polynom polynom2)
        {
            int[] coeffs = new int[polynom1.coefficients.Length + polynom2.coefficients.Length - 1];
            for (int i = 0; i < polynom1.coefficients.Length; ++i)
                for (int j = 0; j < polynom2.coefficients.Length; ++j)
                    coeffs[i + j] += polynom1.coefficients[i] * polynom2.coefficients[j];
            return new Polynom(coeffs);
        }
        public override string ToString()
        {
            if (coefficients == null || coefficients.Length == 0)
            {
                return "0"; 
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < coefficients.Length; i++)
            {
                if (coefficients[i] != 0)
                {
                    if (i > 0)
                    {
                        result.Append(" + ");
                    }

                    result.Append(coefficients[i]);
                    if (i > 0)
                    {
                        result.Append("x");
                        if (i > 1)
                        {
                            result.Append("^" + i);
                        }
                    }
                }
            }

            return result.ToString();
        }
    }

}

