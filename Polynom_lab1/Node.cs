using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom_lab1
{
    public class Node : INode
    {
        private int coef;
        private Node pointerNext;
        private int size;
        public int Size
        {
            get => this.size;
            set => this.size = value;
        }

        public int Coef 
        {
            get => this.coef;
            set => this.coef = value; //syntax sugar
        }
        public Node PointerNext 
        {
            get => this.pointerNext; 
            set => this.pointerNext = value; 
        }

        public Node() { }

        public Node(int coef)
        {
            this.Coef = coef;
            this.PointerNext = null;
            Size++;
        }

        public Node(int coef, Node pointerNext)
        {
            this.Coef = coef;  
            this.PointerNext = pointerNext;
            Size++;
        }

        public Node(Node copy)
        {
            this.Coef = copy.coef;
            this.PointerNext = copy.pointerNext;
            this.Size = copy.size;
        }

    }
}
