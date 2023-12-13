using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CTP
{
    // Дробь
    public class FractionalNum : TFractionalNum
    {

        public FractionalNum(int a, int b) : base(a, b)
        {

        }

        public FractionalNum(string str) : base(str)
        {

        }

        public FractionalNum() : base()
        {

        }

        public static FractionalNum operator +(FractionalNum a, FractionalNum b) => (FractionalNum)a.Add(b);


        public static FractionalNum operator *(FractionalNum a, FractionalNum b) => (FractionalNum)a.Multiplication(b);


        public static FractionalNum operator -(FractionalNum a, FractionalNum b) => (FractionalNum)a.Difference(b);


        public static FractionalNum operator /(FractionalNum a, FractionalNum b) => (FractionalNum)a.Division(b);


        public static FractionalNum operator /(int a, FractionalNum b) => (FractionalNum)(new FractionalNum(a, 1)).Division(b);
        

        public override bool Equals(object obj)
        {
            FractionalNum frac = (FractionalNum)obj;
            if ((frac.Numerator == this.Numerator) && (this.Denominator == frac.Denominator))
            {
                return true;
            }
            else return false;
        }

        public static bool operator ==(FractionalNum a, FractionalNum b) => (a.Numerator == b.Numerator) && (a.Denominator == b.Denominator);
        

        public static bool operator !=(FractionalNum a, FractionalNum b) => (a.Numerator != b.Numerator) || (a.Denominator != b.Denominator);
        

        public static bool operator >(FractionalNum a, FractionalNum b) => ((double)a.Numerator / (double)a.Denominator) > ((double)b.Numerator / (double)b.Denominator);
        
        public static bool operator <(FractionalNum a, FractionalNum b) => ((double)a.Numerator / (double)a.Denominator) < ((double)b.Numerator / (double)b.Denominator);

        public override int GetHashCode() => this.Numerator.GetHashCode() + this.Denominator.GetHashCode();

        public override string ToString() => GetString();

    }
}
