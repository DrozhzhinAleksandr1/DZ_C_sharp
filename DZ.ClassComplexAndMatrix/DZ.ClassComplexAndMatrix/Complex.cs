using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ.ClassComplexAndMatrix
{
    class Complex
    {
        private int xReZ;
        private int yImZ;
        public Complex(int x, int y)
        {
            this.xReZ = x;
            this.yImZ = y;
        }
        public override string ToString()
        {
            return $"{xReZ} {yImZ}i";
        }
        public static Complex operator + (Complex a, Complex b)
        {
            return new Complex(a.xReZ + b.xReZ, a.yImZ + b.yImZ);
        }
        public static Complex operator - (Complex a, Complex b)
        {
            return new Complex(a.xReZ - b.xReZ, a.yImZ - b.yImZ);
        }
        public static Complex operator * (Complex a, Complex b)
        {
            return new Complex(a.xReZ * b.xReZ - a.yImZ * b.yImZ, b.xReZ * a.yImZ + a.xReZ*b.yImZ);
        }
        public static Complex operator / (Complex a, Complex b)
        {
            return new Complex( 
                (a.xReZ * b.xReZ + a.yImZ * b.yImZ) / (a.yImZ * a.yImZ + b.yImZ * b.yImZ) ,
                (b.xReZ*a.yImZ - a.xReZ*b.yImZ) / (a.yImZ * a.yImZ + b.yImZ * b.yImZ)
            );
        }
    }
}
