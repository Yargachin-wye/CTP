using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_CTP
{
    public class Polynom
    {
        public SortedSet<MemberPolynom> Members;
        public Polynom()
        {
            Members = new SortedSet<MemberPolynom>();
            Members.Add(new MemberPolynom(0, 0));
        }
        public Polynom Add(Polynom tp)
        {
            Polynom newtpoly = new Polynom();
            foreach (MemberPolynom mem in tp.Members)
            {
                newtpoly.Members.Add(new MemberPolynom(mem.FCoeff, mem.FDegree));
            }
            foreach (MemberPolynom mem in this.Members)
            {
                newtpoly.Members.Add(new MemberPolynom(mem.FCoeff, mem.FDegree));
            }
            return newtpoly;
        }
        public Polynom Mul(Polynom tp)
        {
            Polynom newtpoly = new Polynom();
            foreach (MemberPolynom mem in tp.Members)
            {
                foreach (MemberPolynom newmem in this.Members)
                {
                    newtpoly.Members.Add(new MemberPolynom(newmem.FCoeff * mem.FCoeff, newmem.FDegree + mem.FDegree));
                }
            }
            return newtpoly;
        }
        public Polynom Res(Polynom tp)
        {
            Polynom newtpoly = new Polynom();
            foreach (MemberPolynom mem in tp.Members)
            {
                newtpoly.Members.Add(new MemberPolynom(-mem.FCoeff, mem.FDegree));
            }
            foreach (MemberPolynom mem in this.Members)
            {
                newtpoly.Members.Add(new MemberPolynom(mem.FCoeff, mem.FDegree));
            }
            return newtpoly;
        }
        public Polynom Rev()
        {
            Polynom newtpoly = new Polynom();
            foreach (MemberPolynom mem in this.Members)
            {
                newtpoly.Members.Add(new MemberPolynom(-mem.FCoeff, mem.FDegree));
            }
            return newtpoly;
        }
        public int RetDegree()
        {
            return Members.Last().FDegree;
        }
        public int RetCoeff(int n)
        {
            try { return Members.Single(x => x.FDegree == n).FCoeff; }
            catch (InvalidOperationException) { return 0; }
        }
        public override bool Equals(object tp)
        {
            if (((Polynom)tp).Members.SequenceEqual(this.Members)) return true;
            else return false;
        }
        public Polynom Diff()
        {
            Polynom newtpoly = new Polynom();
            foreach (MemberPolynom mem in this.Members)
            {
                newtpoly.Members.Add(new MemberPolynom(mem.FCoeff, mem.FDegree).Diff());
            }
            return newtpoly;
        }
        public double Calculate(double a)
        {
            double an = 0.0;
            foreach (MemberPolynom mem in this.Members)
            {
                an += mem.Calculate(a);
            }
            return an;
        }
        public void Clear()
        {
            Members = new SortedSet<MemberPolynom>
            {
                new MemberPolynom(0, 0)
            };
        }
        public Tuple<int, int> ElementAt(int i)
        {
            try { return Tuple.Create(this.Members.Reverse().ElementAt(i).FCoeff, this.Members.Reverse().ElementAt(i).FDegree); }
            catch (ArgumentOutOfRangeException) { return Tuple.Create(0, 0); }

        }
        public string Show()
        {
            string str = "";
            foreach (MemberPolynom x in Members.Reverse())
            {
                str += (x.FCoeff > 0) ? "+" : "";
                str += x.TMember2Str();
            }
            return str.TrimStart('+');
        }
    }
}
