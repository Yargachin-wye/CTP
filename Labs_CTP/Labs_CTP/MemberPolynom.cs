using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CTP
{
    public class MemberPolynom : IComparable<MemberPolynom>
    {
        private int fcoeff;
        private int fdegree;
        public int FCoeff
        {
            get { return fcoeff; }
            set
            {
                if (value == 0)
                    fdegree = 0;
                fcoeff = value;
            }
        }
        public int FDegree
        {
            get { return fdegree; }
            set
            {
                if (fcoeff == 0)
                    fdegree = 0;
                else fdegree = value;
            }
        }
        public MemberPolynom(int coeff = 0, int degree = 0)
        {
            FCoeff = coeff;
            FDegree = degree;
        }
        public override bool Equals(object tmem)
        {
            if ((((MemberPolynom)tmem).FCoeff == this.FCoeff) && (((MemberPolynom)tmem).FDegree == this.FDegree))
                return true;
            else
                return false;
        }
        public MemberPolynom Diff()
        {
            return new MemberPolynom() { FCoeff = (this.FCoeff * this.FDegree), FDegree = this.FDegree - 1 };
        }
        public double Calculate(double a)
        {
            return this.FCoeff * Math.Pow(a, this.FDegree);
        }
        public string TMember2Str()
        {
            return this.FCoeff == 0 ? "" : $"{this.FCoeff}x^{this.FDegree}";
        }

        public int CompareTo(MemberPolynom other)
        {
            if (this.FDegree.CompareTo(other.FDegree) != 0)
                return this.FDegree.CompareTo(other.FDegree);
            else
            {
                other.FCoeff += this.FCoeff;
                return 0;
            }
        }
    }
}
